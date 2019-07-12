Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization

''' <summary>
''' 30/05/2019
''' </summary>
''' <remarks></remarks>
Partial Class sDatosPersonales
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

                    Dim rut As String = Session("Usuario.Rut")
                    Dim varmenu As String = 1
                    Dim reg As New Tipos.oIANTP()
                    reg.consultaMasiva(rut, varmenu)
                    Response.Write(__js.Serialize(reg))

                Case "consultarCorreoIntranet"

                    Dim rut As String = Session("Usuario.Rut")
                    Dim prioridad = ""
                    Dim reg As List(Of Tipos.oCTUSM) = New Tipos.oCTUSM().consultaMasiva(prioridad, rut)
                    Dim correoIntranet As String = String.Empty

                    For Each datos As Tipos.oCTUSM In reg
                        If datos.PRIORIDAD = "1" Then
                            Session("Usuario.Email") = datos.EMAIL
                            Session("Usuario.clave") = datos.PASSMAIL
                            correoIntranet = datos.EMAIL
                            correoIntranet = Replace(correoIntranet, "/", "@")
                        End If
                    Next

                    Response.Write(__js.Serialize(correoIntranet))

                Case "validarLogin"

                    Dim rut As String = Session("Usuario.Rut")
                    Dim opcion = ""
                    Dim mant = "INQ"
                    Dim passmail = ""
                    Dim prioridad As String = 1

                    Dim reg As New Tipos.oIIMTU()
                    reg.consultarCorreo(prioridad, rut, mant)
                    Response.Write(__js.Serialize(reg))

                Case "modificarCorreoIntranet"

                    Dim correoACambiar = Request.QueryString("correoACambiar")
                    correoACambiar = Replace(correoACambiar, "@", "/")
                    Dim rut As String = Session("Usuario.Rut")
                    Dim prioridad As String = 1
                    Dim clave As String = String.Empty
                    Dim reg As New Tipos.oIIMTU()

                    If Session("Usuario.Email") <> "" Then
                        If correoACambiar <> Session("Usuario.Email") Then
                            clave = Session("Usuario.clave")
                            reg.modificar(prioridad, correoACambiar, rut, clave)
                            Response.Write(__js.Serialize(reg))
                        Else
                            Exit Sub
                        End If
                    ElseIf correoACambiar <> "" Then
                        clave = 123
                        reg.agregar(prioridad, correoACambiar, rut, clave)
                        Response.Write(__js.Serialize(reg))
                    Else

                        Exit Sub

                    End If

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