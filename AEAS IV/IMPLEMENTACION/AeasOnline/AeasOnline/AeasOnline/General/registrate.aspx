<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="registrate.aspx.cs" Inherits="AeasOnline.General.registrate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
                //Estas funciones Ketchup sirven para las validaciones.
            $.ketchup.messages({//aqui seteamos los mensajes que queremos que aparezcan
                required: 'Debe llenar este campo',
                number: 'Debe ingresar un numero',
                email: 'Debe ingresar un email valido'
            });
            //aqui se activa el validador.
            $('#frmRegistro').ketchup();
            //esto activa el plugin de Fechas.
            $("#<%=txtxfechaNacimiento.ClientID%>").datepicker();
            
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoprincipal" runat="server">

    <div class="content form-signin form-horizontal" style="width:600px; margin:30px auto 20px auto;" id="frmRegistro">
    
        <center>
        <h1>AEAS</h1>
        <h3 style="margin-top:-40px;">Asociaci&oacute;n de Ex-Alumnos Sanjuanistas</h3>
        </center>
        <legend style="margin-bottom:50px;">Registro de socios</legend>
        <asp:Label ID="lblOk" runat="server" Text="" ForeColor="#33CC33" Font-Bold="True"></asp:Label>
        <asp:LinkButton ID="lbtnRedirect" runat="server" OnClick="lbtnRedirect_Click">Iniciar sesi&oacute;n</asp:LinkButton>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Bold="True"></asp:Label>
          <div class="control-group">
            <label class="control-label" for="inputEmail">Usuario</label>
            <div class="controls">
              <asp:TextBox ID="txtUsername" runat="server" data-validate="validate(required)"></asp:TextBox>
            </div>
          </div>
          <div class="control-group">
            <label class="control-label" for="inputPassword">Contrase&ntilde;a</label>
            <div class="controls">
              <asp:TextBox ID="txtpass" runat="server" data-validate="validate(required)" TextMode="Password"></asp:TextBox>
            </div>
          </div>
          <div class="control-group">
            <label class="control-label" for="inputEmail">Nombre</label>
            <div class="controls">
              <asp:TextBox ID="txtnombre" runat="server" data-validate="validate(required)"></asp:TextBox>
            </div>
          </div>  
          <div class="control-group">
            <label class="control-label" for="inputEmail">Apellidos</label>
            <div class="controls">
              <asp:TextBox ID="txtapellido" runat="server" data-validate="validate(required)"></asp:TextBox>
            </div>
          </div> 
          <div class="control-group">
            <label class="control-label" for="inputEmail">DNI</label>
            <div class="controls">
              <asp:TextBox ID="txtdni" runat="server" data-validate="validate(required,number)" MaxLength="8"></asp:TextBox>
            </div>
          </div> 
          <div class="control-group">
            <label class="control-label" for="inputEmail">Fecha de Nacimiento</label>
            <div class="controls">
                <asp:TextBox ID="txtxfechaNacimiento" runat="server" data-validate="validate(required)"></asp:TextBox>
            </div>
          </div>      
          <div class="control-group">
            <label class="control-label" for="inputEmail">Telefono</label>
            <div class="controls">
              <asp:TextBox ID="txttelefono" runat="server" data-validate="validate(required,number)"></asp:TextBox>
            </div>
          </div> 
          <div class="control-group">
            <label class="control-label" for="inputEmail">Celular</label>
            <div class="controls">
              <asp:TextBox ID="txtcel" runat="server" data-validate="validate(required,number)"></asp:TextBox>
            </div>
          </div> 
          <div class="control-group">
            <label class="control-label" for="inputEmail">E-mail</label>
            <div class="controls">
              <asp:TextBox ID="txtemail" runat="server" data-validate="validate(required,email)"></asp:TextBox>
            </div>
          </div> 
        
          <div class="control-group">
            <div class="controls">
                <asp:LinkButton ID="lbtnRegistro" runat="server" OnClick="lbtnRegistro_Click" CssClass="btn">REGISTRATE</asp:LinkButton>
            </div>
          </div>

</asp:Content>
