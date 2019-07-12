Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization

''' <summary>
''' 30/05/2019
''' </summary>
''' <remarks></remarks>
Partial Class sCambioClave
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
          Dim reg As New Tipos.oMTUSU()
          reg.consultar(rut)
          Response.Write(__js.Serialize(reg))

        Case "cambioClave"

          Dim rut As String = Session("Usuario.Rut")
          Dim actual As String = Request.QueryString("actual")
          Dim nueva As String = Request.QueryString("nueva")
          Dim confirma As String = Request.QueryString("confirma")
          Dim codigo = "CPW"
          Dim reg As New Tipos.oMTUSU()
          reg.modificarPassword(rut, codigo, confirma, nueva, actual)

          Response.Write(__js.Serialize(reg))

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