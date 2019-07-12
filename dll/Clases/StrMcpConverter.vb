Friend Class StrMcpConverter
	Private caracteres As List(Of String)

	Friend Sub New()
		Me.caracteres = New List(Of String)
		Me.caracteres.Add("Ñ=\")
		Me.caracteres.Add("ñ=|")
		Me.caracteres.Add("á='")
		Me.caracteres.Add("Á=µ")
		Me.caracteres.Add("é=^")
		Me.caracteres.Add("É=»")
		Me.caracteres.Add("í=`")
		Me.caracteres.Add("Í=¿")
		Me.caracteres.Add("ó=~")
		Me.caracteres.Add("Ó=ø")
		Me.caracteres.Add("ú={")
		Me.caracteres.Add("Ú=þ")
	End Sub

	Friend Function toMcpString(ByVal str As String) As String
		Dim nuevoStr As String = str

		For Each caracter As String in Me.caracteres
			nuevoStr = nuevoStr.Replace(caracter.Split("=")(0), caracter.Split("=")(1))
		Next

		Return nuevoStr
	End Function

	Friend Function toRealString(ByVal str As String) As String
		Dim nuevoStr As String = str

		For Each caracter As String in Me.caracteres
			nuevoStr = nuevoStr.Replace(caracter.Split("=")(1), caracter.Split("=")(0))
		Next

		Return nuevoStr
	End Function
End Class
