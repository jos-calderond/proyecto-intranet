<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLicencias.aspx.vb" Inherits="frmLicencias"
  MasterPageFile="~/Site.Master" %>

<%@ Register Src="../controles/wucLicencias.ascx" TagName="wucLicencias" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  <uc1:wucLicencias runat="server" ID="miWucLicencias" />
</asp:Content>
