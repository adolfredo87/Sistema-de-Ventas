Imports LogicaNegocio.General
Imports EntidadNegocio.General
Imports System.Threading

Public Class FrmPlantilla

#Region "Atributos"
    Private _columnIndex As Integer = 0
    Private _grid As System.Windows.Forms.DataGridView
    Private _caracter As Presentacion.Plantilla.FrmPlantilla.TipoFormato
#End Region

#Region "Enumerado"
    Public Enum TipoFormato
        Numeros = 1
        Decimales = 2
        Letras = 3
        NumeroLetras = 4
    End Enum
#End Region

#Region "Metodos"
    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
#End Region

#Region "Metodos Utilitarios"
    Public Sub FormatoNumeroEntero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As TextBox)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Sub FormatoLetra(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As TextBox)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Sub FormatoNumeroLetra(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As TextBox)
        If Char.IsLetter(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Sub FormatoNumeroDecimal(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As TextBox)
        If e.KeyChar = Chr(Keys.Back) Then
            e.Handled = False
            Exit Sub
        End If
        ' se verifica si es un digito o un punto 
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        ' se verifica que el primer digito ingresado no sea un punto al seleccionar
        If Text.SelectedText <> "" Then
            If e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator Then
                e.Handled = True
            End If
        End If
        'aqui se hace la verificacion cuando es seleccionado el valor del texto
        'y no sea considerado como la adicion de un digito mas al valor ya contenido en el textbox
        If Text.SelectedText = "" Then
            ' aqui se hace el for para controlar que el numero sea de dos digitos - contadose a partir del punto decimal.
            Dim pos As Integer = InStr(Text.Text, Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator, CompareMethod.Text)
            If pos > 0 Then
                If e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator And pos > 0 Then
                    e.Handled = True
                End If
                If Text.SelectionStart + 1 > pos And pos + 2 = Text.Text.Length Then
                    e.Handled = True
                End If
            Else
                If Text.SelectionStart = 0 And e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator Then
                    e.Handled = True
                End If

            End If
        End If
    End Sub
    Public Sub FormatoFecha(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal text As TextBox)
        If e.KeyChar = Chr(8) Then Exit Sub
        Select Case Len(text.Text) + 1
            Case 1, 2, 4, 5, 7, 8, 9, 10
                If Not IsNumeric(e.KeyChar) Then
                    e.KeyChar = Nothing
                End If
            Case 3, 6
                If Not e.KeyChar = "/" Then
                    e.KeyChar = Nothing
                End If
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub
    Private Sub KeypessCeldaEnGrid(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If _columnIndex = _grid.CurrentCell.ColumnIndex Then
            Select Case _caracter
                Case TipoFormato.Numeros
                    FormatoNumeroEntero(e, CType(sender, TextBox))
                Case TipoFormato.Decimales
                    FormatoNumeroDecimal(e, CType(sender, TextBox))
                Case TipoFormato.Letras
                    FormatoLetra(e, CType(sender, TextBox))
                Case TipoFormato.NumeroLetras
                    FormatoNumeroLetra(e, CType(sender, TextBox))
            End Select
        End If
    End Sub
    Public Sub FormatoCeldaGrid(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs, _
                             ByVal columnIndex As Integer, ByVal caracter As Presentacion.Plantilla.FrmPlantilla.TipoFormato)
        Try
            If sender.GetType.Name = "DataGridView" Then
                _grid = DirectCast(sender, DataGridView)
                _columnIndex = columnIndex
                _caracter = caracter
                Dim validar As TextBox = CType(e.Control, TextBox)
                AddHandler validar.KeyPress, AddressOf KeypessCeldaEnGrid
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub HabilitarControl(ByRef _control As System.Windows.Forms.Control, ByVal recursivo As Boolean)
        For Each _c As System.Windows.Forms.Control In _control.Controls
            _c.Enabled = True
            If _c.Controls.Count > 0 And recursivo Then
                HabilitarControl(_c, recursivo)
            End If
        Next
    End Sub
    Public Sub HabilitarControles(ByRef _control As System.Windows.Forms.Control, Optional ByVal recursivo As Boolean = True)
        HabilitarControl(_control, recursivo)
    End Sub
    Private Sub DesHabilitarControl(ByRef _control As System.Windows.Forms.Control, ByVal recursivo As Boolean)
        For Each _c As System.Windows.Forms.Control In _control.Controls
            _c.Enabled = False
            If _c.Controls.Count > 0 And recursivo Then
                DesHabilitarControl(_c, recursivo)
            End If
        Next
    End Sub
    Public Sub DesHabilitarControles(ByRef _control As System.Windows.Forms.Control, Optional ByVal recursivo As Boolean = True)
        DesHabilitarControl(_control, recursivo)
    End Sub
    Private Sub LimpiarControl(ByRef _control As System.Windows.Forms.Control)
        Try
            If _control.GetType.Name = "TextBox" Then
                _control.Text = String.Empty
            End If
            If _control.GetType.Name = "ComboBox" Then
                _control.Text = String.Empty
                CType(_control, ComboBox).SelectedItem = Nothing
            End If

            If _control.GetType.Name = "DataGridView" Then
                CType(_control, DataGridView).DataSource = Nothing
            End If

            If _control.GetType.Name = "NumericUpDown" Then
                CType(_control, NumericUpDown).Value = CType(_control, NumericUpDown).Minimum
            End If

            If _control.GetType.Name = "CheckBox" Then
                CType(_control, CheckBox).Checked = False
            End If

            For Each _c As System.Windows.Forms.Control In _control.Controls
                If _c.GetType.Name = "TextBox" Then
                    _c.Text = String.Empty
                End If
                If _c.GetType.Name = "ComboBox" Then
                    _c.Text = String.Empty
                    CType(_c, ComboBox).SelectedItem = Nothing
                End If

                If _c.GetType.Name = "DataGridView" Then
                    CType(_c, DataGridView).DataSource = Nothing
                End If

                If _c.GetType.Name = "NumericUpDown" Then
                    CType(_c, NumericUpDown).Value = CType(_c, NumericUpDown).Minimum
                End If

                If _c.Controls.Count > 0 Then
                    LimpiarControl(_c)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub LimpiarControles(ByRef _control As System.Windows.Forms.Control)
        LimpiarControl(_control)
    End Sub
    Public Function EnumToDictionary(ByVal _enumerado As Object) As Dictionary(Of String, Integer)
        Dim _dic As New Dictionary(Of String, Integer)
        Try
            For Each enumValue As Integer In [Enum].GetValues(_enumerado.GetType)
                _dic.Add([Enum].GetName(_enumerado.GetType, enumValue), enumValue)
            Next
        Catch ex As Exception

        End Try
        Return _dic
    End Function
    Public Function EnumToDictionary(ByVal _enumerado As Object, ByVal idColumnasInvisibles() As Integer) As Dictionary(Of String, Integer)
        Dim _dic As New Dictionary(Of String, Integer)
        Try
            For Each enumValue As Integer In [Enum].GetValues(_enumerado.GetType)
                If idColumnasInvisibles IsNot Nothing Then
                    If Not idColumnasInvisibles.Contains(enumValue) Then
                        _dic.Add([Enum].GetName(_enumerado.GetType, enumValue), enumValue)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
        Return _dic
    End Function
    Public Sub LoadEnumToComboBox(ByVal _enumerado As Object, ByRef combo As ComboBox)
        Try
            combo.DisplayMember = "Key"
            combo.ValueMember = "Value"
            combo.DataSource = New BindingSource(EnumToDictionary(_enumerado), Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadDiccionarioToComboBox(ByVal _diccionario As Dictionary(Of String, Integer), ByRef combo As ComboBox)
        Try
            combo.DisplayMember = "Key"
            combo.ValueMember = "Value"
            combo.DataSource = New BindingSource(_diccionario, Nothing)
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Class