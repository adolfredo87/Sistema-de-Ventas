Public Class Estatus

#Region "Atributos"
    Private _id As Integer
    Private _descripcion As String
#End Region

#Region "Propiedades"
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
#End Region

End Class
