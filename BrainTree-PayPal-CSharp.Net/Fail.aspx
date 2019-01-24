<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fail.aspx.cs" Inherits="BrainTree_PayPal_CSharp.Net.Fail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    There was a problem with the payment transaction for the order with basketId: <asp:Label ID="BasketId" runat="server" Text="Label"></asp:Label>
</asp:Content>
