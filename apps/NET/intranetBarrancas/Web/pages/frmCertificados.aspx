<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCertificados.aspx.vb" Inherits="frmCertificados"
  MasterPageFile="~/Site.Master" %>

<%@ Register Src="../controles/wucCertificados.ascx" TagName="wucCertificados" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  <uc1:wucCertificados runat="server" ID="miWucCertificados" />
</asp:Content>
