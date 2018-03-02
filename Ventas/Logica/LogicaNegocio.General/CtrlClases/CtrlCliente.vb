Imports Dato.General
Imports EntidadNegocio.General
Imports System.Text.RegularExpressions

Public Class CtrlCliente
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>19/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Private _adCliente As New AdCliente
#End Region

#Region "Propieades"

#End Region

#Region "Metodos Privados"

#End Region

#Region "Metodos Publicos"
    Public Function ObtenerItems() As List(Of Cliente)
        Try
            If IsNothing(_adCliente) Then _adCliente = New AdCliente
            Return _adCliente.ObtenerItems()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObtenerItems(ByVal texto As String, ByVal _buscarPor As EnumBuscarPor.Cliente) As List(Of Cliente)
        Try
            If IsNothing(_adCliente) Then _adCliente = New AdCliente
            Return _adCliente.ObtenerItems(texto, _buscarPor)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObtenerItem(ByVal _id As Integer) As Cliente
        Try
            If IsNothing(_adCliente) Then _adCliente = New AdCliente
            Return _adCliente.ObtenerItem(_id)
        Catch ex As Exception
            Throw ex
        Finally
            _adCliente = Nothing
        End Try
    End Function
    Public Function ObtenerItem(ByVal _id As Integer, ByVal _tipo As Integer) As Cliente
        Try
            If IsNothing(_adCliente) Then _adCliente = New AdCliente
            Return _adCliente.ObtenerItem(_id, _tipo)
        Catch ex As Exception
            Throw ex
        Finally
            _adCliente = Nothing
        End Try
    End Function
    Public Function ValidarDatos(ByVal _cliente As Cliente) As Boolean
        Dim valido As Boolean = True : Dim count As Integer = 0
        If String.IsNullOrEmpty(_cliente.Codigo) Or String.IsNullOrEmpty(_cliente.Nombre) Or String.IsNullOrEmpty(_cliente.Telefono) Or String.IsNullOrEmpty(_cliente.Correo) Then
            count = 1
        End If
        If count > 0 Then
            Return False
        Else
            Return True
        End If
        Return valido
    End Function
    Public Function Guardar(ByVal _cliente As Cliente, ByVal esTipoSP As Int32) As Boolean
        Dim _resultado As Boolean = False
        Try
            If ValidarDatos(_cliente) Then
                If MessageBox.Show(Mensajes.Info_Guardar, Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If IsNothing(_adCliente) Then _adCliente = New AdCliente
                    _resultado = _adCliente.Guardar(_cliente, esTipoSP)
                End If
            End If
            Return _resultado
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        Finally
            _adCliente = Nothing
        End Try
    End Function
    Public Function Eliminar(ByVal _cliente As Cliente, ByVal esTipoSP As Int32) As Boolean
        Dim _resultado As Boolean = False
        Try
            If ValidarDatos(_cliente) Then
                If IsNothing(_adCliente) Then _adCliente = New AdCliente
                _resultado = _adCliente.Guardar(_cliente, esTipoSP)
            End If
            Return _resultado
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        Finally
            _adCliente = Nothing
        End Try
    End Function
#End Region

End Class
