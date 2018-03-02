Imports LogicaNegocio.General
Imports EntidadNegocio.General

Public Class frmProducto

#Region "Atributos"
    Private esTipoSP As Integer = 0
    Private _ctrlProducto As New CtrlProducto
    Private _lstProductos As New List(Of Producto)
#End Region

#Region "Eventos"
    Event MenuInsert(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuSuprimir(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuGuardar(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuCancelar(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuSalir(ByVal sender As System.Object, ByVal e As System.EventArgs)
#End Region

#Region "Metodos"
    Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        esTipoSP = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("EsTipoGuardadoSP").ToString())
    End Sub
    Private Sub CargarProductos()
        Try
            _lstProductos = _ctrlProducto.ObtenerItems
        Catch ex As Exception
            MessageBox.Show(Mensajes.Info_ErrorAlCargar, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MostrarProductos()
        Try
            dgProductos.AutoGenerateColumns = False
            dgProductos.DataSource = Nothing
            dgProductos.DataSource = _lstProductos
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LlenarComboGridCategoria()
        Try
            Dim column As DataGridViewComboBoxColumn = DirectCast(dgProductos.Columns(3), DataGridViewComboBoxColumn)
            Dim l As New List(Of Estatus)
            Dim values() As Integer = CType([Enum].GetValues(GetType(EnumTipos.TipoCategoria)), Integer())
            Dim i As Estatus
            For Each value In values
                i = New Estatus
                i.Descripcion = [Enum].GetName(GetType(EnumTipos.TipoCategoria), value)
                i.Id = value
                l.Add(i)
            Next
            column.DataSource = l
            column.DisplayMember = "Descripcion"
            column.ValueMember = "Id"            
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AñadirProducto()
        Try
            Dim _Producto As New Producto
            _Producto.Estatus = EnumEstatus.Registro.Activo
            _Producto.Edicion = EnumEstatus.Edicion.Nuevo
            If _lstProductos.Count = 0 Then _lstProductos = New List(Of Producto)
            _lstProductos.Add(_Producto)
            MostrarProductos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EliminarProducto()
        Try
            If _lstProductos.Count > 0 Then
                CType(dgProductos.CurrentRow.DataBoundItem, Producto).Estatus = EnumEstatus.Registro.Inactivo
                CType(dgProductos.CurrentRow.DataBoundItem, Producto).Edicion = EnumEstatus.Edicion.Eliminar
                If CType(dgProductos.CurrentRow.DataBoundItem, Producto).Edicion <> EnumEstatus.Edicion.Eliminar Then
                    CType(dgProductos.CurrentRow.DataBoundItem, Producto).Edicion = EnumEstatus.Edicion.Editado
                End If
                If _lstProductos.Count <> 0 Then
                    If _ctrlProducto.ProductosValidos(_lstProductos) Then
                        If _ctrlProducto.Eliminar(_lstProductos, esTipoSP) Then
                        End If
                    End If
                Else
                    _lstProductos.Remove(CType(dgProductos.CurrentRow.DataBoundItem, Producto))
                End If
            End If
            CargarProductos()
            MostrarProductos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GuardarProductos()
        Try
            dgProductos.EndEdit()
            If _ctrlProducto.Guardar(_lstProductos, esTipoSP) Then
                CargarProductos()
                MostrarProductos()
                MessageBox.Show(Mensajes.Info_Guardado, Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            dgProductos.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TeclaPresionada(ByVal Tecla As Windows.Forms.Keys)
        Select Case Tecla
            Case Windows.Forms.Keys.Insert
                If mstpItemInsert.Enabled Then RaiseEvent MenuInsert(mstpItemInsert, Nothing)
            Case Windows.Forms.Keys.Delete
                If mstpItemSupr.Enabled Then RaiseEvent MenuSuprimir(mstpItemSupr, Nothing)
            Case Windows.Forms.Keys.F10
                If mstpItemGuardar.Enabled Then RaiseEvent MenuGuardar(mstpItemGuardar, Nothing)
            Case Windows.Forms.Keys.F12
                If mstpItemCancelar.Enabled Then RaiseEvent MenuCancelar(mstpItemCancelar, Nothing)
            Case Windows.Forms.Keys.Escape
                If mstpItemSalir.Enabled Then RaiseEvent MenuSalir(mstpItemSalir, Nothing)
        End Select
    End Sub
    Private Sub frmProducto_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show(Mensajes.Salir, Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
    Private Sub frmProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LlenarComboGridCategoria()
            CargarProductos()
            MostrarProductos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgProductos_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgProductos.DataError
        e.Cancel = True
    End Sub
    Private Sub dgProductos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgProductos.CellEndEdit
        Try
            If e.ColumnIndex = 0 Then
                If _ctrlProducto.DatoDuplicado(_lstProductos, CType(dgProductos.CurrentRow.DataBoundItem, Producto).Id) Then
                    MessageBox.Show(Mensajes.Info_DatosRepetidos, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CType(dgProductos.CurrentRow.DataBoundItem, Producto).Id = String.Empty
                End If
            End If
            If CType(dgProductos.CurrentRow.DataBoundItem, Producto).Edicion <> EnumEstatus.Edicion.Nuevo Then
                CType(dgProductos.CurrentRow.DataBoundItem, Producto).Edicion = EnumEstatus.Edicion.Editado
            End If
            dgProductos.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub mstpItemInsert_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemInsert.Click
        AñadirProducto()
    End Sub
    Private Sub mstpItemSupr_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemSupr.Click
        EliminarProducto()
    End Sub
    Private Sub mstpItemGuardar_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemGuardar.Click
        GuardarProductos()
    End Sub
    Private Sub mstpItemCancelar_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemCancelar.Click
        CargarProductos()
        MostrarProductos()
    End Sub
    Private Sub mstpItemSalir_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemSalir.Click
        Me.Close()
    End Sub
    Private Sub frmProducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Me.TeclaPresionada(e.KeyCode)
    End Sub
    Private Sub dgProductos_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgProductos.EditingControlShowing
        Try
            If dgProductos.CurrentCell.ColumnIndex = 0 Then
                FormatoCeldaGrid(dgProductos, e, dgProductos.CurrentCell.ColumnIndex, TipoFormato.Numeros)
            End If
            If dgProductos.CurrentCell.ColumnIndex = 1 Then
                FormatoCeldaGrid(dgProductos, e, dgProductos.CurrentCell.ColumnIndex, TipoFormato.Letras)
            End If
            If dgProductos.CurrentCell.ColumnIndex = 2 Then
                FormatoCeldaGrid(dgProductos, e, dgProductos.CurrentCell.ColumnIndex, TipoFormato.Decimales)
            End If
            If dgProductos.CurrentCell.ColumnIndex = 3 Then
                FormatoCeldaGrid(dgProductos, e, dgProductos.CurrentCell.ColumnIndex, TipoFormato.NumeroLetras)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

End Class