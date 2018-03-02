Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports EntidadNegocio.General

Public Class AccesoDatos
    Implements IDisposable

#Region "Atributos"
    Private _cadenaConexion As String = String.Empty
    Private _parametros As List(Of Parametro)
    Private _connection As New SqlConnection()
#End Region

    Public ReadOnly Property CadenaConexion As String
        Get
            Return _cadenaConexion
        End Get
    End Property
    Sub New()
        Try
            ObtenerCadenaConexion()
            _parametros = New List(Of Parametro)
            _connection.ConnectionString = _cadenaConexion
            _connection.Open() ' abrimos la conexion
        Catch ex As Exception

        End Try
    End Sub
    Public Function ProbarConexion() As Boolean
        Try
            _cadenaConexion = ObtenerCadenaConexion()
            If _connection.State = ConnectionState.Open Then
                _connection.Close() ' cerramos la conexion
            End If
            _parametros = New List(Of Parametro)
            _connection.ConnectionString = _cadenaConexion
            _connection.Open() ' abrimos la conexion
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Function ObtenerCadenaConexion() As String
        Try
            _cadenaConexion = GetConnectionString("PRINCIPAL")
            If String.IsNullOrEmpty(_cadenaConexion) Then
                Throw New Exception("No se obtuvo la cadena conexión")
            End If
            Return _cadenaConexion
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function GetConnectionString(ByVal strConnection As String) As String
        Dim sReturn As String = String.Empty
        If Not String.IsNullOrEmpty(strConnection) Then
            sReturn = ConfigurationManager.ConnectionStrings(strConnection).ConnectionString
        End If
        Return sReturn
    End Function
    Public Function EjecutarProcedimiento(ByVal NomProcedimiento As String) As IDataReader
        Try
            Dim command As New SqlCommand(NomProcedimiento, _connection)
            command.CommandType = CommandType.StoredProcedure
            command.CommandTimeout = 360
            For Each _param As Parametro In _parametros
                command.Parameters.AddWithValue(_param.Nombre, _param.Valor)
                command.Parameters(_param.Nombre).Direction = _param.Direccion
                If _param.Tamaño > 0 Then command.Parameters(_param.Nombre).Size = _param.Tamaño
            Next
            Dim reader As IDataReader = Nothing

            reader = command.ExecuteReader()
            For Each _param As Parametro In _parametros
                If _param.Direccion = ParameterDirection.Output Or _param.Direccion = ParameterDirection.InputOutput Or _param.Direccion = ParameterDirection.ReturnValue Then
                    _param.Valor = command.Parameters(_param.Nombre).Value
                End If
            Next
            RemoverParametros()
            Return reader
        Catch ex As Exception
            RemoverParametros()
            Throw
        End Try
    End Function
    Public Function EjecutarProcedimientoInDataTable(ByVal NomProcedimiento As String) As DataTable
        Try
            Dim command As New SqlCommand(NomProcedimiento, _connection)
            command.CommandType = CommandType.StoredProcedure
            command.CommandTimeout = 360
            For Each _param As Parametro In _parametros
                command.Parameters.AddWithValue(_param.Nombre, _param.Valor)
            Next
            Dim da As New SqlDataAdapter()
            Dim dt As New DataTable()
            da.SelectCommand = command
            da.Fill(dt)
            Return dt
        Catch x As Exception
            Throw
        End Try
    End Function
    Public Function ObtenerParametro(ByVal Nombre As String) As Object
        Return From p As Parametro In _parametros Where p.Nombre = Nombre Select p.Valor
    End Function
    Public Sub EjecutarProcedimientoNonQuery(ByVal NomProcedimiento As String)

        Dim command As New SqlCommand(NomProcedimiento, _connection)
        command.CommandType = CommandType.StoredProcedure
        For Each _param As Parametro In _parametros
            command.Parameters.AddWithValue(_param.Nombre, _param.Valor)
            command.Parameters(_param.Nombre).Direction = _param.Direccion
            If _param.Tamaño > 0 Then command.Parameters(_param.Nombre).Size = _param.Tamaño
        Next
        command.ExecuteNonQuery() ' ejecutamos es SP
        For Each _param As Parametro In _parametros
            If _param.Direccion = ParameterDirection.Output Or _param.Direccion = ParameterDirection.InputOutput Or _param.Direccion = ParameterDirection.ReturnValue Then
                _param.Valor = command.Parameters(_param.Nombre).Value
            End If
        Next
        RemoverParametros()
    End Sub
    Public Function EjecutarQueryReaderSinParametro(NomQuery As String) As IDataReader
        Try
            Dim command As New SqlCommand(NomQuery, _connection)
            command.CommandType = CommandType.Text
            command.CommandTimeout = 360
            Dim reader As IDataReader = Nothing
            reader = command.ExecuteReader()
            Return reader
        Catch x As Exception
            Throw
        End Try
    End Function
    Public Function EjecutarQueryReader(NomQuery As String) As IDataReader
        Try
            Dim command As New SqlCommand(NomQuery, _connection)
            command.CommandType = CommandType.Text
            command.CommandTimeout = 360
            For Each _param As Parametro In _parametros
                command.Parameters.AddWithValue(_param.Nombre, _param.Valor)
                command.Parameters(_param.Nombre).Direction = _param.Direccion
                If _param.Tamaño > 0 Then
                    command.Parameters(_param.Nombre).Size = _param.Tamaño
                End If
            Next
            Dim reader As IDataReader = Nothing
            reader = command.ExecuteReader()
            For Each _param As Parametro In _parametros
                If _param.Direccion = ParameterDirection.Output Or _param.Direccion = ParameterDirection.InputOutput Or _param.Direccion = ParameterDirection.ReturnValue Then
                    _param.Valor = command.Parameters(_param.Nombre).Value
                End If
            Next
            RemoverParametros()
            Return reader
        Catch x As Exception
            Throw
        End Try
    End Function
    Public Function EjecutarQueryExcalar(NomQuery As String) As String
        Try
            Dim command As New SqlCommand(NomQuery, _connection)
            command.CommandType = CommandType.Text
            Dim str As String = Convert.ToString(command.ExecuteScalar())
            Return str
        Catch x As Exception
            Throw
        End Try
    End Function
    Public Sub AgregarParametro(ByVal Nombre As String, ByVal Valor As Object, _
                                Optional ByVal direccion As System.Data.ParameterDirection = System.Data.ParameterDirection.Input, _
                                Optional ByVal tamaño As Integer = 0)
        Dim _parametro As New Parametro
        _parametro.Nombre = Nombre
        _parametro.Valor = Valor
        _parametro.Direccion = direccion
        _parametro.Tamaño = tamaño
        _parametros.Add(_parametro)
        _parametro = Nothing
    End Sub
    Public Sub AgregarParametroSimple(ByVal Nombre As String, ByVal Valor As Object)
        Me.AgregarParametro(Nombre, Valor, System.Data.ParameterDirection.Input, 0)
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub RemoverParametros()
        _parametros = Nothing
        _parametros = New List(Of Parametro)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Para detectar llamadas redundantes
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: eliminar estado administrado (objetos administrados).
            End If

            ' TODO: liberar recursos no administrados (objetos no administrados) e invalidar Finalize() below.
            ' TODO: Establecer campos grandes como Null.
            _parametros = Nothing
            _connection.Close()
            _connection = Nothing
        End If
        Me.disposedValue = True
    End Sub
    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
