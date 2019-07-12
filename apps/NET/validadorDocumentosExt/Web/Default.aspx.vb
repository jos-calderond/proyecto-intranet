Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

''' <summary>
''' 14/05/2019 croman: Se agrega información de junta.
''' 04/07/2019 croman: Se utilizan strings desde web.config.
''' </summary>
''' <remarks></remarks>
Partial Class _Default

  Inherits System.Web.UI.Page

  Public miFTP As FTP

  Public scriptVersion As Integer = Integer.Parse(ConfigurationManager.AppSettings("script.version"))
  Private __rutaMapping As String = ConfigurationManager.AppSettings("rutaMapping")
  Private __servidorFtp As String = ConfigurationManager.AppSettings("servidorFtp")
  Private __directorioFtp As String = ConfigurationManager.AppSettings("directorioFtp")
  Private __certAntiguedadFtp As String = ConfigurationManager.AppSettings("FtpCertAntiguedad")
  Private __certAntiguedadRentaFtp As String = ConfigurationManager.AppSettings("FtpCertAntiguedadRenta")
  Private __rutaFtp As String = ConfigurationManager.AppSettings("rutaFtp")
  Private __usuarioFtp As String = ConfigurationManager.AppSettings("usuarioFtp")
  Private __passwordFtp As String = ConfigurationManager.AppSettings("passwordFtp")
  Private __recaptcha As String = ConfigurationManager.AppSettings("recaptcha")
  Private __rutaPdfLiquidaciones As String = ConfigurationManager.AppSettings("rutaPdfLiquidaciones")
  Private __rutaPdfAntiguedad As String = ConfigurationManager.AppSettings("rutaPdfAntiguedad")
  Private __rutaPdfAntiguedadRenta As String = ConfigurationManager.AppSettings("rutaPdfAntiguedadRenta")

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    PageTitle.InnerHtml = ConfigurationManager.AppSettings("sistemaNombre").ToString()
    bSistemaNombre.InnerHtml = ConfigurationManager.AppSettings("sistemaNombre").ToString()

  End Sub

  Protected Sub btnConsultarClick(ByVal sender As Object, ByVal e As System.EventArgs)
    If Page.IsValid Then
      If Me.txtCodigo.Value = "" Then
        __alerta("Debe Ingresar Número de Documento")
        'ElseIf captchaValido() = False Then
        '  __alerta("Debe Completar Captcha")
      Else
        Try
          Dim ws = New WS_FirmaDigital.Service()
          Dim valida = Me.txtCodigo.Value
          Dim respuesta = ws.CodigoValidador(valida, "DEC")
          Dim nombre = respuesta.WS_Codigo.ToString()
          Dim path As String = nombre + ".pdf"
          Dim carpeta = nombre.Substring(8, 6)

          miFTP = New FTP(__servidorFtp & __rutaFtp, __usuarioFtp, __passwordFtp)

          Dim lista As List(Of String)

          lista = miFTP.fileList(__directorioFtp & "/" & carpeta)

          For Each valor In lista
            If valor = path Then
              Response.Redirect(__rutaPdfLiquidaciones & "/" & carpeta & "/" + path) 

            End If
          Next

          miFTP = New FTP(__servidorFtp & __rutaFtp, __usuarioFtp, __passwordFtp)


          lista = miFTP.fileList(__certAntiguedadFtp & "/" & carpeta)

          For Each valor In lista
            If valor = path Then
              Response.Redirect(__rutaPdfAntiguedad & "/" & carpeta & "/" + path)
            End If
          Next

          miFTP = New FTP(__servidorFtp & __rutaFtp, __usuarioFtp, __passwordFtp)


          lista = miFTP.fileList(__certAntiguedadRentaFtp & "/" & carpeta)

          For Each valor In lista
            If valor = path Then
              Response.Redirect(__rutaPdfAntiguedadRenta & "/" & carpeta & "/" + path)
            End If
          Next

          __alerta("El Certificado No Tiene Registro")

        Catch ex As Exception

          Me.txtCodigo.Value = ""
          __onError(ex.Message)
          Exit Sub

        End Try

      End If

    End If

  End Sub

  Public Function captchaValido() As Boolean

    Dim Response As String = Request.Form("g-recaptcha-response")
    Dim Valid As Boolean = False
    Dim req As HttpWebRequest = DirectCast(WebRequest.Create(__recaptcha & "&response=" & Response), HttpWebRequest)

    Try
      Using wResponse As WebResponse = req.GetResponse()

        Using readStream As New StreamReader(wResponse.GetResponseStream())

          Dim jsonResponse As String = readStream.ReadToEnd()
          Dim js As New JavaScriptSerializer()
          Dim data As MyObject = js.Deserialize(Of MyObject)(jsonResponse)

          Valid = Convert.ToBoolean(data.success)

          Return Valid

        End Using

      End Using

    Catch ex As Exception

      Return False

    End Try

  End Function

  Public Class MyObject
    Public Property success() As String
      Get
        Return m_success
      End Get
      Set(value As String)
        m_success = value
      End Set
    End Property
    Private m_success As String
  End Class

  Private Sub __onError(ByVal strError As String)

    Me.lblDialogTitulo.Text = "Error"
    Me.lblDialogMsg.Text = strError
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "error", "<script>$('#dialogo').modal('show');</script>")

  End Sub

  Private Sub __alerta(ByVal strAlerta As String)

    Me.lblDialogTitulo2.Text = "Alerta"
    Me.lblDialogMsg2.Text = strAlerta
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "Alerta", "<script>$('#dialogo2').modal('show');</script>")

  End Sub

End Class
