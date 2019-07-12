Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization

''' <summary>
''' 05/06/2019 jCalderon: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class sAccesos
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

        Case "cambioPermiso"

          Dim rut As String = Request.QueryString("rut")
          Dim identificador As String = Request.QueryString("numero")
          Dim cambio As String = Request.QueryString("cambio")
          Dim sistema As String = ConfigurationManager.AppSettings("codigoSistema").ToString()
          Dim codigo As String = "USU"
          If cambio = "or" Then
            cambio = "S"
          Else
            cambio = "N"
          End If

          Dim datos As List(Of Tipos.oIMROL) = New Tipos.oIMROL().cambioPermiso(identificador, rut, codigo, sistema, cambio)

          Response.Write(__js.Serialize(rut))

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