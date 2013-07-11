<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Principal.Master" CodeBehind="Home.aspx.cs" Inherits="AeasOnline.General.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            CargarDataEvento();
            CargarDataAmbiente();
            CargarDataCurso();
        });
        function CargarDataEvento() {
            var glancedata = $("#<%=hfDataEvento.ClientID%>").val() != '' ? $("#<%=hfDataEvento.ClientID%>").val() : '{}';
            
                var obj = $.parseJSON(glancedata);
                var len = obj.length;
                for (var i = 0; i < len; i++) {
                    var index = i + 1;
                    var str = "<div id='evento" + obj[i].Id + "'>"
                            + "<strong>" + obj[i].Nombre + "</strong>"
                            + "<br>" + obj[i].Descripcion
                            + "<br> s/." + obj[i].Precio
                            + "<br><a href='../Reservas/frmDocServicio.aspx?t=e&id=" + obj[i].Id + "'>Enviar a un contacto</a>"
                            + "</div><br>";
                    $("#divEventos").append(str);
                    //var row = {
                    //    id: obj[i].Id,
                    //    num: i + 1,
                    //    fecini: obj[i].FechaInicio,
                    //    fecfin: obj[i].FechaFin,
                    //    direccion: obj[i].Direccion,
                    //    organizador: obj[i].Organizador
                    //    //descripcion: obj[i].Descripcion
                    //};
                }
            
        }
        function CargarDataAmbiente() {
            var glancedata = $("#<%=hfDataAmbiente.ClientID%>").val() != '' ? $("#<%=hfDataAmbiente.ClientID%>").val() : '{}';
            
                var obj = $.parseJSON(glancedata);
                var len = obj.length;
                for (var i = 0; i < len; i++) {
                    var index = i + 1;
                    var str = "<div id='ambiente" + obj[i].Id + "'>"
                            + "<strong>" + obj[i].Nombre + "</strong>"
                            + "<br>" + obj[i].Direccion
                            + "<br>" + obj[i].Telefono
                            + "<br> s/." + obj[i].Precio
                            + "<br><a href='#'>Enviar a un contacto</a>"
                            + "</div><br>";
                    $("#divAmbiente").append(str);
                    //var row = {
                    //    id: obj[i].Id,
                    //    num: i + 1,
                    //    nombre: obj[i].Nombre,
                    //    precio: obj[i].Precio,
                    //    direccion: obj[i].Direccion,
                    //    telefono: obj[i].Telefono,
                    //    capacidad: obj[i].Capacidad
                    //};

                }
            
        }
        function CargarDataCurso() {
            var glancedata = $("#<%=hfDataCurso.ClientID%>").val() != '' ? $("#<%=hfDataCurso.ClientID%>").val() : '{}';
            
                var obj = $.parseJSON(glancedata);
                var len = obj.length;
                for (var i = 0; i < len; i++) {
                    var index = i + 1;
                    var str = "<div id='curso" + obj[i].Id + "'>"
                            + "<strong>Curso : " + obj[i].Nombre + "</strong>"
                            + "<br> Inicio : " + obj[i].FechaInicio
                            + "<br> s/." + obj[i].Precio
                            + "<br><a href='#'>Enviar a un contacto</a>"
                            + "</div><br>";
                    $("#divCurso").append(str);
                    //var row = {
                    //    id: obj[i].Id,
                    //    num: i + 1,
                    //    nombre: obj[i].Nombre,
                    //    precio: obj[i].Precio,
                    //    fecini: obj[i].FechaInicio,
                    //    fecfin: obj[i].FechaFin,
                    //    capacidad: obj[i].Capacidad
                    //};
                }
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoprincipal" runat="server">
    <div class="well">
        <div class="row-fluid">
            <div class="span4">
                <h2>Eventos</h2>
                <p>
                    Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, 
                  tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem 
                  malesuada magna mollis euismod. Donec sed odio dui.
                </p>
                <div id="divEventos">
                </div>
            </div>
            <!--/span-->
            <div class="span4">
                <h2>Cursos</h2>
                <p>
                    Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, 
                  tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem 
                  malesuada magna mollis euismod. Donec sed odio dui.
                </p>
                <div id="divCurso">
                </div>
            </div>
            <!--/span-->
            <div class="span4">
                <h2>Ambientes</h2>
                <p>
                    Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, 
                  tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem 
                  malesuada magna mollis euismod. Donec sed odio dui.
                </p>
                <div id="divAmbiente">
                </div>
            </div>
            <!--/span-->
        </div>
        <div style="width:100%; height:50px;">
            <a class="btn btn-warning" href="../Reservas/frmReservas.aspx" style="float:right;">Ir a reservas</a>
        </div>
        
    </div>
    <asp:HiddenField ID="hfDataEvento" runat="server" />
    <asp:HiddenField ID="hfDataCurso" runat="server" />
    <asp:HiddenField ID="hfDataAmbiente" runat="server" />
</asp:Content>
