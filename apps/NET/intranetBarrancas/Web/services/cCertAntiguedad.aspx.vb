Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization
Imports System.IO
Imports Ws_Validador

''' <summary>
''' 12/06/2019 jcalderón: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class cCertAntiguedad
  Inherits System.Web.UI.Page

  Private __pagina As String = "../services/cCertAntiguedad.aspx"
  Private __js As New JavaScriptSerializer
  Private __miPDF As PDF
  Private __rutaMapping As String = ConfigurationManager.AppSettings("rutaMapping")
  Private __servidorFtp As String = ConfigurationManager.AppSettings("servidorFtp")
  Private __rutaFtp As String = ConfigurationManager.AppSettings("rutaFtpLaboral")
  Private __usuarioFtp As String = ConfigurationManager.AppSettings("usuarioFtp")
  Private __passwordFtp As String = ConfigurationManager.AppSettings("passwordFtp")
  Private __miFTP As FTP

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    Try
      ' Control de acceso.
      Dim caller As String = HttpContext.Current.Request.ServerVariables("HTTP_REFERER")
      If caller Is Nothing Then
        Throw New Exception("Acceso no autorizado.")
        Exit Sub
      Else
        If Not caller.Contains("/pages/frm") Then
          Throw New Exception("Acceso no autorizado.")
          Exit Sub
        End If
      End If

      ' Control de sesión
      If Session("Usuario.Rut") Is Nothing Then
        Throw New Exception("Sesión caducada.")
      End If

      Dim accion = Request.QueryString("accion")
      If (accion = "") Then
        accion = Request.Form("accion")
      End If

      Select accion

        Case "AntiguedadLaboral"

          Dim rut As String = Session("Usuario.Rut")
          Dim año As String = Date.Now.Year
          paginaWeb.InnerHtml = ConfigurationManager.AppSettings.Item("Tx_UrlCodigo").ToString()
          Dim reg As New Tipos.oICERW()
          reg.consultar(rut, año)
          lblNombre.Text = reg.NOMBREFUN + " " + reg.APEPATFUN + " " + reg.APEMATFUN
          lblRut.Text = reg.RUTFUN_C
          Dim fecha As String = reg.FINGSER
          Dim fecAno = fecha.Substring(0, 4)
          Dim fecMes = fecha.Substring(4, 2)
          Dim fecDia = fecha.Substring(6, 2)
          lblTipo.Text = reg.TCONTRA_P
          lblVigente.Text = reg.ESTA_P

          Select Case fecMes
            Case "01"
              fecMes = "Enero"
            Case "02"
              fecMes = "Febrero"
            Case "03"
              fecMes = "Marzo"
            Case "04"
              fecMes = "Abril"
            Case "05"
              fecMes = "Mayo"
            Case "06"
              fecMes = "Junio"
            Case "07"
              fecMes = "Julio"
            Case "08"
              fecMes = "Agosto"
            Case "09"
              fecMes = "Septiembre"
            Case "10"
              fecMes = "Octubre"
            Case "11"
              fecMes = "Noviembre"
            Case "12"
              fecMes = "Diciembre"
          End Select

          lblFecha.Text = fecDia + " " + fecMes + " " + fecAno
          lblTipoContrato.Text = reg.TIPOFUN_P

          Dim numCert As New Tipos.oICERW()
          Dim actual As String = Date.Now.Year

          numCert.consultar(rut, actual)

          lblNumroLiqui.Text = numCert.NUMCERT

          Dim numCertificado = numCert.NUMCERT

          Me.imglogoGob.Src = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logoGob.jpg")
          Me.imgLogoBarrancas.Src = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logoBarrancas.png")

          Dim NCert As String = ""
          If numCertificado.ToString.Length = 1 Then NCert = "000000000" + numCertificado
          If numCertificado.ToString.Length = 2 Then NCert = "00000000" + numCertificado
          If numCertificado.ToString.Length = 3 Then NCert = "0000000" + numCertificado
          If numCertificado.ToString.Length = 4 Then NCert = "000000" + numCertificado

          Dim NamePDF = "SL" & "901" & "002" & DateTime.Now.ToString("yyyyMM") + "00" & NCert
          Dim respuesta = New Ws_Validador.Service()
          Dim valida = respuesta.CodigoValidador(NamePDF, "COD")
          Dim codVali = valida.WS_Codigo.ToString()
          Dim mes As String = DateTime.Now.ToString("MM")
          Dim nombre As String = "CAL" & actual & Right("00" & mes, 2) & 1 & Right("0000000000" & Trim(Session("Usuario.Rut")), 10) & ".pdf"

          Dim pieDia As String = Date.Now.Day
          Dim pieAno As String = Date.Now.Year
          Dim pieMes As String = Date.Now.Month

          Select Case pieMes
            Case "1"
              pieMes = "Enero"
            Case "2"
              pieMes = "Febrero"
            Case "3"
              pieMes = "Marzo"
            Case "4"
              pieMes = "Abril"
            Case "5"
              pieMes = "Mayo"
            Case "6"
              pieMes = "Junio"
            Case "7"
              pieMes = "Julio"
            Case "8"
              pieMes = "Agosto"
            Case "9"
              pieMes = "Septiembre"
            Case "10"
              pieMes = "Octubre"
            Case "11"
              fecMes = "Noviembre"
            Case "12"
              pieMes = "Diciembre"
          End Select
          lblFechaActual.Text = pieDia + " " + "de" + " " + pieMes + " " + "de" + " " + pieAno

          CodigoVerifica.InnerHtml = codVali

          Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
          Dim sw As System.IO.StringWriter = New System.IO.StringWriter(sb)
          Dim tw As HtmlTextWriter = New HtmlTextWriter(sw)

          Me.headContent.RenderControl(tw)

          Dim html As String = sb.ToString()

          __miPDF = New PDF(NamePDF)

          Try
            __miPDF.GenerarArchivo(html)

          Catch ex As Exception

            If File.Exists(__miPDF.RutArchivoPDF) Then
              File.Delete(__miPDF.RutArchivoPDF)

            End If

            Throw ex

          End Try

          Dim buffer As Byte() = __miPDF.BytesArchivoPDF

          With HttpContext.Current.Response
            .ClearContent()
            .ClearHeaders()
            .ContentType = "application/pdf"
            .AddHeader("Content-Length", buffer.Length.ToString)
            .AddHeader("Content-Disposition", "inline; filename=liquidacion.pdf")
            .BinaryWrite(buffer)
            .Flush()
            .Clear()
          End With

          HttpContext.Current.ApplicationInstance.CompleteRequest()
          Dim tipo As String = "CAL"
          Dim incrementa As New Tipos.oICERW()
          incrementa.agregar(rut, actual, tipo, numCertificado)

          'subir pdf a ftp
          nombre = NamePDF & ".pdf"

          Dim documento As Stream = New MemoryStream(File.ReadAllBytes(__rutaMapping & nombre))
          Dim carpetaSave = DateTime.Now.ToString("yyyyMM")
          __miFTP = New FTP(__servidorFtp & __rutaFtp, __usuarioFtp, __passwordFtp)
          __miFTP.makeDirectory(carpetaSave)

          Dim carpetaUpload = nombre.Substring(8, 6)
          __miFTP = New FTP(__servidorFtp & __rutaFtp & "/" & carpetaUpload, __usuarioFtp, __passwordFtp)
          __miFTP.upload(nombre, documento)

          If File.Exists(__miPDF.RutArchivoPDF) Then
            File.Delete(__miPDF.RutArchivoPDF)
          End If

      End Select

    Catch ex As Exception

      html.Visible = False

      Response.Clear()
      Response.ClearContent()
      Response.ClearHeaders()

      Response.Write(ex.Message)

    End Try

  End Sub

End Class
