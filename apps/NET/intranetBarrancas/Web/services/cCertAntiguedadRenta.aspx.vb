Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization
Imports System.IO
Imports Ws_Validador

''' <summary>
''' 12/06/2019 jcalderón: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class cCertAntiguedadRenta
  Inherits System.Web.UI.Page

  Private __pagina As String = "../services/cCertAntiguedadRenta.aspx"
  Private __js As New JavaScriptSerializer
  Private __miPDF As PDF
  Private __rutaMapping As String = ConfigurationManager.AppSettings("rutaMapping")
  Private __servidorFtp As String = ConfigurationManager.AppSettings("servidorFtp")
  Private __rutaFtp As String = ConfigurationManager.AppSettings("rutaFtpLaboralRenta")
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

        Case "AntiguedadLaboralRenta"

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
          Dim icolMes As String = Request.Form("mes")
          lblMes.Text = icolMes
          Dim icolAno As String = Request.Form("ano")
          lblAno.Text = icolAno

          Dim numCert As New Tipos.oICERW()

          Dim actual As String = Date.Now.Year
          Dim proceso As String = 1
          Dim institucion As String = 2
          Dim monto As Integer
          Dim bruto As List(Of Tipos.oICOL4) = New Tipos.oICOL4().consultaMasiva(rut, proceso, icolMes, icolAno, institucion)
          For i As Integer = 0 To bruto.Count - 1
            If bruto.Item(i).NUMCOD = 149 Then
              Dim valor As String() = bruto.Item(i).VALORC.Split(New Char(), ".")
              monto = valor(0)
              lblRenta.Text = monto.ToString("##,#")
            End If
          Next
          lblDescripccion.Text = Num2Text(monto)
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
          Dim nombre As String = "ARI" & actual & Right("00" & mes, 2) & 1 & Right("0000000000" & Trim(Session("Usuario.Rut")), 10) & ".pdf"

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
          Dim tipo As String = "ARI"
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

  Public Function Num2Text(ByVal valor As Double)

    Select Case valor

      Case 0 : Num2Text = "CERO"

      Case 1 : Num2Text = "UN"

      Case 2 : Num2Text = "DOS"

      Case 3 : Num2Text = "TRES"

      Case 4 : Num2Text = "CUATRO"

      Case 5 : Num2Text = "CINCO"

      Case 6 : Num2Text = "SEIS"

      Case 7 : Num2Text = "SIETE"

      Case 8 : Num2Text = "OCHO"

      Case 9 : Num2Text = "NUEVE"

      Case 10 : Num2Text = "DIEZ"

      Case 11 : Num2Text = "ONCE"

      Case 12 : Num2Text = "DOCE"

      Case 13 : Num2Text = "TRECE"

      Case 14 : Num2Text = "CATORCE"

      Case 15 : Num2Text = "QUINCE"

      Case Is < 20 : Num2Text = "DIECI" & Num2Text(valor - 10)

      Case 20 : Num2Text = "VEINTE"

      Case Is < 30 : Num2Text = "VEINTI" & Num2Text(valor - 20)

      Case 30 : Num2Text = "TREINTA"

      Case 40 : Num2Text = "CUARENTA"

      Case 50 : Num2Text = "CINCUENTA"

      Case 60 : Num2Text = "SESENTA"

      Case 70 : Num2Text = "SETENTA"

      Case 80 : Num2Text = "OCHENTA"

      Case 90 : Num2Text = "NOVENTA"

      Case Is < 100 : Num2Text = Num2Text(Int(valor \ 10) * 10) & " Y " & Num2Text(valor Mod 10)

      Case 100 : Num2Text = "CIEN"

      Case Is < 200 : Num2Text = "CIENTO " & Num2Text(valor - 100)

      Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(valor \ 100)) & "CIENTOS"

      Case 500 : Num2Text = "QUINIENTOS"

      Case 700 : Num2Text = "SETECIENTOS"

      Case 900 : Num2Text = "NOVECIENTOS"

      Case Is < 1000 : Num2Text = Num2Text(Int(valor \ 100) * 100) & " " & Num2Text(valor Mod 100)

      Case 1000 : Num2Text = "MIL"

      Case Is < 2000 : Num2Text = "MIL " & Num2Text(valor Mod 1000)

      Case Is < 1000000 : Num2Text = Num2Text(Int(valor \ 1000)) & " MIL"

        If valor Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(valor Mod 1000)

      Case 1000000 : Num2Text = "UN MILLON"

      Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(valor Mod 1000000)

      Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(valor / 1000000)) & " MILLONES"

        If (valor - Int(valor / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(valor - Int(valor / 1000000) * 1000000)

      Case 1000000000000.0# : Num2Text = "UN BILLON"

      Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(valor - Int(valor / 1000000000000.0#) * 1000000000000.0#)

      Case Else : Num2Text = Num2Text(Int(valor / 1000000000000.0#)) & " BILLONES"

        If (valor - Int(valor / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(valor - Int(valor / 1000000000000.0#) * 1000000000000.0#)

    End Select

    Return Num2Text

  End Function

End Class
