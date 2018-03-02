Imports EntidadNegocio.General
Imports Dato.Conexion
Imports System.Data.SqlClient
Imports Dato.General

Public Class AdCliente
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
    Public Function ObtenerItems() As List(Of Cliente)
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            sel.Append("SELECT ID, Cliente, Telefono, Correo ")
            sel.Append("FROM DemoWinForm.dbo.clientes A WITH (NOLOCK) ")
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReaderSinParametro(sel.ToString())
            Dim _lstClientes As New List(Of Cliente)
            While reader.Read
                Dim _cliente As New Cliente
                _cliente.Codigo = reader.GetInt32(reader.GetOrdinal("ID"))
                _cliente.Nombre = reader.GetString(reader.GetOrdinal("Cliente"))
                _cliente.Telefono = reader.GetString(reader.GetOrdinal("Telefono"))
                _cliente.Correo = reader.GetString(reader.GetOrdinal("Correo"))
                _cliente.Status = EnumEstatus.Registro.Activo
                _lstClientes.Add(_cliente)
            End While
            Return _lstClientes
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerItems")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: ObtenerItems")
        Finally
            If Not reader.IsClosed Then
                reader.Close()
            End If
            reader = Nothing
            ad.Dispose()
        End Try
    End Function
    Public Function ObtenerItems(ByVal texto As String, ByVal _buscarPor As EnumBuscarPor.Cliente) As List(Of Cliente)
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            sel.Append("SELECT ID, Cliente, Telefono, Correo ")
            sel.Append("FROM DemoWinForm.dbo.clientes A WITH (NOLOCK) ")
            If _buscarPor = EnumBuscarPor.Cliente.Codigo Then
                Dim boltxt As Boolean = IsNumeric(texto)
                If boltxt Then
                    ad.AgregarParametro("@ICLIENTE", IIf(texto = String.Empty, DBNull.Value, texto))
                Else
                    ad.AgregarParametro("@ICLIENTE", IIf(texto = String.Empty, DBNull.Value, 0))
                End If
                sel.Append("WHERE A.ID = ISNULL(@ICLIENTE, A.ID) ")
            Else
                ad.AgregarParametro("@ICLIENTE", DBNull.Value)
            End If
            If _buscarPor = EnumBuscarPor.Cliente.Nombre Then
                Dim txt As String = IIf(texto = String.Empty, DBNull.Value, texto)
                sel.Append("WHERE A.Cliente LIKE ('%" + txt + "%') ")
            Else
                ad.AgregarParametro("@VCLIENTE", DBNull.Value)
            End If
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReader(sel.ToString())
            Dim _lstClientes As New List(Of Cliente)
            While reader.Read
                Dim _cliente As New Cliente
                _cliente.Codigo = reader.GetInt32(reader.GetOrdinal("ID"))
                _cliente.Nombre = reader.GetString(reader.GetOrdinal("Cliente"))
                _cliente.Telefono = reader.GetString(reader.GetOrdinal("Telefono"))
                _cliente.Correo = reader.GetString(reader.GetOrdinal("Correo"))
                _cliente.Status = EnumEstatus.Registro.Activo
                _lstClientes.Add(_cliente)
            End While
            Return _lstClientes
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerItems")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: ObtenerItems")
        Finally
            If Not reader.IsClosed Then
                reader.Close()
            End If
            reader = Nothing
            ad.Dispose()
        End Try
    End Function
    Public Function ObtenerItem(ByVal _id As Integer) As Cliente
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            ad.AgregarParametro("@ICLIENTE", _id)
            ad.AgregarParametro("@VCLIENTE", DBNull.Value)
            ad.AgregarParametro("@VTELEFONO", DBNull.Value)
            ad.AgregarParametro("@VCORREO", DBNull.Value)
            sel = New System.Text.StringBuilder()
            sel.Append("SELECT ID, Cliente, Telefono, Correo ")
            sel.Append("FROM DemoWinForm.dbo.clientes A WITH (NOLOCK) ")
            sel.Append("WHERE A.ID = ISNULL(@ICLIENTE, A.ID) ")
            sel.Append("ORDER BY A.ID")
            reader = ad.EjecutarQueryReader(sel.ToString())
            Dim _cliente As New Cliente
            If reader.Read Then
                _cliente.Codigo = reader.GetInt32(reader.GetOrdinal("ID"))
                _cliente.Nombre = reader.GetString(reader.GetOrdinal("Cliente"))
                _cliente.Telefono = reader.GetString(reader.GetOrdinal("Telefono"))
                _cliente.Correo = reader.GetString(reader.GetOrdinal("Correo"))
                _cliente.Status = EnumEstatus.Registro.Activo
            End If
            Return _cliente
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerClientePorCodigo")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: ObtenerClientePorCodigo")
        Finally
            reader = Nothing
            ad.Dispose()
            ad = Nothing
        End Try
    End Function
    Public Function ObtenerItem(ByVal _id As Integer, ByVal _tipo As Integer) As Cliente
        sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            ad.AgregarParametro("@ICLIENTE", _id)
            ad.AgregarParametro("@VCLIENTE", DBNull.Value)
            ad.AgregarParametro("@VTELEFONO", DBNull.Value)
            ad.AgregarParametro("@VCORREO", DBNull.Value)
            If _tipo = 0 Then
                sel = New System.Text.StringBuilder()
                sel.Append("SELECT ID, Cliente, Telefono, Correo ")
                sel.Append("FROM DemoWinForm.dbo.clientes A WITH (NOLOCK) ")
                sel.Append("ORDER BY A.ID")
            Else
                sel = New System.Text.StringBuilder()
                sel.Append("SELECT ID, Cliente, Telefono, Correo ")
                sel.Append("FROM DemoWinForm.dbo.clientes A WITH (NOLOCK) ")
                sel.Append("WHERE A.ID = ISNULL(@ICLIENTE, A.ID) ")
                sel.Append("ORDER BY A.ID")
            End If
            reader = ad.EjecutarQueryReader(sel.ToString())
            Dim _cliente As New Cliente
            If reader.Read Then
                _cliente.Codigo = reader.GetInt32(reader.GetOrdinal("ID"))
                _cliente.Nombre = reader.GetString(reader.GetOrdinal("Cliente"))
                _cliente.Telefono = reader.GetString(reader.GetOrdinal("Telefono"))
                _cliente.Correo = reader.GetString(reader.GetOrdinal("Correo"))
                _cliente.Status = EnumEstatus.Registro.Activo
            End If
            Return _cliente
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerClientePorCodigo")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: ObtenerClientePorCodigo")
        Finally
            reader = Nothing
            ad.Dispose()
            ad = Nothing
        End Try
    End Function
    Public Function Guardar(ByRef _cliente As Cliente, ByVal esTipoSP As Int32) As Boolean
        Dim resultado As Boolean = False : sel = New System.Text.StringBuilder() : reader = Nothing : ad = New AccesoDatos
        Try
            If _cliente.Edicion = EnumEstatus.Edicion.Nuevo Then
                ad.AgregarParametro("@VCLIENTE", _cliente.Nombre)
                ad.AgregarParametro("@VTELEFONO", _cliente.Telefono)
                ad.AgregarParametro("@VCORREO", _cliente.Correo)
                If esTipoSP = 0 Then
                    sel = New System.Text.StringBuilder()
                    sel.Append("INSERT INTO DemoWinForm.dbo.clientes ")
                    sel.Append("VALUES (@VCLIENTE, @VTELEFONO, @VCORREO) ")
                    reader = ad.EjecutarQueryReader(sel.ToString())
                Else
                    ad.EjecutarProcedimiento("USP_INCCLIENTE")
                End If
                resultado = True
            ElseIf _cliente.Edicion = EnumEstatus.Edicion.Eliminar Then
                ad.AgregarParametro("@ICLIENTE", _cliente.Codigo)
                ad.AgregarParametro("@VCLIENTE", _cliente.Nombre)
                ad.AgregarParametro("@VTELEFONO", _cliente.Telefono)
                ad.AgregarParametro("@VCORREO", _cliente.Correo)
                sel = New System.Text.StringBuilder()
                sel.Append("DELETE FROM DemoWinForm.dbo.clientes ")
                sel.Append("WHERE ID = @ICLIENTE ")
                reader = ad.EjecutarQueryReader(sel.ToString())
                resultado = True
            Else
                ad.AgregarParametro("@ICLIENTE", _cliente.Codigo)
                ad.AgregarParametro("@VCLIENTE", _cliente.Nombre)
                ad.AgregarParametro("@VTELEFONO", _cliente.Telefono)
                ad.AgregarParametro("@VCORREO", _cliente.Correo)
                If esTipoSP = 0 Then
                    sel = New System.Text.StringBuilder()
                    sel.Append("UPDATE DemoWinForm.dbo.clientes ")
                    sel.Append("SET Cliente = @VCLIENTE, Telefono = @VTELEFONO, Correo = @VCORREO ")
                    sel.Append("WHERE ID = @ICLIENTE ")
                    reader = ad.EjecutarQueryReader(sel.ToString())
                Else
                    ad.EjecutarProcedimiento("USP_MODCLIENTE")
                End If
                resultado = True
            End If
            Return resultado
        Catch ex As Exception
            Dim excepcion As New Utilidad.Excepcion.Excepcion(Me.ToString() + ".ObtenerItem")
            excepcion.RegistrarExcepcion(ex)
            excepcion = Nothing
            Throw New ApplicationException("ERROR EN: " + ex.Message.ToString())
        Finally
            reader = Nothing
            ad.Dispose()
            ad = Nothing
        End Try
    End Function
#End Region

End Class
