Public Class Parametro

#Region "Atributos"
    Private _nombre As String
    Private _valor As Object
    Private _direccion As System.Data.ParameterDirection
    Private _tamaño As Integer
#End Region

#Region "Propiedades"
    Public Property Nombre As String
        Get
            Nombre = _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Public Property Valor As Object
        Get
            Valor = _valor
        End Get
        Set(ByVal value As Object)
            _valor = value
        End Set
    End Property
    Public Property Direccion As System.Data.ParameterDirection
        Get
            Return _direccion
        End Get
        Set(ByVal value As System.Data.ParameterDirection)
            _direccion = value
        End Set
    End Property
    Public Property Tamaño As Integer
        Get
            Tamaño = _tamaño
        End Get
        Set(ByVal value As Integer)
            _tamaño = value
        End Set
    End Property
#End Region

End Class
