<%@ Page StylesheetTheme="Tema1" Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AeasOnline.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoprincipal" runat="server">

    <div class="content form-signin" style="width:300px; margin:130px auto 20px auto;">
    <center>
    <div>
        <h1>AEAS</h1>
        <h3 style="margin-top:-40px;">Asociaci&oacute;n de Ex-Alumnos Sanjuanistas</h3>
    </div>
    </center>
        <asp:TextBox ID="txtUser" runat="server" placeholder="Usuario" class="input-block-level"></asp:TextBox>
        <asp:TextBox ID="txtPass" runat="server" placeholder="Password" TextMode="Password" class="input-block-level"></asp:TextBox>
        <asp:LinkButton ID="lbtn_Entrar" runat="server" OnClick="lbtn_Entrar_Click" class="btn btn-warning btn-large" Style="margin-top: 0px;">Ingresar</asp:LinkButton>
        <a href="registrate.aspx" class="btn" style="margin-top: 0px; float:right;">Registrarse</a>
    </div>
    <center>
        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red" Font-Bold="True" Font-Size="Larger"></asp:Label>
    </center>
    
</asp:Content>
