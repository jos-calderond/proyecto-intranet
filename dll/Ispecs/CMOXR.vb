Imports System.Web.Script.Serialization

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class CMOXR
  Public ORQ As String = ""

  Public CODOPC_B As String = ""
  Public CODROL_B As String = ""
  Public CODSIS As String = ""

  Public CF As List(Of CFType)

  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Public Class CFType
    Public CODOPC As String = ""
    Public CODPADRE As String = ""
    Public DESCRIP As String = ""
    Public FORMU As String = ""
    Public ICONO As String = ""
    Public ORDEN As String = ""
  End Class

  Sub New()
  End Sub

  Public Function CallIspec() As CMOXR
    Dim ISPEC As String = WebService.CMOXR(ORQ, CODOPC_B, CODROL_B, CODSIS)
    Dim cmoxr As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)
    __dic = TryCast(cmoxr, Dictionary(Of String, Object))
    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "CMOXR")

      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.CODOPC_B = cmoxr("__PARAMETERS__")(0)("CODOPC_B")
    Me.CODROL_B = cmoxr("__PARAMETERS__")(0)("CODROL_B")

    Dim cftype As CMOXR.CFType

    Me.CF = New List(Of CFType)

    For Each reg In cmoxr("__COPYFROM__")
      cftype = New CMOXR.CFType()
      cftype.CODOPC = reg("CODOPC")
      cftype.CODPADRE = reg("CODPADRE")
      cftype.DESCRIP = reg("DESCRIP")
      cftype.FORMU = reg("FORMU")
      cftype.ICONO = reg("ICONO")
      cftype.ORDEN = reg("ORDEN")
      Me.CF.Add(cftype)
    Next

    Return Me
  End Function

End Class