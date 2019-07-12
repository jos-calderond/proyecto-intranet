Imports System.Web.Script.Serialization

Public Class IMESL

  Public ORQ As String = "T"
  Public INST As String = ""
  Public ANO As String = ""
  Public RUTFUN As String = ""
  Public NOMBRE As String = ""
  Public APEMAT As String = ""
  Public APEPAT As String = ""
  Public ANOINI As String = ""
  Public GLOSAMES As String = ""
  Public NUMMES As String = ""

  Public CF As List(Of CFType)

  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Public Class CFType
    Public GLOSAMES As String = ""
    Public NUMMES As String = ""
  End Class

  Sub New()

  End Sub

  Public Function CallIspec() As IMESL

    Dim ISPEC As String = WebService.IMESL(ORQ, INST, ANO, RUTFUN, ANOINI)
    Dim IMESL As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(IMESL, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "IMESL")
      End If
    End If

    If __dic.Count = 0 Then

      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.INST = IMESL("__PARAMETERS__")(0)("INST")
    Me.ANO = IMESL("__PARAMETERS__")(0)("ANO")
    Me.RUTFUN = IMESL("__PARAMETERS__")(0)("RUTFUN")
    Me.ANOINI = IMESL("__PARAMETERS__")(0)("ANOINI")

    Dim cftype As IMESL.CFType

    Me.CF = New List(Of CFType)

    For Each reg In IMESL("__COPYFROM__")

      cftype = New IMESL.CFType()
      cftype.GLOSAMES = reg("GLOSAMES")
      cftype.NUMMES = reg("NUMMES")

      Me.CF.Add(cftype)

    Next

    Return Me
    End Function

    Public Function CallIspecInquiry() As IMESL

        Dim ISPEC As String = WebService.IMESL(ORQ, INST, ANO, RUTFUN, ANOINI)
        Dim IMESL As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

        __dic = TryCast(IMESL, Dictionary(Of String, Object))

        If (Not __dic Is Nothing) Then
            If (__dic.ContainsKey("ERROR")) Then
                Throw New WSException(__dic("ERROR")("Message"), "IMESL")
            End If
        End If

        If __dic.Count = 0 Then
            Throw New Exception("Error de conexion con el Webservice")
        End If

        Me.INST = IMESL("__PARAMETERS__")(0)("INST")
        Me.ANO = IMESL("__PARAMETERS__")(0)("ANO")
        Me.RUTFUN = IMESL("__PARAMETERS__")(0)("RUTFUN")
        Me.ANOINI = IMESL("__PARAMETERS__")(0)("ANOINI")

        Return Me

    End Function
End Class

