<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Success.aspx.vb" Inherits="BrainTree_PayPal_DotNet.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    The payment has been successful for the order with basketId: <asp:Label ID="BasketId" runat="server" Text="Label"></asp:Label>
</asp:Content>
