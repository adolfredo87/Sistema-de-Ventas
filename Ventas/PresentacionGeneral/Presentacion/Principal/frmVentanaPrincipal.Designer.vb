<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentanaPrincipal
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentanaPrincipal))
        Me.PanelBusqda = New System.Windows.Forms.Panel()
        Me.btnVerTodos = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.QBusqLabel = New System.Windows.Forms.Label()
        Me.BusqLabel = New System.Windows.Forms.Label()
        Me.TextBusqda = New System.Windows.Forms.TextBox()
        Me.ListBoxResultBusqueda = New System.Windows.Forms.ListBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.Refrescar_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Producto_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.Cliente_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ProcesarVenta_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.Salir_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ArchivoMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Producto_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cliente_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProcesarVenta_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Calculadora_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.TemasAyuda_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Acerca_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelBusqda.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBusqda
        '
        Me.PanelBusqda.BackgroundImage = CType(resources.GetObject("PanelBusqda.BackgroundImage"), System.Drawing.Image)
        Me.PanelBusqda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelBusqda.Controls.Add(Me.btnVerTodos)
        Me.PanelBusqda.Controls.Add(Me.btnBuscar)
        Me.PanelBusqda.Controls.Add(Me.QBusqLabel)
        Me.PanelBusqda.Controls.Add(Me.BusqLabel)
        Me.PanelBusqda.Controls.Add(Me.TextBusqda)
        Me.PanelBusqda.Controls.Add(Me.ListBoxResultBusqueda)
        Me.PanelBusqda.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelBusqda.Location = New System.Drawing.Point(0, 49)
        Me.PanelBusqda.Name = "PanelBusqda"
        Me.PanelBusqda.Size = New System.Drawing.Size(335, 581)
        Me.PanelBusqda.TabIndex = 7
        '
        'btnVerTodos
        '
        Me.btnVerTodos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVerTodos.BackgroundImage = CType(resources.GetObject("btnVerTodos.BackgroundImage"), System.Drawing.Image)
        Me.btnVerTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVerTodos.Location = New System.Drawing.Point(7, 101)
        Me.btnVerTodos.Name = "btnVerTodos"
        Me.btnVerTodos.Size = New System.Drawing.Size(319, 22)
        Me.btnVerTodos.TabIndex = 4
        Me.btnVerTodos.Text = "Ver Todos"
        Me.btnVerTodos.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.BackgroundImage = CType(resources.GetObject("btnBuscar.BackgroundImage"), System.Drawing.Image)
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscar.Location = New System.Drawing.Point(7, 73)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(319, 22)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'QBusqLabel
        '
        Me.QBusqLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QBusqLabel.BackColor = System.Drawing.Color.Transparent
        Me.QBusqLabel.Location = New System.Drawing.Point(4, 53)
        Me.QBusqLabel.Name = "QBusqLabel"
        Me.QBusqLabel.Size = New System.Drawing.Size(328, 17)
        Me.QBusqLabel.TabIndex = 2
        Me.QBusqLabel.Text = "Numero Venta"
        '
        'BusqLabel
        '
        Me.BusqLabel.AutoSize = True
        Me.BusqLabel.BackColor = System.Drawing.Color.Transparent
        Me.BusqLabel.Location = New System.Drawing.Point(4, 14)
        Me.BusqLabel.Name = "BusqLabel"
        Me.BusqLabel.Size = New System.Drawing.Size(121, 13)
        Me.BusqLabel.TabIndex = 0
        Me.BusqLabel.Text = "Buscar Ventas Cerradas"
        '
        'TextBusqda
        '
        Me.TextBusqda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBusqda.Location = New System.Drawing.Point(7, 30)
        Me.TextBusqda.Name = "TextBusqda"
        Me.TextBusqda.Size = New System.Drawing.Size(319, 20)
        Me.TextBusqda.TabIndex = 1
        '
        'ListBoxResultBusqueda
        '
        Me.ListBoxResultBusqueda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxResultBusqueda.FormattingEnabled = True
        Me.ListBoxResultBusqueda.Location = New System.Drawing.Point(0, 135)
        Me.ListBoxResultBusqueda.Name = "ListBoxResultBusqueda"
        Me.ListBoxResultBusqueda.Size = New System.Drawing.Size(335, 433)
        Me.ListBoxResultBusqueda.TabIndex = 5
        '
        'ToolStrip
        '
        Me.ToolStrip.BackgroundImage = CType(resources.GetObject("ToolStrip.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Refrescar_ToolStripButton, Me.ToolStripSeparator1, Me.Producto_ToolStripButton, Me.Cliente_ToolStripButton, Me.ProcesarVenta_ToolStripButton, Me.ToolStripSeparator2, Me.HelpToolStripButton, Me.ToolStripSeparator7, Me.Salir_ToolStripButton})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(942, 25)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'Refrescar_ToolStripButton
        '
        Me.Refrescar_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refrescar_ToolStripButton.Image = CType(resources.GetObject("Refrescar_ToolStripButton.Image"), System.Drawing.Image)
        Me.Refrescar_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Refrescar_ToolStripButton.Name = "Refrescar_ToolStripButton"
        Me.Refrescar_ToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.Refrescar_ToolStripButton.Text = "Refrescar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Producto_ToolStripButton
        '
        Me.Producto_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Producto_ToolStripButton.Image = Global.Presentacion.My.Resources.Resources.box
        Me.Producto_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.Producto_ToolStripButton.Name = "Producto_ToolStripButton"
        Me.Producto_ToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.Producto_ToolStripButton.Text = "Producto"
        '
        'Cliente_ToolStripButton
        '
        Me.Cliente_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cliente_ToolStripButton.Image = Global.Presentacion.My.Resources.Resources.customer
        Me.Cliente_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.Cliente_ToolStripButton.Name = "Cliente_ToolStripButton"
        Me.Cliente_ToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.Cliente_ToolStripButton.Text = "Cliente"
        '
        'ProcesarVenta_ToolStripButton
        '
        Me.ProcesarVenta_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProcesarVenta_ToolStripButton.Image = CType(resources.GetObject("ProcesarVenta_ToolStripButton.Image"), System.Drawing.Image)
        Me.ProcesarVenta_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.ProcesarVenta_ToolStripButton.Name = "ProcesarVenta_ToolStripButton"
        Me.ProcesarVenta_ToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ProcesarVenta_ToolStripButton.Text = "Procesar Venta"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "Temas de Ayuda"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'Salir_ToolStripButton
        '
        Me.Salir_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Salir_ToolStripButton.Image = CType(resources.GetObject("Salir_ToolStripButton.Image"), System.Drawing.Image)
        Me.Salir_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Salir_ToolStripButton.Name = "Salir_ToolStripButton"
        Me.Salir_ToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.Salir_ToolStripButton.Text = "Salir"
        '
        'MenuStrip
        '
        Me.MenuStrip.BackgroundImage = CType(resources.GetObject("MenuStrip.BackgroundImage"), System.Drawing.Image)
        Me.MenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoMenu, Me.HerramientasMenu, Me.AyudaMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(942, 24)
        Me.MenuStrip.TabIndex = 2
        Me.MenuStrip.Text = "MenuStrip"
        '
        'ArchivoMenu
        '
        Me.ArchivoMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Producto_ToolStripMenuItem, Me.Cliente_ToolStripMenuItem, Me.MenuStripSeparator1, Me.ProcesarVenta_ToolStripMenuItem, Me.MenuStripSeparator3, Me.ExitToolStripMenuItem})
        Me.ArchivoMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.ArchivoMenu.Name = "ArchivoMenu"
        Me.ArchivoMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ArchivoMenu.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoMenu.Text = "&Archivo"
        '
        'Producto_ToolStripMenuItem
        '
        Me.Producto_ToolStripMenuItem.Image = Global.Presentacion.My.Resources.Resources.box
        Me.Producto_ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.Producto_ToolStripMenuItem.Name = "Producto_ToolStripMenuItem"
        Me.Producto_ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.Producto_ToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.Producto_ToolStripMenuItem.Text = "&Producto"
        '
        'Cliente_ToolStripMenuItem
        '
        Me.Cliente_ToolStripMenuItem.Image = Global.Presentacion.My.Resources.Resources.customer
        Me.Cliente_ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.Cliente_ToolStripMenuItem.Name = "Cliente_ToolStripMenuItem"
        Me.Cliente_ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.Cliente_ToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.Cliente_ToolStripMenuItem.Text = "&Cliente"
        '
        'MenuStripSeparator1
        '
        Me.MenuStripSeparator1.Name = "MenuStripSeparator1"
        Me.MenuStripSeparator1.Size = New System.Drawing.Size(186, 6)
        '
        'ProcesarVenta_ToolStripMenuItem
        '
        Me.ProcesarVenta_ToolStripMenuItem.Image = CType(resources.GetObject("ProcesarVenta_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProcesarVenta_ToolStripMenuItem.Name = "ProcesarVenta_ToolStripMenuItem"
        Me.ProcesarVenta_ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.ProcesarVenta_ToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ProcesarVenta_ToolStripMenuItem.Text = "Procesar &Venta"
        '
        'MenuStripSeparator3
        '
        Me.MenuStripSeparator3.Name = "MenuStripSeparator3"
        Me.MenuStripSeparator3.Size = New System.Drawing.Size(186, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ExitToolStripMenuItem.Text = "&Salir"
        '
        'HerramientasMenu
        '
        Me.HerramientasMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Calculadora_ToolStripMenuItem})
        Me.HerramientasMenu.Name = "HerramientasMenu"
        Me.HerramientasMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HerramientasMenu.Size = New System.Drawing.Size(90, 20)
        Me.HerramientasMenu.Text = "&Herramientas"
        '
        'Calculadora_ToolStripMenuItem
        '
        Me.Calculadora_ToolStripMenuItem.Image = CType(resources.GetObject("Calculadora_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Calculadora_ToolStripMenuItem.Name = "Calculadora_ToolStripMenuItem"
        Me.Calculadora_ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.Calculadora_ToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.Calculadora_ToolStripMenuItem.Text = "Calculadora"
        '
        'AyudaMenu
        '
        Me.AyudaMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TemasAyuda_ToolStripMenuItem, Me.MenuStripSeparator8, Me.Acerca_ToolStripMenuItem})
        Me.AyudaMenu.Name = "AyudaMenu"
        Me.AyudaMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.AyudaMenu.Size = New System.Drawing.Size(53, 20)
        Me.AyudaMenu.Text = "A&yuda"
        '
        'TemasAyuda_ToolStripMenuItem
        '
        Me.TemasAyuda_ToolStripMenuItem.Image = CType(resources.GetObject("TemasAyuda_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TemasAyuda_ToolStripMenuItem.Name = "TemasAyuda_ToolStripMenuItem"
        Me.TemasAyuda_ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.TemasAyuda_ToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TemasAyuda_ToolStripMenuItem.Text = "&Temas de Ayuda"
        '
        'MenuStripSeparator8
        '
        Me.MenuStripSeparator8.Name = "MenuStripSeparator8"
        Me.MenuStripSeparator8.Size = New System.Drawing.Size(178, 6)
        '
        'Acerca_ToolStripMenuItem
        '
        Me.Acerca_ToolStripMenuItem.Image = CType(resources.GetObject("Acerca_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Acerca_ToolStripMenuItem.Name = "Acerca_ToolStripMenuItem"
        Me.Acerca_ToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.Acerca_ToolStripMenuItem.Text = "&Acerca de ..."
        '
        'frmVentanaPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.Presentacion.My.Resources.Resources.msnmessenger_fond_Black_Sale
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(942, 630)
        Me.Controls.Add(Me.PanelBusqda)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmVentanaPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistemas de Ventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelBusqda.ResumeLayout(False)
        Me.PanelBusqda.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Producto_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cliente_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ProcesarVenta_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HerramientasMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Calculadora_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TemasAyuda_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Acerca_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents Refrescar_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Producto_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cliente_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProcesarVenta_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Salir_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelBusqda As System.Windows.Forms.Panel
    Friend WithEvents btnVerTodos As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents QBusqLabel As System.Windows.Forms.Label
    Friend WithEvents BusqLabel As System.Windows.Forms.Label
    Friend WithEvents TextBusqda As System.Windows.Forms.TextBox
    Friend WithEvents ListBoxResultBusqueda As System.Windows.Forms.ListBox
End Class
