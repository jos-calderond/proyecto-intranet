Imports slbaperbDll

Namespace Tipos
  Public Class oICERW
#Region "Atributos públicos"

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
#End Region

#Region "Constructores"
    Sub New()
    End Sub

    Private Sub __IspecToModel(ByVal Ispec As ICERW)

      Me.NUMCERT = Ispec.NUMCERT
      Me.CARGOJEFE = Ispec.CARGOJEFE
      Me.NOMBREJEF = Ispec.NOMBREJEF
      Me.CARGOFUN = Ispec.CARGOFUN
      Me.MESREM = Ispec.MESREM
      Me.ANOREM = Ispec.ANOREM
      Me.SEXO = Ispec.SEXO
      Me.APEMATFUN = Ispec.APEMATFUN
      Me.APEPATFUN = Ispec.APEPATFUN
      Me.NOMBREFUN = Ispec.NOMBREFUN
      Me.ANO_C = Ispec.ANO_C
      Me.SECMOV_C = Ispec.SECMOV_C
      Me.SECUN_C = Ispec.SECUN_C
      Me.RUTFUN_C = Ispec.RUTFUN_C
      Me.TIPOCER_C = Ispec.TIPOCER_C
      Me.MANT = Ispec.MANT
      Me.VARIOS_P = Ispec.VARIOS_P
      Me.CODAREA_P = Ispec.CODAREA_P
      Me.ESTA_P = Ispec.ESTA_P
      Me.TCONTRA_P = Ispec.TCONTRA_P
      Me.TIPOCON_P = Ispec.TIPOCON_P
      Me.TIPPAGO_P = Ispec.TIPPAGO_P
      Me.CCOSTO_P = Ispec.CCOSTO_P
      Me.FTERCON_P = Ispec.FTERCON_P
      Me.FINICON_P = Ispec.FINICON_P
      Me.SEC_MOV_P = Ispec.SEC_MOV_P
      Me.SEC_CON_P = Ispec.SEC_CON_P
      Me.GCCOSTO_P = Ispec.GCCOSTO_P
      Me.TIPOFUN_P = Ispec.TIPOFUN_P
      Me.FINGCORP = Ispec.FINGCORP
      Me.FINGSER = Ispec.FINGSER
      Me.NUMBIE = Ispec.NUMBIE
      Me.VARIOS = Ispec.VARIOS
      Me.CENTROCOST = Ispec.CENTROCOST
      Me.TIPOFUN = Ispec.TIPOFUN
      Me.TIPO_PAGO = Ispec.TIPO_PAGO
      Me.TCONTRA = Ispec.TCONTRA
      Me.ESTA = Ispec.ESTA
      Me.TIPOCON = Ispec.TIPOCON
      Me.FECTERCON = Ispec.FECTERCON
      Me.FECINICON = Ispec.FECINICON

    End Sub

    Private Function __ModelToIspec() As ICERW

      Dim Ispec As New ICERW()

      Ispec.CARGOJEFE = Me.CARGOJEFE
      Ispec.NUMCERT = Me.NUMCERT
      Ispec.NOMBREJEF = Me.NOMBREJEF
      Ispec.CARGOFUN = Me.CARGOFUN
      Ispec.MESREM = Me.MESREM
      Ispec.ANOREM = Me.ANOREM
      Ispec.SEXO = Me.SEXO
      Ispec.APEMATFUN = Me.APEMATFUN
      Ispec.APEPATFUN = Me.APEPATFUN
      Ispec.NOMBREFUN = Me.NOMBREFUN
      Ispec.ANO_C = Me.ANO_C
      Ispec.SECMOV_C = Me.SECMOV_C
      Ispec.SECUN_C = Me.SECUN_C
      Ispec.RUTFUN_C = Me.RUTFUN_C
      Ispec.TIPOCER_C = Me.TIPOCER_C
      Ispec.MANT = Me.MANT
      Ispec.VARIOS_P = Me.VARIOS_P
      Ispec.CODAREA_P = Me.CODAREA_P
      Ispec.ESTA_P = Me.ESTA_P
      Ispec.TCONTRA_P = Me.TCONTRA_P
      Ispec.TIPOCON_P = Me.TIPOCON_P
      Ispec.TIPPAGO_P = Me.TIPPAGO_P
      Ispec.CCOSTO_P = Me.CCOSTO_P
      Ispec.FTERCON_P = Me.FTERCON_P
      Ispec.FINICON_P = Me.FINICON_P
      Ispec.SEC_MOV_P = Me.SEC_MOV_P
      Ispec.SEC_CON_P = Me.SEC_CON_P
      Ispec.GCCOSTO_P = Me.GCCOSTO_P
      Ispec.TIPOFUN_P = Me.TIPOFUN_P
      Ispec.FINGCORP = Me.FINGCORP
      Ispec.FINGSER = Me.FINGSER
      Ispec.NUMBIE = Me.NUMBIE
      Ispec.VARIOS = Me.VARIOS
      Ispec.CENTROCOST = Me.CENTROCOST
      Ispec.TIPOFUN = Me.TIPOFUN
      Ispec.TIPO_PAGO = Me.TIPO_PAGO
      Ispec.TCONTRA = Me.TCONTRA
      Ispec.ESTA = Me.ESTA
      Ispec.TIPOCON = Me.TIPOCON
      Ispec.FECTERCON = Me.FECTERCON
      Ispec.FECINICON = Me.FECINICON

      Return Ispec

    End Function

    Friend Sub New(ByVal miICERWCFType As ICERW.CFType)
      VARIOS = miICERWCFType.VARIOS
      CENTROCOST = miICERWCFType.CENTROCOST
      TIPOFUN = miICERWCFType.TIPOFUN
      TIPO_PAGO = miICERWCFType.TIPO_PAGO
      TCONTRA = miICERWCFType.TCONTRA
      ESTA = miICERWCFType.ESTA
      TIPOCON = miICERWCFType.TIPOCON
      FECTERCON = miICERWCFType.FECTERCON
      FECINICON = miICERWCFType.FECINICON
      NUMCERT = miICERWCFType.NUMCERT
    End Sub
#End Region

#Region "Métodos privados"
    Private Function __callIspec(ByVal Ispec As ICERW) As List(Of ICERW.CFType)
      Try
        Return Ispec.CallIspec().CF
      Catch ex As MCPResponseException
        Throw New Exception(ex.getMessage)
      Catch ex As WSRequestException
        Throw New Exception(ex.getMessage())
      Catch ex As InvalidTokenException
        Throw New Exception(ex.getMessage())
      End Try
    End Function

    Private Function __callIspecInquiry(ByVal Ispec As ICERW) As ICERW
      Try
        Return Ispec.CallIspecInquiry()
      Catch ex As MCPResponseException
        Throw New Exception(ex.getMessage)
      Catch ex As WSRequestException
        Throw New Exception(ex.getMessage())
      Catch ex As InvalidTokenException
        Throw New Exception(ex.getMessage())
      End Try
    End Function
#End Region

#Region "Métodos públicos"
    Public Function consultaMasiva(ByVal RUTFUN_C As String) As List(Of oICERW)

      Dim miICERW As New ICERW()
      Dim lista As New List(Of oICERW)

      miICERW.RUTFUN_C = RUTFUN_C
      miICERW.MANT = "INQ"

      For Each reg As ICERW.CFType In Me.__callIspec(miICERW)
        lista.Add(New oICERW(reg))
      Next

      Return lista

    End Function

    Public Sub agregar(ByVal RUTFUN_C As String, ByVal ANO_C As String, ByVal TIPOCER_C As String, ByVal NUMCERT As String)

      Dim milspec As ICERW = Me.__ModelToIspec

      milspec.RUTFUN_C = RUTFUN_C
      milspec.ANO_C = ANO_C
      milspec.TIPOCER_C = TIPOCER_C
      milspec.NUMCERT = NUMCERT
      milspec.MANT = "ADD"

      __IspecToModel(Me.__callIspecInquiry(milspec))

    End Sub

    Public Sub consultar(ByVal RUTFUN_C As String, ByVal ANO_C As String)

      Dim miIspec As New ICERW()
      miIspec.ANO_C = ANO_C
      miIspec.RUTFUN_C = RUTFUN_C
      miIspec.MANT = "INQ"

      __IspecToModel(Me.__callIspecInquiry(miIspec))

    End Sub


#End Region
  End Class
End Namespace

