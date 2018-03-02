Imports EntidadNegocio.General

Public Class Cliente
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>18/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Private _codigo As Integer
    Private _nombre As String
    Private _telefono As String
    Private _correo As String
    Private _status As EnumEstatus.Registro
    Private _edicion As EnumEstatus.Edicion = EnumEstatus.Edicion.Normal
#End Region

#Region "Propiedades"
    Public Property Codigo As Integer
        Get
            Codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Nombre = _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Public Property Telefono As String
        Get
            Telefono = _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
    Public Property Correo As String
        Get
            Correo = _correo
        End Get
        Set(ByVal value As String)
            _correo = value
        End Set
    End Property
    Public Property Status As EnumEstatus.Registro
        Get
            Return _status
        End Get
        Set(ByVal value As EnumEstatus.Registro)
            _status = value
        End Set
    End Property
    Public Property Edicion As EnumEstatus.Edicion
        Get
            Return _edicion
        End Get
        Set(ByVal value As EnumEstatus.Edicion)
            _edicion = value
        End Set
    End Property
#End Region

End Class
