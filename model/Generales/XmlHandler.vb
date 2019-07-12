''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class XmlHandler
  Public __dictionary As List(Of String)

  Public Sub New()
    Me.__dictionary = New List(Of String)
    Me.__dictionary.Add("&lt;=<")
    Me.__dictionary.Add("&gt;=>")
  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="value"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function translateInvalidCharacters(ByVal value As String) As String
    Dim newValue As String = value

    For Each character As String In Me.__dictionary
      newValue = newValue.Replace(character.Split("=")(1), character.Split("=")(0))
    Next

    Return newValue
  End Function

End Class
