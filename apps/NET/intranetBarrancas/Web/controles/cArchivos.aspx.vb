Imports System.IO
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Web.Script.Serialization

''' <summary>
''' 16/05/2019 croman: Creación. Clase para manejar la carga, descarga y listado de archivos desde un FTP.
''' </summary>
''' <remarks></remarks>
Partial Class cArchivos
    Inherits System.Web.UI.Page

    Private __js As New JavaScriptSerializer
    Private __miFTP As FTP

    Private __servidorFtp As String = ConfigurationManager.AppSettings("servidorFtp")
    Private __rutaFtp As String = ConfigurationManager.AppSettings("rutaFtp")
    Private __usuarioFtp As String = ConfigurationManager.AppSettings("usuarioFtp")
    Private __passwordFtp As String = ConfigurationManager.AppSettings("passwordFtp")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim action = Request.QueryString("action")

            If (action = String.Empty) Then
                action = Request.Form("action")
            End If

            Select Case action

                Case "getFiles"
                    __miFTP = New FTP(__servidorFtp & __rutaFtp, __usuarioFtp, __passwordFtp)
                    Dim folder As String = Request.QueryString("folder")
                    Dim archivos As List(Of String) = __miFTP.fileList(folder)
                    Response.Write(__js.Serialize(archivos))

                Case "upload"
                    Dim archivo As HttpPostedFile = Request.Files("file")
                    Dim subfolder As String = Request.Form("subfolder")

                    __miFTP = New FTP(__servidorFtp & __rutaFtp, __usuarioFtp, __passwordFtp)

                    Try
                        __miFTP.makeDirectory(subfolder)

                    Catch ex As Exception

                    End Try
                    __miFTP.upload(subfolder & "/" & archivo.FileName, archivo.InputStream)
                    Response.Write(__js.Serialize(True))

                Case "deleteFile"

                    Dim folder As String = Request.QueryString("folder")
                    Dim filename As String = Request.QueryString("filename")
                    __miFTP = New FTP(__servidorFtp & __rutaFtp, __usuarioFtp, __passwordFtp)
                    __miFTP.deleteFile(folder & "/" & filename)
                    Response.Write(__js.Serialize(True))

                Case "openfile"

                    Dim folder As String = Request.Form("folder")
                    Dim filename As String = Request.Form("filename")
                    __miFTP = New FTP(__servidorFtp & __rutaFtp, __usuarioFtp, __passwordFtp)
                    Dim byteArray As Byte() = __miFTP.getStream(folder & "/" & filename)

                    With HttpContext.Current.Response
                        .ClearContent()
                        .ClearHeaders()
                        .ContentType = "application/octet-stream"
                        .AddHeader("Content-Disposition", "inline; filename=" & filename)
                        .BinaryWrite(byteArray)
                    End With
                    HttpContext.Current.ApplicationInstance.CompleteRequest()

            End Select

        Catch ex As Exception

            Dim err As New Dictionary(Of String, Exception)
            err.Add("error", New Exception(ex.Message.Replace(vbLf, " ").Replace(vbCr, " ")))
            Response.Write(__js.Serialize(err))

        End Try

    End Sub

End Class
