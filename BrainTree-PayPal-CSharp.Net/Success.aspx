<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="BrainTree_PayPal_CSharp.Net.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    The payment has been successful for the order with basketId: <asp:Label ID="BasketId" runat="server" Text="Label"></asp:Label>
</asp:Content>
