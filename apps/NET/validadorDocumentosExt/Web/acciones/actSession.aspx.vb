
Partial Class actSession
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Session("Usuario.Rut") IsNot Nothing Then
            Response.Write("OK")
        Else
            Response.Write("NOK")
        End If

    End Sub

End Class
