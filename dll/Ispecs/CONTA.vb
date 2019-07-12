Imports System.Web.Script.Serialization

''' <summary>
''' 08/05/2019 rtorreblanca: Creación.
''' </summary>
''' <remarks></remarks>
Public Class CONTA
  Public ORQ As String = "T"

  Public TIPORDEN As String = ""
  Public TIPREG_B As String = ""
  Public ALFA01_B As String = ""
  Public ALFA02_B As String = ""
  Public CODIGO_B As String = ""
  Public DESCRI_B As String = ""

  Public CF As List(Of CFType)

  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Public Class CFType
    Public ALFA01 As String = ""
    Public ALFA02 As String = ""
    Public CODIGO As String = ""
    Public DESCRI As String = ""
  End Class

  Sub New()
  End Sub

  Public Function CallIspec() As CONTA

    Dim ISPEC As String = WebService.CONTA(ORQ, TIPORDEN, TIPREG_B, ALFA01_B, ALFA02_B, CODIGO_B, DESCRI_B)
    Dim conta As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)
    __dic = TryCast(conta, Dictionary(Of String, Object))
    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "CONTA")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.ALFA01_B = conta("__PARAMETERS__")(0)("ALFA01_B")
    Me.ALFA02_B = conta("__PARAMETERS__")(0)("ALFA02_B")
    Me.CODIGO_B = conta("__PARAMETERS__")(0)("CODIGO_B")
    Me.DESCRI_B = conta("__PARAMETERS__")(0)("DESCRI_B")
    Me.TIPORDEN = conta("__PARAMETERS__")(0)("TIPORDEN")

    Dim cftype As CONTA.CFType
    CF = New List(Of CFType)

    For Each reg In conta("__COPYFROM__")
      cftype = New CONTA.CFType()
      cftype.ALFA01 = reg("ALFA01")
      cftype.ALFA02 = reg("ALFA02")
      cftype.CODIGO = reg("CODIGO")
      cftype.DESCRI = reg("DESCRI")
      Me.CF.Add(cftype)
    Next

    Return Me
  End Function

End Class