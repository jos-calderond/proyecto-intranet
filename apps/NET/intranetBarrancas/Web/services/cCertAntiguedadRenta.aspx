<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cCertAntiguedadRenta.aspx.vb"
    Inherits="cCertAntiguedadRenta" %>

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
                        CERTIFICADO N°
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
        <br />
        <br />
        <br />
         <br />
        <table style="width: 700px;">
        <tbody>
             <tr>
               <td style="font-family: Verdana, Arial; font-size: 9pt; width: 650px" height="20"
                        align="left">El Servicio Local de Educación Pública Las Barrancas certifica que <asp:Label ID="lblNombre" name="lblNombre" runat="server"></asp:Label> con Rut <asp:Label ID="lblRut" name="lblRut" runat="server"></asp:Label></td>
             </tr>
             <tr>
             <td style="font-family: Verdana, Arial; font-size: 9pt; width: 650px" height="20"
                        align="left">es funcionario de este servicio desde el <asp:Label ID="lblFecha" name="lblFecha" runat="server"></asp:Label>, desempeñando actualmente el cargo de </td>
             </tr>
             <tr>
             <td  style="font-family: Verdana, Arial; font-size: 9pt; width: 650px" height="20"
                        align="left"> <asp:Label ID="lblTipoContrato" name="lblTipoContrato" runat="server"></asp:Label>, con contrato de trabajo,En el mes de <asp:Label ID="lblMes" name="lblMes" runat="server"></asp:Label> del <asp:Label ID="lblAno" name="lblAno" runat="server"></asp:Label>,percibio una renta </td>
             </tr>
             <tr>
             <td style="font-family: Verdana, Arial; font-size: 9pt; width: 650px" height="20"
                        align="left">bruta de  $<asp:Label ID="lblRenta" name="lblRenta" runat="server"></asp:Label> - (<asp:Label ID="lblDescripccion" name="lblDescripccion" runat="server"></asp:Label>).</td>
             </tr>
        </tbody>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table>
        <tbody>
        <tr>
        <td style="font-family: Verdana, Arial; font-size: 9pt; width: 700px" height="20"
                        align="left">Se otorga el presente documento a solicitud del interesado,para los fines que este estime convenientes.</td>
        </tr>
        </tbody>
        </table>
        <br />
         <br />
        <br />
        <br />
        <br />
         <br />
        <br />
        <table>
        <tbody>
        <tr>
        <td>Santiago,<asp:Label ID="lblFechaActual" name="lblFechaActual" runat="server"></asp:Label></td>
        </tr>
        </tbody>
        </table>
         <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table style="width: 700px">
            <tbody>
                <tr>
                    <td align="left" style="width: 130px; font-size: small">Código de Verificación :</td>
                    <td align="left" style="width: 400px" runat="server" id="CodigoVerifica"></td>
                    </tr>
                    <tr>
                    <td align="left" style="width: 130px; font-size: small">Página validadora: </td>
                    <td align="left" style="width: 400px; font-size: small" runat="server" id="paginaWeb">
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
