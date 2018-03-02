<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCliente
    Inherits Presentacion.Plantilla.frmPlantilla

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCliente))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.mstpMenuMaestro = New System.Windows.Forms.MenuStrip()
        Me.mstpItemNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.mstpMenuMaestro.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(601, 487)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.gbDatos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(593, 461)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos Generales"
        '
        'gbDatos
        '
        Me.gbDatos.BackColor = System.Drawing.Color.Transparent
        Me.gbDatos.Controls.Add(Me.TableLayoutPanel1)
        Me.gbDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDatos.Location = New System.Drawing.Point(3, 3)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(587, 455)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCodigo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNombre, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTelefono, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCorreo, 1, 4)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(578, 433)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(25, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codido"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre (*)"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(71, 3)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(164, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtNombre, 3)
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(71, 29)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(504, 20)
        Me.txtNombre.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(3, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Telefono (*)"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(14, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Correo (*)"
        '
        'txtTelefono
        '
        Me.txtTelefono.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtTelefono, 3)
        Me.txtTelefono.Enabled = False
        Me.txtTelefono.Location = New System.Drawing.Point(71, 55)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTelefono.Size = New System.Drawing.Size(504, 20)
        Me.txtTelefono.TabIndex = 5
        '
        'txtCorreo
        '
        Me.txtCorreo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtCorreo, 3)
        Me.txtCorreo.Enabled = False
        Me.txtCorreo.Location = New System.Drawing.Point(71, 81)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(504, 20)
        Me.txtCorreo.TabIndex = 7
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
        'frmCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 487)
        Me.Controls.Add(Me.mstpMenuMaestro)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmCliente"
        Me.Text = "Cliente"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.gbDatos.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.mstpMenuMaestro.ResumeLayout(False)
        Me.mstpMenuMaestro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents mstpMenuMaestro As System.Windows.Forms.MenuStrip
    Public WithEvents mstpItemNuevo As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemBuscar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemModificar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemGuardar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemEliminar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemCancelar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemSalir As System.Windows.Forms.ToolStripMenuItem
End Class
