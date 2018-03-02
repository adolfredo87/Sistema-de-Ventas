<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProducto))
        Me.mstpGuardarCancelar = New System.Windows.Forms.MenuStrip()
        Me.mstpItemGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgProductos = New System.Windows.Forms.DataGridView()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategoria = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.mstpInsSupr = New System.Windows.Forms.MenuStrip()
        Me.mstpItemInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpItemSupr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mstpGuardarCancelar.SuspendLayout()
        CType(Me.dgProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mstpInsSupr.SuspendLayout()
        Me.SuspendLayout()
        '
        'mstpGuardarCancelar
        '
        Me.mstpGuardarCancelar.BackColor = System.Drawing.Color.Transparent
        Me.mstpGuardarCancelar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mstpItemGuardar, Me.mstpItemCancelar, Me.mstpItemSalir})
        Me.mstpGuardarCancelar.Location = New System.Drawing.Point(0, 0)
        Me.mstpGuardarCancelar.Name = "mstpGuardarCancelar"
        Me.mstpGuardarCancelar.Size = New System.Drawing.Size(601, 24)
        Me.mstpGuardarCancelar.TabIndex = 0
        Me.mstpGuardarCancelar.Text = "MenuStrip2"
        '
        'mstpItemGuardar
        '
        Me.mstpItemGuardar.Image = CType(resources.GetObject("mstpItemGuardar.Image"), System.Drawing.Image)
        Me.mstpItemGuardar.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemGuardar.Name = "mstpItemGuardar"
        Me.mstpItemGuardar.Size = New System.Drawing.Size(106, 20)
        Me.mstpItemGuardar.Text = "Guardar (F10)"
        '
        'mstpItemCancelar
        '
        Me.mstpItemCancelar.Image = CType(resources.GetObject("mstpItemCancelar.Image"), System.Drawing.Image)
        Me.mstpItemCancelar.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemCancelar.Name = "mstpItemCancelar"
        Me.mstpItemCancelar.Size = New System.Drawing.Size(110, 20)
        Me.mstpItemCancelar.Text = "Cancelar (F12)"
        '
        'mstpItemSalir
        '
        Me.mstpItemSalir.Image = CType(resources.GetObject("mstpItemSalir.Image"), System.Drawing.Image)
        Me.mstpItemSalir.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemSalir.Name = "mstpItemSalir"
        Me.mstpItemSalir.Size = New System.Drawing.Size(85, 20)
        Me.mstpItemSalir.Text = "Salir (Esc)"
        '
        'dgProductos
        '
        Me.dgProductos.AllowUserToAddRows = False
        Me.dgProductos.AllowUserToResizeRows = False
        Me.dgProductos.BackgroundColor = System.Drawing.Color.LightGray
        Me.dgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colNombre, Me.colPrecio, Me.colCategoria})
        Me.dgProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgProductos.Location = New System.Drawing.Point(0, 24)
        Me.dgProductos.Name = "dgProductos"
        Me.dgProductos.RowHeadersVisible = False
        Me.dgProductos.Size = New System.Drawing.Size(601, 463)
        Me.dgProductos.TabIndex = 1
        '
        'colCodigo
        '
        Me.colCodigo.DataPropertyName = "Id"
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.Visible = False
        Me.colCodigo.Width = 90
        '
        'colNombre
        '
        Me.colNombre.DataPropertyName = "Nombre"
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.Width = 250
        '
        'colPrecio
        '
        Me.colPrecio.DataPropertyName = "Precio"
        Me.colPrecio.HeaderText = "Precio"
        Me.colPrecio.Name = "colPrecio"
        '
        'colCategoria
        '
        Me.colCategoria.DataPropertyName = "TipoCategoria"
        Me.colCategoria.HeaderText = "TipoCategoria"
        Me.colCategoria.Name = "colCategoria"
        Me.colCategoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'mstpInsSupr
        '
        Me.mstpInsSupr.BackColor = System.Drawing.Color.Transparent
        Me.mstpInsSupr.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.mstpInsSupr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mstpItemInsert, Me.mstpItemSupr})
        Me.mstpInsSupr.Location = New System.Drawing.Point(0, 463)
        Me.mstpInsSupr.Name = "mstpInsSupr"
        Me.mstpInsSupr.Size = New System.Drawing.Size(601, 24)
        Me.mstpInsSupr.TabIndex = 2
        Me.mstpInsSupr.Text = "MenuStrip2"
        '
        'mstpItemInsert
        '
        Me.mstpItemInsert.Image = CType(resources.GetObject("mstpItemInsert.Image"), System.Drawing.Image)
        Me.mstpItemInsert.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemInsert.Name = "mstpItemInsert"
        Me.mstpItemInsert.Size = New System.Drawing.Size(72, 20)
        Me.mstpItemInsert.Text = "(Insert)"
        '
        'mstpItemSupr
        '
        Me.mstpItemSupr.Image = CType(resources.GetObject("mstpItemSupr.Image"), System.Drawing.Image)
        Me.mstpItemSupr.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.mstpItemSupr.Name = "mstpItemSupr"
        Me.mstpItemSupr.Size = New System.Drawing.Size(67, 20)
        Me.mstpItemSupr.Text = "(Supr)"
        '
        'frmProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 487)
        Me.Controls.Add(Me.mstpInsSupr)
        Me.Controls.Add(Me.dgProductos)
        Me.Controls.Add(Me.mstpGuardarCancelar)
        Me.Name = "frmProducto"
        Me.Text = "Producto"
        Me.mstpGuardarCancelar.ResumeLayout(False)
        Me.mstpGuardarCancelar.PerformLayout()
        CType(Me.dgProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mstpInsSupr.ResumeLayout(False)
        Me.mstpInsSupr.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mstpGuardarCancelar As System.Windows.Forms.MenuStrip
    Public WithEvents mstpItemGuardar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemCancelar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgProductos As System.Windows.Forms.DataGridView
    Friend WithEvents mstpInsSupr As System.Windows.Forms.MenuStrip
    Public WithEvents mstpItemInsert As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mstpItemSupr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategoria As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
