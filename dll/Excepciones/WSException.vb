Public Class WSException
  Inherits Exception
  Private __Message As String

  Public Sub New(ByVal Message As String, ByVal Ispec As String)
    Me.__Message = Message

    Logg.e("ISPEC=" & Ispec & ";EX.TYPE=WSException;MENSAJE=" & Message)

  End Sub

  Public Overrides ReadOnly Property Message() As String
    Get
      Return Me.__Message

    End Get

  End Property

End Class
