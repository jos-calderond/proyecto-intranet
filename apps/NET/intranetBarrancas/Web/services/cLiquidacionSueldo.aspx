<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cLiquidacionSueldo.aspx.vb"
    Inherits="cLiquidacionSueldo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" runat="server" id="html">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 160px;
        }
        .style2
        {
            width: 134px;
        }
        .style5
        {
            height: 17px;
        }
        .style6
        {
            width: 91px;
        }
        .style7
        {
            height: 17px;
            width: 91px;
        }
        .style8
        {
            width: 88px;
        }
        .style9
        {
            width: 266px;
        }
    </style>
</head>
<body>
    <form id="frmPDF" action="">
    <div id="headContent" runat="server">
        <table style="width: 700px;">
            <tbody>
                <tr>
                    <td>
                        <img src="" id="imglogoGob" runat="server" alt="" style="width: 110px; height: 110px" />
                    </td>
                    <td style="text-align: center; font-size: 9pt;" class="style9;width: 220px">
                        SERVICIO LOCAL DE EDUCACIÓN PUBLICA BARRANCAS
                        <br />
                        64.154.021-6
                        <br />
                        <br />
                        COPIA LIQUIDACIÓN N°
                        <asp:Label ID="lblNumroLiqui" name="lblNumroLiqui" runat="server"></asp:Label>
                    </td>
                    <td>
                        <img src="" id="imgLogoBarrancas" runat="server" alt="" style="width: 110px; height: 110px;
                            text-align: right" />
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <table style="width: 700px;">
            <tbody>
                <tr>
                    <td style="font-family: Verdana, Arial; font-size: 8pt; width: 305px" height="20"
                        align="left">
                        <strong>Centro de Costo :</strong>
                        <asp:Label ID="lblCentroCosto" name="lblCentroCosto" runat="server"></asp:Label>
                    </td>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Mes de Pago :</strong>
                        <asp:Label ID="lblMesPago" name="lblMesPago" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Nombre :</strong>
                        <asp:Label ID="lblNombre" name="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Año :</strong>
                        <asp:Label ID="lblAno" name="lblAno" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>RUT :</strong>
                        <asp:Label ID="lblRut" name="lblRut" runat="server"></asp:Label>
                    </td>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>N° de Bienios :</strong>
                        <asp:Label ID="lblBienios" name="lblBienios" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Previsión :</strong>
                        <asp:Label ID="lblPrevision" name="lblPrevision" runat="server"></asp:Label>
                    </td>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Periodo de Pago :</strong>
                        <asp:Label ID="lblPeriodoPago" name="lblPeriodoPago" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Salud :</strong>
                        <asp:Label ID="lblSalud" name="lblSalud" runat="server"></asp:Label>
                    </td>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Dias Trabajados :</strong>
                        <asp:Label ID="lblDiasTrabajados" name="lblDiasTrabajados" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Fecha Contrato :</strong>
                        <asp:Label ID="lblFecContrato" name="lblFecContrato" runat="server"></asp:Label>
                    </td>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Pactado :</strong>
                        <asp:Label ID="lblPactado" name="lblPactado" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                    </td>
                    <td style="font-family: Verdana, Arial; font-size: 8pt;" height="20" align="left">
                        <strong>Jornada :</strong><asp:Label ID="lblJornada" name="lblJornada" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        
        <table style="width: 700px; height: 448px;">
            <tbody>
                <tr>
                    <td style="width: 202.033px; border: 1 solid black" colspan="2" align="center">
                        HABERES
                    </td>
                    <td style="width: 202.033px; border: 1 solid black" colspan="2" align="center">
                        DESCUENTOS
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="h1" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hM1" align="right">
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="d1" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dM1" align="right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="h2" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hM2" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="d2" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dM2" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="h3" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hM3" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="d3" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dM3" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="h4" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hM4" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="d4" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dM4" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="h5" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hM5" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="d5" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dM5" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="h6" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hM6" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="d6" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dM6" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="h7" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hM7" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="d7" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dM7" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="h8" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hM8" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="d8" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dM8" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="h9" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hM9" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="d9" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dM9" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 11pt; border-bottom: 1 solid black" align="left">
                        TOTAL IMPONIBLE :
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-bottom: 1 solid black; border-right: 1 solid black"
                        align="right" runat="server" id="totalHaberesImponibles">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 11pt; border-bottom: 1 solid black" align="left">
                        TOTAL DESC LEGALES :
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-bottom: 1 solid black" align="right"
                        runat="server" id="totalDescuentosImponibles">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="hN1" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hNM1" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="dV1" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dVM1" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="hN2" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hNM2" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="dV2" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dVM2" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="hN3" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hNM3" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="dV3" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dVM3" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="hN4" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hNM4" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="dV4" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dVM4" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="hN5" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hNM5" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="dV5" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dVM5" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="hN6" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hNM6" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dV6" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="dVM6" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="hN7" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hNM7" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="dV7" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dVM7" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="hN8" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hNM8" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="dV8" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dVM8" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="hN9" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" runat="server"
                        id="hNM9" align="right">
                        &nbsp;
                    </td>
                    <td style="width: 380px; font-size: 9pt;" runat="server" id="dV9" align="left">
                        &nbsp;
                    </td>
                    <td style="width: 20px; font-size: 9pt;" runat="server" id="dVM9" align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 11pt; border-bottom: 1 solid black" align="left">
                        TOTAL NO IMPONIBLE
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-bottom: 1 solid black; border-right: 1 solid black"
                        align="right" runat="server" id="totalNoImponible">
                    </td>
                    <td style="width: 380px; font-size: 11pt; border-bottom: 1 solid black" align="left">
                        TOTAL DESC VARIOS
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-bottom: 1 solid black" align="right"
                        runat="server" id="totalDescuentosVariables">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 11pt; border-bottom: 1 solid black" align="left">
                        TOTAL HABERES :
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-bottom: 1 solid black; border-right: 1 solid black"
                        align="right" runat="server" id="totalHaberes">
                    </td>
                    <td style="width: 380px; font-size: 11pt; border-bottom: 1 solid black" align="left">
                        TOTAL DESCUENTOS :
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-bottom: 1 solid black" align="right"
                        runat="server" id="totalDescuentos">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 380px; font-size: 11pt;" align="left">
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-right: 1 solid black" align="right"
                        runat="server">
                    </td>
                    <td style="width: 380px; font-size: 11pt; border-bottom: 1 solid black" align="left">
                        LIQUIDO A PAGO :
                    </td>
                    <td style="width: 20px; font-size: 9pt; border-bottom: 1 solid black" align="right"
                        runat="server" id="liquidoPago">
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
        <br />
        <table style="width: 700px">
            <tbody>
                <tr>
                    <td align="left" style="width: 150px; font-size: small">
                        Código de Verificación :
                    </td>
                    <td align="left" style="width: 405px" runat="server" id="CodigoVerifica">
                    </td>
                </tr>
                <tr>
                <td  align="left" style="width: 150px; font-size: small">Página Validadora :</td>
                 <td align="right" style="width: 405px; font-size: small" runat="server" id="paginaWeb"></td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
