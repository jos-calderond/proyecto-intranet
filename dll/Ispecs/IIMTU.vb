Imports System.Web.Script.Serialization

Public Class IIMTU
  Public PRIORIDAD As Integer = 0
  Public EMAIL As String = ""
  Public CODUSU As String = ""
  Public OPCION As String = ""
  Public MANT As String = ""
  Public PASSMAIL As String = ""
  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, Object)
  Public WebService As New WS.WebService

  Sub New()
  End Sub

  Public Function CallIspec() As IIMTU
    Dim ISPEC As String = WebService.IIMTU(PRIORIDAD, EMAIL, CODUSU, OPCION, MANT, PASSMAIL)
    Dim IIMTU As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)
    __dic = TryCast(IIMTU, Dictionary(Of String, Object))
    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "IIMTU")
      End If
    End If
    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If
    Me.PRIORIDAD = IIMTU("PRIORIDAD")
    Me.EMAIL = IIMTU("EMAIL")
    Me.CODUSU = IIMTU("CODUSU")
    Me.OPCION = IIMTU("OPCION")
    Me.MANT = IIMTU("MANT")
    Me.PASSMAIL = IIMTU("PASSMAIL")

    Return Me

  End Function

End Class

