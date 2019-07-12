'''
''' 05/06/2019 rtorreblanca: Creación.
'''
Partial Class wucLicencias
  Inherits System.Web.UI.UserControl

  Private __scriptVersion As Integer = Integer.Parse(ConfigurationManager.AppSettings("script.version"))

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsWucJscrollScript", JScrollV2.JSCRIPT(__scriptVersion))
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsWucHeadScript", "<script src=""../js/wucLicencias.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsControl1", "<script src=""../js/services/sLicencias.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")
    'Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsControl2", "<script src=""../js/services/sRol.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")
    ' Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsControl3", "<script src=""../js/controles/cModalRolPorUsuario.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsControl4", "<script src=""../js/services/sTabla.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")

    End Sub

End Class