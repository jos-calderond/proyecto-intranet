Imports System.Web.Script.Serialization

Public Class CTUSM

  Public ORQ As String = "T"
  Public PRIORIDA_B As String = ""
  Public CODUSU As String = ""
  Public GLOUSU As String = ""
  Public PASSMAIL As String = ""
  Public EMAIL As String = ""
  Public PRIORIDAD As String = ""

  Public CF As List(Of CFType)

  Private __js As JavaScriptSerializer

  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Public Class CFType
    Public PASSMAIL As String = ""
    Public EMAIL As String = ""
    Public PRIORIDAD As String = ""
  End Class

  Sub New()
  End Sub

  Public Function CallIspec() As CTUSM

    Dim ISPEC As String = WebService.CTUSM(ORQ, PRIORIDA_B, CODUSU)
    Dim CTUSM As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(CTUSM, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "CTUSM")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.PRIORIDA_B = CTUSM("__PARAMETERS__")(0)("PRIORIDA_B")
    Me.CODUSU = CTUSM("__PARAMETERS__")(0)("CODUSU")

    Dim cftype As CTUSM.CFType

    Me.CF = New List(Of CFType)

    For Each reg In CTUSM("__COPYFROM__")
      cftype = New CTUSM.CFType()
      cftype.PASSMAIL = reg("PASSMAIL")
      cftype.EMAIL = reg("EMAIL")
      cftype.PRIORIDAD = reg("PRIORIDAD")
      Me.CF.Add(cftype)
    Next

    Return Me

  End Function

End Class

