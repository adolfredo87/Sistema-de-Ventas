<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentas
    Inherits Presentacion.Plantilla.FrmPlantilla

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.gbCabecera = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtIDVenta = New System.Windows.Forms.TextBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.gbDetalle = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.mstpInsSupr = New System.Windows.Forms.MenuStrip()
        Me.mstpItemInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemSupr = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgDetalle = New System.Windows.Forms.DataGridView()
        Me.colProducto = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mstpMenuMaestro = New System.Windows.Forms.MenuStrip()
        Me.mstpItemNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.gbCabecera.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.gbDetalle.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.mstpInsSupr.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.mstpMenuMaestro.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.gbCabecera, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.gbDetalle, 0, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(601, 463)
        Me.TableLayoutPanel6.TabIndex = 6
        '
        'gbCabecera
        '
        Me.gbCabecera.BackColor = System.Drawing.Color.Transparent
        Me.gbCabecera.Controls.Add(Me.TableLayoutPanel7)
        Me.gbCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbCabecera.Location = New System.Drawing.Point(3, 3)
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.Size = New System.Drawing.Size(595, 120)
        Me.gbCabecera.TabIndex = 0
        Me.gbCabecera.TabStop = False
        Me.gbCabecera.Text = "Datos Generales de la Venta"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel7.ColumnCount = 4
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.Controls.Add(Me.txtIDVenta, 1, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.cmbCliente, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.dtpFecha, 1, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.Label6, 2, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.cmbEstatus, 3, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.Label5, 2, 3)
        Me.TableLayoutPanel7.Controls.Add(Me.txtTotal, 3, 3)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 4
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.78571!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.21429!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(589, 101)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'txtIDVenta
        '
        Me.txtIDVenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIDVenta.Location = New System.Drawing.Point(59, 29)
        Me.txtIDVenta.Name = "txtIDVenta"
        Me.txtIDVenta.Size = New System.Drawing.Size(331, 20)
        Me.txtIDVenta.TabIndex = 3
        Me.txtIDVenta.Text = " "
        '
        'cmbCliente
        '
        Me.cmbCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(59, 3)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(331, 21)
        Me.cmbCliente.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(14, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(3, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "N° Venta"
        '
        'dtpFecha
        '
        Me.dtpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.dtpFecha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpFecha.Location = New System.Drawing.Point(59, 53)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(331, 20)
        Me.dtpFecha.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(420, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Estado"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(466, 29)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(120, 21)
        Me.cmbEstatus.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(396, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Monto Total"
        '
        'txtTotal
        '
        Me.txtTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(466, 78)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(120, 20)
        Me.txtTotal.TabIndex = 11
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbDetalle
        '
        Me.gbDetalle.BackColor = System.Drawing.Color.Transparent
        Me.gbDetalle.Controls.Add(Me.TableLayoutPanel1)
        Me.gbDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDetalle.Location = New System.Drawing.Point(3, 129)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(595, 331)
        Me.gbDetalle.TabIndex = 1
        Me.gbDetalle.TabStop = False
        Me.gbDetalle.Text = "Deatlle de la Venta"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.mstpInsSupr, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgDetalle, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel8, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.19009!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.80992!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(589, 312)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'mstpInsSupr
        '
        Me.mstpInsSupr.BackColor = System.Drawing.Color.Transparent
        Me.mstpInsSupr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mstpInsSupr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mstpItemInsert, Me.mstpItemSupr})
        Me.mstpInsSupr.Location = New System.Drawing.Point(0, 212)
        Me.mstpInsSupr.Name = "mstpInsSupr"
        Me.mstpInsSupr.Size = New System.Drawing.Size(589, 31)
        Me.mstpInsSupr.TabIndex = 15
        Me.mstpInsSupr.Text = "MenuStrip2"
        '
        'mstpItemInsert
        '
        Me.mstpItemInsert.Image = CType(resources.GetObject("mstpItemInsert.Image"), System.Drawing.Image)
        Me.mstpItemInsert.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemInsert.Name = "mstpItemInsert"
        Me.mstpItemInsert.Size = New System.Drawing.Size(72, 27)
        Me.mstpItemInsert.Text = "(Insert)"
        '
        'mstpItemSupr
        '
        Me.mstpItemSupr.Image = CType(resources.GetObject("mstpItemSupr.Image"), System.Drawing.Image)
        Me.mstpItemSupr.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemSupr.Name = "mstpItemSupr"
        Me.mstpItemSupr.Size = New System.Drawing.Size(67, 27)
        Me.mstpItemSupr.Text = "(Supr)"
        '
        'dgDetalle
        '
        Me.dgDetalle.AllowUserToAddRows = False
        Me.dgDetalle.AllowUserToResizeRows = False
        Me.dgDetalle.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colProducto, Me.colPrecio, Me.colCantidad, Me.colMonto})
        Me.dgDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDetalle.Location = New System.Drawing.Point(3, 3)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.RowHeadersVisible = False
        Me.dgDetalle.Size = New System.Drawing.Size(583, 206)
        Me.dgDetalle.TabIndex = 0
        '
        'colProducto
        '
        Me.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colProducto.DataPropertyName = "IdProducto"
        Me.colProducto.HeaderText = "Producto"
        Me.colProducto.Name = "colProducto"
        '
        'colPrecio
        '
        Me.colPrecio.DataPropertyName = "Precio"
        Me.colPrecio.HeaderText = "Precio Unitario"
        Me.colPrecio.Name = "colPrecio"
        '
        'colCantidad
        '
        Me.colCantidad.DataPropertyName = "Cantidad"
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.Name = "colCantidad"
        '
        'colMonto
        '
        Me.colMonto.DataPropertyName = "Monto"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colMonto.DefaultCellStyle = DataGridViewCellStyle1
        Me.colMonto.HeaderText = "Monto"
        Me.colMonto.Name = "colMonto"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.lblTotalVenta, 1, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.lblMonto, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(384, 246)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(202, 63)
        Me.TableLayoutPanel8.TabIndex = 13
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalVenta.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.Location = New System.Drawing.Point(104, 34)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(95, 26)
        Me.lblTotalVenta.TabIndex = 3
        Me.lblTotalVenta.Text = "0,00"
        Me.lblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMonto
        '
        Me.lblMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonto.BackColor = System.Drawing.Color.Transparent
        Me.lblMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMonto.Location = New System.Drawing.Point(104, 5)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(95, 21)
        Me.lblMonto.TabIndex = 1
        Me.lblMonto.Text = "0,00"
        Me.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(4, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Suma Monto Total"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Total Venta"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mstpMenuMaestro
        '
        Me.mstpMenuMaestro.BackColor = System.Drawing.Color.Transparent
        Me.mstpMenuMaestro.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mstpItemNuevo, Me.mstpItemBuscar, Me.mstpItemModificar, Me.mstpItemGuardar, Me.mstpItemEliminar, Me.mstpItemCancelar, Me.mstpItemSalir})
        Me.mstpMenuMaestro.Location = New System.Drawing.Point(0, 0)
        Me.mstpMenuMaestro.Name = "mstpMenuMaestro"
        Me.mstpMenuMaestro.ShowItemToolTips = True
        Me.mstpMenuMaestro.Size = New System.Drawing.Size(601, 24)
        Me.mstpMenuMaestro.TabIndex = 5
        Me.mstpMenuMaestro.Text = "MenuStrip1"
        '
        'mstpItemNuevo
        '
        Me.mstpItemNuevo.Image = CType(resources.GetObject("mstpItemNuevo.Image"), System.Drawing.Image)
        Me.mstpItemNuevo.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemNuevo.Name = "mstpItemNuevo"
        Me.mstpItemNuevo.Size = New System.Drawing.Size(55, 20)
        Me.mstpItemNuevo.Text = "(F7)"
        Me.mstpItemNuevo.ToolTipText = "Nuevo"
        '
        'mstpItemBuscar
        '
        Me.mstpItemBuscar.Image = CType(resources.GetObject("mstpItemBuscar.Image"), System.Drawing.Image)
        Me.mstpItemBuscar.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemBuscar.Name = "mstpItemBuscar"
        Me.mstpItemBuscar.Size = New System.Drawing.Size(55, 20)
        Me.mstpItemBuscar.Text = "(F8)"
        Me.mstpItemBuscar.ToolTipText = "Buscar"
        '
        'mstpItemModificar
        '
        Me.mstpItemModificar.Enabled = False
        Me.mstpItemModificar.Image = CType(resources.GetObject("mstpItemModificar.Image"), System.Drawing.Image)
        Me.mstpItemModificar.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemModificar.Name = "mstpItemModificar"
        Me.mstpItemModificar.Size = New System.Drawing.Size(55, 20)
        Me.mstpItemModificar.Text = "(F9)"
        Me.mstpItemModificar.ToolTipText = "Modificar"
        '
        'mstpItemGuardar
        '
        Me.mstpItemGuardar.Enabled = False
        Me.mstpItemGuardar.Image = CType(resources.GetObject("mstpItemGuardar.Image"), System.Drawing.Image)
        Me.mstpItemGuardar.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemGuardar.Name = "mstpItemGuardar"
        Me.mstpItemGuardar.Size = New System.Drawing.Size(61, 20)
        Me.mstpItemGuardar.Text = "(F10)"
        Me.mstpItemGuardar.ToolTipText = "Guardar"
        '
        'mstpItemEliminar
        '
        Me.mstpItemEliminar.Enabled = False
        Me.mstpItemEliminar.Image = CType(resources.GetObject("mstpItemEliminar.Image"), System.Drawing.Image)
        Me.mstpItemEliminar.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemEliminar.Name = "mstpItemEliminar"
        Me.mstpItemEliminar.Size = New System.Drawing.Size(61, 20)
        Me.mstpItemEliminar.Text = "(F11)"
        Me.mstpItemEliminar.ToolTipText = "Eliminar"
        '
        'mstpItemCancelar
        '
        Me.mstpItemCancelar.Enabled = False
        Me.mstpItemCancelar.Image = CType(resources.GetObject("mstpItemCancelar.Image"), System.Drawing.Image)
        Me.mstpItemCancelar.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemCancelar.Name = "mstpItemCancelar"
        Me.mstpItemCancelar.Size = New System.Drawing.Size(61, 20)
        Me.mstpItemCancelar.Text = "(F12)"
        Me.mstpItemCancelar.ToolTipText = "Cancelar"
        '
        'mstpItemSalir
        '
        Me.mstpItemSalir.Image = CType(resources.GetObject("mstpItemSalir.Image"), System.Drawing.Image)
        Me.mstpItemSalir.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemSalir.Name = "mstpItemSalir"
        Me.mstpItemSalir.Size = New System.Drawing.Size(60, 20)
        Me.mstpItemSalir.Text = "(Esc)"
        Me.mstpItemSalir.ToolTipText = "Salir"
        '
        'frmVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 487)
        Me.Controls.Add(Me.TableLayoutPanel6)
        Me.Controls.Add(Me.mstpMenuMaestro)
        Me.Name = "frmVentas"
        Me.Text = "frmVentas"
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.gbCabecera.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.gbDetalle.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.mstpInsSupr.ResumeLayout(False)
        Me.mstpInsSupr.PerformLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.mstpMenuMaestro.ResumeLayout(False)
        Me.mstpMenuMaestro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mstpMenuMaestro As System.Windows.Forms.MenuStrip
    Public WithEvents mstpItemNuevo As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemBuscar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemModificar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemGuardar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemEliminar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemCancelar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtIDVenta As System.Windows.Forms.TextBox
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents gbDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTotalVenta As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mstpInsSupr As System.Windows.Forms.MenuStrip
    Public WithEvents mstpItemInsert As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemSupr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colProducto As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonto As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
