Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization
Imports System.IO
Imports Ws_Validador

''' <summary>
''' 12/06/2019 jcalderón: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class cLiquidacionSueldo
  Inherits System.Web.UI.Page

  Private __pagina As String = "../services/cLiquidacionSueldo.aspx"
  Private __js As New JavaScriptSerializer
  Private __miPDF As PDF
  Private __rutaMapping As String = ConfigurationManager.AppSettings("rutaMapping")

  Private __servidorFtp As String = ConfigurationManager.AppSettings("servidorFtp")
  Private __rutaFtp As String = ConfigurationManager.AppSettings("rutaFtp")
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

      Select Case accion

        Case "Liquidacion"

          lblMesPago.Text = Request.Form("mes")
          lblAno.Text = Request.Form("ano")
          lblRut.Text = Session("Usuario.Rut")
          lblDiasTrabajados.Text = Request.Form("diasTrabajados")
          lblJornada.Text = Request.Form("horas")
          paginaWeb.InnerHtml = ConfigurationManager.AppSettings.Item("Tx_UrlCodigo").ToString()
          Dim rut As String = Session("Usuario.Rut")
          Dim proceso As String = 1
          Dim mes As String = Request.Form("mes")
          Dim año As String = Request.Form("ano")
          Dim institucion As String = 2

          Select Case mes

            Case "Enero"
              mes = 1
            Case "Febrero"
              mes = 2
            Case "Marzo"
              mes = 3
            Case "Abril"
              mes = 4
            Case "Mayo"
              mes = 5
            Case "Junio"
              mes = 6
            Case "Julio"
              mes = 7
            Case "Agosto"
              mes = 8
            Case "Septiembre"
              mes = 9
            Case "Octubre"
              mes = 10
            Case "Noviembre"
              mes = 11
            Case "Diciembre"
              mes = 12

          End Select

          Dim tipoLiquidacion = 99
          Dim ini = 0
          Dim numCert As New Tipos.oICERW()
          Dim actual As String = Date.Now.Year

          numCert.consultar(rut, actual)

          lblNumroLiqui.Text = numCert.NUMCERT

          Dim numCertificado = numCert.NUMCERT

          Dim descuentos As List(Of Tipos.oICOL2) = New Tipos.oICOL2().consultaMasiva(rut, proceso, mes, año, institucion)

          Dim haberes As List(Of Tipos.oICOL4) = New Tipos.oICOL4().consultaMasiva(rut, proceso, mes, año, institucion)

          Dim reg As New Tipos.oICOLI()

          reg.consultar(rut, institucion, tipoLiquidacion, año, mes)

          lblCentroCosto.Text = reg.GLOCCOSTO
          lblPrevision.Text = reg.GLO_AFP
          lblSalud.Text = reg.GLO_IS

          lblFecContrato.Text = Funciones.gMcpFormatDate(reg.FINGSE, Funciones.DateFormats.DDMMAAAA)

          lblBienios.Text = reg.NROBIE
          lblNombre.Text = reg.NOMBRET + " " + reg.APEPATT + " " + reg.APEMATT

          If reg.COPLAN = "U" Then
            lblPactado.Text = "UF" + " " + reg.MONPLA
          ElseIf reg.COPLAN = "P" Then
            lblPactado.Text = "UF" + " " + reg.MONPLA
          Else
            lblPactado.Text = String.Empty + " " + reg.MONPLA
          End If

          Dim DiaMes = 0

          If mes = 1 Or mes = 3 Or mes = 5 Or mes = 7 Or mes = 8 Or mes = 10 Or mes = 12 Then
            DiaMes = 31
          ElseIf mes = 4 Or mes = 6 Or mes = 9 Or mes = 11 Then
            DiaMes = 30
          Else
            DiaMes = 28
          End If

          If mes.Length < 2 Then
            lblPeriodoPago.Text = String.Format("DESDE" & " " & "01/" & "0" & mes & "/" & año & " " & "HASTA" & " " & DiaMes & "/" & "0" & mes & "/" & año)
          Else
            lblPeriodoPago.Text = String.Format("DESDE" & " " & "01/" & mes & "/" & año & " " & "HASTA" & " " & DiaMes & "/" & mes & "/" + año)
          End If

          Me.imglogoGob.Src = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logoGob.jpg")
          Me.imgLogoBarrancas.Src = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/logoBarrancas.png")

          'haberes imponibles
          Dim totalHaberesImpo As Integer
          Dim c As Integer = 1
          Dim Monto As Integer

          For i As Integer = 0 To haberes.Count - 1

            If haberes.Item(i).IMP = "N" And haberes.Item(i).LETCOD = "H" Then

              Dim valor As String() = haberes.Item(i).VALORC.Split(New Char(), ".")

              totalHaberesImpo += valor(0)

              Select Case c

                Case 1
                  h1.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hM1.InnerHtml = Monto.ToString("##,#")
                Case 2
                  h2.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hM2.InnerHtml = Monto.ToString("##,#")
                Case 3
                  h3.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hM3.InnerHtml = Monto.ToString("##,#")
                Case 4
                  h4.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hM4.InnerHtml = Monto.ToString("##,#")
                Case 5
                  h5.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hM5.InnerHtml = Monto.ToString("##,#")
                Case 6
                  h6.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hM6.InnerHtml = Monto.ToString("##,#")
                Case 7
                  h7.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hM7.InnerHtml = Monto.ToString("##,#")
                Case 8
                  h8.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hM8.InnerHtml = Monto.ToString("##,#")
                Case 9
                  h9.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hM9.InnerHtml = Monto.ToString("##,#")

              End Select

              c += 1
              Array.Clear(valor, 0, valor.Length)

            End If

          Next

          totalHaberesImponibles.InnerHtml = totalHaberesImpo.ToString("##,#")
          'haberes No Imponibles
          Dim totalNoImpo As Integer
          c = 1

          For i As Integer = 0 To haberes.Count - 1

            If haberes.Item(i).IMP <> "N" And haberes.Item(i).LETCOD = "H" Then

              Dim valor As String() = haberes.Item(i).VALORC.Split(New Char(), ".")

              totalNoImpo += valor(0)

              Select Case c
                Case 1
                  hN1.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hNM1.InnerHtml = Monto.ToString("##,#")
                Case 2
                  hN2.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hNM2.InnerHtml = Monto.ToString("##,#")
                Case 3
                  hN3.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hNM3.InnerHtml = Monto.ToString("##,#")
                Case 4
                  hN4.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hNM4.InnerHtml = Monto.ToString("##,#")
                Case 5
                  hN5.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hNM5.InnerHtml = Monto.ToString("##,#")
                Case 6
                  hN6.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hNM6.InnerHtml = Monto.ToString("##,#")
                Case 7
                  hN7.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hNM7.InnerHtml = Monto.ToString("##,#")
                Case 8
                  hN8.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hNM8.InnerHtml = Monto.ToString("##,#")
                Case 9
                  hN9.InnerHtml = haberes.Item(i).GLOCOD
                  Monto = valor(0)
                  hNM9.InnerHtml = Monto.ToString("##,#")

              End Select

              c += 1

              Array.Clear(valor, 0, valor.Length)

            End If

          Next

          totalNoImponible.InnerHtml = totalNoImpo.ToString("##,#")
          totalHaberes.InnerHtml = (totalHaberesImpo + totalNoImpo).ToString("##,#")

          'descuentos imponibles
          Dim totalDescuentosImpo As Integer
          c = 1

          For i As Integer = 0 To descuentos.Count - 1

            If descuentos.Item(i).MOV_TIPO = "L" And descuentos.Item(i).LETCOD = "B" Then

              Dim valor As String() = descuentos.Item(i).VALORC.Split(New Char(), ".")

              totalDescuentosImpo += valor(0)

              Select Case c
                Case 1
                  d1.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dM1.InnerHtml = Monto.ToString("##,#")
                Case 2
                  d2.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dM2.InnerHtml = Monto.ToString("##,#")
                Case 3
                  d3.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dM3.InnerHtml = Monto.ToString("##,#")
                Case 4
                  d4.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dM4.InnerHtml = Monto.ToString("##,#")
                Case 5
                  d5.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dM5.InnerHtml = Monto.ToString("##,#")
                Case 6
                  d6.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dM6.InnerHtml = Monto.ToString("##,#")
                Case 7
                  d7.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dM7.InnerHtml = Monto.ToString("##,#")
                Case 8
                  d8.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dM8.InnerHtml = Monto.ToString("##,#")
                Case 9
                  d9.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dM9.InnerHtml = Monto.ToString("##,#")

              End Select

              c += 1

              Array.Clear(valor, 0, valor.Length)

            End If

          Next

          totalDescuentosImponibles.InnerHtml = totalDescuentosImpo.ToString("##,#")
          'descuentos Varios imponibles

          Dim totalDescuentosNoImpo As Integer
          c = 1

          For i As Integer = 0 To descuentos.Count - 1

            If descuentos.Item(i).MOV_TIPO = "L" And descuentos.Item(i).LETCOD = "D" Then

              Dim valor As String() = descuentos.Item(i).VALORC.Split(New Char(), ".")

              totalDescuentosNoImpo += valor(0)

              Select Case c

                Case 1
                  dV1.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dVM1.InnerHtml = Monto.ToString("##,#")
                Case 2
                  dV2.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dVM2.InnerHtml = Monto.ToString("##,#")
                Case 3
                  dV3.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dVM3.InnerHtml = Monto.ToString("##,#")
                Case 4
                  dV4.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dVM4.InnerHtml = Monto.ToString("##,#")
                Case 5
                  dV5.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dVM5.InnerHtml = Monto.ToString("##,#")
                Case 6
                  dV6.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dVM6.InnerHtml = Monto.ToString("##,#")
                Case 7
                  dV7.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dVM7.InnerHtml = Monto.ToString("##,#")
                Case 8
                  dV8.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dVM8.InnerHtml = Monto.ToString("##,#")
                Case 9
                  dV9.InnerHtml = descuentos.Item(i).GLOCOD
                  Monto = valor(0)
                  dVM9.InnerHtml = Monto.ToString("##,#")

              End Select

              c += 1

              Array.Clear(valor, 0, valor.Length)

            End If

          Next

          totalDescuentosVariables.InnerHtml = totalDescuentosNoImpo.ToString("##,#")
          totalDescuentos.InnerHtml = (totalDescuentosImpo + totalDescuentosNoImpo).ToString("##,#")
          liquidoPago.InnerHtml = ((totalHaberesImpo + totalNoImpo) - (totalDescuentosImpo + totalDescuentosNoImpo)).ToString("##,#")

          Dim NCert As String = ""
          If numCertificado.ToString.Length = 1 Then NCert = "000000000" + numCertificado
          If numCertificado.ToString.Length = 2 Then NCert = "00000000" + numCertificado
          If numCertificado.ToString.Length = 3 Then NCert = "0000000" + numCertificado
          If numCertificado.ToString.Length = 4 Then NCert = "000000" + numCertificado

          Dim NamePDF = "SL" & "901" & "001" & DateTime.Now.ToString("yyyyMM") + "00" & NCert
          Dim respuesta = New Ws_Validador.Service()
          Dim valida = respuesta.CodigoValidador(NamePDF, "COD")
          Dim codVali = valida.WS_Codigo.ToString()

          Dim nombre As String = "LIQ" & año & Right("00" & mes, 2) & 1 & Right("0000000000" & Trim(Session("Usuario.Rut")), 10) & ".pdf"

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
          Dim tipo As String = "LIQ"
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
