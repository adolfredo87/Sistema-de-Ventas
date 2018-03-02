Imports Presentacion.Plantilla
Imports System.Xml
Imports System.Windows.Forms
Imports System.Reflection
Imports EntidadNegocio.General
Imports System.ServiceProcess
Imports LogicaNegocio.General

Public Class frmVentanaPrincipal

    Private _ctrlVenta As New LogicaNegocio.General.CtrlVenta
    Private _Clientes As New List(Of Cliente)
    Private _ctrlCliente As New CtrlCliente
    Private _Productos As New List(Of Producto)
    Private _ctrlProducto As New CtrlProducto

    Private Sub CargarClientes()
        Try
            _Clientes = _ctrlCliente.ObtenerItems
        Catch ex As Exception
            MessageBox.Show(Mensajes.Info_ErrorAlCargar, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarProductos()
        Try
            _Productos = _ctrlProducto.ObtenerItems
            
        Catch ex As Exception
            MessageBox.Show(Mensajes.Info_ErrorAlCargar, Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function FormularioEstaCargado(ByVal NombreFormulario As String) As Boolean
        Dim respuesta As Boolean = False
        For i As Integer = 0 To Me.MdiChildren.Length - 1
            If Me.MdiChildren(i).GetType.UnderlyingSystemType.FullName = NombreFormulario Then
                Me.MdiChildren(i).BringToFront()
                respuesta = True
                Exit For
            End If
        Next
        Return respuesta
    End Function

    Private Sub frmVentanaPrincipal_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim nombre = Me.MdiChildren(0).Name
            MessageBox.Show("Debe Cerrar Todas las Ventanas.!", "Salir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        Catch ex As Exception
            If MessageBox.Show("Desea Salir del Sistema.?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End Try
    End Sub

    Private Sub frmVentanaPrincipal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            ListBoxResultBusqueda.DataSource = Nothing
            ListBoxResultBusqueda.Items.Clear()
            If String.IsNullOrEmpty(TextBusqda.Text) Then
                System.Windows.Forms.MessageBox.Show("Escriba los Criterios de Busqueda o Pulse Ver Todos", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim lectura As List(Of String) = _ctrlVenta.BusquedaVentasCerradas(Me.TextBusqda.Text).ToList()
                ListBoxResultBusqueda.DataSource = lectura.ToList()
                If ListBoxResultBusqueda.Items.Count = 0 Then
                    System.Windows.Forms.MessageBox.Show("No se encontraron coincidencias", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If
                TextBusqda.Text = ""
            End If
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("ERROR de Excepcion: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBusqda.Focus()
        End Try
    End Sub

    Private Sub btnVerTodos_Click(sender As System.Object, e As System.EventArgs) Handles btnVerTodos.Click
        Try
            TextBusqda.Text = ""
            ListBoxResultBusqueda.DataSource = Nothing
            ListBoxResultBusqueda.Items.Clear()
            Dim lectura As List(Of String) = _ctrlVenta.BusquedaVentasCerradas("-1").ToList()
            ListBoxResultBusqueda.DataSource = lectura.ToList()
            If ListBoxResultBusqueda.Items.Count = 0 Then
                System.Windows.Forms.MessageBox.Show("No se encontraron coincidencias", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            TextBusqda.Text = ""
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("ERROR de Excepcion: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextBusqda.Focus()
        End Try
    End Sub

    Private Sub Producto_ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Producto_ToolStripMenuItem.Click
        Try
            If Not FormularioEstaCargado("Presentacion.Maestros.frmProducto") Then
                Dim frmMdiParent As New frmProducto
                frmMdiParent.MdiParent = Me
                frmMdiParent.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cliente_ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Cliente_ToolStripMenuItem.Click
        Try
            If Not FormularioEstaCargado("Presentacion.Maestros.frmCliente") Then
                Dim frmMdiParent As New frmCliente
                frmMdiParent.MdiParent = Me
                frmMdiParent.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProcesarVenta_ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProcesarVenta_ToolStripMenuItem.Click
        Try
            CargarClientes()
            If _Clientes.Count = 0 Then
                MessageBox.Show("No se puede Hacer ventas mientras que no existan clientes.", Mensajes.Titulo_Mostrar, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                CargarProductos()
                If _Productos.Count = 0 Then
                    MessageBox.Show("No se puede Hacer ventas mientras que no existan productos.", Mensajes.Titulo_Mostrar, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If Not FormularioEstaCargado("Presentacion.Operaciones.frmVentas") Then
                        Dim frmMdiParent As New frmVentas
                        frmMdiParent.MdiParent = Me
                        frmMdiParent.Show()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Refrescar_ToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles Refrescar_ToolStripButton.Click
        ListBoxResultBusqueda.DataSource = Nothing
        ListBoxResultBusqueda.Items.Clear()
        TextBusqda.Text = ""
        Presentacion.OpcionMenu._cod = ""
        Presentacion.OpcionMenu._str = ""
    End Sub

    Private Sub Salir_ToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles Salir_ToolStripButton.Click
        Me.Close()
    End Sub

    Private Sub Producto_ToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles Producto_ToolStripButton.Click
        Try
            If Not FormularioEstaCargado("Presentacion.Maestros.frmProducto") Then
                Dim frmMdiParent As New frmProducto
                frmMdiParent.MdiParent = Me
                frmMdiParent.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cliente_ToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles Cliente_ToolStripButton.Click
        Try
            If Not FormularioEstaCargado("Presentacion.Maestros.frmCliente") Then
                Dim frmMdiParent As New frmCliente
                frmMdiParent.MdiParent = Me
                frmMdiParent.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProcesarVenta_ToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ProcesarVenta_ToolStripButton.Click
        Try
            CargarClientes()
            If _Clientes.Count = 0 Then
                MessageBox.Show("No se puede Hacer ventas mientras que no existan clientes.", Mensajes.Titulo_Mostrar, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                CargarProductos()
                If _Productos.Count = 0 Then
                    MessageBox.Show("No se puede Hacer ventas mientras que no existan productos.", Mensajes.Titulo_Mostrar, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If Not FormularioEstaCargado("Presentacion.Operaciones.frmVentas") Then
                        Dim frmMdiParent As New frmVentas
                        frmMdiParent.MdiParent = Me
                        frmMdiParent.Show()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Calculadora_ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Calculadora_ToolStripMenuItem.Click
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "calc.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Private Sub Acerca_ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Acerca_ToolStripMenuItem.Click

    End Sub

    Private Sub ListBoxResultBusqueda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBoxResultBusqueda.SelectedIndexChanged
        Dim _with1 = ListBoxResultBusqueda
        Try
            Presentacion.OpcionMenu._cod = ""
            Presentacion.OpcionMenu._str = ""
            Dim DatosCompleto As String = _with1.GetItemText(_with1.SelectedItem)
            If (Not String.IsNullOrEmpty(DatosCompleto)) Then
                Dim delimiterChars As Char() = {","}
                Dim Cadena As String() = DatosCompleto.Split(delimiterChars)
                Presentacion.OpcionMenu._cod = Convert.ToString(Cadena(3).ToString())
                Presentacion.OpcionMenu._cod = Presentacion.OpcionMenu._cod.Trim().ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class