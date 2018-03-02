Imports EntidadNegocio.General

Public Class Producto
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>18/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Private _id As Integer
    Private _nombre As String
    Private _precio As Double
    Private _tipoCategoria As EnumTipos.TipoCategoria = EnumTipos.TipoCategoria.Verduras
    Private _estatus As EnumEstatus.Registro = EnumEstatus.Registro.Activo
    Private _edicion As EnumEstatus.Edicion = EnumEstatus.Edicion.Normal
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
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Public Property Precio As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property
    Public Property TipoCategoria As EnumTipos.TipoCategoria
        Get
            Return _tipoCategoria
        End Get
        Set(ByVal value As EnumTipos.TipoCategoria)
            _tipoCategoria = value
        End Set
    End Property
    Public Property Estatus As EnumEstatus.Registro
        Get
            Return _estatus
        End Get
        Set(ByVal value As EnumEstatus.Registro)
            _estatus = value
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
