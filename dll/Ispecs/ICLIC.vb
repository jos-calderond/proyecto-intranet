Imports System.Web.Script.Serialization

''' <summary>
''' 30/05/2019 rtorreblanca: Creación.
''' </summary>
''' <remarks></remarks>
Public Class ICLIC

  Public ORQ As String = "T"
  Public FECINI As String = ""
  Public RUTFUN As String = ""
  Public VAMENU As String = ""
  Public MENJ35 As String = ""
  Public VIGENCIA As String = ""
  Public FECTER_LIC As String = ""
  Public NRODIA_LIC As String = ""
  Public FECACC_LIC As String = ""
  Public FECRESL As String = ""
  Public RESSAL As String = ""
  Public NUMLIC As String = ""
  Public GLODIRECC As String = ""
  Public FECINI_LIC As String = ""

  Public CF As List(Of CFType)

  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Public Class CFType

    Public FECTER_LIC As String = ""
    Public NRODIA_LIC As String = ""
    Public FECACC_LIC As String = ""
    Public FECRESL As String = ""
    Public RESSAL As String = ""
    Public NUMLIC As String = ""
    Public GLODIRECC As String = ""
    Public FECINI_LIC As String = ""

  End Class

  Sub New()
  End Sub

  Public Function CallIspec() As ICLIC

    Dim ISPEC As String = WebService.ICLIC(ORQ, FECINI, RUTFUN, VAMENU)
    Dim ICLIC As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(ICLIC, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "ICLIC")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.FECINI = ICLIC("__PARAMETERS__")(0)("FECINI")
    Me.RUTFUN = ICLIC("__PARAMETERS__")(0)("RUTFUN")
    Me.VAMENU = ICLIC("__PARAMETERS__")(0)("VAMENU")

    Dim cftype As ICLIC.CFType

    Me.CF = New List(Of CFType)

    For Each reg In ICLIC("__COPYFROM__")

      cftype = New ICLIC.CFType()

      cftype.FECTER_LIC = reg("FECTER_LIC")
      cftype.NRODIA_LIC = reg("NRODIA_LIC")
      cftype.FECACC_LIC = reg("FECACC_LIC")
      cftype.FECRESL = reg("FECRESL")
      cftype.RESSAL = reg("RESSAL")
      cftype.NUMLIC = reg("NUMLIC")
      cftype.GLODIRECC = reg("GLODIRECC")
      cftype.FECINI_LIC = reg("FECINI_LIC")

      Me.CF.Add(cftype)

    Next

    Return Me

  End Function

End Class

