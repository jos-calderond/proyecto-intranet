
Imports System.Web.Script.Serialization

Public Class ICOLI

  Public ORQ As String = "T"
  Public TIPO As String = ""
  Public DIA_TRABAJ As String = ""
  Public COD_D As String = ""
  Public COD_B As String = ""
  Public COD_H As String = ""
  Public TIPFUN As String = ""
  Public RUTFUN As String = ""
  Public TIPOLIQ As String = ""
  Public MES As String = ""
  Public ANO As String = ""
  Public INST As String = ""
  Public NROBIE As String = ""
  Public FECTERVIG As String = ""
  Public FINGSE As String = ""
  Public SUEL_BASE2 As String = ""
  Public SIGNO_SB2 As String = ""
  Public SUEL_BASE1 As String = ""
  Public SUEL_BASE As String = ""
  Public SIGNO_SB As String = ""
  Public VAL_PAGO As String = ""
  Public SIGNO_PA As String = ""
  Public TOT_DESV As String = ""
  Public SIGNO_DV As String = ""
  Public TOT_DESL As String = ""
  Public SIGNO_DL As String = ""
  Public SIGNO_SB1 As String = ""
  Public TOT_HAB As String = ""
  Public SIGNO_TH As String = ""
  Public GLOCCOSTO As String = ""
  Public CCOSTO As String = ""
  Public HORAS As String = ""
  Public NIVEL As String = ""
  Public CAT As String = ""
  Public GLOPLANTA As String = ""
  Public POR_IS As String = ""
  Public GLO_IS As String = ""
  Public CODISA As String = ""
  Public MONPLA As String = ""
  Public COPLAN As String = ""
  Public VAL_AFP As String = ""
  Public GLO_AFP As String = ""
  Public CODAFP As String = ""
  Public VAL_IMPON As String = ""
  Public SIGNO_VI As String = ""
  Public GLOGRADO As String = ""
  Public CODGRADO As String = ""
  Public CODPLANTA As String = ""
  Public NOMBRET As String = ""
  Public APEMATT As String = ""
  Public APEPATT As String = ""
  Public GLO_MES As String = ""
  Public VALDV As String = ""
  Public SIGNO_D As String = ""
  Public NOMDV As String = ""
  Public VALDL As String = ""
  Public SIGNO_B As String = ""
  Public NOMDL As String = ""
  Public VALHAB As String = ""
  Public SIGNO_H As String = ""
  Public NOMHAB As String = ""

  Public CF As List(Of CFType)

  Private __js As JavaScriptSerializer

  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Public Class CFType

    Public VALDV As String = ""
    Public SIGNO_D As String = ""
    Public NOMDV As String = ""
    Public VALDL As String = ""
    Public SIGNO_B As String = ""
    Public NOMDL As String = ""
    Public VALHAB As String = ""
    Public SIGNO_H As String = ""
    Public NOMHAB As String = ""

  End Class

  Sub New()
  End Sub

  Public Function CallIspec() As ICOLI

    Dim ISPEC As String = WebService.ICOLI(ORQ, ANO, COD_D, COD_B, COD_H, DIA_TRABAJ, INST, MES, RUTFUN, TIPFUN, TIPO, TIPOLIQ)
    Dim ICOLI As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(ICOLI, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then

      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "ICOLI")
      End If

    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.TIPO = ICOLI("__PARAMETERS__")(0)("TIPO")
    Me.DIA_TRABAJ = ICOLI("__PARAMETERS__")(0)("DIA_TRABAJ")
    Me.COD_D = ICOLI("__PARAMETERS__")(0)("COD_D")
    Me.COD_B = ICOLI("__PARAMETERS__")(0)("COD_B")
    Me.COD_H = ICOLI("__PARAMETERS__")(0)("COD_H")
    Me.TIPFUN = ICOLI("__PARAMETERS__")(0)("TIPFUN")
    Me.RUTFUN = ICOLI("__PARAMETERS__")(0)("RUTFUN")
    Me.TIPOLIQ = ICOLI("__PARAMETERS__")(0)("TIPOLIQ")
    Me.MES = ICOLI("__PARAMETERS__")(0)("MES")
    Me.ANO = ICOLI("__PARAMETERS__")(0)("ANO")
    Me.INST = ICOLI("__PARAMETERS__")(0)("INST")

    Dim cftype As ICOLI.CFType

    Me.CF = New List(Of CFType)

    For Each reg In ICOLI("__COPYFROM__")
      cftype = New ICOLI.CFType()
      cftype.VALDV = reg("VALDV")
      cftype.SIGNO_D = reg("SIGNO_D")
      cftype.NOMDV = reg("NOMDV")
      cftype.VALDL = reg("VALDL")
      cftype.SIGNO_B = reg("SIGNO_B")
      cftype.NOMDL = reg("NOMDL")
      cftype.VALHAB = reg("VALHAB")
      cftype.SIGNO_H = reg("SIGNO_H")
      cftype.NOMHAB = reg("NOMHAB")
      Me.CF.Add(cftype)

    Next

    Return Me

  End Function

  Public Function CallIspecInquiry() As ICOLI

    Dim ISPEC As String = WebService.ICOLI(ORQ, ANO, COD_D, COD_B, COD_H, DIA_TRABAJ, INST, MES, RUTFUN, TIPFUN, TIPO, TIPOLIQ)
    Dim ICOLI As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(ICOLI, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "ICOLI")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.DIA_TRABAJ = ICOLI("__PARAMETERS__")(0)("DIA_TRABAJ")
    Me.COD_D = ICOLI("__PARAMETERS__")(0)("COD_D")
    Me.COD_B = ICOLI("__PARAMETERS__")(0)("COD_B")
    Me.COD_H = ICOLI("__PARAMETERS__")(0)("COD_H")
    Me.RUTFUN = ICOLI("__PARAMETERS__")(0)("RUTFUN")
    Me.TIPOLIQ = ICOLI("__PARAMETERS__")(0)("TIPOLIQ")
    Me.MES = ICOLI("__PARAMETERS__")(0)("MES")
    Me.ANO = ICOLI("__PARAMETERS__")(0)("ANO")
    Me.APEMATT = ICOLI("__PARAMETERS__")(0)("APEMATT")
    Me.APEPATT = ICOLI("__PARAMETERS__")(0)("APEPATT")
    Me.CAT = ICOLI("__PARAMETERS__")(0)("CAT")
    Me.CCOSTO = ICOLI("__PARAMETERS__")(0)("CCOSTO")
    Me.CODAFP = ICOLI("__PARAMETERS__")(0)("CODAFP")
    Me.CODGRADO = ICOLI("__PARAMETERS__")(0)("CODGRADO")
    Me.CODISA = ICOLI("__PARAMETERS__")(0)("CODISA")
    Me.CODPLANTA = ICOLI("__PARAMETERS__")(0)("CODPLANTA")
    Me.COPLAN = ICOLI("__PARAMETERS__")(0)("COPLAN")
    Me.FECTERVIG = ICOLI("__PARAMETERS__")(0)("FECTERVIG")
    Me.FINGSE = ICOLI("__PARAMETERS__")(0)("FINGSE")
    Me.GLO_AFP = ICOLI("__PARAMETERS__")(0)("GLO_AFP")
    Me.GLO_IS = ICOLI("__PARAMETERS__")(0)("GLO_IS")
    Me.GLOCCOSTO = ICOLI("__PARAMETERS__")(0)("GLOCCOSTO")
    Me.GLOGRADO = ICOLI("__PARAMETERS__")(0)("GLOGRADO")
    Me.GLOPLANTA = ICOLI("__PARAMETERS__")(0)("GLOPLANTA")
    Me.HORAS = ICOLI("__PARAMETERS__")(0)("HORAS")
    Me.MONPLA = ICOLI("__PARAMETERS__")(0)("MONPLA")
    Me.NIVEL = ICOLI("__PARAMETERS__")(0)("NIVEL")
    Me.NOMBRET = ICOLI("__PARAMETERS__")(0)("NOMBRET")
    Me.NROBIE = ICOLI("__PARAMETERS__")(0)("NROBIE")
    Me.POR_IS = ICOLI("__PARAMETERS__")(0)("POR_IS")
    Me.SUEL_BASE = ICOLI("__PARAMETERS__")(0)("SUEL_BASE")
    Me.SUEL_BASE1 = ICOLI("__PARAMETERS__")(0)("SUEL_BASE1")
    Me.SUEL_BASE2 = ICOLI("__PARAMETERS__")(0)("SUEL_BASE2")
    Me.TOT_DESL = ICOLI("__PARAMETERS__")(0)("TOT_DESL")
    Me.TOT_DESV = ICOLI("__PARAMETERS__")(0)("TOT_DESV")
    Me.TOT_HAB = ICOLI("__PARAMETERS__")(0)("TOT_HAB")
    Me.VAL_AFP = ICOLI("__PARAMETERS__")(0)("VAL_AFP")
    Me.VAL_IMPON = ICOLI("__PARAMETERS__")(0)("VAL_IMPON")
    Me.VAL_PAGO = ICOLI("__PARAMETERS__")(0)("VAL_PAGO")

    Return Me

  End Function

End Class