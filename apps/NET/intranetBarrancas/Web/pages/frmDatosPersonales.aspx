<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmDatosPersonales.aspx.vb" Inherits="frmDatosPersonales"
 MasterPageFile="~/Site.Master" %>

<%@ Register Src="../controles/wucDatosPersonales.ascx" TagName="wucDatosPersonales" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  <uc1:wucDatosPersonales runat="server" ID="miWucDatosPersonales" />
</asp:Content>
