Imports Dato.General
Imports EntidadNegocio.General

Public Class CtrlProducto
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>19/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Dim _adProducto As New AdProducto
    Private WithEvents _Producto As New Producto
#End Region

#Region "Propieades"

#End Region

#Region "Metodos Privados"

#End Region

#Region "Metodos Publicos"
    Public Function ObtenerItems() As List(Of Producto)
        Try
            If IsNothing(_adProducto) Then _adProducto = New AdProducto
            Return _adProducto.ObtenerItems
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObtenerItem(ByVal id As Integer) As Producto
        Try
            If IsNothing(_adProducto) Then _adProducto = New AdProducto
            Return _adProducto.ObtenerItem(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ProductosValidos(ByVal _lstProductos As List(Of Producto)) As Boolean
        Dim valido As Boolean = True
        Dim count = (From a In _lstProductos Where String.IsNullOrEmpty(a.Nombre) Or String.IsNullOrEmpty(a.Precio) Select a.Nombre).Count
        If count > 0 Then
            Return False
        Else
            Return True
        End If
        Return valido
    End Function
    Public Function DatoDuplicado(ByVal _lstProductos As List(Of Producto), ByVal codigo As Int32) As Boolean
        If _lstProductos.FindAll(Function(a) a.Id = codigo).Count > 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Guardar(ByVal _lstProductos As List(Of Producto), ByVal esTipoSP As Int32) As Boolean
        Try
            Dim resul As Boolean = False
            Dim l = (From a In _lstProductos Where a.Edicion <> EnumEstatus.Edicion.Normal Select a)
            Dim _listP As List(Of Producto)
            _listP = l.ToList()
            If ProductosValidos(_listP) Then
                If _listP.Count = 0 Then
                    resul = False
                ElseIf _listP.Count > 0 Then
                    If MessageBox.Show(Mensajes.Info_Guardar, Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        For Each _Producto As Producto In _listP
                            If IsNothing(_adProducto) Then _adProducto = New AdProducto
                            resul = _adProducto.Guardar(_Producto, esTipoSP)
                        Next
                    End If
                Else
                    resul = False
                    MessageBox.Show(Mensajes.Info_ErrorAlGuardar, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                resul = False
            End If
            Return resul
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Eliminar(ByVal _lstProductos As List(Of Producto), ByVal esTipoSP As Int32) As Boolean
        Try
            Dim resul As Boolean = False
            Dim l = (From a In _lstProductos Where a.Edicion <> EnumEstatus.Edicion.Normal Select a)
            Dim _listP As List(Of Producto)
            _listP = l.ToList()
            If ProductosValidos(_listP) Then
                If _listP.Count = 0 Then
                    resul = False
                ElseIf _listP.Count > 0 Then
                    For Each _Producto As Producto In _listP
                        If IsNothing(_adProducto) Then _adProducto = New AdProducto
                        resul = _adProducto.Guardar(_Producto, esTipoSP)
                    Next
                Else
                    resul = False
                End If
            Else
                resul = False
            End If
            Return resul
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class