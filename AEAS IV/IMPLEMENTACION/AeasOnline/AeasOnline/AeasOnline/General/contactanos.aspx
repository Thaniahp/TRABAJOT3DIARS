<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactanos.aspx.cs" Inherits="AeasOnline.General.contactanos" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoprincipal" runat="server">
    <div class="well">
        <form class="form-horizontal">
            <div class="control-group">
                <label class="control-label" for="inputEmail">Email</label>
                <div class="controls">
                    <input type="text" id="inputEmail" placeholder="Email">
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="inputPassword">Asunto</label>
                <div class="controls">
                    <input type="password" id="inputPassword" placeholder="Password">
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="inputPassword">Mensaje</label>
                <div class="controls">
                    <textarea></textarea>
                </div>
            </div>
            <a class="btn">Enviar</a>
        </form>
    </div>
</asp:Content>













