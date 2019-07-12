Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization

''' <summary>
''' 31/05/2019 jcalderón: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class sLiquidacion
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

                Case "detalleLiquidacion"

                    Dim rut = Request.QueryString("rut")
                    Dim institucion = Request.QueryString("institucion")
                    Dim tipoLiquidacion = Request.QueryString("tipoLiquidacion")
                    Dim ano = Request.QueryString("ano")
                    Dim mes = Request.QueryString("mes")
                    Dim reg As New Tipos.oICOLI()
                    reg.consultaMasiva(rut, institucion, tipoLiquidacion, ano, mes)
                    Response.Write(__js.Serialize(reg))

                Case "anoIni"

                    Dim rut As String = Session("Usuario.Rut")
                    Dim actual As String = Date.Now.Year
                    actual += 1
                    Dim mes As String = Date.Now.Month
                    Dim anoini As String = ""
                    Dim lista As New List(Of String)

                    Dim reg As New Tipos.oIMESL()
                    reg.aniIni(rut, actual)
                    anoini = reg.ANOINI
                    If anoini = 0 Then
                        anoini = actual
                    End If

                    Dim institucion As String = "2"
                    Dim ano As Integer = anoini

                    While ano <> actual

                        Dim datos As List(Of Tipos.oIMESL) = New Tipos.oIMESL().consultarLista(rut, ano, institucion)

                        For i As Integer = 0 To datos.Count - 1

                            If datos.Item(i).NUMMES <> 0 Then
                                If lista.Count = 0 Then
                                    lista.Add(ano.ToString())
                                Else

                                    For x As Integer = 0 To lista.Count - 1
                                        If lista.Item(x) <> ano Then
                                            lista.Add(ano.ToString())
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        ano += 1
                    End While

                    If lista.Count = 0 Then
                        lista.Add(Date.Now.Year)
                    End If

                    Response.Write(__js.Serialize(lista))

                Case "listaAños"

                    Dim rut As String = Session("Usuario.Rut")
                    Dim actual As String = Date.Now.Year
                    Dim mes As String = Date.Now.Month
                    Dim anoini = Request.QueryString("anoIni")
                    Dim reg As New Tipos.oIMESL()
                    reg.consultar(rut, actual)
                    Response.Write(__js.Serialize(reg))

                Case "consultar"

                    Dim reg As New Usuario()
                    reg.RUT_FUN = Session("Usuario.Rut")
                    reg.NOMBRE_FUN = Session("Usuario.Nombre")
                    Response.Write(__js.Serialize(reg))

                Case "consultarDetalle"

                    Dim rut = Session("Usuario.Rut")
                    Dim institucion = Request.QueryString("institucion")
                    Dim tipoLiquidacion = Request.QueryString("tipoLiquidacion")
                    Dim ano = Request.QueryString("ano")
                    Dim mes = Request.QueryString("mes")
                    Dim reg As New Tipos.oICOLI()
                    reg.consultar(rut, institucion, tipoLiquidacion, ano, mes)
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

Public Class Usuario

    Public RUT_FUN As String = ""
    Public NOMBRE_FUN As String = ""

End Class