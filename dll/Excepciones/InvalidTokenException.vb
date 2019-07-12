Public Class InvalidTokenException
  Inherits Exception
  Private msg As String

  Public Sub New(ByVal Message As String)
    Me.msg = Message
  End Sub

  Public Function getMessage() As String

    Logg.e("ISPEC=" & Me.TargetSite.ReflectedType.Name.ToString & ";EX.TYPE=InvalidTokenException;MENSAJE=" & msg)

    Return Me.msg
  End Function
End Class
