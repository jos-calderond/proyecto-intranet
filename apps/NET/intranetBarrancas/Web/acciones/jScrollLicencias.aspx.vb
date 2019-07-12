Imports System.Collections.Generic
Imports slbaperbModel

''' <summary>
''' 05/06/2019 rtorreblanca: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class jScrollLicencias
    Inherits System.Web.UI.Page
    Private __pagina As String = "../acciones/jScrollLicencias.aspx"
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

            Select Case __accion

                Case "consultaMasiva"

                    Dim jScroll As New JScrollV2(Request, __pagina)

                    Dim row As New JScrollV2.myRow(Request)

                    row.OnDblclickJsFunction = "jScrollLicenciasRowClick"

                    Dim selano As String = jScroll.GetQueryString("periodo")

                    Dim usuarios As List(Of Tipos.oICLIC) = New Tipos.oICLIC().consultaMasiva(Session("Usuario.Rut"), selano)
                    jScroll.Data = usuarios

                    Dim fieldNUMLIC As New JScrollV2.myField("NUMLIC", "N° Licencia")
                    fieldNUMLIC.Width = 12
                    row.Fields.Add(fieldNUMLIC)

                    Dim fieldFECINI As New JScrollV2.myField("FECINI_LIC", "Fecha Inicio")
                    fieldFECINI.Width = 12
                    fieldFECINI.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                    Return Funciones.gFormatDate(fieldValue)
                                                End Function
                    row.Fields.Add(fieldFECINI)

                    Dim fieldFECTER As New JScrollV2.myField("FECTER_LIC", "Fecha Término")
                    fieldFECTER.Width = 12
                    fieldFECTER.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                    Return Funciones.gFormatDate(fieldValue)
                                                End Function
                    row.Fields.Add(fieldFECTER)

                    Dim fieldGLODIRECC As New JScrollV2.myField("GLODIRECC", "Dirección de reposo")
                    fieldGLODIRECC.Width = 30
                    row.Fields.Add(fieldGLODIRECC)

                    Dim fieldNRODIALIC As New JScrollV2.myField("NRODIA_LIC", "Días de reposo")
                    fieldNRODIALIC.Width = 12

                    fieldNRODIALIC.Alignment = JScrollV2.myField.FieldAlignment.Right
                    row.Fields.Add(fieldNRODIALIC)

                    Dim fieldFECACC_LIC As New JScrollV2.myField("NRODIA_LIC", "")
                    fieldFECACC_LIC.IsVisible = False
                    row.Fields.Add(fieldFECACC_LIC)

                    Dim fieldFECRESL As New JScrollV2.myField("NRODIA_LIC", "")
                    fieldFECRESL.IsVisible = False
                    row.Fields.Add(fieldFECRESL)

                    Dim fieldRESSAL As New JScrollV2.myField("NRODIA_LIC", "")
                    fieldRESSAL.IsVisible = False
                    row.Fields.Add(fieldRESSAL)

                    jScroll.RowConfiguration = row
                    Response.Write(jScroll.GetMyGrid())

                Case "consulta3Meses"
                    Dim monto As Integer
                    Dim jScroll As New JScrollV2(Request, __pagina)

                    Dim row As New JScrollV2.myRow(Request)
                    Dim fecLic As String = jScroll.GetQueryString("fecini_lic")

                    fecLic = Funciones.gMcpFormatDate(fecLic, Funciones.DateFormats.AAAAMMDD)

                    Dim reg As New Tipos.oCINLI()
                    reg.consultar(fecLic, Session("Usuario.Rut"))

                    Dim licencia1 As New JscrollLicencia
                    licencia1.periodo = reg.GLOMES1
                    licencia1.diasTrabajados = reg.DIASNO1
                    licencia1.rtaImpPrevAntigua = reg.FONREG1
                    licencia1.TotalRemuneraciones = reg.RENIMP1
                    licencia1.fondoPensiones = reg.FONPEN1
                    licencia1.fondoDesahucio = reg.FONDES1
                    licencia1.fondoSalud = reg.FONSAL1
                    licencia1.totalLeyesSociales = reg.LEYSOC1
                    licencia1.impuestoUnico = reg.IMPUNI1
                    licencia1.totalRemunNeta = reg.REMNET1

                    Dim licencia2 As New JscrollLicencia
                    licencia2.periodo = reg.GLOMES2
                    licencia2.diasTrabajados = reg.DIASNO2
                    licencia2.rtaImpPrevAntigua = reg.FONREG2
                    licencia2.TotalRemuneraciones = reg.RENIMP2
                    licencia2.fondoPensiones = reg.FONPEN2
                    licencia2.fondoDesahucio = reg.FONDES2
                    licencia2.fondoSalud = reg.FONSAL2
                    licencia2.totalLeyesSociales = reg.LEYSOC2
                    licencia2.impuestoUnico = reg.IMPUNI2
                    licencia2.totalRemunNeta = reg.REMNET2

                    Dim licencia3 As New JscrollLicencia
                    licencia3.periodo = reg.GLOMES3
                    licencia3.diasTrabajados = reg.DIASNO3
                    licencia3.rtaImpPrevAntigua = reg.FONREG3
                    licencia3.TotalRemuneraciones = reg.RENIMP3
                    licencia3.fondoPensiones = reg.FONPEN3
                    licencia3.fondoDesahucio = reg.FONDES3
                    licencia3.fondoSalud = reg.FONSAL3
                    licencia3.totalLeyesSociales = reg.LEYSOC3
                    licencia3.impuestoUnico = reg.IMPUNI3
                    licencia3.totalRemunNeta = reg.REMNET3

                    Dim lista As New List(Of JscrollLicencia)

                    lista.Add(licencia1)
                    lista.Add(licencia2)
                    lista.Add(licencia3)

                    jScroll.Data = lista

                    Dim fieldperiodo As New JScrollV2.myField("periodo", "Periodo")
                    fieldperiodo.Width = 5
                    row.Fields.Add(fieldperiodo)
                    fieldperiodo.Alignment = JScrollV2.myField.FieldAlignment.Right

                    Dim fielddiasTrabajados As New JScrollV2.myField("diasTrabajados", "Dias Trabajados")
                    fielddiasTrabajados.Width = 6
                    row.Fields.Add(fielddiasTrabajados)
                    fielddiasTrabajados.Alignment = JScrollV2.myField.FieldAlignment.Right

                    Dim fieldrtaImpPrevAntigua As New JScrollV2.myField("rtaImpPrevAntigua", "Rta Imp Prev Antigua")
                    fieldrtaImpPrevAntigua.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                               monto = fieldValue
                                                               Return monto.ToString("##,#")
                                                           End Function
                    fieldrtaImpPrevAntigua.Width = 7
                    row.Fields.Add(fieldrtaImpPrevAntigua)
                    fieldrtaImpPrevAntigua.Alignment = JScrollV2.myField.FieldAlignment.Right

                    Dim fieldTotalRemuneraciones As New JScrollV2.myField("TotalRemuneraciones", "Total Remuneraciones")
                    fieldTotalRemuneraciones.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                                 monto = fieldValue
                                                                 Return monto.ToString("##,#")
                                                             End Function
                    fieldTotalRemuneraciones.Width = 9
                    row.Fields.Add(fieldTotalRemuneraciones)
                    fieldTotalRemuneraciones.Alignment = JScrollV2.myField.FieldAlignment.Right

                    Dim fieldfondoPensiones As New JScrollV2.myField("fondoPensiones", "Fondo Pensiones")
                    fieldfondoPensiones.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                            monto = fieldValue
                                                            Return monto.ToString("##,#")
                                                        End Function
                    fieldfondoPensiones.Width = 7
                    row.Fields.Add(fieldfondoPensiones)

                    fieldfondoPensiones.Alignment = JScrollV2.myField.FieldAlignment.Right
                    Dim fieldfondoDesahucio As New JScrollV2.myField("fondoDesahucio", "Fondo Desahucio")
                    fieldfondoDesahucio.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                            monto = fieldValue
                                                            Return monto.ToString("##,#")
                                                        End Function
                    fieldfondoDesahucio.Width = 7
                    row.Fields.Add(fieldfondoDesahucio)
                    fieldfondoDesahucio.Alignment = JScrollV2.myField.FieldAlignment.Right

                    Dim fieldfondoSalud As New JScrollV2.myField("fondoSalud", "Fondo Salud")
                    fieldfondoSalud.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                        monto = fieldValue
                                                        Return monto.ToString("##,#")
                                                    End Function
                    fieldfondoSalud.Width = 7
                    row.Fields.Add(fieldfondoSalud)
                    fieldfondoSalud.Alignment = JScrollV2.myField.FieldAlignment.Right

                    Dim fieldtotalLeyesSociales As New JScrollV2.myField("totalLeyesSociales", "Total Leyes Sociales")
                    fieldtotalLeyesSociales.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                                monto = fieldValue
                                                                Return monto.ToString("##,#")
                                                            End Function
                    fieldtotalLeyesSociales.Width = 7
                    row.Fields.Add(fieldtotalLeyesSociales)
                    fieldtotalLeyesSociales.Alignment = JScrollV2.myField.FieldAlignment.Right

                    Dim fieldimpuestoUnico As New JScrollV2.myField("impuestoUnico", "Impuesto Unico")
                    fieldimpuestoUnico.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                           monto = fieldValue
                                                           Return monto.ToString("##,#")
                                                       End Function
                    fieldimpuestoUnico.Width = 7
                    row.Fields.Add(fieldimpuestoUnico)
                    fieldimpuestoUnico.Alignment = JScrollV2.myField.FieldAlignment.Right

                    Dim fieldtotalRemunNeta As New JScrollV2.myField("totalRemunNeta", "Total Remun Neta")
                    fieldtotalRemunNeta.FieldFunction = Function(fieldValue As String, rowSequence As Integer) As String
                                                            monto = fieldValue
                                                            Return monto.ToString("##,#")
                                                        End Function
                    fieldtotalRemunNeta.Width = 7
                    row.Fields.Add(fieldtotalRemunNeta)
                    fieldtotalRemunNeta.Alignment = JScrollV2.myField.FieldAlignment.Right

                    jScroll.RowConfiguration = row
                    Response.Write(jScroll.GetMyGrid())

            End Select

        Catch ex As Exception

            Response.Write(ex.Message)

        End Try

    End Sub

    Class JscrollLicencia

        Public periodo As String
        Public diasTrabajados As String
        Public rtaImpPrevAntigua As String
        Public TotalRemuneraciones As String
        Public fondoPensiones As String
        Public fondoDesahucio As String
        Public fondoSalud As String
        Public totalLeyesSociales As String
        Public impuestoUnico As String
        Public totalRemunNeta As String

        Sub New()

        End Sub

    End Class

End Class