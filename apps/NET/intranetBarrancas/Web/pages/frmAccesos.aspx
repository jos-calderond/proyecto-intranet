<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAccesos.aspx.vb" Inherits="frmAccesos"
  MasterPageFile="~/Site.Master" %>

<%@ Register Src="../controles/wucAccesos.ascx" TagName="wucAccesos" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
  <uc1:wucAccesos runat="server" ID="miWucAccesos" />
</asp:Content>
