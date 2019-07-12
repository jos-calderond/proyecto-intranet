Imports System.Collections.Generic
Imports System.Web.Script.Serialization
Imports slbaperbModel

''' <summary>
''' 29/05/2019 rtorreblanca: Creación
''' </summary>
''' <remarks></remarks>
Partial Class sLogin
    Inherits System.Web.UI.Page

    Private __js As New JavaScriptSerializer

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

            Dim login As Dictionary(Of String, Dictionary(Of String, String)) = New Dictionary(Of String, Dictionary(Of String, String))

            Dim usuarioData As Dictionary(Of String, String) = New Dictionary(Of String, String)

            usuarioData.Add("rut", Session("Usuario.Rut"))
            usuarioData.Add("nombre", Session("Usuario.Nombre"))
            usuarioData.Add("codsis", Session("Usuario.Codsis"))

            login.Add("usuario", usuarioData)

            Response.Write(__js.Serialize(login))

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