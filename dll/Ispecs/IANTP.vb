Imports System.Web.Script.Serialization

Public Class IANTP
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

  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Sub New()

  End Sub
  Public Function CallIspec() As IANTP

    Dim ISPEC As String = WebService.IANTP(USUARIO, TELEFO_FUN, COMUNA_FUN, ACLARA_FUN, NCALLE_FUN, CALLE_FUN, MAIL_PER,NOMBRE_CON,TELEFO_CON,ACTIVO,MEDPAG,CTACTE,CODBANCO,RUTFUN,VAMENU,MANT)

    Dim IANTP As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(IANTP, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "IANTP")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.USUARIO = IANTP("USUARIO")
    Me.TELEFO_FUN = IANTP("TELEFO_FUN")
    Me.COMUNA_FUN = IANTP("COMUNA_FUN")
    Me.ACLARA_FUN = IANTP("ACLARA_FUN")
    Me.NCALLE_FUN = IANTP("NCALLE_FUN")
    Me.CALLE_FUN = IANTP("CALLE_FUN")
    Me.MAIL_PER = IANTP("MAIL_PER")
    Me.NOMBRE_CON = IANTP("NOMBRE_CON")
    Me.TELEFO_CON = IANTP("TELEFO_CON")
    Me.ACTIVO = IANTP("ACTIVO")
    Me.MEDPAG = IANTP("MEDPAG")
    Me.CTACTE = IANTP("CTACTE")
    Me.CODBANCO = IANTP("CODBANCO")
    Me.RUTFUN = IANTP("RUTFUN")
    Me.VAMENU = IANTP("VAMENU")
    Me.MANT = IANTP("MANT")
    Me.GESCOLARI = IANTP("GESCOLARI")
    Me.ESCOLARI = IANTP("ESCOLARI")
    Me.OBSERVA = IANTP("OBSERVA")
    Me.FINGGA_FUN = IANTP("FINGGA_FUN")
    Me.FINGCA_FUN = IANTP("FINGCA_FUN")
    Me.FINGSE_FUN = IANTP("FINGSE_FUN")
    Me.FADMPU_FUN = IANTP("FADMPU_FUN")
    Me.FSERES_FUN = IANTP("FSERES_FUN")
    Me.FEC1AFP = IANTP("FEC1AFP")
    Me.TIPPOLI = IANTP("TIPPOLI")
    Me.NROPOL2 = IANTP("NROPOL2")
    Me.NROPOL = IANTP("NROPOL")
    Me.NROBIE_FUN = IANTP("NROBIE_FUN")
    Me.FECBIE_FUN = IANTP("FECBIE_FUN")
    Me.GHORARIO = IANTP("GHORARIO")
    Me.GLOPROFE = IANTP("GLOPROFE")
    Me.CODPROFE = IANTP("CODPROFE")
    Me.HORARIO = IANTP("HORARIO")
    Me.GCODISA = IANTP("GCODISA")
    Me.CODISA = IANTP("CODISA")
    Me.MARCA_TAR = IANTP("MARCA_TAR")
    Me.GCODAFP = IANTP("GCODAFP")
    Me.CODAFP = IANTP("CODAFP")
    Me.GLOESTCIV = IANTP("GLOESTCIV")
    Me.ESTCIV_FUN = IANTP("ESTCIV_FUN")
    Me.GLOSEXO = IANTP("GLOSEXO")
    Me.SEXO = IANTP("SEXO")
    Me.FECNAC_FUN = IANTP("FECNAC_FUN")
    Me.APEMAT_FUN = IANTP("APEMAT_FUN")
    Me.APEPAT_FUN = IANTP("APEPAT_FUN")
    Me.NOMBRE_FUN = IANTP("NOMBRE_FUN")
    Me.GLOMEDPAG = IANTP("GLOMEDPAG")
    Me.GLOCODBAN = IANTP("GLOCODBAN")

    Return Me

  End Function

End Class

