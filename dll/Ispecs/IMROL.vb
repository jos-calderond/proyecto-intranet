Imports System.Web.Script.Serialization

Public Class IMROL
  Public ORQ As String = "T"
  Public CODOPCB As String = ""
  Public CODUSU As String = ""
  Public CODROL As String = ""
  Public CODSIS As String = ""
  Public MANT As String = ""
  Public MENSAJE As String = ""
  Public GLOCODUSU As String = ""
  Public PERMISO4 As String = ""
  Public CODOPC4 As String = ""
  Public PERMISO3 As String = ""
  Public CODOPC3 As String = ""
  Public PERMISO2 As String = ""
  Public CODOPC2 As String = ""
  Public PERMISO1 As String = ""
  Public CODOPC1 As String = ""
  Public PERMISO As String = ""

  Public CF As List(Of CFType)

  Private __js As JavaScriptSerializer

  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Public Class CFType

    Public PERMISO4 As String = ""
    Public CODOPC4 As String = ""
    Public PERMISO3 As String = ""
    Public CODOPC3 As String = ""
    Public PERMISO2 As String = ""
    Public CODOPC2 As String = ""
    Public PERMISO1 As String = ""
    Public CODOPC1 As String = ""

  End Class

  Sub New()
  End Sub

  Public Function CallIspec() As IMROL

    Dim ISPEC As String = WebService.IMROL(ORQ, CODOPCB, CODUSU, CODROL, CODSIS, MANT, PERMISO)
    Dim IMROL As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(IMROL, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "IMROL")
      End If
    End If
    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.CODOPCB = IMROL("__PARAMETERS__")(0)("CODOPCB")
    Me.CODUSU = IMROL("__PARAMETERS__")(0)("CODUSU")
    Me.CODROL = IMROL("__PARAMETERS__")(0)("CODROL")
    Me.CODSIS = IMROL("__PARAMETERS__")(0)("CODSIS")
    Me.MANT = IMROL("__PARAMETERS__")(0)("MANT")

    Dim cftype As IMROL.CFType

    Me.CF = New List(Of CFType)

    For Each reg In IMROL("__COPYFROM__")

      cftype = New IMROL.CFType()
      cftype.PERMISO4 = reg("PERMISO4")
      cftype.CODOPC4 = reg("CODOPC4")
      cftype.PERMISO3 = reg("PERMISO3")
      cftype.CODOPC3 = reg("CODOPC3")
      cftype.PERMISO2 = reg("PERMISO2")
      cftype.CODOPC2 = reg("CODOPC2")
      cftype.PERMISO1 = reg("PERMISO1")
      cftype.CODOPC1 = reg("CODOPC1")

      Me.CF.Add(cftype)

    Next

    Return Me

  End Function

End Class

