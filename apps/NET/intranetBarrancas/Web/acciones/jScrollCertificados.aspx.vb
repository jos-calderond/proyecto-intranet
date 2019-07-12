Imports System.Collections.Generic
Imports slbaperbModel

''' <summary>
''' 05/06/2019 jcalderón: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class jScrollCertificados
  Inherits System.Web.UI.Page
  Private __pagina As String = "../acciones/jScrollCertificados.aspx"
  Private __accion As String = ""

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
        Throw New Exception(Funciones.gSessionCaducadaForJscroll)
      End If

      __accion = Request.QueryString("accion")

      Select Case __accion

        Case "consultaOpciones"

          Dim jScroll As New JScrollV2(Request, __pagina)

          Dim row As New JScrollV2.myRow(Request)

          row.OnDblclickJsFunction = "jScrollCertificadosRowClick"

          Dim codSistema As String = ConfigurationManager.AppSettings("codigoSistema")
          Dim codRol As String = "USU"
          Dim rut As String = Session("Usuario.Rut")

          Dim datos1 As New JscrollPermisos
          Dim datos2 As New JscrollPermisos
          Dim datos3 As New JscrollPermisos
          Dim datos4 As New JscrollPermisos
          Dim datos5 As New JscrollPermisos
          Dim opciones As List(Of Tipos.oCTURO) = New Tipos.oCTURO().consultaMasiva(codRol, rut, codSistema)
          For Each dato As Tipos.oCTURO In opciones
            If dato.PERMISO = "S" And dato.CODOPC = 610 Then
              datos1.numero = 1
              datos1.nombre = "ANTIGUEDAD LABORAL"
            ElseIf dato.PERMISO = "S" And dato.CODOPC = 620 Then
              datos2.numero = 2
              datos2.nombre = "ANTIGUEDAD LABORAL CON RENTA"
            ElseIf dato.PERMISO = "S" And dato.CODOPC = 630 Then
              datos3.numero = 3
              datos3.nombre = "LEY 19.070"
            ElseIf dato.PERMISO = "S" And dato.CODOPC = 640 Then
              datos4.numero = 4
              datos4.nombre = "CARRERA FUNCIONARIO"
            ElseIf dato.PERMISO = "S" And dato.CODOPC = 650 Then
              datos5.numero = 5
              datos5.nombre = "CARGA FAMILIAR"
            End If
          Next
          Dim lista As New List(Of JscrollPermisos)
          If datos1.numero = String.Empty Then

          Else
            lista.Add(datos1)
          End If
          If datos2.numero = String.Empty Then
          Else
            lista.Add(datos2)
          End If
          If datos3.numero = String.Empty Then
          Else
            lista.Add(datos3)
          End If
          If datos4.numero = String.Empty Then
          Else
            lista.Add(datos4)
          End If
          If datos5.numero = String.Empty Then
          Else
            lista.Add(datos5)
          End If

          jScroll.Data = lista

          Dim field01 As New JScrollV2.myField("numero", "IDENTIFICADOR")
          field01.Width = 12
          row.Fields.Add(field01)

          Dim fieldCert As New JScrollV2.myField("nombre", "TIPO CERTIFICADO")
          fieldCert.Width = 12
          row.Fields.Add(fieldCert)

          jScroll.RowConfiguration = row
          Response.Write(jScroll.GetMyGrid())

      End Select

    Catch ex As Exception

      Response.Write(ex.Message)

    End Try

  End Sub

 

  Class JscrollPermisos

    Public numero As String
    Public nombre As String
   
    Sub New()

    End Sub

  End Class

End Class