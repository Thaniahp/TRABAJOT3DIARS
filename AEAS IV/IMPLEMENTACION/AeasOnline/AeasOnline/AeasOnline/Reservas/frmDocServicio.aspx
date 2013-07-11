<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDocServicio.aspx.cs" MasterPageFile="~/Principal.Master" Inherits="AeasOnline.Reservas.frmDocServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            //$("#btnImprimir").click(function () {

            //});
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoprincipal" runat="server">
    <div class="row-fluid well">
        <div class="span3">&nbsp;</div>
        <div class="span5">Enviar a :<asp:TextBox ID="txtemail" runat="server"></asp:TextBox><br />
            <asp:Button CssClass="btn btn-warning" ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" /></div>
    </div>
    <div class="well">

        <div class="row-fluid">
            <div class="span3">&nbsp;</div>
            <div class="span6" id="divservicio" runat="server">
            </div>
            <div class="span3">&nbsp;</div>
        </div>
        <div style="width: 100%; height: 50px;">
            <a class="btn btn-warning" id="btnImprimir" style="float: right;" onclick="window.print();">Imprimir</a>
        </div>

    </div>
</asp:Content>
