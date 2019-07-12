'''
''' 02/07/2019 jcalderon: Creación.
'''
Partial Class wucAccesos
  Inherits System.Web.UI.UserControl

  Private __scriptVersion As Integer = Integer.Parse(ConfigurationManager.AppSettings("script.version"))

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsWucJscrollScript", JScrollV2.JSCRIPT(__scriptVersion))
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsWucHeadScript", "<script src=""../js/wucAccesos.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsControl1", "<script src=""../js/services/sAccesos.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")
  End Sub

End Class