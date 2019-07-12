Imports Microsoft.VisualBasic
Imports System.Web.Script.Serialization

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class ErrorHandler

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="ex"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Shared Function ErrorAsJson(ByVal ex As Exception) As String
    Dim dic As New Dictionary(Of String, Exception)
    Dim js As New JavaScriptSerializer

    Dim exMessage As String = ex.Message

    dic.Add("ERROR", New Exception(exMessage))

    Return js.Serialize(dic)

  End Function

End Class
