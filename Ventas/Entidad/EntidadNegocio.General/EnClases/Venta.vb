Imports EntidadNegocio.General

Public Class Venta
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>19/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Private _id As Integer
    Private _cliente As Cliente
    Private _idCliente As Integer
    Private _fecha As Date
    Private _dTotal As Double
    Private _estatus As EnumEstatus.EstadoVenta
    Private _edicion As EnumEstatus.Edicion = EnumEstatus.Edicion.Nuevo
    Private _detalle As List(Of DetalleVenta)
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
    Public Property Cliente As Cliente
        Get
            Return _cliente
        End Get
        Set(ByVal value As Cliente)
            _cliente = value
        End Set
    End Property
    Public Property IdCliente As Integer
        Get
            Return _idCliente '_Cliente.Id
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property
    Public Property Fecha As Date
        Get
            Return _fecha.Date
        End Get
        Set(ByVal value As Date)
            _fecha = value.Date
        End Set
    End Property
    Public Property Total As Double
        Get
            Return _dTotal
        End Get
        Set(ByVal value As Double)
            _dTotal = value
        End Set
    End Property
    Public Property Estatus As EnumEstatus.EstadoVenta
        Get
            Return _estatus
        End Get
        Set(ByVal value As EnumEstatus.EstadoVenta)
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
    Public Property Detalle As List(Of DetalleVenta)
        Get
            Return _detalle
        End Get
        Set(ByVal value As List(Of DetalleVenta))
            _detalle = value
        End Set
    End Property
#End Region

End Class
