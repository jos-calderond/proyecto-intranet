<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCambioClave.aspx.vb" Inherits="frmCambioClave"
  MasterPageFile="~/Site.Master" %>

<%@ Register Src="../controles/wucCambioClave.ascx" TagName="wucCambioClave" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  <uc1:wucCambioClave runat="server" ID="miWucCambioClave" />
</asp:Content>
