Imports EntidadNegocio.General
Imports Dato.Conexion
Imports System.Data.SqlClient
Imports Dato.General

Public Class AdVenta
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>19/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Private ad As New AccesoDatos
    Private reader As IDataReader = Nothing
    Private sel As System.Text.StringBuilder = New System.Text.StringBuilder()
#End Region

#Region "Propiedades"

#End Region

#Region "Metodos"
    Public Function ObtenerVentas() As List(Of Venta)
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            ad.AgregarParametro("@ID", DBNull.Value)
            ad.AgregarParametro("@ICLIENTE", DBNull.Value)
            ad.AgregarParametro("@DFECHA", DBNull.Value)
            ad.AgregarParametro("@DTOTAL", DBNull.Value)
            sel.Append("SELECT ID, IdCliente, Fecha, Total ")
            sel.Append("FROM DemoWinForm.dbo.ventas A WITH (NOLOCK) ")
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReaderSinParametro(sel.ToString())
            Dim _Ventas As New List(Of Venta)
            While reader.Read
                Dim _Venta As New Venta
                _Venta.Id = reader.GetInt32(reader.GetOrdinal("ID"))
                _Venta.IdCliente = reader.GetInt32(reader.GetOrdinal("IDCliente"))
                _Venta.Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha"))
                _Venta.Total = CDbl(reader.GetDouble(reader.GetOrdinal("Total")))
                _Venta.Estatus = EnumEstatus.EstadoVenta.Registrado
                _Ventas.Add(_Venta)
            End While
            Return _Ventas
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerItems")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: " + ex.Message.ToString())
        Finally
            reader = Nothing
            ad.Dispose()
        End Try
    End Function
    Public Function BusquedaVentasCerradas(ByVal texto As String) As List(Of String)
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            If texto.ToString = "-1" Then
                sel.Append("SELECT 'N° CLIENTE ' + RTRIM(LTRIM(CAST(A.IDCliente AS VARCHAR))) + ', TOTAL VENTA ' +  RTRIM(LTRIM(CAST(A.Total AS VARCHAR))) + ', ' + ' F.V: ' + LEFT(CONVERT(VARCHAR, A.Fecha, 3), 10) + '                                                                                               ,' + RTRIM(LTRIM(CAST (A.ID AS VARCHAR))) AS datos_completo ")
                sel.Append("FROM DemoWinForm.dbo.ventas A WITH (NOLOCK) ")
                sel.Append("ORDER BY RTRIM(LTRIM(CAST(A.ID AS VARCHAR)))")
            Else
                sel.Append("SELECT 'N° CLIENTE ' + RTRIM(LTRIM(CAST(A.IDCliente AS VARCHAR))) + ', TOTAL VENTA ' +  RTRIM(LTRIM(CAST(A.Total AS VARCHAR))) + ', ' + ' F.V: ' + LEFT(CONVERT(VARCHAR, A.Fecha, 3), 10) + '                                                                                               ,' + RTRIM(LTRIM(CAST (A.ID AS VARCHAR))) AS datos_completo ")
                sel.Append("FROM DemoWinForm.dbo.ventas A WITH (NOLOCK) ")
                sel.Append("WHERE A.ID Like '%" + texto.ToString() + "%'")
            End If
            reader = ad.EjecutarQueryReaderSinParametro(sel.ToString())
            Dim _lstString As New List(Of String)
            While reader.Read
                Dim str As String = ""
                str = reader.GetString(reader.GetOrdinal("datos_completo"))
                _lstString.Add(str)
            End While
            Return _lstString
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerItems")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: " + ex.Message.ToString())
        Finally
            reader = Nothing
            ad.Dispose()
        End Try
    End Function
    Public Function ObtenerItems(ByVal texto As String, ByVal _buscarPor As EnumBuscarPor.Venta) As List(Of Venta)
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            If _buscarPor = EnumBuscarPor.Venta.Id Then
                ad.AgregarParametro("@ID", IIf(texto = String.Empty, DBNull.Value, texto))
            Else
                ad.AgregarParametro("@ID", DBNull.Value)
            End If
            ad.AgregarParametro("@ICLIENTE", DBNull.Value)
            ad.AgregarParametro("@DFECHA", DBNull.Value)
            ad.AgregarParametro("@DTOTAL", DBNull.Value)
            sel.Append("SELECT ID, IdCliente, Fecha, Total ")
            sel.Append("FROM DemoWinForm.dbo.ventas A WITH (NOLOCK) ")
            sel.Append("WHERE A.ID = @ID ")
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReader(sel.ToString())
            Dim _Ventas As New List(Of Venta)
            While reader.Read
                Dim _Venta As New Venta
                _Venta.Id = reader.GetInt32(reader.GetOrdinal("ID"))
                _Venta.IdCliente = reader.GetInt32(reader.GetOrdinal("IDCliente"))
                _Venta.Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha"))
                _Venta.Total = reader.GetDouble(reader.GetOrdinal("Total"))
                _Venta.Estatus = EnumEstatus.EstadoVenta.Registrado
                _Ventas.Add(_Venta)
            End While
            Return _Ventas
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerItems")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: " + ex.Message.ToString())
        Finally
            reader = Nothing
            ad.Dispose()
        End Try
    End Function
    Private Function CrearXmlAtributoDetVenta(ByVal _listv As List(Of DetalleVenta)) As XElement
        Try
            Dim xEle = New XElement("VENTAS", From ven As DetalleVenta In _listv _
                Select New XElement("DETALLE", _
                                    New XAttribute("ID", CType(ven.Id, Integer)), _
                                    New XAttribute("IDVenta", CType(ven.IdVentaCab, Integer)), _
                                    New XAttribute("IPORDUCTO", CType(ven.IdProducto, Integer)), _
                                    New XAttribute("FPRECIO", CType(ven.Precio, Double)), _
                                    New XAttribute("ICANTIDAD", CType(ven.Cantidad, Integer)), _
                                    New XAttribute("NMONTO", Math.Abs(CType(ven.Monto, Double)))
                        ))
            Return xEle
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function Guardar(ByVal _Venta As Venta) As Boolean
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Dim excepcion As Utilidad.Excepcion.Excepcion
        Try
            If _Venta.Edicion = EnumEstatus.Edicion.Nuevo Then
                ad.AgregarParametro("@ICLIENTE", _Venta.IdCliente)
                ad.AgregarParametro("@DFECHA", _Venta.Fecha)
                ad.AgregarParametro("@DTOTAL", Math.Abs(Convert.ToDouble(_Venta.Total)))
                sel = New System.Text.StringBuilder()
                sel.Append("INSERT INTO DemoWinForm.dbo.ventas ")
                sel.Append("VALUES (@ICLIENTE, @DFECHA, @DTOTAL) ")
                reader = ad.EjecutarQueryReader(sel.ToString())
            ElseIf _Venta.Edicion = EnumEstatus.Edicion.Eliminar Then
                ad.AgregarParametro("@ID", _Venta.Id)
                ad.AgregarParametro("@ICLIENTE", _Venta.IdCliente)
                ad.AgregarParametro("@DFECHA", _Venta.Fecha)
                ad.AgregarParametro("@DTOTAL", Math.Abs(Convert.ToDouble(_Venta.Total)))
                sel = New System.Text.StringBuilder()
                sel.Append("DELETE FROM DemoWinForm.dbo.ventas ")
                sel.Append("WHERE ID = @ID ")
                reader = ad.EjecutarQueryReader(sel.ToString())
            Else
                ad.AgregarParametro("@ID", _Venta.Id)
                ad.AgregarParametro("@ICLIENTE", _Venta.IdCliente)
                ad.AgregarParametro("@DFECHA", _Venta.Fecha)
                ad.AgregarParametro("@DTOTAL", Math.Abs(Convert.ToDouble(_Venta.Total)))
                sel = New System.Text.StringBuilder()
                sel.Append("UPDATE DemoWinForm.dbo.ventas ")
                sel.Append("SET IdCliente = @ICLIENTE, Fecha = @DFECHA, Total = @DTOTAL ")
                sel.Append("WHERE ID = @ID ")
                reader = ad.EjecutarQueryReader(sel.ToString())
            End If
            Return True
        Catch ex As SqlException
            'Controlar SqlException
            excepcion = New Utilidad.Excepcion.Excepcion
            Throw New ApplicationException(excepcion.RetonarExcepcionSistema(ex, Me.ToString(), EnumEstatus.Edicion.Nuevo))
        Catch ex As Exception
            'Controlar exception            
            excepcion = New Utilidad.Excepcion.Excepcion
            Throw New ApplicationException("ERROR EN: " + ex.Message.ToString())
        Finally
            ad.Dispose()
            ad = Nothing
            excepcion = Nothing
        End Try
    End Function
    Public Function Guardar(ByVal _Venta As Venta, ByVal _listdetalle As List(Of DetalleVenta), ByVal esTipoSP As Int32) As Boolean
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Dim excepcion As Utilidad.Excepcion.Excepcion : Dim _detalles As XElement
        Try
            _detalles = CrearXmlAtributoDetVenta(_listdetalle)
            If _Venta.Edicion = EnumEstatus.Edicion.Nuevo Then
                ad.AgregarParametro("@ICLIENTE", _Venta.IdCliente)
                ad.AgregarParametro("@DFECHA", _Venta.Fecha)
                ad.AgregarParametro("@DTOTAL", Math.Abs(Convert.ToDouble(_Venta.Total)))
                If esTipoSP = 0 Then
                    sel = New System.Text.StringBuilder()
                    sel.Append("INSERT INTO DemoWinForm.dbo.ventas ")
                    sel.Append("VALUES (@ICLIENTE, @DFECHA, @DTOTAL) ")
                    reader = ad.EjecutarQueryReader(sel.ToString())
                    sel = New System.Text.StringBuilder()
                    sel.Append("DECLARE @VENTAS XML = N'" + _detalles.ToString + "' ")
                    sel.Append("INSERT INTO DemoWinForm.dbo.ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) ")
                    sel.Append("SELECT IDVenta = T.Item.value('@IDVenta', 'INT'), ")
                    sel.Append("IDProducto = T.Item.value('@IPORDUCTO', 'INT'), ")
                    sel.Append("PrecioUnitario = T.Item.value('@FPRECIO', 'FLOAT'), ")
                    sel.Append("Cantidad = T.Item.value('@ICANTIDAD', 'INT'), ")
                    sel.Append("PrecioTotal = T.Item.value('@NMONTO', 'FLOAT')  ")
                    sel.Append("FROM @VENTAS.nodes('VENTAS/DETALLE') AS T(Item)  ")
                    reader = ad.EjecutarQueryReaderSinParametro(sel.ToString())
                Else
                    ad.AgregarParametro("@VENTAS", _detalles.ToString)
                    ad.EjecutarProcedimiento("USP_INCVENTA")
                End If
            ElseIf _Venta.Edicion = EnumEstatus.Edicion.Eliminar Then
                ad.AgregarParametro("@ID", _Venta.Id)
                ad.AgregarParametro("@ICLIENTE", _Venta.IdCliente)
                ad.AgregarParametro("@DFECHA", _Venta.Fecha)
                ad.AgregarParametro("@DTOTAL", Math.Abs(Convert.ToDouble(_Venta.Total)))
                sel = New System.Text.StringBuilder()
                sel.Append("DELETE FROM DemoWinForm.dbo.ventas ")
                sel.Append("WHERE ID = @ID ")
                reader = ad.EjecutarQueryReader(sel.ToString())
                ad.AgregarParametro("@ID", _Venta.Id)
                sel = New System.Text.StringBuilder()
                sel.Append("DELETE FROM DemoWinForm.dbo.ventasitems ")
                sel.Append("WHERE IDVenta = @ID ")
                reader = ad.EjecutarQueryReader(sel.ToString())
            Else
                ad.AgregarParametro("@ID", _Venta.Id)
                ad.AgregarParametro("@ICLIENTE", _Venta.IdCliente)
                ad.AgregarParametro("@DFECHA", _Venta.Fecha)
                ad.AgregarParametro("@DTOTAL", Math.Abs(Convert.ToDouble(_Venta.Total)))
                If esTipoSP = 0 Then
                    sel = New System.Text.StringBuilder()
                    sel.Append("UPDATE DemoWinForm.dbo.ventas ")
                    sel.Append("SET IdCliente = @ICLIENTE, Fecha = @DFECHA, Total = @DTOTAL ")
                    sel.Append("WHERE ID = @ID ")
                    reader = ad.EjecutarQueryReader(sel.ToString())
                    ad.AgregarParametro("@ID", _Venta.Id)
                    sel = New System.Text.StringBuilder()
                    sel.Append("DELETE FROM DemoWinForm.dbo.ventasitems ")
                    sel.Append("WHERE IDVenta = @ID ")
                    reader = ad.EjecutarQueryReader(sel.ToString())
                    sel = New System.Text.StringBuilder()
                    sel.Append("DECLARE @VENTAS XML = N'" + _detalles.ToString + "' ")
                    sel.Append("INSERT INTO DemoWinForm.dbo.ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) ")
                    sel.Append("SELECT IDVenta = T.Item.value('@IDVenta', 'INT'), ")
                    sel.Append("IDProducto = T.Item.value('@IPORDUCTO', 'INT'), ")
                    sel.Append("PrecioUnitario = T.Item.value('@FPRECIO', 'FLOAT'), ")
                    sel.Append("Cantidad = T.Item.value('@ICANTIDAD', 'INT'), ")
                    sel.Append("PrecioTotal = T.Item.value('@NMONTO', 'FLOAT')  ")
                    sel.Append("FROM @VENTAS.nodes('VENTAS/DETALLE') AS T(Item)  ")
                    reader = ad.EjecutarQueryReaderSinParametro(sel.ToString())
                Else
                    ad.AgregarParametro("@VENTAS", _detalles.ToString)
                    ad.EjecutarProcedimiento("USP_MODVENTA")
                End If
            End If
            Return True
        Catch ex As SqlException
            'Controlar SqlException
            excepcion = New Utilidad.Excepcion.Excepcion
            Throw New ApplicationException(excepcion.RetonarExcepcionSistema(ex, Me.ToString(), EnumEstatus.Edicion.Nuevo))
        Catch ex As Exception
            'Controlar exception            
            excepcion = New Utilidad.Excepcion.Excepcion
            Throw New ApplicationException("ERROR EN: " + ex.Message.ToString())
        Finally
            ad.Dispose()
            ad = Nothing
            excepcion = Nothing
        End Try
    End Function
#End Region

End Class
