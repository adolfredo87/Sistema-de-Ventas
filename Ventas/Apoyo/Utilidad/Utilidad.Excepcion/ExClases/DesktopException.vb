Public Class DesktopException
   Inherits Exception

   Private strMessage As String
   Private strClase As String
   Private strMetodo As String
   Private strStackTrace As String

   Public Sub New(ByVal message As String)
      strMessage = message
   End Sub

   Public Sub New(ByVal clase As String, ByVal metodo As String, ByVal message As String, ByVal inner As Exception)
      MyBase.New(inner.Message, inner)
      strStackTrace = inner.StackTrace
      strMessage = message
      strClase = clase
      strMetodo = metodo
   End Sub

   Public Property Clase() As String
      Get
         Return strClase
      End Get
      Set(ByVal value As String)
         strClase = value
      End Set
   End Property

   Public Property Metodo() As String
      Get
         Return strMetodo
      End Get
      Set(ByVal value As String)
         strMetodo = value
      End Set
   End Property

   Public Overrides ReadOnly Property Message() As String
      Get
         Return strMessage
      End Get
   End Property

   Public Overrides ReadOnly Property StackTrace() As String
      Get
         Return strStackTrace
      End Get
    End Property

End Class
