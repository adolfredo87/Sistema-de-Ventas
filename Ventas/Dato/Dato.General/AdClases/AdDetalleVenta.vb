Imports EntidadNegocio.General
Imports Dato.Conexion
Imports System.Data.SqlClient
Imports Dato.General

Public Class AdDetalleVenta
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
    Public Function VerDetVentaTotal(ByVal iVenta As Integer) As DetalleVenta
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            ad.AgregarParametro("@ID", iVenta)
            ad.AgregarParametro("@IDVenta", DBNull.Value)
            ad.AgregarParametro("@IDPRODUCTO", DBNull.Value)
            ad.AgregarParametro("@FPRECIO", DBNull.Value)
            ad.AgregarParametro("@ICANTIDAD", DBNull.Value)
            ad.AgregarParametro("@FMONTO", DBNull.Value)
            sel.Append("SELECT ID, IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal ")
            sel.Append("FROM DemoWinForm.dbo.ventasitems A WITH (NOLOCK) ")
            sel.Append("WHERE A.ID = @ID ")
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReader(sel.ToString())
            Dim _DetalleVenta As New DetalleVenta
            If reader.Read Then
                _DetalleVenta.Id = reader.GetInt32(reader.GetOrdinal("ID"))
                _DetalleVenta.IdVentaCab = reader.GetInt32(reader.GetOrdinal("IDVenta"))
                _DetalleVenta.IdProducto = reader.GetInt32(reader.GetOrdinal("IDProducto"))
                _DetalleVenta.Precio = reader.GetDouble(reader.GetOrdinal("PrecioUnitario"))
                _DetalleVenta.Cantidad = CInt(reader.GetDouble(reader.GetOrdinal("Cantidad")))
                _DetalleVenta.Monto = reader.GetDouble(reader.GetOrdinal("PrecioTotal"))
                _DetalleVenta.Estatus = EnumEstatus.Registro.Activo
            End If
            Return _DetalleVenta
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
    Public Function VerDetVentaMonto(ByVal iVenta As Integer) As List(Of DetalleVenta)
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            ad.AgregarParametro("@ID", DBNull.Value)
            ad.AgregarParametro("@IDVenta", iVenta)
            ad.AgregarParametro("@IDPRODUCTO", DBNull.Value)
            ad.AgregarParametro("@FPRECIO", DBNull.Value)
            ad.AgregarParametro("@ICANTIDAD", DBNull.Value)
            ad.AgregarParametro("@FMONTO", DBNull.Value)
            sel.Append("SELECT ID, IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal ")
            sel.Append("FROM DemoWinForm.dbo.ventasitems A WITH (NOLOCK) ")
            sel.Append("WHERE A.IDVenta = @IDVenta ")
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReader(sel.ToString())
            Dim _DetalleVentas As New List(Of DetalleVenta)
            While reader.Read
                Dim _DetalleVenta As New DetalleVenta
                _DetalleVenta.Id = reader.GetInt32(reader.GetOrdinal("ID"))
                _DetalleVenta.IdVentaCab = reader.GetInt32(reader.GetOrdinal("IDVenta"))
                _DetalleVenta.IdProducto = reader.GetInt32(reader.GetOrdinal("IDProducto"))
                _DetalleVenta.Precio = reader.GetDouble(reader.GetOrdinal("PrecioUnitario"))
                _DetalleVenta.Cantidad = CInt(reader.GetDouble(reader.GetOrdinal("Cantidad")))
                _DetalleVenta.Monto = reader.GetDouble(reader.GetOrdinal("PrecioTotal"))
                _DetalleVenta.IdVentaCab = iVenta
                _DetalleVenta.Estatus = EnumEstatus.Registro.Activo
                _DetalleVentas.Add(_DetalleVenta)
            End While
            Return _DetalleVentas
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
    Public Function ObtenerItems(ByVal iVenta As Integer) As List(Of DetalleVenta)
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            ad.AgregarParametro("@ID", DBNull.Value)
            ad.AgregarParametro("@IDVenta", iVenta)
            ad.AgregarParametro("@IDPRODUCTO", DBNull.Value)
            ad.AgregarParametro("@FPRECIO", DBNull.Value)
            ad.AgregarParametro("@ICANTIDAD", DBNull.Value)
            ad.AgregarParametro("@FMONTO", DBNull.Value)
            sel.Append("SELECT ID, IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal ")
            sel.Append("FROM DemoWinForm.dbo.ventasitems A WITH (NOLOCK) ")
            sel.Append("WHERE A.IDVenta = @IDVenta ")
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReader(sel.ToString())
            Dim _DetalleVentas As New List(Of DetalleVenta)
            While reader.Read
                Dim _DetalleVenta As New DetalleVenta
                _DetalleVenta.Id = reader.GetInt32(reader.GetOrdinal("ID"))
                _DetalleVenta.IdVentaCab = reader.GetInt32(reader.GetOrdinal("IDVenta"))
                _DetalleVenta.IdProducto = reader.GetInt32(reader.GetOrdinal("IDProducto"))
                _DetalleVenta.Precio = reader.GetDouble(reader.GetOrdinal("PrecioUnitario"))
                _DetalleVenta.Cantidad = CInt(reader.GetDouble(reader.GetOrdinal("Cantidad")))
                _DetalleVenta.Monto = reader.GetDouble(reader.GetOrdinal("PrecioTotal"))
                _DetalleVenta.IdVentaCab = iVenta
                _DetalleVenta.Estatus = EnumEstatus.Registro.Activo
                _DetalleVentas.Add(_DetalleVenta)
            End While
            Return _DetalleVentas
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
    Public Function Guardar(ByVal _DetalleVenta As DetalleVenta) As Boolean
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            If _DetalleVenta.Edicion = EnumEstatus.Edicion.Nuevo Then
                ad.AgregarParametro("@ID", _DetalleVenta.Id)
                ad.AgregarParametro("@IDVenta", _DetalleVenta.IdVentaCab)
                ad.AgregarParametro("@IDPRODUCTO", _DetalleVenta.IdProducto)
                ad.AgregarParametro("@FPRECIO", Math.Abs(Convert.ToDouble(_DetalleVenta.Precio)))
                ad.AgregarParametro("@ICANTIDAD", Convert.ToInt32(_DetalleVenta.Cantidad))
                ad.AgregarParametro("@FMONTO", Math.Abs(Convert.ToDouble(_DetalleVenta.Monto)))
                sel = New System.Text.StringBuilder()
                sel.Append("INSERT INTO DemoWinForm.dbo.ventasitems ")
                sel.Append("VALUES (@IDVenta, @IDPRODUCTO, @FPRECIO, @ICANTIDAD, @FMONTO) ")
                reader = ad.EjecutarQueryReader(sel.ToString())
            ElseIf _DetalleVenta.Edicion = EnumEstatus.Edicion.Eliminar Then
                ad.AgregarParametro("@ID", _DetalleVenta.Id)
                ad.AgregarParametro("@IDVenta", _DetalleVenta.IdVentaCab)
                ad.AgregarParametro("@IDPRODUCTO", _DetalleVenta.IdProducto)
                ad.AgregarParametro("@FPRECIO", Math.Abs(Convert.ToDouble(_DetalleVenta.Precio)))
                ad.AgregarParametro("@ICANTIDAD", Convert.ToInt32(_DetalleVenta.Cantidad))
                ad.AgregarParametro("@FMONTO", Math.Abs(Convert.ToDouble(_DetalleVenta.Monto)))
                sel = New System.Text.StringBuilder()
                sel.Append("DELETE FROM DemoWinForm.dbo.ventasitems ")
                sel.Append("WHERE IDVenta = @IDVenta ")
                reader = ad.EjecutarQueryReader(sel.ToString())
            Else
                ad.AgregarParametro("@ID", _DetalleVenta.Id)
                ad.AgregarParametro("@IDVenta", _DetalleVenta.IdVentaCab)
                ad.AgregarParametro("@IDPRODUCTO", _DetalleVenta.IdProducto)
                ad.AgregarParametro("@FPRECIO", Math.Abs(Convert.ToDouble(_DetalleVenta.Precio)))
                ad.AgregarParametro("@ICANTIDAD", Convert.ToInt32(_DetalleVenta.Cantidad))
                ad.AgregarParametro("@FMONTO", Math.Abs(Convert.ToDouble(_DetalleVenta.Monto)))
                sel = New System.Text.StringBuilder()
                sel.Append("UPDATE DemoWinForm.dbo.ventasitems ")
                sel.Append("SET IDVenta = @IDVenta, IDProducto = @IDPRODUCTO, PrecioUnitario = @FPRECIO, Cantidad = @ICANTIDAD, Monto = @FMONTO ")
                sel.Append("WHERE ID = @ID ")
                reader = ad.EjecutarQueryReader(sel.ToString())
            End If
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".Guardar")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: " + ex.Message.ToString())
        Finally
            reader = Nothing
            ad.Dispose()
        End Try
        Return True
    End Function
#End Region

End Class
