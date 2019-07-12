Imports System.Collections.Generic
Imports slbaperbModel

''' <summary>
''' 05/06/2019 jcalderón: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class jScrollAccesos
  Inherits System.Web.UI.Page
  Private __pagina As String = "../acciones/jScrollAccesos.aspx"
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

        Case "consultaPermisos"

          Dim jScroll As New JScrollV2(Request, __pagina)

          Dim row As New JScrollV2.myRow(Request)

          row.OnDblclickJsFunction = "jScrollPermisosRowClick"

          Dim codSistema As String = ConfigurationManager.AppSettings("codigoSistema")
          Dim codRol As String = "USU"
          Dim rut As String = Request.QueryString("rut")

          Dim datos1 As New JscrollPermisos
          Dim datos2 As New JscrollPermisos
          Dim datos3 As New JscrollPermisos
          Dim datos4 As New JscrollPermisos
          Dim datos5 As New JscrollPermisos
          Dim datos6 As New JscrollPermisos
          Dim datos7 As New JscrollPermisos
          Dim datos8 As New JscrollPermisos
          Dim datos9 As New JscrollPermisos
          Dim datos10 As New JscrollPermisos
          Dim datos11 As New JscrollPermisos
          Dim datos12 As New JscrollPermisos
          Dim datos13 As New JscrollPermisos
          Dim datos14 As New JscrollPermisos
          Dim datos15 As New JscrollPermisos
          Dim datos16 As New JscrollPermisos
          Dim datos17 As New JscrollPermisos
          Dim datos18 As New JscrollPermisos
          Dim datos19 As New JscrollPermisos
          Dim datos20 As New JscrollPermisos
          Dim datos21 As New JscrollPermisos

          Dim opciones As List(Of Tipos.oCTURO) = New Tipos.oCTURO().consultaMasiva(codRol, rut, codSistema)
          For Each dato As Tipos.oCTURO In opciones
            If dato.CODOPC = 1 Then
              datos1.numero = dato.CODOPC
              datos1.nombre = "CORPORACIÓN"
              datos1.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 50 Then
              datos2.numero = dato.CODOPC
              datos2.nombre = "AUTORIZACIÓN"
              datos2.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 100 Then
              datos3.numero = dato.CODOPC
              datos3.nombre = "DATOS PERSONALES"
              datos3.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 150 Then
              datos4.numero = dato.CODOPC
              datos4.nombre = "MODIFICACIÓN DE ANTECEDENTES"
              datos4.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 300 Then
              datos5.numero = dato.CODOPC
              datos5.nombre = "SOLICITUDES"
              datos5.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 310 Then
              datos6.numero = dato.CODOPC
              datos6.nombre = "PERMISOS ADMINISTRATIVOS"
              datos6.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 450 Then
              datos7.numero = dato.CODOPC
              datos7.nombre = "LIQUIDACIÓN DE SUELDO"
              datos7.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 460 Then
              datos8.numero = dato.CODOPC
              datos8.nombre = "CONSULTA CARRERA FUNCIONARIOS"
              datos8.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 470 Then
              datos9.numero = dato.CODOPC
              datos9.nombre = "CONSULTA LICENCIAS MÉDICAS"
              datos9.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 500 Then
              datos10.numero = dato.CODOPC
              datos10.nombre = "PRESUPUESTO"
              datos10.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 510 Then
              datos11.numero = dato.CODOPC
              datos11.nombre = "GASTOS"
              datos11.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 520 Then
              datos12.numero = dato.CODOPC
              datos12.nombre = "INGRESOS"
              datos12.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 600 Then
              datos13.numero = dato.CODOPC
              datos13.nombre = "CERTIFICADOS"
              datos13.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 610 Then
              datos14.numero = dato.CODOPC
              datos14.nombre = "CERTIFICADOS ANTIGUEDAD LABORAL"
              datos14.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 620 Then
              datos15.numero = dato.CODOPC
              datos15.nombre = "CERTIFICADO ANTIGUEDAD LABORAL IMPONIBLE"
              datos15.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 630 Then
              datos16.numero = dato.CODOPC
              datos16.nombre = "CERTIFICADO LEY 19070"
              datos16.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 640 Then
              datos17.numero = dato.CODOPC
              datos17.nombre = "CERTIFICADO CARRERA FUNCIONARIO"
              datos17.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 650 Then
              datos18.numero = dato.CODOPC
              datos18.nombre = "CERTIFICADO CARGAS FAMILIARES"
              datos18.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 850 Then
              datos19.numero = dato.CODOPC
              datos19.nombre = "CAMBIO DE CLAVE"
              datos19.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 900 Then
              datos20.numero = dato.CODOPC
              datos20.nombre = "CAMBIO CONTRASEÑA"
              datos20.permiso = dato.PERMISO

            ElseIf dato.CODOPC = 950 Then
              datos21.numero = dato.CODOPC
              datos21.nombre = "ACCESOS AL MENU"
              datos21.permiso = dato.PERMISO

            End If
          Next
          Dim lista As New List(Of JscrollPermisos)

          If datos1.numero <> String.Empty Then lista.Add(datos1)

          If datos2.numero <> String.Empty Then lista.Add(datos2)

          If datos3.numero <> String.Empty Then lista.Add(datos3)

          If datos4.numero <> String.Empty Then lista.Add(datos4)

          If datos5.numero <> String.Empty Then lista.Add(datos5)

          If datos6.numero <> String.Empty Then lista.Add(datos6)

          If datos7.numero <> String.Empty Then lista.Add(datos7)

          If datos8.numero <> String.Empty Then lista.Add(datos8)

          If datos9.numero <> String.Empty Then lista.Add(datos9)

          If datos10.numero <> String.Empty Then lista.Add(datos10)

          If datos11.numero <> String.Empty Then lista.Add(datos11)

          If datos12.numero <> String.Empty Then lista.Add(datos12)

          If datos13.numero <> String.Empty Then lista.Add(datos13)

          If datos14.numero <> String.Empty Then lista.Add(datos14)

          If datos15.numero <> String.Empty Then lista.Add(datos15)

          If datos16.numero <> String.Empty Then lista.Add(datos16)

          If datos17.numero <> String.Empty Then lista.Add(datos17)

          If datos18.numero <> String.Empty Then lista.Add(datos18)

          If datos19.numero <> String.Empty Then lista.Add(datos19)

          If datos20.numero <> String.Empty Then lista.Add(datos20)

          If datos21.numero <> String.Empty Then lista.Add(datos21)

          jScroll.Data = lista

          Dim field01 As New JScrollV2.myField("numero", "IDENTIFICADOR")
          field01.Width = 2
          row.Fields.Add(field01)

          Dim fieldCert As New JScrollV2.myField("nombre", "OPCIONE DEL MENÚ")
          fieldCert.Width = 5
          row.Fields.Add(fieldCert)

          Dim fieldPermiso As New JScrollV2.myField("permiso", "HABILITADO")
          fieldPermiso.Alignment = JScrollV2.myField.FieldAlignment.Left
          fieldPermiso.Width = 2
          fieldPermiso.CustomFieldFunction = Function(rowDataObject As Object, rowSequence As Integer) As String

                                               Dim permiso = rowDataObject("permiso")
                                               Dim opcion As String = ""

                                               If permiso = "S" Then
                                                 opcion = "<span class=""glyphicon glyphicon-eye-open fa-w-18 fa-2x"" style=""color:green""></span>"
                                               Else
                                                 opcion = "<span class=""glyphicon glyphicon-eye-close fa-w-18 fa-2x"" style=""color:red""></span>"
                                               End If

                                               Return opcion
                                             End Function
          row.Fields.Add(fieldPermiso)

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
    Public permiso As String

    Sub New()

    End Sub

  End Class

End Class