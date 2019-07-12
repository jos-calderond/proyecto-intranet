Imports System.Collections.Generic
Imports slbaperbModel

''' <summary>
''' 14/05/2019 croman: Se agrega información de junta.
''' </summary>
''' <remarks></remarks>
Partial Class _Default
  Inherits System.Web.UI.Page

  Public scriptVersion As Integer = Integer.Parse(ConfigurationManager.AppSettings("script.version"))

  Private __opcionesPorUsuario As New Tipos.oCMOXU()
  Private __permisos As List(Of Tipos.oCMOXU)

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    PageTitle.InnerHtml = ConfigurationManager.AppSettings("sistemaNombre").ToString()
    bSistemaNombre.InnerHtml = ConfigurationManager.AppSettings("sistemaNombre").ToString()
    Session("Usuario.Codsis") = ConfigurationManager.AppSettings("codigoSistema").ToString()
    Session("Sistema.Nombre") = ConfigurationManager.AppSettings("sistemaNombre").ToString()

    'Cerrar sesión
    If (Not Request.QueryString("Close") Is Nothing) Then
      Session.Clear()
      Session.Abandon()
      Session.RemoveAll()
      Response.Redirect("Default.aspx")
    End If

  End Sub

  Protected Sub btnIngresarClick(ByVal sender As Object, ByVal e As System.EventArgs)

    If Me.txtUsuario.Value = "" Or Me.txtPassword.Value = "" Then
      __Alerta("Debe Ingresar los campos")
    Else

      Try

        Dim usu = Me.txtUsuario
        Dim clave = Me.txtPassword.Value

        Dim codigoSistema As String = ConfigurationManager.AppSettings("codigoSistema")

        Dim codRol = "USU"

        Dim mtusu As Tipos.oMTUSU = New Tipos.oMTUSU()
        Dim strMenu As String = ""

        mtusu.consultarCredenciales(Me.txtUsuario.Value, Me.txtPassword.Value)

        If mtusu.PASSWORD.ToString.Trim <> Convert.ToString(clave) Then
          Throw New Exception("ERROR USUARIO Y/O CLAVE NO CORRESPONDE")
          Me.txtUsuario.Focus()
        Else
          Session("Usuario.Rut") = Trim(Me.txtUsuario.Value)
          Session("Usuario.Nombre") = Trim(mtusu.NOMBRES) & " " & Trim(mtusu.APEPAT) & " " & Trim(mtusu.APEMAT)

          Dim cturo As List(Of Tipos.oCTURO) = New Tipos.oCTURO().consultaMasiva(codRol, Me.txtUsuario.Value, codigoSistema)
          Dim lista As List(Of String) = New List(Of String)

          For Each item As Tipos.oCTURO In cturo

            If item.PERMISO.ToUpper() = "S" Then
              lista.Add(item.CODOPC)
            End If

          Next

          Dim menuBuilder As New MenuBuilder()
          Session("Usuario.Permisos") = menuBuilder.RetrieveClosedTwoLevelMenu(lista)

        End If

        If mtusu.VIGENTE <> 1 Then
          Throw New Exception("ERROR USUARIO Y/O CLAVE NO CORRESPONDE")
          Me.txtUsuario.Focus()
        End If

      Catch ex As Exception

        Me.txtUsuario.Value = ""
        Me.txtPassword.Value = ""
        __onError(ex.Message)

        Exit Sub

      End Try

      Response.Redirect("./pages/frmInicio.aspx")

    End If

  End Sub

  Protected Sub btnRecuperaClick(ByVal sender As Object, ByVal e As System.EventArgs)

    If Me.txtRut.Value = "" Or Me.txtFecha.Value = "" Then
      __Alerta("Debe Ingresar los campos")
    Else

      Try

        Dim mtusu As Tipos.oMTUSU = New Tipos.oMTUSU()
        mtusu.consultar(Me.txtRut.Value)
        Dim fechaRecupera As String = String.Empty
        fechaRecupera = mtusu.FECNAC

        If Val(mtusu.VIGENTE) <> 1 Then

          Throw New Exception(" Funcionario no vigente en la Municipalidad")

          Exit Sub

        End If

        Dim fechaNacimiento = Replace(txtFecha.Value, "/", "")

        If fechaNacimiento = fechaRecupera Then
          __enviarCorreo()
        End If

      Catch ex As Exception

        Me.txtRut.Value = ""
        Me.txtFecha.Value = ""
        Me.txtRut.Focus()
        __onError(ex.Message)

        Exit Sub

      End Try

    End If

  End Sub

  Private Sub __enviarCorreo()

    Dim mtusu As Tipos.oMTUSU = New Tipos.oMTUSU()
    mtusu.consultar(Me.txtRut.Value)
    Dim nombre = Trim(mtusu.NOMBRES) & " " & Trim(mtusu.APEPAT) & " " & Trim(mtusu.APEMAT)
    Dim Texto As String = "Sr(a). " & nombre & "," & Chr(13) & Chr(13) & "Le recuerdo a Ud. su clave de usuario y contraseña para el ingreso a la Intranet: " & Chr(13) & Chr(13) & "Usuario    : " & mtusu.CODUSU & Chr(13) & "Contraseña : " & Trim(mtusu.PASSWORD & Chr(13) & Chr(13) & "Atte." & Chr(13) & Chr(13) & "Servicio de Atención a Usuario" & Chr(13) & "Intranet")
    Dim rut As String = mtusu.CODUSU
    Dim prioridad = ""
    Dim reg As List(Of Tipos.oCTUSM) = New Tipos.oCTUSM().consultaMasiva(prioridad, rut)
    Dim correoIntranet As String = String.Empty

    For Each datos As Tipos.oCTUSM In reg

      If datos.PRIORIDAD <> 1 Then
        Session("Usuario.Email") = datos.EMAIL
        correoIntranet = datos.EMAIL
        correoIntranet = Replace(correoIntranet, "/", "@")

      End If

    Next

    If correoIntranet <> "" Then
      If enviarMail("172.16.3.235", "envioweb", "proexsi.moneda", "noreply@cpr.cl", correoIntranet, "Recordatorio de Contraseña", Texto) Then
        Throw New Exception("Contraseña enviada satisfactoriamente a su correo")
      Else
        Throw New Exception("No se ha podido enviar su contraseña a su correo electrónico")
      End If
    Else
      Throw New Exception("El correo del usuario no se encuentra registrado en el Sistema")

    End If

  End Sub

  Private Function enviarMail(ByVal iServidor As String, ByVal iUsuario As String, ByVal iPassword As String, ByVal iDe As String, ByVal iPara As String, ByVal iAsunto As String, ByVal iCorreo As String, Optional ByVal iHtml As Boolean = False, Optional ByVal AdjuntarDoc As Boolean = False, Optional ByVal FileAdjunto As System.Net.Mail.Attachment = Nothing) As Boolean
    Dim correo As New System.Net.Mail.MailMessage

    correo.From = New System.Net.Mail.MailAddress(iDe)

    correo.To.Add(iPara)
    correo.Subject = iAsunto

    If AdjuntarDoc = True Then
      correo.Attachments.Add(FileAdjunto)
    End If

    correo.Body = iCorreo
    correo.IsBodyHtml = iHtml
    correo.Priority = System.Net.Mail.MailPriority.Normal

    'Datos del servidor

    Dim smtp As New System.Net.Mail.SmtpClient
    smtp.Host = iServidor
    smtp.Credentials = New System.Net.NetworkCredential(iUsuario, iPassword)

    Try
      smtp.Send(correo)
      Return True
    Catch ex As Exception
      Return False
    End Try

  End Function

  Private Sub __onError(ByVal strError As String)

    Me.lblDialogTitulo.Text = "Error"
    Me.lblDialogMsg.Text = strError
    'Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "reset", "<script>$('#cmbRoles').val('');</script>")
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "error", "<script>$('#dialogo').modal('show');</script>")

  End Sub

  Private Sub __Alerta(ByVal strAlerta As String)

    Me.lblDialogTitulo2.Text = "Alerta"
    Me.lblDialogMsg2.Text = strAlerta
    'Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "reset", "<script>$('#cmbRoles').val('');</script>")
    Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "Alerta", "<script>$('#dialogo2').modal('show');</script>")

  End Sub

End Class
