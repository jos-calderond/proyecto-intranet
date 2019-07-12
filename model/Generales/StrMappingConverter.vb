''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class StrMappingConverter
  Public __dictionary As List(Of String)

  Public Sub New()
    Me.__dictionary = New List(Of String)
    Me.__dictionary.Add("á='")
    Me.__dictionary.Add("Á=µ")
    Me.__dictionary.Add("Á=�")
    Me.__dictionary.Add("é=^")
    Me.__dictionary.Add("É=»")
    Me.__dictionary.Add("í=`")
    Me.__dictionary.Add("Í=¿")
    Me.__dictionary.Add("ó=~")
    Me.__dictionary.Add("Ó=ø")
    Me.__dictionary.Add("ú={")
    Me.__dictionary.Add("Ú=þ")
    Me.__dictionary.Add("Á=Ñ")
    Me.__dictionary.Add("É=Å")
    Me.__dictionary.Add("Í=Ó")
    Me.__dictionary.Add("Ó=º")
    Me.__dictionary.Add("Ú=È")
    Me.__dictionary.Add("Ñ=\")
    Me.__dictionary.Add("ñ=ã")

  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="value"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function fromMappingToString(ByVal value As String) As String
    Dim newValue As String = value

    For Each character As String In Me.__dictionary
      newValue = newValue.Replace(character.Split("=")(1), character.Split("=")(0))
    Next

    Return newValue
  End Function
End Class
