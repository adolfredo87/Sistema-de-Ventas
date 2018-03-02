Imports EntidadNegocio.General
Imports Presentacion.Plantilla
Imports LogicaNegocio.General

Public Class frmCliente

#Region "Atributos"
    Private _ctrlCliente As CtrlCliente
    Private _cliente As Cliente
    Private esTipoSP As Integer = 0
    Private _idcliente As Integer
    Private WithEvents _catalago As frmCatalogo
    Public Event Guardar(ByVal _cliente As Cliente)
#End Region

#Region "Eventos"
    Event MenuNuevo(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuBuscar(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuModificar(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuGuardar(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuEliminar(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuCancelar(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Event MenuSalir(ByVal sender As System.Object, ByVal e As System.EventArgs)
#End Region

#Region "Metodos"
    Sub New()
        ' Llamada necesaria para el diseñador.
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InitializeComponent()
        _ctrlCliente = New CtrlCliente
        _cliente = New Cliente
        esTipoSP = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("EsTipoGuardadoSP").ToString())
    End Sub
    Sub New(ByVal idcliente As Integer)
        ' Llamada necesaria para el diseñador.
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InitializeComponent()
        _ctrlCliente = New CtrlCliente
        _cliente = New Cliente
        _idcliente = idcliente
        Me.mstpItemCancelar.Visible = False
        Me.mstpItemEliminar.Visible = False
        Me.mstpItemModificar.Visible = False
        Me.mstpItemNuevo.Visible = False
        txtCodigo.TabIndex = 0
        esTipoSP = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("EsTipoGuardadoSP").ToString())
    End Sub
    Public Sub ControlBotonesMenu(ByVal Accion As EnumTipos.AccionMenu)
        Select Case Accion
            Case EnumTipos.AccionMenu.Nuevo
                mstpItemNuevo.Enabled = False
                mstpItemBuscar.Enabled = False
                mstpItemModificar.Enabled = False
                mstpItemGuardar.Enabled = True
                mstpItemEliminar.Enabled = False
                mstpItemCancelar.Enabled = True
                txtCodigo.Enabled = False
                txtNombre.Enabled = True
                txtTelefono.Enabled = True
                txtCorreo.Enabled = True
            Case EnumTipos.AccionMenu.Buscar
                mstpItemNuevo.Enabled = False
                If mstpItemBuscar.Tag <> "N" Then mstpItemBuscar.Enabled = True
                If mstpItemModificar.Tag <> "N" Then mstpItemModificar.Enabled = True
                mstpItemGuardar.Enabled = False
                If mstpItemEliminar.Tag <> "N" Then mstpItemEliminar.Enabled = True
                mstpItemCancelar.Enabled = True
                txtCodigo.Enabled = False
                txtNombre.Enabled = False
                txtTelefono.Enabled = False
                txtCorreo.Enabled = False
            Case EnumTipos.AccionMenu.Modificar
                mstpItemNuevo.Enabled = False
                mstpItemBuscar.Enabled = False
                mstpItemModificar.Enabled = False
                mstpItemGuardar.Enabled = True
                mstpItemEliminar.Enabled = False
                mstpItemCancelar.Enabled = True
                txtCodigo.Enabled = False
                txtNombre.Enabled = True
                txtTelefono.Enabled = True
                txtCorreo.Enabled = True
            Case EnumTipos.AccionMenu.Eliminar, EnumTipos.AccionMenu.Cancelar, EnumTipos.AccionMenu.Guardar, EnumTipos.AccionMenu.Inicializar
                If mstpItemNuevo.Tag <> "N" Then mstpItemNuevo.Enabled = True
                If mstpItemBuscar.Tag <> "N" Then mstpItemBuscar.Enabled = True
                mstpItemModificar.Enabled = False
                mstpItemGuardar.Enabled = False
                mstpItemEliminar.Enabled = False
                mstpItemCancelar.Enabled = False
                txtCodigo.Enabled = False
                txtNombre.Enabled = False
                txtTelefono.Enabled = False
                txtCorreo.Enabled = False
        End Select
    End Sub
    Public Sub TeclaPresionada(ByVal Tecla As Windows.Forms.Keys)
        Select Case Tecla
            Case Windows.Forms.Keys.F7
                If mstpItemNuevo.Enabled Then RaiseEvent MenuNuevo(mstpItemNuevo, Nothing)
            Case Windows.Forms.Keys.F8
                If mstpItemBuscar.Enabled Then RaiseEvent MenuBuscar(mstpItemBuscar, Nothing)
            Case Windows.Forms.Keys.F9
                If mstpItemModificar.Enabled Then RaiseEvent MenuModificar(mstpItemModificar, Nothing)
            Case Windows.Forms.Keys.F10
                If mstpItemGuardar.Enabled Then RaiseEvent MenuGuardar(mstpItemGuardar, Nothing)
            Case Windows.Forms.Keys.F11
                If mstpItemEliminar.Enabled Then RaiseEvent MenuEliminar(mstpItemEliminar, Nothing)
            Case Windows.Forms.Keys.F12
                If mstpItemCancelar.Enabled Then RaiseEvent MenuCancelar(mstpItemCancelar, Nothing)
            Case Windows.Forms.Keys.Escape
                If mstpItemSalir.Enabled Then RaiseEvent MenuSalir(mstpItemSalir, Nothing)
        End Select
    End Sub
    Private Sub mstpItemNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mstpItemNuevo.Click
        NuevoCliente()
        txtNombre.Focus()
    End Sub
    Private Sub mstpItemBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mstpItemBuscar.Click
        BuscarClientes()
    End Sub
    Private Sub mstpItemModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mstpItemModificar.Click
        txtCodigo.Enabled = False
        _cliente.Edicion = EntidadNegocio.General.EnumEstatus.Edicion.Editado
        Me.ControlBotonesMenu(EnumTipos.AccionMenu.Modificar)
        txtNombre.Focus()
    End Sub
    Private Sub mstpItemGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mstpItemGuardar.Click
        _cliente.Codigo = CInt(Val(txtCodigo.Text))
        _cliente.Nombre = txtNombre.Text
        _cliente.Telefono = txtTelefono.Text
        _cliente.Correo = txtCorreo.Text
        If _ctrlCliente.Guardar(_cliente, esTipoSP) Then
            MessageBox.Show(Mensajes.Info_Guardado, Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
            Me.ControlBotonesMenu(EnumTipos.AccionMenu.Guardar)
            RaiseEvent Guardar(_cliente)
        End If
    End Sub
    Private Sub mstpItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mstpItemEliminar.Click
        _cliente.Status = EnumEstatus.Registro.Inactivo
        _cliente.Edicion = EntidadNegocio.General.EnumEstatus.Edicion.Eliminar
        Me.ControlBotonesMenu(EnumTipos.AccionMenu.Eliminar)
        If _ctrlCliente.Eliminar(_cliente, esTipoSP) Then
            MessageBox.Show(Mensajes.Info_Eliminado, Mensajes.Titulo_Eliminar, MessageBoxButtons.OK, MessageBoxIcon.Information)
            LimpiarCampos()
        End If
    End Sub
    Private Sub mstpItemCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mstpItemCancelar.Click
        LimpiarCampos()
        Me.ControlBotonesMenu(EnumTipos.AccionMenu.Cancelar)
    End Sub
    Private Sub mstpItemSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mstpItemSalir.Click
        Me.Close()
    End Sub
    Private Sub frmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gbDatos.Text = "Cleinte"
    End Sub
    Private Sub frmCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show(Mensajes.Salir, Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
    Private Sub frmCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.TeclaPresionada(e.KeyCode)
    End Sub
    Private Sub frmCliente_Disposed(ByVal sender As Object, ByVal e As System.EventArgs)
        _ctrlCliente = Nothing
        _cliente = Nothing
    End Sub
    Private Sub NuevoCliente()
        LimpiarCampos()
        Dim codigo As Integer = CInt(_ctrlCliente.ObtenerItem(0, 0).Codigo)
        txtCodigo.Text = IIf(codigo = 0, 1, codigo + 1)
        txtCodigo.Enabled = False
        _cliente.Edicion = EntidadNegocio.General.EnumEstatus.Edicion.Nuevo
        Me.ControlBotonesMenu(EnumTipos.AccionMenu.Nuevo)
        txtNombre.Focus()
    End Sub
    Private Sub LimpiarCampos()
        txtCodigo.Text = ""
        txtNombre.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
    End Sub
    Private Sub BuscarClientes()
        Try
            _catalago = New frmCatalogo
            Dim col1 As New DataGridViewTextBoxColumn
            Dim col2 As New DataGridViewTextBoxColumn

            AddHandler _catalago.BuscarDato, AddressOf ObtenerBindingClientes
            col1.Name = "codigo"
            col1.HeaderText = "Codigo"
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            col1.DataPropertyName = "Codigo"
            col1.Tag = "/Buscar = S"
            col1.ReadOnly = True

            col2.Name = "nombre"
            col2.HeaderText = "Nombre"
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            col2.DataPropertyName = "Nombre"
            col2.Tag = "/Buscar = S"
            col2.ReadOnly = True

            Dim columnas() As DataGridViewColumn = {col1, col2}
            _catalago.Columnas = columnas
            _catalago.SeleccionMultiple = False
            _catalago.MarcarTodo = False
            _catalago.EliTodo = False
            _catalago.ShowDialog()
            If frmCatalogo.ValorBuscar IsNot String.Empty And frmCatalogo.ValorBuscar IsNot Nothing Then
                _cliente = New Cliente
                _cliente = _ctrlCliente.ObtenerItem(CType(frmCatalogo.ValorBuscar, Cliente).Codigo)
                MostrarDatos()
                Me.ControlBotonesMenu(EnumTipos.AccionMenu.Buscar)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub MostrarDatos()
        Try
            txtCodigo.Text = _cliente.Codigo
            txtNombre.Text = _cliente.Nombre
            txtTelefono.Text = _cliente.Telefono
            txtCorreo.Text = _cliente.Correo
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ObtenerBindingClientes(ByVal valorBuscado As String, ByRef binding As Object, ByVal columnaBuscada As Integer)
        Try
            If valorBuscado = String.Empty Then
                binding = _ctrlCliente.ObtenerItems()
            Else
                Select Case columnaBuscada
                    Case 0
                        binding = _ctrlCliente.ObtenerItems(valorBuscado, EnumBuscarPor.Cliente.Codigo)
                    Case 1
                        binding = _ctrlCliente.ObtenerItems(valorBuscado, EnumBuscarPor.Cliente.Nombre)
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

End Class