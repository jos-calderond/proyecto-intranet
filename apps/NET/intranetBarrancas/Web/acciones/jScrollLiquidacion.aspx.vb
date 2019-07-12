Imports System.Collections.Generic
Imports slbaperbModel

''' <summary>
''' 05/06/2019 jcalderón: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class jScrollLiquidacion
    Inherits System.Web.UI.Page
    Private __pagina As String = "../acciones/jScrollLiquidacion.aspx"
    Private __accion As String = ""

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
                Throw New Exception(Funciones.gSessionCaducadaForJscroll)
            End If

            __accion = Request.QueryString("accion")
            Dim ano = Request.QueryString("ano")
            Dim institucion = Request.QueryString("institucion")
            Dim rut As String = Session("Usuario.Rut")
            Dim mes = Request.QueryString("mes")
            Dim tipoLiquidacion = "99"

            Select Case __accion

                Case "consultarLiquidaciones"

                    Dim jScroll As New JScrollV2(Request, __pagina)

                    Dim row As New JScrollV2.myRow(Request)

                    row.OnDblclickJsFunction = "jScrollLiquidacionRowClick"
                    row.OnDeleteJsFunction = "jScrollLiquidacionDeleteClick"

                    Dim liquidaciones As List(Of Tipos.oIMESL) = New Tipos.oIMESL().consultarLista(rut, ano, institucion)
                    jScroll.Data = liquidaciones

                    Dim fieldNUMMES As New JScrollV2.myField("NUMMES", "ID")
                    fieldNUMMES.Width = 10
                    row.Fields.Add(fieldNUMMES)

                    Dim fieldGLOSAMES As New JScrollV2.myField("GLOSAMES", "Mes")
                    row.Fields.Add(fieldGLOSAMES)

                    Dim fieldACCION As New JScrollV2.myField("", "ACCION")
                    fieldACCION.Alignment = JScrollV2.myField.FieldAlignment.Center
                    fieldACCION.Width = 10
                    fieldACCION.IsText = False

                    jScroll.RowConfiguration = row
                    Response.Write(jScroll.GetMyGrid())

                Case "consultarDetalleLiquidacion"
                    Dim monto As Integer
                    Dim jScroll As New JScrollV2(Request, __pagina)

                    Dim row As New JScrollV2.myRow(Request)

                    Dim liquidaciones As List(Of Tipos.oICOLI) = New Tipos.oICOLI().consultaMasiva(rut, institucion, tipoLiquidacion, ano, mes)
                    jScroll.Data = liquidaciones

                    Dim fieldNOMHAB As New JScrollV2.myField("NOMHAB", "HABERES")
                    fieldNOMHAB.Width = 20
                    row.Fields.Add(fieldNOMHAB)

                    Dim fieldVALHAB As New JScrollV2.myField("VALHAB", "MONTO")
                    fieldVALHAB.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                    monto = fieldValue
                                                    Return monto.ToString("##,#")
                                                End Function
                    fieldVALHAB.Width = 8
                    fieldVALHAB.Alignment = JScrollV2.myField.FieldAlignment.Right
                    row.Fields.Add(fieldVALHAB)

                    Dim fielDNOMDL As New JScrollV2.myField("NOMDL", "DESCUENTOS LEGALES")
                    fielDNOMDL.Width = 20
                    row.Fields.Add(fielDNOMDL)

                    Dim fielVALDL As New JScrollV2.myField("VALDL", "MONTO")
                    fielVALDL.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                  monto = fieldValue
                                                  Return monto.ToString("##,#")
                                              End Function
                    fielVALDL.Width = 8
                    fielVALDL.Alignment = JScrollV2.myField.FieldAlignment.Right
                    row.Fields.Add(fielVALDL)

                    Dim fielNOMDV As New JScrollV2.myField("NOMDV", "DESCUENTOS VARIOS")
                    fielNOMDV.Width = 20
                    row.Fields.Add(fielNOMDV)

                    Dim fielVALDV As New JScrollV2.myField("VALDV", "MONTO")
                    fielVALDV.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                  monto = fieldValue
                                                  Return monto.ToString("##,#")
                                              End Function
                    fielVALDV.Width = 8
                    fielVALDV.Alignment = JScrollV2.myField.FieldAlignment.Right
                    row.Fields.Add(fielVALDV)

                    jScroll.RowConfiguration = row
                    Response.Write(jScroll.GetMyGrid())

            End Select

        Catch ex As Exception

            Response.Write(ex.Message)

        End Try

    End Sub

End Class

