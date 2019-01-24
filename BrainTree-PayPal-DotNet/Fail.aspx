<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Fail.aspx.vb" Inherits="BrainTree_PayPal_DotNet.Fail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    There was a problem with the payment transaction for the order with basketId: <asp:Label ID="BasketId" runat="server" Text="Label"></asp:Label>
</asp:Content>
