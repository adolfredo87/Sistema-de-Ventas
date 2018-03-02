<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogo))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboBuscarPor = New System.Windows.Forms.ComboBox()
        Me.dgvBuscar = New System.Windows.Forms.DataGridView()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnEliTodo = New System.Windows.Forms.Button()
        Me.btnMarTodo = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBuscar, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboBuscarPor, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvBuscar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelar, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAceptar, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEliTodo, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnMarTodo, 3, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.4555!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.544503!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(568, 336)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(3, 284)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtBuscar, 3)
        Me.txtBuscar.Location = New System.Drawing.Point(49, 284)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(193, 20)
        Me.txtBuscar.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(291, 284)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Buscar por"
        '
        'cboBuscarPor
        '
        Me.cboBuscarPor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboBuscarPor, 2)
        Me.cboBuscarPor.FormattingEnabled = True
        Me.cboBuscarPor.Location = New System.Drawing.Point(355, 284)
        Me.cboBuscarPor.Name = "cboBuscarPor"
        Me.cboBuscarPor.Size = New System.Drawing.Size(210, 21)
        Me.cboBuscarPor.TabIndex = 2
        '
        'dgvBuscar
        '
        Me.dgvBuscar.AllowUserToAddRows = False
        Me.dgvBuscar.AllowUserToDeleteRows = False
        Me.dgvBuscar.AllowUserToResizeRows = False
        Me.dgvBuscar.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvBuscar, 7)
        Me.dgvBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBuscar.Location = New System.Drawing.Point(3, 3)
        Me.dgvBuscar.MultiSelect = False
        Me.dgvBuscar.Name = "dgvBuscar"
        Me.dgvBuscar.RowHeadersVisible = False
        Me.dgvBuscar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBuscar.Size = New System.Drawing.Size(562, 275)
        Me.dgvBuscar.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(462, 306)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(103, 24)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(355, 306)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(101, 24)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnEliTodo
        '
        Me.btnEliTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliTodo.BackColor = System.Drawing.Color.Transparent
        Me.btnEliTodo.Image = CType(resources.GetObject("btnEliTodo.Image"), System.Drawing.Image)
        Me.btnEliTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliTodo.Location = New System.Drawing.Point(248, 306)
        Me.btnEliTodo.Name = "btnEliTodo"
        Me.btnEliTodo.Size = New System.Drawing.Size(101, 24)
        Me.btnEliTodo.TabIndex = 6
        Me.btnEliTodo.Text = "Eliminar Todos"
        Me.btnEliTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliTodo.UseVisualStyleBackColor = False
        Me.btnEliTodo.Visible = False
        '
        'btnMarTodo
        '
        Me.btnMarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarTodo.BackColor = System.Drawing.Color.Transparent
        Me.btnMarTodo.Image = CType(resources.GetObject("btnMarTodo.Image"), System.Drawing.Image)
        Me.btnMarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMarTodo.Location = New System.Drawing.Point(141, 306)
        Me.btnMarTodo.Name = "btnMarTodo"
        Me.btnMarTodo.Size = New System.Drawing.Size(101, 24)
        Me.btnMarTodo.TabIndex = 5
        Me.btnMarTodo.Text = "Marcar Todos"
        Me.btnMarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMarTodo.UseVisualStyleBackColor = False
        Me.btnMarTodo.Visible = False
        '
        'frmCatalogo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 336)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmCatalogo"
        Me.Text = "frmCatalogo"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboBuscarPor As System.Windows.Forms.ComboBox
    Friend WithEvents dgvBuscar As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnEliTodo As System.Windows.Forms.Button
    Friend WithEvents btnMarTodo As System.Windows.Forms.Button
End Class
