Imports Dato.General
Imports EntidadNegocio.General

Public Class CtrlVenta
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>19/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Private _adVenta As New AdVenta
    Private _adDetalleVenta As New AdDetalleVenta
#End Region

#Region "Propieades"

#End Region

#Region "Metodos Privados"

#End Region

#Region "Metodos Publicos"
    Public Function ObtenerVentas() As List(Of Venta)
        Try
            If IsNothing(_adVenta) Then _adVenta = New AdVenta
            Return _adVenta.ObtenerVentas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function BusquedaVentasCerradas(ByVal texto As String) As List(Of String)
        Try
            If IsNothing(_adVenta) Then _adVenta = New AdVenta
            Return _adVenta.BusquedaVentasCerradas(texto)
        Catch ex As Exception
            Throw ex
        Finally
            _adVenta = Nothing
        End Try
    End Function
    Public Function ObtenerItems(ByVal texto As String, ByVal _buscarPor As EnumBuscarPor.Venta) As List(Of Venta)
        Try
            If IsNothing(_adVenta) Then _adVenta = New AdVenta
            Return _adVenta.ObtenerItems(texto, _buscarPor)
        Catch ex As Exception
            Throw ex
        Finally
            _adVenta = Nothing
        End Try
    End Function
    Public Function DetalleVentaValidos(ByVal _listdetalle As List(Of DetalleVenta)) As Boolean
        Dim valido As Boolean = True
        Dim count = (From vd In _listdetalle Where String.IsNullOrEmpty(vd.IdProducto) Or String.IsNullOrEmpty(vd.IdVentaCab) Or String.IsNullOrEmpty(vd.Precio) Select vd.Id).Count
        If count > 0 Then
            Return False
        Else
            Return True
        End If
        Return valido
    End Function
    Public Function Guardar(ByVal _Venta As Venta, ByVal _listdetalle As List(Of DetalleVenta), ByVal _iTipo As Int32, ByVal esTipoSP As Int32) As Boolean
        Dim lG = (From a In _listdetalle Where a.Edicion <> EnumEstatus.Edicion.Eliminar Select a)
        Dim lE = (From a In _listdetalle Where a.Edicion = EnumEstatus.Edicion.Eliminar Select a)
        Dim _listVDG As List(Of DetalleVenta) : Dim _listVDE As List(Of DetalleVenta) : Dim resul As Boolean = False
        Try
            If MessageBox.Show(Mensajes.Info_Guardar, Mensajes.Titulo_Guardar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If IsNothing(_adVenta) Then _adVenta = New AdVenta
                If _iTipo = 0 Then
                    If _adVenta.Guardar(_Venta) Then
                        resul = Me.GuardarDetalle(_listdetalle)
                    End If
                Else
                    _listVDE = lE.ToList()
                    If _listVDE.Count > 0 Then
                        If Me.EliminarDetalle(_listVDE) Then
                            _listVDG = lG.ToList()
                            If _listVDG.Count > 0 Then
                                resul = _adVenta.Guardar(_Venta, _listVDG, esTipoSP)
                            Else
                                resul = False
                            End If
                        Else
                            resul = False
                        End If
                    Else
                        _listVDG = lG.ToList()
                        If _listVDG.Count > 0 Then
                            resul = _adVenta.Guardar(_Venta, _listVDG, esTipoSP)
                        Else
                            resul = False
                        End If
                    End If
                End If
            End If
            Return resul
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        Finally
            _adVenta = Nothing
        End Try
    End Function
    Public Function GuardarDetalle(ByVal _listdetalle As List(Of DetalleVenta)) As Boolean
        Try
            Dim resul As Boolean = False
            Dim l = (From a In _listdetalle Where a.Edicion <> EnumEstatus.Edicion.Normal Select a)
            Dim _listVD As List(Of DetalleVenta)
            If IsNothing(_adDetalleVenta) Then _adDetalleVenta = New AdDetalleVenta
            _listVD = l.ToList()
            If DetalleVentaValidos(_listVD) Then
                If _listVD.Count = 0 Then
                    resul = False
                ElseIf _listVD.Count > 0 Then
                    For Each _detalleVenta As DetalleVenta In _listVD
                        resul = _adDetalleVenta.Guardar(_detalleVenta)
                    Next
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
    Public Function Eliminar(ByVal _Venta As Venta, ByVal _listdetalle As List(Of DetalleVenta), ByVal _iTipo As Int32, ByVal esTipoSP As Int32) As Boolean
        Dim lG = (From a In _listdetalle Where a.Edicion <> EnumEstatus.Edicion.Eliminar Select a)
        Dim lE = (From a In _listdetalle Where a.Edicion = EnumEstatus.Edicion.Eliminar Select a)
        Dim _listVDG As List(Of DetalleVenta) : Dim _listVDE As List(Of DetalleVenta) : Dim resul As Boolean = False
        Try
            If _Venta.Estatus <> EnumEstatus.Registro.Inactivo Then _Venta.Estatus = EnumEstatus.Registro.Inactivo
            If _Venta.Edicion <> EnumEstatus.Edicion.Eliminar Then _Venta.Edicion = EnumEstatus.Edicion.Eliminar
            If MessageBox.Show(Mensajes.Info_Eliminar, Mensajes.Titulo_Eliminar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If IsNothing(_adVenta) Then _adVenta = New AdVenta
                If _iTipo = 0 Then
                    If _adVenta.Guardar(_Venta) Then
                        resul = Me.EliminarDetalle(_listdetalle)
                    End If
                Else
                    _listVDE = lE.ToList()
                    If _listVDE.Count > 0 Then
                        If Me.EliminarDetalle(_listVDE) Then
                            _listVDG = lG.ToList()
                            If _listVDG.Count > 0 Then
                                resul = _adVenta.Guardar(_Venta, _listVDG, esTipoSP)
                            Else
                                resul = False
                            End If
                        Else
                            resul = False
                        End If
                    Else
                        _listVDG = lG.ToList()
                        If _listVDG.Count > 0 Then
                            resul = _adVenta.Guardar(_Venta, _listVDG, esTipoSP)
                        Else
                            resul = False
                        End If
                    End If
                End If
            End If
            Return resul
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        Finally
            _adVenta = Nothing
        End Try
    End Function
    Public Function EliminarDetalle(ByVal _listdetalle As List(Of DetalleVenta)) As Boolean
        Try
            Dim resul As Boolean = False
            Dim l = (From a In _listdetalle Where a.Edicion = EnumEstatus.Edicion.Eliminar Select a)
            Dim _listVD As List(Of DetalleVenta)
            If IsNothing(_adDetalleVenta) Then _adDetalleVenta = New AdDetalleVenta
            _listVD = l.ToList()
            If DetalleVentaValidos(_listVD) Then
                If _listVD.Count = 0 Then
                    resul = False
                ElseIf _listVD.Count > 0 Then
                    For Each _detalleVenta As DetalleVenta In _listVD
                        _detalleVenta.Edicion = EnumEstatus.Edicion.Eliminar
                        resul = _adDetalleVenta.Guardar(_detalleVenta)
                    Next
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
#End Region

End Class
