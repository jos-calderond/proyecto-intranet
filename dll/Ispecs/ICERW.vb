Imports System.Web.Script.Serialization

Public Class ICERW
  Public ORQ As String = "T"
  Public CARGOJEFE As String = ""
  Public NUMCERT As String = ""
  Public NOMBREJEF As String = ""
  Public CARGOFUN As String = ""
  Public MESREM As String = ""
  Public ANOREM As String = ""
  Public SEXO As String = ""
  Public APEMATFUN As String = ""
  Public APEPATFUN As String = ""
  Public NOMBREFUN As String = ""
  Public ANO_C As String = ""
  Public SECMOV_C As String = ""
  Public SECUN_C As String = ""
  Public RUTFUN_C As String = ""
  Public TIPOCER_C As String = ""
  Public MANT As String = ""
  Public VARIOS_P As String = ""
  Public CODAREA_P As String = ""
  Public ESTA_P As String = ""
  Public TCONTRA_P As String = ""
  Public TIPOCON_P As String = ""
  Public TIPPAGO_P As String = ""
  Public CCOSTO_P As String = ""
  Public FTERCON_P As String = ""
  Public FINICON_P As String = ""
  Public SEC_MOV_P As String = ""
  Public SEC_CON_P As String = ""
  Public GCCOSTO_P As String = ""
  Public TIPOFUN_P As String = ""
  Public MENSAJE As String = ""
  Public FINGCORP As String = ""
  Public FINGSER As String = ""
  Public NUMBIE As String = ""
  Public VARIOS As String = ""
  Public CENTROCOST As String = ""
  Public TIPOFUN As String = ""
  Public TIPO_PAGO As String = ""
  Public TCONTRA As String = ""
  Public ESTA As String = ""
  Public TIPOCON As String = ""
  Public FECTERCON As String = ""
  Public FECINICON As String = ""

  Public CF As List(Of CFType)

  Private __js As JavaScriptSerializer

  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Public Class CFType
    Public VARIOS As String = ""
    Public CENTROCOST As String = ""
    Public TIPOFUN As String = ""
    Public TIPO_PAGO As String = ""
    Public TCONTRA As String = ""
    Public ESTA As String = ""
    Public TIPOCON As String = ""
    Public FECTERCON As String = ""
    Public FECINICON As String = ""
    Public NUMCERT As String = ""
    Public CARGOJEFE As String = ""
    Public NOMBREJEF As String = ""
    Public CARGOFUN As String = ""
    Public MESREM As String = ""
    Public ANOREM As String = ""
    Public SEXO As String = ""
    Public APEMATFUN As String = ""
    Public APEPATFUN As String = ""
    Public NOMBREFUN As String = ""
    Public ANO_C As String = ""
    Public SECMOV_C As String = ""
    Public SECUN_C As String = ""
    Public RUTFUN_C As String = ""
    Public TIPOCER_C As String = ""
    Public MANT As String = ""
    Public VARIOS_P As String = ""
    Public CODAREA_P As String = ""
    Public ESTA_P As String = ""
    Public TCONTRA_P As String = ""
    Public TIPOCON_P As String = ""
    Public TIPPAGO_P As String = ""
    Public CCOSTO_P As String = ""
    Public FTERCON_P As String = ""
    Public FINICON_P As String = ""
    Public SEC_MOV_P As String = ""
    Public SEC_CON_P As String = ""
    Public GCCOSTO_P As String = ""
    Public TIPOFUN_P As String = ""
    Public MENSAJE As String = ""
    Public FINGCORP As String = ""
    Public FINGSER As String = ""
    Public NUMBIE As String = ""
   
  End Class

  Sub New()
  End Sub

  Public Function CallIspec() As ICERW

    Dim ISPEC As String = WebService.ICERW(ORQ, CARGOJEFE, NUMCERT, NOMBREJEF, CARGOFUN, MESREM, ANOREM, SEXO, APEMATFUN, APEPATFUN, NOMBREFUN, ANO_C, SECMOV_C, SECUN_C, RUTFUN_C, TIPOCER_C, MANT, VARIOS_P, CODAREA_P, ESTA_P, TCONTRA_P, TIPOCON_P, TIPPAGO_P, CCOSTO_P, FTERCON_P, FINICON_P, SEC_MOV_P, SEC_CON_P, GCCOSTO_P, TIPOFUN_P, FINGCORP, FINGSER, NUMBIE, VARIOS, CENTROCOST, TIPOFUN, TIPO_PAGO, TCONTRA, ESTA, TIPOCON, FECTERCON, FECINICON)
    Dim ICERW As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(ICERW, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "ICERW")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.CARGOJEFE = ICERW("__PARAMETERS__")(0)("CARGOJEFE")
    Me.NUMCERT = ICERW("__PARAMETERS__")(0)("NUMCERT")
    Me.NOMBREJEF = ICERW("__PARAMETERS__")(0)("NOMBREJEF")
    Me.CARGOFUN = ICERW("__PARAMETERS__")(0)("CARGOFUN")
    Me.MESREM = ICERW("__PARAMETERS__")(0)("MESREM")
    Me.ANOREM = ICERW("__PARAMETERS__")(0)("ANOREM")
    Me.SEXO = ICERW("__PARAMETERS__")(0)("SEXO")
    Me.APEMATFUN = ICERW("__PARAMETERS__")(0)("APEMATFUN")
    Me.APEPATFUN = ICERW("__PARAMETERS__")(0)("APEPATFUN")
    Me.NOMBREFUN = ICERW("__PARAMETERS__")(0)("NOMBREFUN")
    Me.ANO_C = ICERW("__PARAMETERS__")(0)("ANO_C")
    Me.SECMOV_C = ICERW("__PARAMETERS__")(0)("SECMOV_C")
    Me.SECUN_C = ICERW("__PARAMETERS__")(0)("SECUN_C")
    Me.RUTFUN_C = ICERW("__PARAMETERS__")(0)("RUTFUN_C")
    Me.TIPOCER_C = ICERW("__PARAMETERS__")(0)("TIPOCER_C")
    Me.MANT = ICERW("__PARAMETERS__")(0)("MANT")
    Me.VARIOS_P = ICERW("__PARAMETERS__")(0)("VARIOS_P")
    Me.CODAREA_P = ICERW("__PARAMETERS__")(0)("CODAREA_P")
    Me.ESTA_P = ICERW("__PARAMETERS__")(0)("ESTA_P")
    Me.TCONTRA_P = ICERW("__PARAMETERS__")(0)("TCONTRA_P")
    Me.TIPOCON_P = ICERW("__PARAMETERS__")(0)("TIPOCON_P")
    Me.TIPPAGO_P = ICERW("__PARAMETERS__")(0)("TIPPAGO_P")
    Me.CCOSTO_P = ICERW("__PARAMETERS__")(0)("CCOSTO_P")
    Me.FTERCON_P = ICERW("__PARAMETERS__")(0)("FTERCON_P")
    Me.FINICON_P = ICERW("__PARAMETERS__")(0)("FINICON_P")
    Me.SEC_MOV_P = ICERW("__PARAMETERS__")(0)("SEC_MOV_P")
    Me.SEC_CON_P = ICERW("__PARAMETERS__")(0)("SEC_CON_P")
    Me.GCCOSTO_P = ICERW("__PARAMETERS__")(0)("GCCOSTO_P")
    Me.TIPOFUN_P = ICERW("__PARAMETERS__")(0)("TIPOFUN_P")
    Me.FINGCORP = ICERW("__PARAMETERS__")(0)("FINGCORP")
    Me.FINGSER = ICERW("__PARAMETERS__")(0)("FINGSER")
    Me.NUMBIE = ICERW("__PARAMETERS__")(0)("NUMBIE")
    Me.VARIOS = ICERW("__PARAMETERS__")(0)("VARIOS")
    Me.CENTROCOST = ICERW("__PARAMETERS__")(0)("CENTROCOST")
    Me.TIPOFUN = ICERW("__PARAMETERS__")(0)("TIPOFUN")
    Me.TIPO_PAGO = ICERW("__PARAMETERS__")(0)("TIPO_PAGO")
    Me.TCONTRA = ICERW("__PARAMETERS__")(0)("TCONTRA")
    Me.ESTA = ICERW("__PARAMETERS__")(0)("ESTA")
    Me.TIPOCON = ICERW("__PARAMETERS__")(0)("TIPOCON")
    Me.FECTERCON = ICERW("__PARAMETERS__")(0)("FECTERCON")
    Me.FECINICON = ICERW("__PARAMETERS__")(0)("FECINICON")

    Dim cftype As ICERW.CFType

    Me.CF = New List(Of CFType)

    For Each reg In ICERW("__COPYFROM__")
      cftype = New ICERW.CFType()
      cftype.VARIOS = reg("VARIOS")
      cftype.CENTROCOST = reg("CENTROCOST")
      cftype.TIPOFUN = reg("TIPOFUN")
      cftype.TIPO_PAGO = reg("TIPO_PAGO")
      cftype.TCONTRA = reg("TCONTRA")
      cftype.ESTA = reg("ESTA")
      cftype.TIPOCON = reg("TIPOCON")
      cftype.FECTERCON = reg("FECTERCON")
      cftype.FECINICON = reg("FECINICON")
      Me.CF.Add(cftype)
    Next

    Return Me

  End Function

  Public Function CallIspecInquiry() As ICERW

    Dim ISPEC As String = WebService.ICERW(ORQ, CARGOJEFE, NUMCERT, NOMBREJEF, CARGOFUN, MESREM, ANOREM, SEXO, APEMATFUN, APEPATFUN, NOMBREFUN, ANO_C, SECMOV_C, SECUN_C, RUTFUN_C, TIPOCER_C, MANT, VARIOS_P, CODAREA_P, ESTA_P, TCONTRA_P, TIPOCON_P, TIPPAGO_P, CCOSTO_P, FTERCON_P, FINICON_P, SEC_MOV_P, SEC_CON_P, GCCOSTO_P, TIPOFUN_P, FINGCORP, FINGSER, NUMBIE, VARIOS, CENTROCOST, TIPOFUN, TIPO_PAGO, TCONTRA, ESTA, TIPOCON, FECTERCON, FECINICON)
    Dim ICERW As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(ICERW, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "ICERW")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.CARGOJEFE = ICERW("__PARAMETERS__")(0)("CARGOJEFE")
    Me.NUMCERT = ICERW("__PARAMETERS__")(0)("NUMCERT")
    Me.NOMBREJEF = ICERW("__PARAMETERS__")(0)("NOMBREJEF")
    Me.CARGOFUN = ICERW("__PARAMETERS__")(0)("CARGOFUN")
    Me.MESREM = ICERW("__PARAMETERS__")(0)("MESREM")
    Me.ANOREM = ICERW("__PARAMETERS__")(0)("ANOREM")
    Me.SEXO = ICERW("__PARAMETERS__")(0)("SEXO")
    Me.APEMATFUN = ICERW("__PARAMETERS__")(0)("APEMATFUN")
    Me.APEPATFUN = ICERW("__PARAMETERS__")(0)("APEPATFUN")
    Me.NOMBREFUN = ICERW("__PARAMETERS__")(0)("NOMBREFUN")
    Me.ANO_C = ICERW("__PARAMETERS__")(0)("ANO_C")
    Me.SECMOV_C = ICERW("__PARAMETERS__")(0)("SECMOV_C")
    Me.SECUN_C = ICERW("__PARAMETERS__")(0)("SECUN_C")
    Me.RUTFUN_C = ICERW("__PARAMETERS__")(0)("RUTFUN_C")
    Me.TIPOCER_C = ICERW("__PARAMETERS__")(0)("TIPOCER_C")
    Me.MANT = ICERW("__PARAMETERS__")(0)("MANT")

    Me.VARIOS_P = ICERW("__PARAMETERS__")(0)("VARIOS_P")
    Me.CODAREA_P = ICERW("__PARAMETERS__")(0)("CODAREA_P")
    Me.ESTA_P = ICERW("__PARAMETERS__")(0)("ESTA_P")
    Me.TCONTRA_P = ICERW("__PARAMETERS__")(0)("TCONTRA_P")
    Me.TIPOCON_P = ICERW("__PARAMETERS__")(0)("TIPOCON_P")
    Me.TIPPAGO_P = ICERW("__PARAMETERS__")(0)("TIPPAGO_P")
    Me.CCOSTO_P = ICERW("__PARAMETERS__")(0)("CCOSTO_P")
    Me.FTERCON_P = ICERW("__PARAMETERS__")(0)("FTERCON_P")
    Me.FINICON_P = ICERW("__PARAMETERS__")(0)("FINICON_P")
    Me.SEC_MOV_P = ICERW("__PARAMETERS__")(0)("SEC_MOV_P")
    Me.SEC_CON_P = ICERW("__PARAMETERS__")(0)("SEC_CON_P")
    Me.GCCOSTO_P = ICERW("__PARAMETERS__")(0)("GCCOSTO_P")
    Me.TIPOFUN_P = ICERW("__PARAMETERS__")(0)("TIPOFUN_P")
    Me.FINGCORP = ICERW("__PARAMETERS__")(0)("FINGCORP")
    Me.FINGSER = ICERW("__PARAMETERS__")(0)("FINGSER")
    Me.NUMBIE = ICERW("__PARAMETERS__")(0)("NUMBIE")
    Me.VARIOS = ICERW("__PARAMETERS__")(0)("VARIOS")
    Me.CENTROCOST = ICERW("__PARAMETERS__")(0)("CENTROCOST")
    Me.TIPOFUN = ICERW("__PARAMETERS__")(0)("TIPOFUN")
    Me.TIPO_PAGO = ICERW("__PARAMETERS__")(0)("TIPO_PAGO")
    Me.TCONTRA = ICERW("__PARAMETERS__")(0)("TCONTRA")
    Me.ESTA = ICERW("__PARAMETERS__")(0)("ESTA")
    Me.TIPOCON = ICERW("__PARAMETERS__")(0)("TIPOCON")
    Me.FECTERCON = ICERW("__PARAMETERS__")(0)("FECTERCON")
    Me.FECINICON = ICERW("__PARAMETERS__")(0)("FECINICON")

    Return Me

  End Function

End Class

