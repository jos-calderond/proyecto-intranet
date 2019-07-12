Imports slbaperbDll
Namespace Tipos
  Public Class oIANTP

#Region "Propiedades públicas"

    Public USUARIO As String = ""
    Public TELEFO_FUN As String = ""
    Public COMUNA_FUN As String = ""
    Public ACLARA_FUN As String = ""
    Public NCALLE_FUN As Integer = 0
    Public CALLE_FUN As String = ""
    Public MAIL_PER As String = ""
    Public NOMBRE_CON As String = ""
    Public TELEFO_CON As String = ""
    Public ACTIVO As String = ""
    Public MEDPAG As String = ""
    Public CTACTE As String = ""
    Public CODBANCO As String = ""
    Public RUTFUN As String = ""
    Public VAMENU As String = ""
    Public MANT As String = ""
    Public GESCOLARI As String = ""
    Public ESCOLARI As String = ""
    Public OBSERVA As String = ""
    Public FINGGA_FUN As Integer = 0
    Public FINGCA_FUN As Integer = 0
    Public FINGSE_FUN As Integer = 0
    Public FADMPU_FUN As Integer = 0
    Public FSERES_FUN As Integer = 0
    Public FEC1AFP As Integer = 0
    Public TIPPOLI As String = ""
    Public NROPOL2 As String = ""
    Public NROPOL As String = ""
    Public NROBIE_FUN As Integer = 0
    Public FECBIE_FUN As Integer = 0
    Public GHORARIO As String = ""
    Public GLOPROFE As String = ""
    Public CODPROFE As String = ""
    Public HORARIO As String = ""
    Public GCODISA As String = ""
    Public CODISA As Integer = 0
    Public MARCA_TAR As String = ""
    Public GCODAFP As String = ""
    Public CODAFP As Integer = 0
    Public GLOESTCIV As String = ""
    Public ESTCIV_FUN As String = ""
    Public GLOSEXO As String = ""
    Public SEXO As String = ""
    Public FECNAC_FUN As Integer = 0
    Public APEMAT_FUN As String = ""
    Public APEPAT_FUN As String = ""
    Public NOMBRE_FUN As String = ""
    Public GLOMEDPAG As String = ""
    Public GLOCODBAN As String = ""

#End Region

#Region "Constructores"

    Public Sub New()

    End Sub

    Private Sub __IspecToModel(ByVal Ispec As IANTP)

      Me.USUARIO = Ispec.USUARIO
      Me.TELEFO_FUN = Ispec.TELEFO_FUN
      Me.COMUNA_FUN = Ispec.COMUNA_FUN
      Me.ACLARA_FUN = Ispec.ACLARA_FUN
      Me.NCALLE_FUN = Ispec.NCALLE_FUN
      Me.CALLE_FUN = Ispec.CALLE_FUN
      Me.MAIL_PER = Ispec.MAIL_PER
      Me.NOMBRE_CON = Ispec.NOMBRE_CON
      Me.TELEFO_CON = Ispec.TELEFO_CON
      Me.ACTIVO = Ispec.ACTIVO
      Me.MEDPAG = Ispec.MEDPAG
      Me.CTACTE = Ispec.CTACTE
      Me.CODBANCO = Ispec.CODBANCO
      Me.RUTFUN = Ispec.RUTFUN
      Me.VAMENU = Ispec.VAMENU
      Me.MANT = Ispec.MANT
      Me.GESCOLARI = Ispec.GESCOLARI
      Me.ESCOLARI = Ispec.ESCOLARI
      Me.OBSERVA = Ispec.OBSERVA
      Me.FINGGA_FUN = Ispec.FINGGA_FUN
      Me.FINGCA_FUN = Ispec.FINGCA_FUN
      Me.FINGSE_FUN = Ispec.FINGSE_FUN
      Me.FADMPU_FUN = Ispec.FADMPU_FUN
      Me.FSERES_FUN = Ispec.FSERES_FUN
      Me.FEC1AFP = Ispec.FEC1AFP
      Me.TIPPOLI = Ispec.TIPPOLI
      Me.NROPOL2 = Ispec.NROPOL2
      Me.NROPOL = Ispec.NROPOL
      Me.NROBIE_FUN = Ispec.NROBIE_FUN
      Me.FECBIE_FUN = Ispec.FECBIE_FUN
      Me.GHORARIO = Ispec.GHORARIO
      Me.GLOPROFE = Ispec.GLOPROFE
      Me.CODPROFE = Ispec.CODPROFE
      Me.HORARIO = Ispec.HORARIO
      Me.GCODISA = Ispec.GCODISA
      Me.CODISA = Ispec.CODISA
      Me.MARCA_TAR = Ispec.MARCA_TAR
      Me.GCODAFP = Ispec.GCODAFP
      Me.CODAFP = Ispec.CODAFP
      Me.GLOESTCIV = Ispec.GLOESTCIV
      Me.ESTCIV_FUN = Ispec.ESTCIV_FUN
      Me.GLOSEXO = Ispec.GLOSEXO
      Me.SEXO = Ispec.SEXO
      Me.FECNAC_FUN = Ispec.FECNAC_FUN
      Me.APEMAT_FUN = Ispec.APEMAT_FUN
      Me.APEPAT_FUN = Ispec.APEPAT_FUN
      Me.NOMBRE_FUN = Ispec.NOMBRE_FUN
      Me.GLOMEDPAG = Ispec.GLOMEDPAG
      Me.GLOCODBAN = Ispec.GLOCODBAN

      
    End Sub
#End Region


#Region "Propiedades públicas"

#End Region
    Private Function __ModelToIspec() As IANTP
      Dim Ispec As New IANTP()
      Ispec.USUARIO = Me.USUARIO
      Ispec.TELEFO_FUN = Me.TELEFO_FUN
      Ispec.COMUNA_FUN = Me.COMUNA_FUN
      Ispec.ACLARA_FUN = Me.ACLARA_FUN
      Ispec.NCALLE_FUN = Me.NCALLE_FUN
      Ispec.CALLE_FUN = Me.CALLE_FUN
      Ispec.MAIL_PER = Me.MAIL_PER
      Ispec.NOMBRE_CON = Me.NOMBRE_CON
      Ispec.TELEFO_CON = Me.TELEFO_CON
      Ispec.ACTIVO = Me.ACTIVO
      Ispec.MEDPAG = Me.MEDPAG
      Ispec.CTACTE = Me.CTACTE
      Ispec.CODBANCO = Me.CODBANCO
      Ispec.RUTFUN = Me.RUTFUN
      Ispec.VAMENU = Me.VAMENU
      Ispec.MANT = Me.MANT
      Ispec.GESCOLARI = Me.GESCOLARI
      Ispec.ESCOLARI = Me.ESCOLARI
      Ispec.OBSERVA = Me.OBSERVA
      Ispec.FINGGA_FUN = Me.FINGGA_FUN
      Ispec.FINGCA_FUN = Me.FINGCA_FUN
      Ispec.FINGSE_FUN = Me.FINGSE_FUN
      Ispec.FADMPU_FUN = Me.FADMPU_FUN
      Ispec.FSERES_FUN = Me.FSERES_FUN
      Ispec.FEC1AFP = Me.FEC1AFP
      Ispec.TIPPOLI = Me.TIPPOLI
      Ispec.NROPOL2 = Me.NROPOL2
      Ispec.NROPOL = Me.NROPOL
      Ispec.NROBIE_FUN = Me.NROBIE_FUN
      Ispec.FECBIE_FUN = Me.FECBIE_FUN
      Ispec.GHORARIO = Me.GHORARIO
      Ispec.GLOPROFE = Me.GLOPROFE
      Ispec.CODPROFE = Me.CODPROFE
      Ispec.HORARIO = Me.HORARIO
      Ispec.GCODISA = Me.GCODISA
      Ispec.CODISA = Me.CODISA
      Ispec.MARCA_TAR = Me.MARCA_TAR
      Ispec.GCODAFP = Me.GCODAFP
      Ispec.CODAFP = Me.CODAFP
      Ispec.GLOESTCIV = Me.GLOESTCIV
      Ispec.ESTCIV_FUN = Me.ESTCIV_FUN
      Ispec.GLOSEXO = Me.GLOSEXO
      Ispec.SEXO = Me.SEXO
      Ispec.FECNAC_FUN = Me.FECNAC_FUN
      Ispec.APEMAT_FUN = Me.APEMAT_FUN
      Ispec.APEPAT_FUN = Me.APEPAT_FUN
      Ispec.NOMBRE_FUN = Me.NOMBRE_FUN
      Ispec.GLOMEDPAG = Me.GLOMEDPAG
      Ispec.GLOCODBAN = Me.GLOCODBAN
      Return Ispec
    End Function
    Public Sub consultar(USUARIO, TELEFO_FUN, COMUNA_FUN, ACLARA_FUN, NCALLE_FUN, CALLE_FUN, MAIL_PER, NOMBRE_CON, TELEFO_CON, ACTIVO, MEDPAG, CTACTE, CODBANCO, RUTFUN, VAMENU, MANT)
      Dim Ispec As New IANTP()
      Ispec.MANT = "INQ"
      Ispec.USUARIO = USUARIO
      Ispec.TELEFO_FUN = TELEFO_FUN
      Ispec.COMUNA_FUN = COMUNA_FUN
      Ispec.ACLARA_FUN = ACLARA_FUN
      Ispec.NCALLE_FUN = NCALLE_FUN
      Ispec.CALLE_FUN = CALLE_FUN
      Ispec.MAIL_PER = MAIL_PER
      Ispec.NOMBRE_CON = NOMBRE_CON
      Ispec.TELEFO_CON = TELEFO_CON
      Ispec.ACTIVO = ACTIVO
      Ispec.MEDPAG = MEDPAG
      Ispec.CTACTE = CTACTE
      Ispec.CODBANCO = CODBANCO
      Ispec.RUTFUN = RUTFUN
      Ispec.VAMENU = VAMENU
      Ispec.MANT = MANT
      __IspecToModel(Me.__callIspec(Ispec))
    End Sub

    Public Sub consultaMasiva(ByVal RUTFUN As String, ByVal VAMENU As String)
      Dim Ispec As New IANTP()
      Ispec.MANT = "INQ"
      Ispec.RUTFUN = RUTFUN
      Ispec.VAMENU = VAMENU
      __IspecToModel(Me.__callIspec(Ispec))
    End Sub

    Public Sub agregar()
      Dim Ispec As IANTP = Me.__ModelToIspec
      Ispec.MANT = "ADD"
      Me.__IspecToModel(Me.__callIspec(Ispec))
    End Sub
    Public Sub modificar()
      Dim Ispec As IANTP = Me.__ModelToIspec
      Ispec.MANT = "CHG"
      Me.__IspecToModel(Me.__callIspec(Ispec))
    End Sub
    Public Sub borrar(USUARIO, TELEFO_FUN, COMUNA_FUN, ACLARA_FUN, NCALLE_FUN, CALLE_FUN, MAIL_PER, NOMBRE_CON, TELEFO_CON, ACTIVO, MEDPAG, CTACTE, CODBANCO, RUTFUN, VAMENU, MANT)
      Dim Ispec As New IANTP()
      Ispec.MANT = "DEL"
      Ispec.USUARIO = USUARIO
      Ispec.TELEFO_FUN = TELEFO_FUN
      Ispec.COMUNA_FUN = COMUNA_FUN
      Ispec.ACLARA_FUN = ACLARA_FUN
      Ispec.NCALLE_FUN = NCALLE_FUN
      Ispec.CALLE_FUN = CALLE_FUN
      Ispec.MAIL_PER = MAIL_PER
      Ispec.NOMBRE_CON = NOMBRE_CON
      Ispec.TELEFO_CON = TELEFO_CON
      Ispec.ACTIVO = ACTIVO
      Ispec.MEDPAG = MEDPAG
      Ispec.CTACTE = CTACTE
      Ispec.CODBANCO = CODBANCO
      Ispec.RUTFUN = RUTFUN
      Ispec.VAMENU = VAMENU
      Ispec.MANT = MANT
      Me.__callIspec(Ispec)
    End Sub
    Private Function __callIspec(ByVal Ispec As IANTP) As IANTP
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

