<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cabecalho.ascx.cs" Inherits="Content_Header_WebUserControl" %>
<div class="container">
    <div class="div1">
        <asp:Label ID="lblData" runat="server" Text=""></asp:Label>
    </div>

    <div class="div2">
        <asp:Label ID="lblProjeto" runat="server" Text="Projeto de Exemplo">

        </asp:Label>
    </div>
</div>

<style>
    .container {
        border: 1pt solid black;
        clear: both
    }

    .div1 {
        float: left;
        width: 45%;
        text-align: center;
    }

    .div2 {
        margin-left: 50%; 
        width: 45%; 
        text-align: center;
    }
</style>