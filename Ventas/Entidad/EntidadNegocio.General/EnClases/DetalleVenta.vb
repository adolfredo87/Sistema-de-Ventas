Imports EntidadNegocio.General

Public Class DetalleVenta
    ''' <summary></summary>
    ''' <autor>Adolfredo Belizario</autor>
    ''' <creacion>19/02/2018</creacion>
    ''' <modificacion></modificacion>

#Region "Atributos"
    Private _id As Integer
    Private _idVentaCab As Integer
    Private _producto As New Producto
    Private _idProducto As Integer
    Private _dPrecio As Double
    Private _iCantidad As Integer
    Private _dMonto As Double = _iCantidad * _dPrecio
    Private _estatus As EnumEstatus.Registro
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
    Public Property IdVentaCab As Integer
        Get
            Return _idVentaCab '_Deposito.Id
        End Get
        Set(ByVal value As Integer)
            _idVentaCab = value
        End Set
    End Property
    Public Property Producto As Producto
        Get
            Return _producto
        End Get
        Set(ByVal value As Producto)
            _producto = value
        End Set
    End Property
    Public Property IdProducto As Integer
        Get
            Return _idProducto ' _Producto.Id
        End Get
        Set(ByVal value As Integer)
            _idProducto = value
        End Set
    End Property
    Public Property Precio As Double
        Get
            Return _dPrecio
        End Get
        Set(ByVal value As Double)
            _dPrecio = value
        End Set
    End Property
    Public Property Cantidad As Integer
        Get
            Return _iCantidad
        End Get
        Set(ByVal value As Integer)
            _iCantidad = value
        End Set
    End Property
    Public Property Monto As Double
        Get
            Return _dMonto
        End Get
        Set(ByVal value As Double)
            _dMonto = value
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
