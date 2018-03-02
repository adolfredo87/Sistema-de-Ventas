Imports EntidadNegocio.General
Imports Dato.Conexion
Imports System.Data.SqlClient

Public Class AdProducto
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>18/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Private ad As New AccesoDatos
    Private reader As IDataReader = Nothing
    Private sel As System.Text.StringBuilder = New System.Text.StringBuilder()
#End Region

#Region "Propiedades"

#End Region

#Region "Metodos"
    Public Function ObtenerItem(ByVal idProducto As Integer) As Producto
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Dim _enumEstatus As EnumEstatus.Edicion = EnumEstatus.Edicion.Normal
        Try
            ad.AgregarParametro("@IDPRODUCTO", idProducto)
            ad.AgregarParametro("@VNOMBRE", DBNull.Value)
            ad.AgregarParametro("@FPRECIO", DBNull.Value)
            ad.AgregarParametro("@VCATEGORIA", DBNull.Value)
            sel.Append("SELECT ID, Nombre, Precio, Categoria ")
            sel.Append("FROM DemoWinForm.dbo.productos A WITH (NOLOCK) ")
            sel.Append("WHERE A.ID = ISNULL(@IDPRODUCTO, A.ID) ")
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReader(sel.ToString())
            Dim _Producto As New Producto
            If reader.Read Then
                _Producto.Id = reader.GetInt32(reader.GetOrdinal("ID"))
                _Producto.Nombre = reader.GetString(reader.GetOrdinal("Nombre"))
                _Producto.Precio = reader.GetDouble(reader.GetOrdinal("Precio"))
                Select Case reader.GetString(reader.GetOrdinal("Categoria"))
                    Case "1"
                        _Producto.TipoCategoria = EnumTipos.TipoCategoria.Verduras
                    Case "2"
                        _Producto.TipoCategoria = EnumTipos.TipoCategoria.Salsas
                    Case "3"
                        _Producto.TipoCategoria = EnumTipos.TipoCategoria.Lacteos
                End Select
                _Producto.Edicion = EnumEstatus.Edicion.Normal
                _Producto.Estatus = EnumEstatus.Registro.Activo
                _enumEstatus = _Producto.Edicion
            End If
            Return _Producto
        Catch ex As SqlException
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerItem")
            Throw New ApplicationException(excepcion.RetonarExcepcionSistema(ex, Me.ToString(), _enumEstatus))
            excepcion = Nothing
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerItem")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: ObtenerItem")
        Finally
            reader = Nothing
            ad.Dispose()
        End Try
    End Function
    Public Function ObtenerItems() As List(Of Producto)
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            ad.AgregarParametro("@IDPRODUCTO", DBNull.Value)
            ad.AgregarParametro("@VNOMBRE", DBNull.Value)
            ad.AgregarParametro("@FPRECIO", DBNull.Value)
            ad.AgregarParametro("@VCATEGORIA", DBNull.Value)
            sel.Append("SELECT ID, Nombre, Precio, Categoria ")
            sel.Append("FROM DemoWinForm.dbo.productos A WITH (NOLOCK) ")
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReaderSinParametro(sel.ToString())
            Dim _lstProductos As New List(Of Producto)
            While reader.Read
                Dim _Producto As New Producto
                _Producto.Id = reader.GetInt32(reader.GetOrdinal("ID"))
                _Producto.Nombre = reader.GetString(reader.GetOrdinal("Nombre"))
                _Producto.Precio = reader.GetDouble(reader.GetOrdinal("Precio"))
                Select Case reader.GetString(reader.GetOrdinal("Categoria"))
                    Case "1"
                        _Producto.TipoCategoria = EnumTipos.TipoCategoria.Verduras
                    Case "2"
                        _Producto.TipoCategoria = EnumTipos.TipoCategoria.Salsas
                    Case "3"
                        _Producto.TipoCategoria = EnumTipos.TipoCategoria.Lacteos
                End Select
                _Producto.Edicion = EnumEstatus.Edicion.Normal
                _Producto.Estatus = EnumEstatus.Registro.Activo
                _lstProductos.Add(_Producto)
            End While
            Return _lstProductos
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerItems")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: ObtenerItems")
        Finally
            reader = Nothing
            ad.Dispose()
        End Try
    End Function
    Public Function Guardar(ByVal _Producto As Producto, ByVal esTipoSP As Int32) As Boolean
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            If _Producto.Edicion = EnumEstatus.Edicion.Nuevo Then
                ad.AgregarParametro("@VNOMBRE", _Producto.Nombre)
                ad.AgregarParametro("@FPRECIO", Math.Abs(Convert.ToDouble(_Producto.Precio)))
                ad.AgregarParametro("@VCATEGORIA", CType(_Producto.TipoCategoria, Integer))
                If esTipoSP = 0 Then
                    sel = New System.Text.StringBuilder()
                    sel.Append("INSERT INTO DemoWinForm.dbo.productos ")
                    sel.Append("VALUES (@VNOMBRE, @FPRECIO, @VCATEGORIA) ")
                    reader = ad.EjecutarQueryReader(sel.ToString())
                Else
                    ad.EjecutarProcedimiento("USP_INCPRODUCTO")
                End If
            ElseIf _Producto.Edicion = EnumEstatus.Edicion.Eliminar Then
                ad.AgregarParametro("@IDPRODUCTO", _Producto.Id)
                ad.AgregarParametro("@VNOMBRE", _Producto.Nombre)
                ad.AgregarParametro("@FPRECIO", Math.Abs(Convert.ToDouble(_Producto.Precio)))
                ad.AgregarParametro("@VCATEGORIA", CType(_Producto.TipoCategoria, Integer))
                sel = New System.Text.StringBuilder()
                sel.Append("DELETE FROM DemoWinForm.dbo.productos ")
                sel.Append("WHERE ID = @IDPRODUCTO ")
                reader = ad.EjecutarQueryReader(sel.ToString())
            Else
                ad.AgregarParametro("@IDPRODUCTO", _Producto.Id)
                ad.AgregarParametro("@VNOMBRE", _Producto.Nombre)
                ad.AgregarParametro("@FPRECIO", Math.Abs(Convert.ToDouble(_Producto.Precio)))
                ad.AgregarParametro("@VCATEGORIA", CType(_Producto.TipoCategoria, Integer))
                If esTipoSP = 0 Then
                    sel = New System.Text.StringBuilder()
                    sel.Append("UPDATE DemoWinForm.dbo.productos ")
                    sel.Append("SET Nombre = @VNOMBRE, Precio = @FPRECIO, Categoria = @VCATEGORIA ")
                    sel.Append("WHERE ID = @IDPRODUCTO ")
                    reader = ad.EjecutarQueryReader(sel.ToString())
                Else
                    ad.EjecutarProcedimiento("USP_MODPRODUCTO")
                End If
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
