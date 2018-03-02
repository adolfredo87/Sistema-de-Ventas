Imports System.Windows.Forms

Public Class frmCatalogo

#Region "Atributos"
    Private Shared _ValorBuscar As Object = Nothing
    Private _precargado As Boolean = False
    Private _multiSelect As Boolean = False
    Private _filaSeleccionada As Integer = -1
#End Region

#Region "Variables Globales"
    Dim _Columnas() As DataGridViewColumn
#End Region

#Region "Eventos"
    Event BuscarDato(ByVal valor As Object, ByRef binding As Object, ByVal columnaBuscada As Integer)
#End Region

#Region "Propiedades"
    Public WriteOnly Property Columnas() As DataGridViewColumn()
        Set(ByVal value As DataGridViewColumn())
            _Columnas = value
        End Set
    End Property
    Shared ReadOnly Property ValorBuscar() As Object
        Get
            Return _ValorBuscar
        End Get
    End Property
    Public WriteOnly Property SeleccionMultiple() As Boolean
        Set(ByVal value As Boolean)
            Me.dgvBuscar.MultiSelect = value
            _multiSelect = value
        End Set
    End Property
    Public WriteOnly Property MarcarTodo() As Boolean
        Set(ByVal value As Boolean)
            Me.btnMarTodo.Visible = value
        End Set
    End Property
    Public WriteOnly Property EliTodo() As Boolean
        Set(ByVal value As Boolean)
            Me.btnEliTodo.Visible = value
        End Set
    End Property
    Public Property Precargado() As Boolean
        Get
            Return _precargado
        End Get
        Set(ByVal value As Boolean)
            _precargado = value
        End Set
    End Property
    Public ReadOnly Property ListaElementosConsultados() As Object
        Get
            Return Me.dgvBuscar.DataSource
        End Get
    End Property
    Public ReadOnly Property TextoBuscar() As String
        Get
            Return txtBuscar.Text.ToString()
        End Get
    End Property
    Public ReadOnly Property ColumnaBuscada() As String
        Get
            Return Me.cboBuscarPor.SelectedIndex
        End Get
    End Property
    Public Property FilaSeleccionada() As Integer
        Get
            Return _filaSeleccionada
        End Get
        Set(ByVal value As Integer)
            _filaSeleccionada = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _ValorBuscar = Nothing
        Me.txtBuscar.Focus()
    End Sub
#End Region

#Region "Metodos Publicos"
    Public Sub AsignarValorBuscar(ByVal valor As Object)
        Me.txtBuscar.Text = valor
    End Sub
    Public Sub EstablecerColumnas()
        If Not _precargado Then
            Me.cboBuscarPor.Items.Clear()
        End If
        dgvBuscar.Columns.Clear()

        For Each col As DataGridViewColumn In _Columnas
            Dim parametro As String = ""
            Me.dgvBuscar.Columns.Add(col)
            If Not col.Tag Is Nothing Then
                parametro = col.Tag
            End If
            If parametro.Contains("/Buscar = S") Then
                Me.cboBuscarPor.Items.Add(col.HeaderText)
            End If
        Next
        If cboBuscarPor.Items.Count > 0 Then
            cboBuscarPor.DropDownStyle = ComboBoxStyle.DropDownList
            cboBuscarPor.SelectedIndex = 0
        End If
    End Sub
    Public Sub ProcesarTecla(ByVal sender As Object, ByVal tecla As Keys)
        Dim e As New System.Windows.Forms.KeyEventArgs(tecla)
        txtBuscar.Focus()
        txtBuscar_KeyDown(sender, e)
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub SeleccionarFila(ByVal fila As Integer)
        If dgvBuscar.RowCount > 0 Then
            dgvBuscar.Focus()
            dgvBuscar.CurrentCell = dgvBuscar.Rows(fila).Cells(0)
        End If
    End Sub
#Region "Metodos Protegidos"
    Protected Sub Aceptar()
        If Me.dgvBuscar.SelectedRows.Count = 0 Then
            _ValorBuscar = String.Empty
        ElseIf Me.dgvBuscar.SelectedRows.Count = 1 Then
            _ValorBuscar = Me.dgvBuscar.CurrentRow.DataBoundItem
        Else
            Dim Lista As New List(Of Object)
            Dim Filas As Integer = Me.dgvBuscar.SelectedRows.Count - 1
            For i As Integer = 0 To Filas
                Lista.Add(Me.dgvBuscar.SelectedRows.Item(i).DataBoundItem)
            Next
            _ValorBuscar = Lista
        End If
        Me.Close()
    End Sub
#End Region
#End Region

#Region "Metodos Protegidos que tienen Handler"
    Protected Sub cboBuscarPor_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBuscarPor.SelectedValueChanged
        If Not Precargado Then
            txtBuscar.Text = ""
        End If
        txtBuscar.Focus()
    End Sub
    Protected Sub dgvBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvBuscar.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Me.dgvBuscar.RowCount = 1 Then
                    Me.dgvBuscar.CurrentCell = Me.dgvBuscar(Me.dgvBuscar.CurrentCell.ColumnIndex, Me.dgvBuscar.CurrentCell.RowIndex)
                    Aceptar()
                Else
                    Me.dgvBuscar.CurrentCell = Me.dgvBuscar(Me.dgvBuscar.CurrentCell.ColumnIndex, Me.dgvBuscar.CurrentCell.RowIndex - 1)
                    Aceptar()
                End If
            End If
        Catch
        End Try
    End Sub
    Protected Sub frmCatalogo_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Not Precargado Then
            Me.txtBuscar.Focus()
        Else
            Me.dgvBuscar.Focus()
        End If
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()
    End Sub
    Private Sub frmCatalogo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
    Protected Sub frmCatalogo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _ValorBuscar = Nothing
        EstablecerColumnas()
        If Precargado Then
            Me.dgvBuscar.Focus()
            If dgvBuscar.RowCount > 0 Then
                Me.txtBuscar.TabIndex = Me.dgvBuscar.TabIndex
                Me.dgvBuscar.TabIndex = 0
            End If
            If FilaSeleccionada >= 0 Then
                For i As Integer = 0 To dgvBuscar.RowCount - 2
                    Me.ProcesarTecla(Me, Keys.Down)
                Next
                For i As Integer = 0 To dgvBuscar.RowCount - FilaSeleccionada - 3
                    Me.ProcesarTecla(Me, Keys.Up)
                Next
            End If
            Buscar()
            Me.dgvBuscar.Focus()
        Else
            Me.dgvBuscar.DataSource = Nothing
            Me.txtBuscar.Focus()
        End If
    End Sub
    Private Sub Buscar()
        Dim lista As Object = Nothing
        RaiseEvent BuscarDato(txtBuscar.Text.ToUpper(), lista, Me.cboBuscarPor.SelectedIndex())
        Me.dgvBuscar.AutoGenerateColumns = False
        Me.dgvBuscar.DataSource = lista
        If dgvBuscar.RowCount > 0 Then
            dgvBuscar.Focus()
            Me.dgvBuscar.CurrentCell = Me.dgvBuscar.Rows(0).Cells(0)
            Me.dgvBuscar.CurrentCell = Me.dgvBuscar(Me.dgvBuscar.CurrentCell.ColumnIndex, Me.dgvBuscar.CurrentCell.RowIndex)
        ElseIf Not _precargado Then
            MessageBox.Show("No hay resultados que concuerden con la búsqueda.", "Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBuscar.SelectAll()
            txtBuscar.Focus()
        End If
    End Sub
#End Region

#Region "Metodos Privados que tienen Handler"
    Private Sub btnMarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarTodo.Click
        dgvBuscar.MultiSelect = True
        Me.dgvBuscar.SelectAll()
        Me.txtBuscar.Focus()
    End Sub
    Private Sub btnEliTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliTodo.Click
        Me.dgvBuscar.ClearSelection()
        If dgvBuscar.RowCount > 0 Then
            Me.dgvBuscar.Focus()
            Me.dgvBuscar.CurrentCell = dgvBuscar.Rows(0).Cells(0)
            dgvBuscar.Rows(0).Cells(0).Selected = True
        End If
    End Sub
    Private Sub dgvBuscar_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvBuscar.DoubleClick
        Try
            If Me.dgvBuscar.CurrentRow.Index < 0 Then Exit Sub
            If Me.dgvBuscar.SelectedRows.Count = 1 Then
                _ValorBuscar = Me.dgvBuscar.CurrentRow.DataBoundItem
            Else
                Dim Lista As New List(Of Object)
                Dim Filas As Integer = Me.dgvBuscar.SelectedRows.Count - 1
                For i As Integer = 0 To Filas
                    Lista.Add(Me.dgvBuscar.SelectedRows.Item(i).DataBoundItem)
                Next
                _ValorBuscar = Lista
            End If

            Me.Close()
        Catch
        End Try
    End Sub
    Private Sub txtBuscar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyDown
        If (e.KeyData = Keys.Down) Then
            If dgvBuscar.RowCount > 0 Then
                dgvBuscar.Focus()
                If Not dgvBuscar.CurrentCell Is Nothing Then
                    If dgvBuscar.CurrentCell.RowIndex < dgvBuscar.RowCount - 1 Then
                        dgvBuscar.CurrentCell = dgvBuscar.Rows(dgvBuscar.CurrentCell.RowIndex + 1).Cells(0)
                    End If
                ElseIf dgvBuscar.RowCount > 0 Then
                    dgvBuscar.CurrentCell = dgvBuscar.Rows(0).Cells(0)
                End If
            End If
        ElseIf (e.KeyData = Keys.Up) Then
            If dgvBuscar.RowCount > 0 Then
                dgvBuscar.Focus()
                If dgvBuscar.CurrentCell.RowIndex > 0 Then
                    dgvBuscar.CurrentCell = dgvBuscar.Rows(dgvBuscar.CurrentCell.RowIndex - 1).Cells(0)
                End If
            End If
        ElseIf (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Return) Then
            e.SuppressKeyPress = False
            Buscar()
        End If
    End Sub
    Private Sub dgvBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBuscar.KeyDown
        Try
            If ((e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Return)) And (dgvBuscar.RowCount > 0) _
             And (Not ReferenceEquals(dgvBuscar.CurrentCell, Nothing)) Then
                e.SuppressKeyPress = True
                Aceptar()
            End If
        Catch
        End Try
    End Sub
    Private Sub dgvBuscar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBuscar.SelectionChanged
        If Not _multiSelect Then
            If (Not (dgvBuscar.SelectedRows.Count = dgvBuscar.Rows.Count)) And (Not dgvBuscar.SelectedRows.Count = 1) Then
                dgvBuscar.MultiSelect = False
            ElseIf (dgvBuscar.SelectedRows.Count = 1) Then
                Dim posiSeleccionado As Integer = dgvBuscar.SelectedRows(0).Index
                dgvBuscar.MultiSelect = False
                dgvBuscar.CurrentCell = dgvBuscar.Rows(posiSeleccionado).Cells(0)
                dgvBuscar.CurrentRow.Selected = True
            End If
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        Buscar()
    End Sub
#End Region

End Class