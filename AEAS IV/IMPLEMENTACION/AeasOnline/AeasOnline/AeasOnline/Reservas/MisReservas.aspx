<%@ Page styleSheetTheme="Tema1" Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Principal.Master" CodeBehind="MisReservas.aspx.cs" Inherits="AeasOnline.Reservas.MisReservas" %>
          
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var $ = jQuery.noConflict();
        $(document).ready(function () {
            CrearTablaEvento();
            CargarDataEvento();
            CrearTablaAmbiente();
            CargarDataAmbiente();
            CrearTablaCurso();
            CargarDataCurso();
            $("#<%=ddlTipoReserva.ClientID%>").change(function () {
            if ($(this).val() == "1") {
                $("#divambiente").hide();
                $("#divcurso").hide();
                $("#divevento").show();
            }
            if ($(this).val() == "2") {
                $("#divcurso").hide();
                $("#divevento").hide();
                $("#divambiente").show();
            }
            if ($(this).val() == "3") {
                $("#divambiente").hide();
                $("#divevento").hide();
                $("#divcurso").show();
            }
        });
    });
        function CrearTablaEvento() {

            try {
                $("#eventosdisponibles").jqGrid({
                    datatype: 'local',
                    colNames: ['', '#', 'Nombre', 'Fecha Reserva', 'Total', 'Fecha Inicio', 'Fecha Fin'],
                    colModel: [
                            { name: 'id', index: 'id', hidden: true },
                            { name: 'num', index: 'num', align: 'center', sorttype: 'number', width: 8 },
                            { name: 'nombre', index: 'nombre', width: 40, align: 'center', sorttype: 'text' },
                            { name: 'fecha', index: 'fecha', width: 20, align: 'center', sorttype: 'text' },
                            { name: 'total', index: 'total', width: 20, align: 'center', sorttype: 'text' },
                            { name: 'fecini', index: 'fecini', align: 'center', sorttype: 'text', width: 25 },
                            { name: 'fecfin', index: 'fecfin', width: 25, align: 'center', sorttype: 'text' }                            
                            //{ name: 'descripcion', index: 'descripcion', width: 15, align: 'center', sorttype: 'text' }
                    ],
                    width: 1040,
                    height: 'auto',
                    pager: '#eventosdisponiblespager',
                    viewrecords: true,
                    sortorder: 'desc',
                    rowNum: 10,
                    rowList: [10, 20, 30],
                    caption: "Eventos Reservados",
                    multiselect: true,
                    onSelectRow: function (id, status) {

                    },
                    onSelectAll: function (aRowids, status) {

                    }
                });


            } catch (e) { }
        }
        function CargarDataEvento() {
            var glancedata = $("#<%=MisEventosData.ClientID%>").val() != '' ? $("#<%=MisEventosData.ClientID%>").val() : '{}';
            try {
                var obj = $.parseJSON(glancedata);
                var len = obj.length;
                for (var i = 0; i < len; i++) {
                    var index = i + 1;
                    var row = {
                        id: obj[i].IdReserva,
                        num: i + 1,
                        nombre: obj[i].NombreEvento,
                        fecha:obj[i].FechaReserva,
                        total: obj[i].Total,
                        fecini: obj[i].FechaInicio,
                        fecfin: obj[i].FechaFin,
                    };

                    $("#eventosdisponibles").jqGrid('addRowData', i + 1, row);
                }
                $("#eventosdisponibles").trigger("reloadGrid");
            }
            catch (e) { }
        }
        function CrearTablaAmbiente() {
            try {
                $("#ambientesdisponibles").jqGrid({
                    datatype: 'local',
                    colNames: ['', '#', 'Nombre', 'Direccion', 'Fecha Reserva', 'Total'],
                    colModel: [
                            { name: 'id', index: 'id', hidden: true },
                            { name: 'num', index: 'num', align: 'center', sorttype: 'number', width: 10 },
                            { name: 'nombre', index: 'nombre', width: 70, align: 'center', sorttype: 'text' },
                            { name: 'direccion', index: 'direccion', width: 45, align: 'center', sorttype: 'text' },
                            { name: 'fecha', index: 'fecha', width: 45, align: 'center', sorttype: 'text' },
                            { name: 'total', index: 'total', width: 20, align: 'center', sorttype: 'text' }
                    ],
                    width: 1040,
                    height: 'auto',
                    pager: '#ambientesdisponiblespager',
                    viewrecords: true,
                    sortorder: 'desc',
                    rowNum: 10,
                    rowList: [10, 20, 30],
                    caption: "Ambientes disponibles",
                    multiselect: true,
                    onSelectRow: function (id, status) {

                    },
                    onSelectAll: function (aRowids, status) {
                    }
                });


            } catch (e) { }
        }
        function CargarDataAmbiente() {
            var glancedata = $("#<%=MisAmbientesData.ClientID%>").val() != '' ? $("#<%=MisAmbientesData.ClientID%>").val() : '{}';
            try {
                var obj = $.parseJSON(glancedata);
                var len = obj.length;
                for (var i = 0; i < len; i++) {
                    var index = i + 1;
                    var row = {
                        id: obj[i].IdReserva,
                        num: i + 1,
                        nombre: obj[i].NombreAmbiente,
                        total: obj[i].Total,
                        direccion: obj[i].Direccion,
                        fecha: obj[i].FechaReserva
                    };

                    $("#ambientesdisponibles").jqGrid('addRowData', i + 1, row);
                }
                $("#ambientesdisponibles").trigger("reloadGrid");
            }
            catch (e) { }
        }
        function CrearTablaCurso() {
            try {
                $("#cursosdisponibles").jqGrid({
                    datatype: 'local',
                    colNames: ['', '#', 'Nombre', 'Total','Fecha Reserva', 'Fecha Inicio', 'Fecha Fin'],
                    colModel: [
                            { name: 'id', index: 'id', hidden: true },
                            { name: 'num', index: 'num', align: 'center', sorttype: 'number', width: 10 },
                            { name: 'nombre', index: 'nombre', width: 50, align: 'center', sorttype: 'text' },
                            { name: 'total', index: 'total', width: 20, align: 'center', sorttype: 'text' },
                            { name: 'fecha', index: 'fecha', width: 30, align: 'center', sorttype: 'text' },
                            { name: 'fecini', index: 'fecini', width: 45, align: 'center', sorttype: 'text' },
                            { name: 'fecfin', index: 'fecfin', align: 'center', sorttype: 'text', width: 50 }
                    ],
                    width: 1040,
                    height: 'auto',
                    pager: '#cursosdisponiblespager',
                    viewrecords: true,
                    sortorder: 'desc',
                    rowNum: 10,
                    rowList: [10, 20, 30],
                    caption: "Cursos disponibles",
                    multiselect: true,
                    onSelectRow: function (id, status) {
                    },
                    onSelectAll: function (aRowids, status) {

                    }
                });


            } catch (e) { }
        }
        function CargarDataCurso() {
            var glancedata = $("#<%=MisCursosData.ClientID%>").val() != '' ? $("#<%=MisCursosData.ClientID%>").val() : '{}';
            try {
                var obj = $.parseJSON(glancedata);
                var len = obj.length;
                for (var i = 0; i < len; i++) {
                    var index = i + 1;
                    var row = {
                        id: obj[i].IdReserva,
                        num: i + 1,
                        nombre: obj[i].NombreCurso,
                        total: obj[i].Total,
                        fecini: obj[i].FechaInicio,
                        fecfin: obj[i].FechaFin,
                        fecha: obj[i].FechaReserva
                    };

                    $("#cursosdisponibles").jqGrid('addRowData', i + 1, row);
                }
                $("#cursosdisponibles").trigger("reloadGrid");
            }
            catch (e) { }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoprincipal" runat="server">
    <div class="well">
    <h2 style="font-size:200%;">Mis Reservas</h2><br />
    <a href="frmReservas.aspx" style="float:right;margin-top:0px;" class="btn">Nueva Reserva</a>
    <div style="margin-top:20px;">
    <asp:DropDownList ID="ddlTipoReserva" runat="server">
        
        <asp:ListItem Value="0">-Seleccionar tipo de reserva-</asp:ListItem>
        <asp:ListItem Value="1">Evento</asp:ListItem>
        <asp:ListItem Value="2">Ambiente</asp:ListItem>
        <asp:ListItem Value="3">Curso</asp:ListItem>
    </asp:DropDownList>
        
    <div style="margin-top:15px;">
    <div id="divevento" style="display:none;">

         <table id="eventosdisponibles"></table>
        <div id="eventosdisponiblespager" ></div>
    </div>
    <div id="divambiente" style="display:none;">
        <table id="ambientesdisponibles"></table>
        <div id="ambientesdisponiblespager" ></div>
    </div>
    <div id="divcurso" style="display:none;">
        <table id="cursosdisponibles"></table>
        <div id="cursosdisponiblespager" ></div>

    </div>
    </div>
    </div>
    <asp:HiddenField ID="MisEventosData" runat="server" />
    <asp:HiddenField ID="MisAmbientesData" runat="server" />
    <asp:HiddenField ID="MisCursosData" runat="server" />

    </div>
</asp:Content>
