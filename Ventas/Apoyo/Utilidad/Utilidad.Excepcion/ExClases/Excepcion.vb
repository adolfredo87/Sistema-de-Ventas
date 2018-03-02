Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports EntidadNegocio.General.Mensajes
Imports EntidadNegocio.General.EnumEstatus

Public Class Excepcion
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>20/01/2014</creacion>
    ''' <modificacion></modificacion>

    Private _origenExcepcion As String
    Private _nombreTraza As String = "application_trace.txt"
    Private _separador As String = "\"
    Private _rutaTraza As String = System.Windows.Forms.Application.StartupPath

    Public Sub New()
        Try
        Catch ex As Exception
        End Try
    End Sub
    Public Property Ruta() As String
        Get
            Return _rutaTraza
        End Get
        Set(ByVal value As String)
            _rutaTraza = value
        End Set
    End Property
    Public Sub New(ByVal origen As String)
        Try
            CrearDirectorio()
            _origenExcepcion = origen
        Catch ex As Exception
            EscribirLocalEx(ex, Me.ToString() + ".Constructor")
            Throw New ApplicationException("Error interno de la Aplicación." + vbCr + _
            "Por favor informar a Sopórte Técnico.")
        End Try
    End Sub
    Public Sub New(ByVal origen As String, ByVal nombreTraza As String)
        Try
            _origenExcepcion = origen
            _nombreTraza = nombreTraza
            CrearDirectorio()
        Catch ex As Exception
            EscribirLocalEx(ex, Me.ToString() + ".Constructor")
            Throw New ApplicationException("Error interno de la Aplicación." + vbCr + _
            "Por favor informar a Sopórte Técnico.")
        End Try
    End Sub
    Public Sub RegistrarExcepcion(ByVal excepcion As Exception)
        Try
            Try
                Throw excepcion
            Catch ex As IO.InvalidDataException
                EscribirInvalidDataException(ex)
            Catch ex As SqlException
                EscribirSqlEx(ex)
            Catch ex As IOException
                EscribirIOEx(ex)
            Catch ex As Exception
                EscribirGenericEx(ex)
            End Try
        Catch ex As Exception
            EscribirLocalEx(ex, Me.ToString() + ".RegistrarExcepcion")
            Throw New ApplicationException("Error interno de la Aplicación." + vbCr + _
            "Por favor informar a Sopórte Técnico.")
        End Try
    End Sub
    Private Sub CrearDirectorio()
        If Not File.Exists(_rutaTraza + _separador + _nombreTraza) Then
            File.Create(_rutaTraza + _separador + _nombreTraza)
        End If
    End Sub
    Private Sub EscribirSqlEx(ByVal ex As SqlException)
        EscribirLinea("SQLEXCEPTION OCURRIDA EN: " + _origenExcepcion)
        EscribirLinea(" FECHA: " + Date.Now.ToString())
        EscribirLinea("FUENTE: " + ex.Source)
        EscribirLinea("NÚMERO: " + ex.Number.ToString())
        EscribirLinea(" LÍNEA: " + ex.LineNumber.ToString())
        EscribirLinea("MESAJE: " + ex.Message)
        EscribirLinea("--------------------------")
        EscribirLinea("SERVIDOR     : " + ex.Server)
        EscribirLinea("PROCEDIMIENTO: " + ex.Procedure)
        EscribirLinea("STACK        : " + ex.StackTrace.ToString)
        EscribirLinea("--------------------------")
        EscribirLinea("")
    End Sub
    Private Sub EscribirIOEx(ByVal ex As IOException)
        EscribirLinea("IOEXCEPTION OCURRIDA EN: " + _origenExcepcion)
        EscribirLinea(" FECHA: " + Date.Now.ToString())
        EscribirLinea("FUENTE: " + ex.Source)
        EscribirLinea("MESAJE: " + ex.Message)
        EscribirLinea("--------------------------")
        EscribirLinea("STACK        : " + ex.StackTrace.ToString)
        EscribirLinea("--------------------------")
        EscribirLinea("")
    End Sub
    Private Sub EscribirInvalidDataException(ByVal ex As InvalidDataException)
        EscribirLinea("INVALIDDATAEXCEPTION OCURRIDA EN: " + _origenExcepcion)
        EscribirLinea(" FECHA: " + Date.Now.ToString())
        EscribirLinea("FUENTE: " + ex.Source)
        EscribirLinea("MESAJE: " + ex.Message)
        EscribirLinea("--------------------------")
        EscribirLinea("STACK        : " + ex.StackTrace.ToString)
        EscribirLinea("--------------------------")
        EscribirLinea("")
    End Sub
    Private Sub EscribirGenericEx(ByVal ex As Exception)
        EscribirLinea("EXCEPTION OCURRIDA EN: " + _origenExcepcion)
        EscribirLinea(" FECHA        : " + Date.Now.ToString())
        EscribirLinea("FUENTE        : " + ex.Source)
        EscribirLinea("MESAJE        : " + ex.Message)
        EscribirLinea("TIPO EXCEPCION: " + ex.ToString)
        EscribirLinea("--------------------------")
        EscribirLinea("STACK         : " + ex.StackTrace)
        EscribirLinea("--------------------------")
        EscribirLinea("")
    End Sub
    Private Sub EscribirLocalEx(ByVal ex As Exception, ByVal origenEx As String)
        EscribirLinea("EXCEPTION OCURRIDA EN: " + origenEx)
        EscribirLinea(" FECHA: " + Date.Now.ToString())
        EscribirLinea("FUENTE: " + ex.Source)
        EscribirLinea("MESAJE: " + ex.Message)
        EscribirLinea("--------------------------")
        EscribirLinea("STACK        : " + ex.StackTrace.ToString)
        EscribirLinea("--------------------------")
        EscribirLinea("")
    End Sub
    Private Sub EscribirLinea(ByVal valor As String)
        Dim objEscritor As StreamWriter
        objEscritor = File.AppendText(_rutaTraza + _separador + _nombreTraza)
        objEscritor.WriteLine(valor)
        objEscritor.Close()
    End Sub
    Public Function RetonarExcepcionSistema(ByVal ex As SqlException, ByVal metodo As String, ByVal operacion As Edicion) As String
        Dim excepcion As New Utilidad.Excepcion.Excepcion(metodo + "." + operacion.ToString)
        Dim msj As String
        excepcion.RegistrarExcepcion(ex)
        excepcion = Nothing
        Select Case ex.State
            Case 1 ' registro duplicado
                msj = ex.Message
            Case Else
                msj = Inf_Error_ConexionServidor
        End Select
        Return msj
    End Function
    Public Function RetonarExcepcionSistema(ByVal ex As Exception, ByVal metodo As String, ByVal operacion As Edicion) As String
        Dim excepcion As New Utilidad.Excepcion.Excepcion(metodo + "." + operacion.ToString)
        Dim msj As String = String.Empty
        excepcion.RegistrarExcepcion(ex)
        excepcion = Nothing
        Select Case operacion
            Case Edicion.Nuevo
                msj = Info_ErrorAlGuardar
            Case Edicion.Editado
                msj = Info_ErrorAlGuardar
        End Select
        Return msj
    End Function

End Class
