Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization

''' <summary>
''' 05/06/2019 rtorreblanca: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class sLicencias
    Inherits System.Web.UI.Page

    Private __js As New JavaScriptSerializer

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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
                Throw New TimeoutException(Funciones.gSessionCaducadaForJsFunction)
            End If

            Dim accion = Request.QueryString("accion")

            Select Case accion

                Case "consultar"

                    Dim rut = Session("Usuario.Rut")
                    Dim numlic = Request.QueryString("numlic")
                    Dim reg As New Tipos.oINLI3()
                    reg.consultar(rut, numlic)
                    Response.Write(__js.Serialize(reg))

                Case "consultar3Meses"

                    Dim rut = Session("Usuario.Rut")
                    Dim fecLic = Request.QueryString("fecini_lic")
                    Dim valores As String() = fecLic.Split(New Char(), "/")
                    fecLic = valores(2) + valores(1) + valores(0)
                    Dim reg As New Tipos.oCINLI()
                    reg.consultar(fecLic, rut)
                    Response.Write(__js.Serialize(reg))

                Case "cargarAnosLicencias"
                    Dim ano = ConfigurationManager.AppSettings.Item("rangoLicencias").ToString()
                    Dim actual = Date.Now.Year
                    ano = actual - ano
                    Dim lista As New List(Of String)

                    While ano <= actual
                        If lista.Count = 0 Then
                            lista.Add(ano.ToString())
                        Else
                            For x As Integer = 0 To lista.Count - 1
                                If lista.Item(x) <> ano Then
                                    lista.Add(ano.ToString())
                                End If
                            Next
                        End If
                        ano += 1
                    End While

                    Dim valoresUnicos As New List(Of String)
                    Dim Existe As Boolean = False

                    For Each ElementString As String In lista
                        Existe = False
                        For Each ElementStringInResult As String In valoresUnicos
                            If ElementString = ElementStringInResult Then
                                Existe = True
                                Exit For
                            End If
                        Next

                        If Not Existe Then
                            valoresUnicos.Add(ElementString)
                        End If
                    Next

                    Response.Write(__js.Serialize(valoresUnicos))

            End Select

        Catch ex0 As TimeoutException

            Dim err As New Dictionary(Of String, Exception)
            err.Add("timeouterror", New Exception(ex0.Message.Replace(vbLf, " ").Replace(vbCr, " ")))
            Response.Write(__js.Serialize(err))

        Catch ex As Exception

            Dim err As New Dictionary(Of String, Exception)
            err.Add("error", New Exception(ex.Message.Replace(vbLf, " ").Replace(vbCr, " ")))
            Response.Write(__js.Serialize(err))

        End Try

    End Sub

End Class