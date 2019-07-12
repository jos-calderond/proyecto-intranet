Imports System.Collections.Generic
Imports slbaperbModel

Partial Class Site
  Inherits System.Web.UI.MasterPage

  Public scriptVersion As Integer = Integer.Parse(ConfigurationManager.AppSettings("script.version"))

  Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    PageTitle.InnerHtml = ConfigurationManager.AppSettings("sistemaNombre").ToString()

    bSistemaNombre.InnerText = ConfigurationManager.AppSettings("sistemaNombre").ToString()
    bSistemaNombreMin.InnerText = ConfigurationManager.AppSettings("sistemaNombre").ToString()

    'If Session IsNot Nothing Then
    '  If Session("Usuario.Rut") Is Nothing Then
    '    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "session", Funciones.gSessionCaducadaForJscroll)
    '    Exit Sub
    '  End If
    'Else
    '  Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "session", Funciones.gSessionCaducadaForJscroll)
    '  Exit Sub
    'End If

    Me.menu.InnerHtml = Session("Usuario.Permisos")
    Me.spnUsuario.InnerText = Session("Usuario.Nombre")
    'Me.spnRol.InnerText = Session("Rol.Nombre")

  End Sub
End Class
