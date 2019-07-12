Imports System.Web.Script.Serialization

Public Class CTURO
  Public ORQ As String = "T"
  Public CODOPC_C As String = ""
  Public CODROL_C As String = ""
  Public CODUSU_C As String = ""
  Public CODSIS_C As String = ""
  Public MENSAJE As String = ""
  Public PERMISO As String = ""
  Public CODOPC As String = ""
  Public CODROL As String = ""
  Public CODUSU As String = ""
  Public CODSIS As String = ""

  Public CF As List(Of CFType)

  Private __js As JavaScriptSerializer

  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Public Class CFType
    Public PERMISO As String = ""
    Public CODOPC As String = ""
    Public CODROL As String = ""
    Public CODUSU As String = ""
    Public CODSIS As String = ""
  End Class

  Sub New()
  End Sub

  Public Function CallIspec() As CTURO

    Dim ISPEC As String = WebService.CTURO(ORQ,CODOPC_C,CODROL_C,CODSIS_C, CODUSU_C)

    Dim CTURO As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(CTURO, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "CTURO")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.CODOPC_C = CTURO("__PARAMETERS__")(0)("CODOPC_C")
    Me.CODROL_C = CTURO("__PARAMETERS__")(0)("CODROL_C")
    Me.CODUSU_C = CTURO("__PARAMETERS__")(0)("CODUSU_C")
    Me.CODSIS_C = CTURO("__PARAMETERS__")(0)("CODSIS_C")

    Dim cftype As CTURO.CFType

    Me.CF = New List(Of CFType)

    For Each reg In CTURO("__COPYFROM__")

      cftype = New CTURO.CFType()
      cftype.PERMISO = reg("PERMISO")
      cftype.CODOPC = reg("CODOPC")
      cftype.CODROL = reg("CODROL")
      cftype.CODUSU = reg("CODUSU")
      cftype.CODSIS = reg("CODSIS")

      Me.CF.Add(cftype)

    Next

    Return Me

  End Function

End Class

