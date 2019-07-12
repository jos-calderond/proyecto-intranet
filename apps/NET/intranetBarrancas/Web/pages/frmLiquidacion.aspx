<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLiquidacion.aspx.vb" Inherits="frmLiquidacion"
 MasterPageFile="~/Site.Master" %>

<%@ Register Src="../controles/wucLiquidacion.ascx" TagName="wucLiquidacion" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  <uc1:wucLiquidacion runat="server" ID="miWucLiquidacion" />
</asp:Content>
