Imports slbaperbDll

Namespace Tipos

  ''' <summary>
  ''' 03/06/2019 rtorreblanca: creación.
  ''' </summary>
  ''' <remarks></remarks>
  Public Class oINLI3

#Region "Propiedades públicas"

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
#End Region
#Region "Constructores"

    Public Sub New()
    End Sub

    Private Sub __IspecToModel(ByVal Ispec As INLI3)

      Me.VALPROMCOT = Ispec.VALPROMCOT
      Me.VALPROMLIQ = Ispec.VALPROMLIQ
      Me.VALRECIBIR = Ispec.VALRECIBIR
      Me.VALSUBSID = Ispec.VALSUBSID
      Me.VALCOTIZA = Ispec.VALCOTIZA
      Me.ANO_AVISO = Ispec.ANO_AVISO
      Me.CODUSU = Ispec.CODUSU
      Me.NUM_AVISO = Ispec.NUM_AVISO
      Me.CODAREA = Ispec.CODAREA
      Me.FECANTECED = Ispec.FECANTECED
      Me.FEC_AVISO = Ispec.FEC_AVISO
      Me.FECANT_LIC = Ispec.FECANT_LIC
      Me.TIPLIC = Ispec.TIPLIC
      Me.ESTLIC = Ispec.ESTLIC
      Me.FECRECLIC = Ispec.FECRECLIC
      Me.FECTER_CON = Ispec.FECTER_CON
      Me.FECINI_CON = Ispec.FECINI_CON
      Me.PRI_AMP = Ispec.PRI_AMP
      Me.OBSER2 = Ispec.OBSER2
      Me.OBSER1 = Ispec.OBSER1
      Me.PERREMUN = Ispec.PERREMUN
      Me.VALREMB = Ispec.VALREMB
      Me.OBSERV_LIC = Ispec.OBSERV_LIC
      Me.ESPECI = Ispec.ESPECI
      Me.DIAGNO_LIC = Ispec.DIAGNO_LIC
      Me.FECRESL = Ispec.FECRESL
      Me.CODDIAG = Ispec.CODDIAG
      Me.TIPSUB = Ispec.TIPSUB
      Me.CODEST = Ispec.CODEST
      Me.ACLARAM = Ispec.ACLARAM
      Me.CORRELA = Ispec.CORRELA
      Me.RESSSAL = Ispec.RESSSAL
      Me.SERVSAL = Ispec.SERVSAL
      Me.COMUNAM = Ispec.COMUNAM
      Me.NUMEROM = Ispec.NUMEROM
      Me.CALLEM = Ispec.CALLEM
      Me.RUTHIJ = Ispec.RUTHIJ
      Me.RUTMED = Ispec.RUTMED
      Me.APEMATM = Ispec.APEMATM
      Me.FONOMED = Ispec.FONOMED
      Me.APEPATM = Ispec.APEPATM
      Me.NOMMED_LIC = Ispec.NOMMED_LIC
      Me.MESCON = Ispec.MESCON
      Me.FECNAC = Ispec.FECNAC
      Me.FECACC_LIC = Ispec.FECACC_LIC
      Me.NRODIA_LIC = Ispec.NRODIA_LIC
      Me.NUMLIC_DV = Ispec.NUMLIC_DV
      Me.NUMLIC_LIC = Ispec.NUMLIC_LIC
      Me.TIPMED = Ispec.TIPMED
      Me.ACLARA_LIC = Ispec.ACLARA_LIC
      Me.FONO_LIC = Ispec.FONO_LIC
      Me.COMUNA_LIC = Ispec.COMUNA_LIC
      Me.NCALLE_LIC = Ispec.NCALLE_LIC
      Me.CALLE_LIC = Ispec.CALLE_LIC
      Me.CODOCU = Ispec.CODOCU
      Me.ACTLAB = Ispec.ACTLAB
      Me.CODJORNADA = Ispec.CODJORNADA
      Me.CODLICEN = Ispec.CODLICEN
      Me.FECEMI = Ispec.FECEMI
      Me.FECINI_LIC = Ispec.FECINI_LIC
      Me.RUTFUN = Ispec.RUTFUN
      Me.VACLICF = Ispec.VACLICF
      Me.VASILIC = Ispec.VASILIC
      Me.VAANLIC = Ispec.VAANLIC
      Me.VAULLIC = Ispec.VAULLIC
      Me.VAMENU = Ispec.VAMENU
      Me.MANT = Ispec.MANT
      Me.GLOFUN = Ispec.GLOFUN
      Me.CODFUN = Ispec.CODFUN
      Me.CCOSMAIL = Ispec.CCOSMAIL
      Me.GESTLIC = Ispec.GESTLIC
      Me.GLOCOS = Ispec.GLOCOS
      Me.CCOSTO = Ispec.CCOSTO
      Me.VALH48 = Ispec.VALH48
      Me.CON_TIP = Ispec.CON_TIP
      Me.TIPCON = Ispec.TIPCON
      Me.FEC1AFP = Ispec.FEC1AFP
      Me.GCODISA = Ispec.GCODISA
      Me.GTIPSUB = Ispec.GTIPSUB
      Me.GCODEST = Ispec.GCODEST
      Me.DIASAPAGO = Ispec.DIASAPAGO
      Me.NRODIA_PAG = Ispec.NRODIA_PAG
      Me.NRODIA_AUT = Ispec.NRODIA_AUT
      Me.GTIPMED = Ispec.GTIPMED
      Me.GCODOCU = Ispec.GCODOCU
      Me.GACTLAB = Ispec.GACTLAB
      Me.GLOJORNA = Ispec.GLOJORNA
      Me.GLOTIPLIC = Ispec.GLOTIPLIC
      Me.FINGSE_FUN = Ispec.FINGSE_FUN
      Me.FECTER_LIC = Ispec.FECTER_LIC
      Me.GLONOMBRE = Ispec.GLONOMBRE


    End Sub

#End Region

#Region "Propiedades públicas"

#End Region

    Private Function __ModelToIspec() As INLI3

      Dim Ispec As New INLI3()

      Ispec.VALPROMCOT = Me.VALPROMCOT
      Ispec.VALPROMLIQ = Me.VALPROMLIQ
      Ispec.VALRECIBIR = Me.VALRECIBIR
      Ispec.VALSUBSID = Me.VALSUBSID
      Ispec.VALCOTIZA = Me.VALCOTIZA
      Ispec.ANO_AVISO = Me.ANO_AVISO
      Ispec.CODUSU = Me.CODUSU
      Ispec.NUM_AVISO = Me.NUM_AVISO
      Ispec.CODAREA = Me.CODAREA
      Ispec.FECANTECED = Me.FECANTECED
      Ispec.FEC_AVISO = Me.FEC_AVISO
      Ispec.FECANT_LIC = Me.FECANT_LIC
      Ispec.TIPLIC = Me.TIPLIC
      Ispec.ESTLIC = Me.ESTLIC
      Ispec.FECRECLIC = Me.FECRECLIC
      Ispec.FECTER_CON = Me.FECTER_CON
      Ispec.FECINI_CON = Me.FECINI_CON
      Ispec.PRI_AMP = Me.PRI_AMP
      Ispec.OBSER2 = Me.OBSER2
      Ispec.OBSER1 = Me.OBSER1
      Ispec.PERREMUN = Me.PERREMUN
      Ispec.VALREMB = Me.VALREMB
      Ispec.OBSERV_LIC = Me.OBSERV_LIC
      Ispec.ESPECI = Me.ESPECI
      Ispec.DIAGNO_LIC = Me.DIAGNO_LIC
      Ispec.FECRESL = Me.FECRESL
      Ispec.CODDIAG = Me.CODDIAG
      Ispec.TIPSUB = Me.TIPSUB
      Ispec.CODEST = Me.CODEST
      Ispec.ACLARAM = Me.ACLARAM
      Ispec.CORRELA = Me.CORRELA
      Ispec.RESSSAL = Me.RESSSAL
      Ispec.SERVSAL = Me.SERVSAL
      Ispec.COMUNAM = Me.COMUNAM
      Ispec.NUMEROM = Me.NUMEROM
      Ispec.CALLEM = Me.CALLEM
      Ispec.RUTHIJ = Me.RUTHIJ
      Ispec.RUTMED = Me.RUTMED
      Ispec.APEMATM = Me.APEMATM
      Ispec.FONOMED = Me.FONOMED
      Ispec.APEPATM = Me.APEPATM
      Ispec.NOMMED_LIC = Me.NOMMED_LIC
      Ispec.MESCON = Me.MESCON
      Ispec.FECNAC = Me.FECNAC
      Ispec.FECACC_LIC = Me.FECACC_LIC
      Ispec.NRODIA_LIC = Me.NRODIA_LIC
      Ispec.NUMLIC_DV = Me.NUMLIC_DV
      Ispec.NUMLIC_LIC = Me.NUMLIC_LIC
      Ispec.TIPMED = Me.TIPMED
      Ispec.ACLARA_LIC = Me.ACLARA_LIC
      Ispec.FONO_LIC = Me.FONO_LIC
      Ispec.COMUNA_LIC = Me.COMUNA_LIC
      Ispec.NCALLE_LIC = Me.NCALLE_LIC
      Ispec.CALLE_LIC = Me.CALLE_LIC
      Ispec.CODOCU = Me.CODOCU
      Ispec.ACTLAB = Me.ACTLAB
      Ispec.CODJORNADA = Me.CODJORNADA
      Ispec.CODLICEN = Me.CODLICEN
      Ispec.FECEMI = Me.FECEMI
      Ispec.FECINI_LIC = Me.FECINI_LIC
      Ispec.RUTFUN = Me.RUTFUN
      Ispec.VACLICF = Me.VACLICF
      Ispec.VASILIC = Me.VASILIC
      Ispec.VAANLIC = Me.VAANLIC
      Ispec.VAULLIC = Me.VAULLIC
      Ispec.VAMENU = Me.VAMENU
      Ispec.MANT = Me.MANT
      Ispec.GLOFUN = Me.GLOFUN
      Ispec.CODFUN = Me.CODFUN
      Ispec.CCOSMAIL = Me.CCOSMAIL
      Ispec.GESTLIC = Me.GESTLIC
      Ispec.GLOCOS = Me.GLOCOS
      Ispec.CCOSTO = Me.CCOSTO
      Ispec.VALH48 = Me.VALH48
      Ispec.CON_TIP = Me.CON_TIP
      Ispec.TIPCON = Me.TIPCON
      Ispec.FEC1AFP = Me.FEC1AFP
      Ispec.GCODISA = Me.GCODISA
      Ispec.GTIPSUB = Me.GTIPSUB
      Ispec.GCODEST = Me.GCODEST
      Ispec.DIASAPAGO = Me.DIASAPAGO
      Ispec.NRODIA_PAG = Me.NRODIA_PAG
      Ispec.NRODIA_AUT = Me.NRODIA_AUT
      Ispec.GTIPMED = Me.GTIPMED
      Ispec.GCODOCU = Me.GCODOCU
      Ispec.GACTLAB = Me.GACTLAB
      Ispec.GLOJORNA = Me.GLOJORNA
      Ispec.GLOTIPLIC = Me.GLOTIPLIC
      Ispec.FINGSE_FUN = Me.FINGSE_FUN
      Ispec.FECTER_LIC = Me.FECTER_LIC
      Ispec.GLONOMBRE = Me.GLONOMBRE

      Return Ispec

    End Function

        Public Sub consultar(RUTFUN, NUMLIC)

            Dim Ispec As New INLI3()

            Ispec.MANT = "INQ"
            Ispec.NUMLIC_LIC = NUMLIC
            Ispec.RUTFUN = Trim(RUTFUN).Replace(".", "").PadLeft(10, " ")

            __IspecToModel(Me.__callIspec(Ispec))

        End Sub

    Public Sub agregar()

      Dim Ispec As INLI3 = Me.__ModelToIspec
      Ispec.MANT = "ADD"

      Me.__IspecToModel(Me.__callIspec(Ispec))

    End Sub

    Public Sub modificar()

      Dim Ispec As INLI3 = Me.__ModelToIspec
      Ispec.MANT = "CHG"

      Me.__IspecToModel(Me.__callIspec(Ispec))

    End Sub


    Private Function __callIspec(ByVal Ispec As INLI3) As INLI3

      Try
        Return Ispec.CallIspec()
      Catch ex As MCPResponseException
        Throw New Exception(ex.getMessage)
      Catch ex As WSRequestException
        Throw New Exception(ex.getMessage())
      Catch ex As InvalidTokenException
        Throw New Exception(ex.getMessage())
      End Try

    End Function

  End Class

End Namespace

