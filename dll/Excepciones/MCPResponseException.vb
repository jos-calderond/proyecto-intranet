Public Class MCPResponseException
	Inherits Exception
	Private statusLine As String
	Private messageList As String

	Public Sub New(ByVal StatusLine As String, ByVal MessageList As String)
		Me.statusLine = StatusLine
		Me.messageList = MessageList
	End Sub

  Public Function getMessage() As String

    Logg.e("ISPEC=" & Me.TargetSite.ReflectedType.Name.ToString & ";EX.TYPE=MCPResponseException;MENSAJE=" & Me.statusLine & " " & Me.messageList)

    Return "ERROR: " & Me.statusLine & " " & Me.messageList
  End Function
End Class
