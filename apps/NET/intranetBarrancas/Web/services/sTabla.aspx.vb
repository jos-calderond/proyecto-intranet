Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization

''' <summary>
''' 08/05/2019 rtorreblanca: Creación.
''' 15/05/2019 xbravo: Modificación.
''' </summary>
''' <remarks></remarks>
Partial Class sTabla
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
            Dim rut As String = Session("Usuario.Rut")

            Select Case accion

                Case "obtenerAnosLiqui"
                    Dim actual As String = Date.Now.Year
                    Dim anoIni As String = String.Empty

                    Dim tabla As New Tipos.oIMESL()
                    Dim lista As New List(Of Tipos.oIMESL)
                    lista = tabla.consultar(rut, actual)
                    Response.Write(__js.Serialize(lista))


                Case "obtenerMesesVigentes"
                    Dim tabla As New Tipos.oIMESL()
                    Dim lista As New List(Of Tipos.oIMESL)
                    lista = tabla.consultar(rut, "")
                    Response.Write(__js.Serialize(lista))

                Case "obtenerSituacionActual"
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar("STA")
                    Response.Write(__js.Serialize(lista))

                Case "obtenerEstadoCivil"
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar("ECV")
                    Response.Write(__js.Serialize(lista))

                Case "obtenerSituacionMilitar"
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar("SIM")
                    Response.Write(__js.Serialize(lista))

                Case "obtenerUnidadVecinal"
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar("UNV")
                    Response.Write(__js.Serialize(lista))

                Case "obtenerPoblacion"
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar("POB")
                    Response.Write(__js.Serialize(lista))

                Case "obtenerComunas"
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar("COM")
                    Response.Write(__js.Serialize(lista))

                Case "obtenerAreasSociales"
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar("ARE")
                    Response.Write(__js.Serialize(lista))

                Case "obtenerParentesco"
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar("TPA")
                    Response.Write(__js.Serialize(lista))

                Case "obtenerNivelEstudios"
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar("ESC")
                    Response.Write(__js.Serialize(lista))

                Case "consultar"
                    Dim codigo As String = Request.QueryString("codigo")
                    Dim tabla As New Tipos.oCONTA()
                    Dim lista As New List(Of Tipos.oCONTA)
                    lista = tabla.consultar(codigo)
                    Response.Write(__js.Serialize(lista))

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