Imports System.Web.Script.Serialization

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class CMOXU
  Public ORQ As String = "T"

  Public CODOPC_B As String = ""
  Public CODUSU As String = ""
  Public ROL As String = ""
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

  Public Function CallIspec() As CMOXU
    Dim ISPEC As String = WebService.CMOXU(ORQ, CODOPC_B, CODUSU, ROL, CODSIS)
    Dim cmoxu As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)
    __dic = TryCast(cmoxu, Dictionary(Of String, Object))
    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "CMOXU")

      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.CODOPC_B = cmoxu("__PARAMETERS__")(0)("CODOPC_B")
    Me.CODUSU = cmoxu("__PARAMETERS__")(0)("CODUSU")
    Me.ROL = cmoxu("__PARAMETERS__")(0)("ROL")

    Dim cftype As CMOXU.CFType

    Me.CF = New List(Of CFType)

    For Each reg In cmoxu("__COPYFROM__")
      cftype = New CMOXU.CFType()
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