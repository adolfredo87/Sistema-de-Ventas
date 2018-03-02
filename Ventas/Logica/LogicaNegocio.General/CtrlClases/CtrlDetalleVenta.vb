Imports Dato.General
Imports EntidadNegocio.General

Public Class CtrlDetalleVenta
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>19/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Private _adDetalleVenta As New AdDetalleVenta
#End Region

#Region "Propieades"

#End Region

#Region "Metodos Privados"

#End Region

#Region "Metodos Publicos"
    Public Function VerDetVentaTotal(ByVal _valor1 As Integer) As DetalleVenta
        Try
            If IsNothing(_adDetalleVenta) Then _adDetalleVenta = New AdDetalleVenta
            Return _adDetalleVenta.VerDetVentaTotal(_valor1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function VerDetVentaMonto(ByVal _valor1 As Integer) As List(Of DetalleVenta)
        Try
            If IsNothing(_adDetalleVenta) Then _adDetalleVenta = New AdDetalleVenta
            Return _adDetalleVenta.VerDetVentaMonto(_valor1)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObtenerItems(ByVal _valor As Integer) As List(Of DetalleVenta)
        Try
            If IsNothing(_adDetalleVenta) Then _adDetalleVenta = New AdDetalleVenta
            Return _adDetalleVenta.ObtenerItems(_valor)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
