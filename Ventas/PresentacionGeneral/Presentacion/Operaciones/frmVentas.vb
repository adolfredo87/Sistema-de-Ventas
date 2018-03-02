Imports EntidadNegocio.General
Imports LogicaNegocio.General
Imports Presentacion.Plantilla

Public Class frmVentas

#Region "Atributos"
    Private IdVenta As Integer
    Private _Venta As Venta
    Private _Ventas As List(Of Venta)
    Private _DetalleVenta As DetalleVenta
    Private _DetallesVentas As List(Of DetalleVenta)
    Private _ctrlVenta As New CtrlVenta
    Private _ctrlDetalleVenta As New CtrlDetalleVenta
    ' Producto
    Private IdProducto As Integer
    Private _Producto As Producto
    Private _Productos As New List(Of Producto)
    Private _ctrlProducto As New CtrlProducto
    ' Cliente
    Private _Cliente As Cliente
    Private _Clientes As New List(Of Cliente)
    Private _ctrlCliente As New CtrlCliente
    'Monto y Total y Tipo de guardado
    Private monto As Double = 0
    Private total As Double = 0
    Private esTipo As Integer = 0
    Private esTipoSP As Integer = 0
    Private WithEvents _catalago As frmCatalogo
    Public Event Guardar(ByVal _Venta As Venta)
    Public Event GuardarDetVenta(ByVal _DetalleVenta As DetalleVenta)
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
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InicializarVenta()
        _Producto = New Producto
        _ctrlProducto = New CtrlProducto
        _Productos = New List(Of Producto)
        IdProducto = _Producto.Id
        _ctrlCliente = New CtrlCliente
        _Clientes = New List(Of Cliente)
        esTipo = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("EsTipoGuardado").ToString())
        esTipoSP = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("EsTipoGuardadoSP").ToString())
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
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
                txtIDVenta.Enabled = False
                txtTotal.Enabled = False
                cmbCliente.Enabled = True
                cmbEstatus.Enabled = True
            Case EnumTipos.AccionMenu.Buscar
                mstpItemNuevo.Enabled = False
                If mstpItemBuscar.Tag <> "N" Then mstpItemBuscar.Enabled = True
                If mstpItemModificar.Tag <> "N" Then mstpItemModificar.Enabled = True
                mstpItemGuardar.Enabled = False
                If mstpItemEliminar.Tag <> "N" Then mstpItemEliminar.Enabled = True
                mstpItemCancelar.Enabled = True
                txtIDVenta.Enabled = False
                txtTotal.Enabled = False
                cmbCliente.Enabled = False
                cmbEstatus.Enabled = False
            Case EnumTipos.AccionMenu.Modificar
                mstpItemNuevo.Enabled = False
                mstpItemBuscar.Enabled = False
                mstpItemModificar.Enabled = False
                mstpItemGuardar.Enabled = True
                mstpItemEliminar.Enabled = False
                mstpItemCancelar.Enabled = True
                txtIDVenta.Enabled = False
                txtTotal.Enabled = False
                cmbCliente.Enabled = True
                cmbEstatus.Enabled = True
            Case EnumTipos.AccionMenu.Eliminar, EnumTipos.AccionMenu.Cancelar, EnumTipos.AccionMenu.Guardar, EnumTipos.AccionMenu.Inicializar
                If mstpItemNuevo.Tag <> "N" Then mstpItemNuevo.Enabled = True
                If mstpItemBuscar.Tag <> "N" Then mstpItemBuscar.Enabled = True
                mstpItemModificar.Enabled = False
                mstpItemGuardar.Enabled = False
                mstpItemEliminar.Enabled = False
                mstpItemCancelar.Enabled = False
                txtIDVenta.Enabled = False
                txtTotal.Enabled = False
                cmbCliente.Enabled = False
                cmbEstatus.Enabled = False
        End Select
    End Sub
    Private Sub PrepararGrid()
        Try
            _DetalleVenta = New DetalleVenta
            _DetalleVenta.Producto = New Producto
            _DetalleVenta.Estatus = EnumEstatus.Registro.Activo
            _DetalleVenta.Edicion = EnumEstatus.Edicion.Nuevo
            _DetalleVenta.IdProducto = (From p In _Productos Select (p.Id)).FirstOrDefault()
            _DetalleVenta.Precio = CDbl((From p In _Productos Where p.Id = _DetalleVenta.IdProducto Select (p.Precio)).Sum)
            _DetalleVenta.Cantidad = CInt(0)
            _DetalleVenta.Monto = CDbl(_DetalleVenta.Precio * _DetalleVenta.Cantidad)
            If _Venta.Detalle.Count = 0 Then _Venta.Detalle = New List(Of DetalleVenta)
            _Venta.Detalle.Add(_DetalleVenta)
            LlenarGridDetalleVenta()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub InicializarVenta()
        _Venta = Nothing
        _DetalleVenta = Nothing
        _Venta = New Venta
        _Ventas = New List(Of Venta)
        _DetalleVenta = New DetalleVenta
        _ctrlVenta = New CtrlVenta
        _ctrlDetalleVenta = New CtrlDetalleVenta
        _Venta.Detalle = New List(Of DetalleVenta)
        CargarVentas()
    End Sub
    Public Sub LimpiarCampos()
        LimpiarCamposVenta()
        LimpiarCamposDetalleVenta()
    End Sub
    Private Sub LimpiarCamposVenta()
        Try
            LimpiarControles(gbCabecera)
            DesHabilitarControles(gbCabecera)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LimpiarCamposDetalleVenta()
        Try
            LimpiarControles(gbDetalle)
            DesHabilitarControles(gbDetalle)
            monto = CDbl(0.0)
            total = CDbl(0.0)
            MostrarTotales()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarVentas()
        Try
            _Ventas = _ctrlVenta.ObtenerVentas
        Catch ex As Exception
            MessageBox.Show(Mensajes.Info_ErrorAlCargar, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarCliente(ByVal _valoridCliente As Integer)
        Try
            _Cliente = _ctrlCliente.ObtenerItem(_valoridCliente)
        Catch ex As Exception
            MessageBox.Show(Mensajes.Info_ErrorAlCargar, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarClientes()
        Try
            _Clientes = _ctrlCliente.ObtenerItems
        Catch ex As Exception
            MessageBox.Show(Mensajes.Info_ErrorAlCargar, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarComboCliente()
        Try
            CargarClientes()
            cmbCliente.DisplayMember = "Nombre"
            cmbCliente.ValueMember = "Codigo"
            cmbCliente.DataSource = (From c In _Clientes Where c.Status = 1).ToList
            _Venta.IdCliente = (From c In _Clientes Where c.Status = 1).First().Codigo
            CargarCliente(_Venta.IdCliente)
            cmbCliente.SelectedValue = _Venta.IdCliente
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function AsignarCliente() As Integer
        CargarCliente(cmbCliente.SelectedValue)
        Dim _cunetaInt As Integer
        _cunetaInt = _Cliente.Codigo
        Return _cunetaInt
    End Function
    Private Sub CargarProductos()
        Try
            _Productos = _ctrlProducto.ObtenerItems
        Catch ex As Exception
            MessageBox.Show(Mensajes.Info_ErrorAlCargar, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarComboProductos()
        Try
            CargarProductos()
            Dim column As DataGridViewComboBoxColumn = DirectCast(dgDetalle.Columns("colProducto"), DataGridViewComboBoxColumn)
            column.DataSource = _Productos
            column.DisplayMember = "Nombre"
            column.ValueMember = "Id"
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function SumarMontoDataGridView(ByVal nombre_Columna As String, ByVal Dgv As DataGridView) As Double
        Dim sumaMonto As Double = 0
        Try
            For i As Integer = 0 To Dgv.RowCount - 1
                sumaMonto = sumaMonto + CDbl(Dgv.Item(nombre_Columna.ToLower, i).Value)
            Next
            Return sumaMonto
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return 0
    End Function
    Private Sub LlenarGridDetalleVenta()
        Try
            If Not IsNothing(_Venta) Then
                dgDetalle.AutoGenerateColumns = False
                dgDetalle.DataSource = Nothing
                dgDetalle.DataSource = (From d In _Venta.Detalle Where d.Estatus = 1).ToList
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MostrarDatos()
        Try
            IdVenta = _Venta.Id
            cmbCliente.SelectedValue = _Venta.IdCliente
            txtIDVenta.Text = _Venta.Id
            dtpFecha.Value = _Venta.Fecha.Date
            cmbEstatus.SelectedValue = CInt(_Venta.Estatus)
            If _Venta.Detalle.Count = 0 And IsNothing(_DetalleVenta) Then
                dgDetalle.DataSource = Nothing
            ElseIf _Venta.Detalle.Count = 0 And Not IsNothing(_DetalleVenta) Then
                txtTotal.Text = _DetalleVenta.Monto
                dgDetalle.DataSource = Nothing
            ElseIf _Venta.Detalle.Count > 0 And IsNothing(_DetalleVenta) Then
                LlenarGridDetalleVenta()
                txtTotal.Text = CDbl(0.0)
            Else
                txtTotal.Text = _DetalleVenta.Monto
                LlenarGridDetalleVenta()
            End If
            monto = SumarMontoDataGridView("colMonto", dgDetalle)
            total = CDbl(txtTotal.Text)
            MostrarTotales()
            If _Venta.Estatus = EnumEstatus.EstadoVenta.Procesado Then
                Me.mstpItemModificar.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AsignarDatoCabeceraVenta()
        Try
            _Venta.Id = IdVenta
            _Venta.IdCliente = AsignarCliente()
            If txtIDVenta.Text = "" Then _Venta.Id = 0 Else _Venta.Id = txtIDVenta.Text
            _Venta.Fecha = dtpFecha.Value.Date
            _Venta.Total = CDbl(lblTotalVenta.Text)
            txtTotal.Text = _Venta.Total
            _Venta.Estatus = cmbEstatus.SelectedValue
            _DetalleVenta.IdVentaCab = _Venta.Id
            Dim iD As Integer = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LlenarComboEstatus()
        Try
            Dim l As New List(Of Estatus)
            Dim values() As Integer = CType([Enum].GetValues(GetType(EnumEstatus.EstadoVenta)), Integer())
            Dim i As Estatus
            For Each value In values
                i = New Estatus
                i.Descripcion = [Enum].GetName(GetType(EnumEstatus.EstadoVenta), value)
                i.Id = value
                l.Add(i)
            Next
            cmbEstatus.DataSource = l
            cmbEstatus.DisplayMember = "Descripcion"
            cmbEstatus.ValueMember = "Id"
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ObtenerBindingVenta(ByVal valorBuscado As String, ByRef binding As Object, ByVal columnaBuscada As Integer)
        Try
            If valorBuscado = String.Empty Then
                binding = _ctrlVenta.ObtenerVentas
            Else
                Select Case columnaBuscada
                    Case 0
                        binding = _ctrlVenta.ObtenerItems(valorBuscado, EnumBuscarPor.Venta.Id)
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MostrarCatalogo()
        Try
            _catalago = New frmCatalogo
            Dim col0 As New DataGridViewTextBoxColumn
            Dim col1 As New DataGridViewTextBoxColumn
            Dim col2 As New DataGridViewTextBoxColumn
            Dim col3 As New DataGridViewTextBoxColumn

            AddHandler _catalago.BuscarDato, AddressOf ObtenerBindingVenta
            col0.Name = "idVenta"
            col0.HeaderText = "ID Venta"
            col0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            col0.DataPropertyName = "Id"
            col0.Tag = "/Buscar = S"
            col0.ReadOnly = True

            col1.Name = "Cliente"
            col1.HeaderText = "Cliente"
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            col1.DataPropertyName = "IdCliente"
            col1.Tag = "/Buscar = N"
            col1.ReadOnly = True

            col2.Name = "fecha"
            col2.HeaderText = "Fecha"
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            col2.DataPropertyName = "Fecha"
            col2.Tag = "/Buscar = N"
            col2.ReadOnly = True

            col3.Name = "estatus"
            col3.HeaderText = "Estado"
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            col3.DataPropertyName = "Estatus"
            col3.Tag = "/Buscar = N"
            col3.ReadOnly = True

            Dim columnas() As DataGridViewColumn = {col0, col1, col2, col3}
            _catalago.Columnas = columnas
            _catalago.SeleccionMultiple = False
            _catalago.MarcarTodo = False
            _catalago.EliTodo = False
            _catalago.ShowDialog()
            If frmCatalogo.ValorBuscar IsNot String.Empty And frmCatalogo.ValorBuscar IsNot Nothing Then
                _Venta = CType(frmCatalogo.ValorBuscar, Venta)
                _Venta.Edicion = EnumEstatus.Edicion.Normal
                _DetalleVenta = _ctrlDetalleVenta.VerDetVentaTotal(_Venta.Id)
                _DetalleVenta.Edicion = EnumEstatus.Edicion.Normal
                _Venta.Detalle = _ctrlDetalleVenta.VerDetVentaMonto(_Venta.Id)
                Me.ControlBotonesMenu(EnumTipos.AccionMenu.Buscar)
                MostrarDatos()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmVenta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show(Mensajes.Salir, Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
    Private Sub frmVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CargarComboCliente()
            CargarComboProductos()
            DesHabilitarControles(gbCabecera)
            DesHabilitarControles(gbDetalle)
            dtpFecha.Value = Date.Now()
            cmbCliente.SelectedItem = 0
            LlenarGridDetalleVenta()
            LlenarComboEstatus()
            cmbEstatus.SelectedValue = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmVenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            Me.TeclaPresionada(e.KeyCode)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub mstpItemNuevo_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemNuevo.Click
        Try
            InicializarVenta()
            LimpiarCampos()
            dgDetalle.EndEdit()
            dgDetalle.AutoGenerateColumns = False
            dgDetalle.DataSource = Nothing
            HabilitarControles(gbCabecera)
            HabilitarControles(gbDetalle)
            CargarComboCliente()
            CargarComboProductos()
            cmbEstatus.SelectedValue = CInt(EnumEstatus.EstadoVenta.Registrado)
            LlenarGridDetalleVenta()
            Dim iD As Integer = 0
            If _Ventas.Count > 0 Then iD = CInt(_Ventas.Last.Id)
            txtIDVenta.Text = IIf(iD = 0, 1, iD + 1)
            txtTotal.Text = lblTotalVenta.Text
            _Venta.Id = txtIDVenta.Text
            _Venta.Edicion = EntidadNegocio.General.EnumEstatus.Edicion.Nuevo
            _DetalleVenta.Estatus = EntidadNegocio.General.EnumEstatus.Registro.Activo
            _DetalleVenta.Edicion = EntidadNegocio.General.EnumEstatus.Edicion.Nuevo
            _DetalleVenta.IdVentaCab = _Venta.Id
            Me.ControlBotonesMenu(EnumTipos.AccionMenu.Nuevo)
            cmbCliente.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub mstpItemBuscar_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemBuscar.Click
        MostrarCatalogo()
    End Sub
    Private Sub mstpItemModificar_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemModificar.Click
        Try
            If _Venta.Estatus = EnumEstatus.EstadoVenta.Registrado Then
                HabilitarControles(gbCabecera)
                HabilitarControles(gbDetalle)
                _Venta.Edicion = EntidadNegocio.General.EnumEstatus.Edicion.Editado
                Me.ControlBotonesMenu(EnumTipos.AccionMenu.Modificar)
                If _Venta.Estatus = EnumEstatus.EstadoVenta.Registrado Then
                    txtIDVenta.Enabled = True
                Else
                    txtIDVenta.Enabled = False
                End If
                txtIDVenta.Focus()
            End If
            Me.ControlBotonesMenu(EnumTipos.AccionMenu.Modificar)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub mstpItemGuardar_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemGuardar.Click
        Try
            If (cmbCliente.SelectedValue = Nothing) Then
                MessageBox.Show("Debe Seleccionar una Cliente", Mensajes.Info_Incompleta, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If cmbEstatus.SelectedValue = CInt(EnumEstatus.EstadoVenta.Procesado) And txtIDVenta.Text = "" Then
                MessageBox.Show("El N° de Venta no puede ser vacio si el estado es Procesado", Mensajes.Info_Incompleta, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If (dtpFecha.Value.Date > Date.Today) Then
                MessageBox.Show("No se puede registrar o procesar un Venta con fecha mayor a la de Hoy", Mensajes.Info_Incompleta, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If dgDetalle.Rows.Count > 0 Then
                If _Venta.Edicion = EnumEstatus.Edicion.Nuevo Or _Venta.Edicion = EnumEstatus.Edicion.Normal Then
                    AsignarDatoCabeceraVenta()
                    dgDetalle.EndEdit()
                    If _ctrlVenta.Guardar(_Venta, _Venta.Detalle, esTipo, esTipoSP) Then
                        MessageBox.Show(Mensajes.Info_Guardado, Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.ControlBotonesMenu(EnumTipos.AccionMenu.Guardar)
                    Else
                        Exit Sub
                    End If
                Else
                    AsignarDatoCabeceraVenta()
                    dgDetalle.EndEdit()
                    If _ctrlVenta.Guardar(_Venta, _Venta.Detalle, esTipo, esTipoSP) Then
                        MessageBox.Show(Mensajes.Info_Guardado, Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.ControlBotonesMenu(EnumTipos.AccionMenu.Guardar)
                    Else
                        Exit Sub
                    End If
                End If
            Else
                MessageBox.Show("No se puede registrar o procesar un Venta sin nigun pruducto", Mensajes.Info_Incompleta, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            dgDetalle.EndEdit()
            InicializarVenta()
            LimpiarCampos()
            dgDetalle.AutoGenerateColumns = False
            dgDetalle.DataSource = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub mstpItemEliminar_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemEliminar.Click
        Try
            If _Venta.Edicion <> EnumEstatus.Edicion.Nuevo Then
                _Venta.Estatus = EnumEstatus.Registro.Inactivo
                _Venta.Edicion = EnumEstatus.Edicion.Editado
                If _ctrlVenta.Eliminar(_Venta, _Venta.Detalle, esTipo, esTipoSP) Then
                    MessageBox.Show(Mensajes.Info_Eliminado, Mensajes.Titulo_Eliminar, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                dgDetalle.EndEdit()
                InicializarVenta()
                LimpiarCampos()
                dgDetalle.AutoGenerateColumns = False
                dgDetalle.DataSource = Nothing
                Me.ControlBotonesMenu(EnumTipos.AccionMenu.Eliminar)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub mstpItemCancelar_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemCancelar.Click
        Try
            dgDetalle.EndEdit()
            InicializarVenta()
            LimpiarCampos()
            dgDetalle.AutoGenerateColumns = False
            dgDetalle.DataSource = Nothing
            Me.ControlBotonesMenu(EnumTipos.AccionMenu.Cancelar)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub mstpItemSalir_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemSalir.Click
        Me.Close()
    End Sub
    Private Sub mstpItemInsert_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemInsert.Click
        Try
            If txtIDVenta.Text.Length = 0 And dtpFecha.Value.Date > Date.Today And txtTotal.Text.Length = 0 Then
                MessageBox.Show(Mensajes.Info_Incompleta, Mensajes.Info_Incompleta, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                AsignarDatoCabeceraVenta()
                PrepararGrid()
                MostrarTotales()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub mstpItemSupr_Click(sender As System.Object, e As System.EventArgs) Handles mstpItemSupr.Click
        Try
            If _Venta.Detalle.Count > 0 Then
                If CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).Edicion <> EnumEstatus.Edicion.Nuevo Then
                    CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).Estatus = EnumEstatus.Registro.Inactivo
                    CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).Edicion = EnumEstatus.Edicion.Eliminar
                Else
                    dgDetalle.EndEdit()
                    _Venta.Detalle.Remove(CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta))
                End If
                dgDetalle.Refresh()
                LlenarGridDetalleVenta()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        FormatoNumeroDecimal(e, txtTotal)
    End Sub
    Private Sub dgDetalle_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgDetalle.EditingControlShowing
        Try
            If dgDetalle.CurrentCell.ColumnIndex = 1 Then
                FormatoCeldaGrid(dgDetalle, e, dgDetalle.CurrentCell.ColumnIndex, TipoFormato.Decimales)
            End If
            If dgDetalle.CurrentCell.ColumnIndex = 2 Then
                FormatoCeldaGrid(dgDetalle, e, dgDetalle.CurrentCell.ColumnIndex, TipoFormato.Decimales)
            End If
            If dgDetalle.CurrentCell.ColumnIndex = 3 Then
                FormatoCeldaGrid(dgDetalle, e, dgDetalle.CurrentCell.ColumnIndex, TipoFormato.Decimales)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgDetalle_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgDetalle.DataError
        e.Cancel = True
    End Sub
    Private Sub dgDetalle_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgDetalle.CellBeginEdit
        _DetalleVenta.IdProducto = CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).IdProducto
        CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).Precio = CDbl((From p In _Productos Where p.Id = _DetalleVenta.IdProducto Select (p.Precio)).Sum)
    End Sub
    Private Sub dgDetalle_CellValidating(sender As System.Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgDetalle.CellValidating
        _DetalleVenta.IdProducto = CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).IdProducto
        CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).Precio = CDbl((From p In _Productos Where p.Id = _DetalleVenta.IdProducto Select (p.Precio)).Sum)
    End Sub
    Private Sub dgDetalle_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDetalle.Validated
        Try
            monto = SumarMontoDataGridView("colMonto", dgDetalle)
            MostrarTotales()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgDetalle_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetalle.CellEndEdit
        Try
            If CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).Edicion <> EnumEstatus.Edicion.Nuevo Then
                CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).Edicion = EnumEstatus.Edicion.Editado
            End If
            _DetalleVenta.IdProducto = CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).IdProducto
            CType(dgDetalle.CurrentRow.DataBoundItem, DetalleVenta).Precio = CDbl((From p In _Productos Where p.Id = _DetalleVenta.IdProducto Select (p.Precio)).Sum)
            monto = SumarMontoDataGridView("colMonto", dgDetalle)
            lblMonto.Text = CDbl(monto)
            MostrarTotales()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MostrarTotales()
        _DetalleVenta.Monto = CDbl(_DetalleVenta.Precio * _DetalleVenta.Cantidad)
        lblMonto.Text = Format(monto, "###,###0.00")
        lblTotalVenta.Text = Format(monto, "###,###0.00")
    End Sub
    Private Sub txtTotal_LostFocus(sender As Object, e As System.EventArgs) Handles txtTotal.LostFocus
        MostrarTotales()
    End Sub
    Private Sub lblTotalVenta_TextChanged(sender As System.Object, e As System.EventArgs) Handles lblTotalVenta.TextChanged
        txtTotal.Text = lblTotalVenta.Text
    End Sub
#End Region
    
End Class