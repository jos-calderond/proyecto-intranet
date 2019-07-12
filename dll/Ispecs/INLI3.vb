Imports System.Web.Script.Serialization

''' <summary>
''' 05/06/2019 rtorreblanca: Creación.
''' </summary>
''' <remarks></remarks>
Public Class INLI3

  Public VALPROMCOT As String = ""
  Public VALPROMLIQ As String = ""
  Public VALRECIBIR As String = ""
  Public VALSUBSID As String = ""
  Public VALCOTIZA As String = ""
  Public ANO_AVISO As String = ""
  Public CODUSU As String = ""
  Public NUM_AVISO As String = ""
  Public CODAREA As String = ""
  Public FECANTECED As String = ""
  Public FEC_AVISO As String = ""
  Public FECANT_LIC As String = ""
  Public TIPLIC As String = ""
  Public ESTLIC As String = ""
  Public FECRECLIC As String = ""
  Public FECTER_CON As String = ""
  Public FECINI_CON As String = ""
  Public PRI_AMP As String = ""
  Public OBSER2 As String = ""
  Public OBSER1 As String = ""
  Public PERREMUN As String = ""
  Public VALREMB As String = ""
  Public OBSERV_LIC As String = ""
  Public ESPECI As String = ""
  Public DIAGNO_LIC As String = ""
  Public FECRESL As String = ""
  Public CODDIAG As String = ""
  Public TIPSUB As String = ""
  Public CODEST As String = ""
  Public ACLARAM As String = ""
  Public CORRELA As String = ""
  Public RESSSAL As String = ""
  Public SERVSAL As String = ""
  Public COMUNAM As String = ""
  Public NUMEROM As String = ""
  Public CALLEM As String = ""
  Public RUTHIJ As String = ""
  Public RUTMED As String = ""
  Public APEMATM As String = ""
  Public FONOMED As String = ""
  Public APEPATM As String = ""
  Public NOMMED_LIC As String = ""
  Public MESCON As String = ""
  Public FECNAC As String = ""
  Public FECACC_LIC As String = ""
  Public NRODIA_LIC As String = ""
  Public NUMLIC_DV As String = ""
  Public NUMLIC_LIC As String = ""
  Public TIPMED As String = ""
  Public ACLARA_LIC As String = ""
  Public FONO_LIC As String = ""
  Public COMUNA_LIC As String = ""
  Public NCALLE_LIC As String = ""
  Public CALLE_LIC As String = ""
  Public CODOCU As String = ""
  Public ACTLAB As String = ""
  Public CODJORNADA As String = ""
  Public CODLICEN As String = ""
  Public FECEMI As String = ""
  Public FECINI_LIC As String = ""
  Public RUTFUN As String = ""
  Public VACLICF As String = ""
  Public VASILIC As String = ""
  Public VAANLIC As String = ""
  Public VAULLIC As String = ""
  Public VAMENU As String = ""
  Public MANT As String = ""
  Public GLOFUN As String = ""
  Public CODFUN As String = ""
  Public CCOSMAIL As String = ""
  Public GESTLIC As String = ""
  Public GLOCOS As String = ""
  Public CCOSTO As String = ""
  Public VALH48 As String = ""
  Public CON_TIP As String = ""
  Public TIPCON As String = ""
  Public FEC1AFP As String = ""
  Public GCODISA As String = ""
  Public GTIPSUB As String = ""
  Public GCODEST As String = ""
  Public DIASAPAGO As String = ""
  Public NRODIA_PAG As String = ""
  Public NRODIA_AUT As String = ""
  Public GTIPMED As String = ""
  Public GCODOCU As String = ""
  Public GACTLAB As String = ""
  Public GLOJORNA As String = ""
  Public GLOTIPLIC As String = ""
  Public FINGSE_FUN As String = ""
  Public FECTER_LIC As String = ""
  Public GLONOMBRE As String = ""

  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Sub New()
  End Sub

  Public Function CallIspec() As INLI3

    Dim ISPEC As String = WebService.INLI3(VALPROMCOT, VALPROMLIQ, VALRECIBIR, VALSUBSID, VALCOTIZA, ANO_AVISO, CODUSU, NUM_AVISO, CODAREA, FECANTECED, FEC_AVISO, FECANT_LIC, TIPLIC, ESTLIC, FECRECLIC, FECTER_CON, FECINI_CON, PRI_AMP, OBSER2, OBSER1, PERREMUN, VALREMB, OBSERV_LIC, ESPECI, DIAGNO_LIC, FECRESL, CODDIAG, TIPSUB, CODEST, ACLARAM, CORRELA, RESSSAL, SERVSAL, COMUNAM, NUMEROM, CALLEM, RUTHIJ, RUTMED, APEMATM, FONOMED, APEPATM, NOMMED_LIC, MESCON, FECNAC, FECACC_LIC, NRODIA_LIC, NUMLIC_DV, NUMLIC_LIC, TIPMED, ACLARA_LIC, FONO_LIC, COMUNA_LIC, NCALLE_LIC, CALLE_LIC, CODOCU, ACTLAB, CODJORNADA, CODLICEN, FECEMI, FECINI_LIC, RUTFUN, VACLICF, VASILIC, VAANLIC, VAULLIC, VAMENU, MANT)
    Dim INLI3 As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(INLI3, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "INLI3")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.VALPROMCOT = INLI3("VALPROMCOT")
    Me.VALPROMLIQ = INLI3("VALPROMLIQ")
    Me.VALRECIBIR = INLI3("VALRECIBIR")
    Me.VALSUBSID = INLI3("VALSUBSID")
    Me.VALCOTIZA = INLI3("VALCOTIZA")
    Me.ANO_AVISO = INLI3("ANO_AVISO")
    Me.CODUSU = INLI3("CODUSU")
    Me.NUM_AVISO = INLI3("NUM_AVISO")
    Me.CODAREA = INLI3("CODAREA")
    Me.FECANTECED = INLI3("FECANTECED")
    Me.FEC_AVISO = INLI3("FEC_AVISO")
    Me.FECANT_LIC = INLI3("FECANT_LIC")
    Me.TIPLIC = INLI3("TIPLIC")
    Me.ESTLIC = INLI3("ESTLIC")
    Me.FECRECLIC = INLI3("FECRECLIC")
    Me.FECTER_CON = INLI3("FECTER_CON")
    Me.FECINI_CON = INLI3("FECINI_CON")
    Me.PRI_AMP = INLI3("PRI_AMP")
    Me.OBSER2 = INLI3("OBSER2")
    Me.OBSER1 = INLI3("OBSER1")
    Me.PERREMUN = INLI3("PERREMUN")
    Me.VALREMB = INLI3("VALREMB")
    Me.OBSERV_LIC = INLI3("OBSERV_LIC")
    Me.ESPECI = INLI3("ESPECI")
    Me.DIAGNO_LIC = INLI3("DIAGNO_LIC")
    Me.FECRESL = INLI3("FECRESL")
    Me.CODDIAG = INLI3("CODDIAG")
    Me.TIPSUB = INLI3("TIPSUB")
    Me.CODEST = INLI3("CODEST")
    Me.ACLARAM = INLI3("ACLARAM")
    Me.CORRELA = INLI3("CORRELA")
    Me.RESSSAL = INLI3("RESSSAL")
    Me.SERVSAL = INLI3("SERVSAL")
    Me.COMUNAM = INLI3("COMUNAM")
    Me.NUMEROM = INLI3("NUMEROM")
    Me.CALLEM = INLI3("CALLEM")
    Me.RUTHIJ = Trim(INLI3("RUTHIJ"))
    Me.RUTMED = Trim(INLI3("RUTMED"))
    Me.APEMATM = INLI3("APEMATM")
    Me.FONOMED = INLI3("FONOMED")
    Me.APEPATM = INLI3("APEPATM")
    Me.NOMMED_LIC = INLI3("NOMMED_LIC")
    Me.MESCON = INLI3("MESCON")
    Me.FECNAC = INLI3("FECNAC")
    Me.FECACC_LIC = INLI3("FECACC_LIC")
    Me.NRODIA_LIC = INLI3("NRODIA_LIC")
    Me.NUMLIC_DV = INLI3("NUMLIC_DV")
    Me.NUMLIC_LIC = INLI3("NUMLIC_LIC")
    Me.TIPMED = INLI3("TIPMED")
    Me.ACLARA_LIC = INLI3("ACLARA_LIC")
    Me.FONO_LIC = INLI3("FONO_LIC")
    Me.COMUNA_LIC = INLI3("COMUNA_LIC")
    Me.NCALLE_LIC = INLI3("NCALLE_LIC")
    Me.CALLE_LIC = INLI3("CALLE_LIC")
    Me.CODOCU = INLI3("CODOCU")
    Me.ACTLAB = INLI3("ACTLAB")
    Me.CODJORNADA = INLI3("CODJORNADA")
    Me.CODLICEN = INLI3("CODLICEN")
    Me.FECEMI = INLI3("FECEMI")
    Me.FECINI_LIC = INLI3("FECINI_LIC")
    Me.RUTFUN = Trim(INLI3("RUTFUN"))
    Me.VACLICF = INLI3("VACLICF")
    Me.VASILIC = INLI3("VASILIC")
    Me.VAANLIC = INLI3("VAANLIC")
    Me.VAULLIC = INLI3("VAULLIC")
    Me.VAMENU = INLI3("VAMENU")
    Me.MANT = INLI3("MANT")
    Me.GLOFUN = INLI3("GLOFUN")
    Me.CODFUN = INLI3("CODFUN")
    Me.CCOSMAIL = INLI3("CCOSMAIL")
    Me.GESTLIC = INLI3("GESTLIC")
    Me.GLOCOS = INLI3("GLOCOS")
    Me.CCOSTO = INLI3("CCOSTO")
    Me.VALH48 = INLI3("VALH48")
    Me.CON_TIP = INLI3("CON_TIP")
    Me.TIPCON = INLI3("TIPCON")
    Me.FEC1AFP = INLI3("FEC1AFP")
    Me.GCODISA = INLI3("GCODISA")
    Me.GTIPSUB = INLI3("GTIPSUB")
    Me.GCODEST = INLI3("GCODEST")
    Me.DIASAPAGO = INLI3("DIASAPAGO")
    Me.NRODIA_PAG = INLI3("NRODIA_PAG")
    Me.NRODIA_AUT = INLI3("NRODIA_AUT")
    Me.GTIPMED = INLI3("GTIPMED")
    Me.GCODOCU = INLI3("GCODOCU")
    Me.GACTLAB = INLI3("GACTLAB")
    Me.GLOJORNA = INLI3("GLOJORNA")
    Me.GLOTIPLIC = INLI3("GLOTIPLIC")
    Me.FINGSE_FUN = INLI3("FINGSE_FUN")
    Me.FECTER_LIC = INLI3("FECTER_LIC")
    Me.GLONOMBRE = INLI3("GLONOMBRE")

    Return Me

  End Function

End Class

