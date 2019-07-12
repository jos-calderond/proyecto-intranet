'''
''' 05/06/2019 jcalderón: Creación.
'''
Partial Class wucLiquidacion
  Inherits System.Web.UI.UserControl

  Private __scriptVersion As Integer = Integer.Parse(ConfigurationManager.AppSettings("script.version"))

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsWucJscrollScript", JScrollV2.JSCRIPT(__scriptVersion))
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsWucHeadScript", "<script src=""../js/wucLiquidacion.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsControl1", "<script src=""../js/services/sLiquidacion.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "jsControl4", "<script src=""../js/services/sTabla.js?v=" & __scriptVersion & """ type=""text/javascript""></script>")

    End Sub

End Class