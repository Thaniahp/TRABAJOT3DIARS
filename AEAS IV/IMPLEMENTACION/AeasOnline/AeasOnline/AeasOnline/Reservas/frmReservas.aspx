<%@ Page styleSheetTheme="Tema1" Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="frmReservas.aspx.cs" Inherits="AeasOnline.Reservas.frmReservas" %>
          
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    <script>
        var totalevento = 0;
        var totalambiente = 0;
        var totalcurso = 0;
    var $=jQuery.noConflict();
    $(document).ready(function () {
        $(".total").attr("style", "display:none;");
        CrearTablaEvento();
        CargarDataEvento();
        CrearTablaAmbiente();
        CargarDataAmbiente();
        CrearTablaCurso();
        CargarDataCurso();
        if ($("#<%=ddlTipoReserva.ClientID%>").val() == "1") {
            $("#divambiente").hide();
            $("#divcurso").hide();
            $("#divevento").show();
        }
        if ($("#<%=ddlTipoReserva.ClientID%>").val() == "2") {
            $("#divcurso").hide();
            $("#divevento").hide();
            $("#divambiente").show();
        }
        if ($("#<%=ddlTipoReserva.ClientID%>").val() == "3") {
            $("#divambiente").hide();
            $("#divevento").hide();
            $("#divcurso").show();
        }
        $("#<%=ddlTipoReserva.ClientID%>").change(function () {
            if ($(this).val() == "1")
            {
                $("#divambiente").hide();
                $("#divcurso").hide();
                $("#divevento").show();
            }
            if ($(this).val() == "2")
            {
                $("#divcurso").hide();
                $("#divevento").hide();
                $("#divambiente").show();
            }
            if ($(this).val() == "3")
            {
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
                    colNames: ['', '#', 'Nombre', 'Precio', 'Direccion', 'Fecha Inicio', 'Fecha Fin', 'Organizador'],
                    colModel: [
                            { name: 'id', index: 'id', hidden: true },
                            { name: 'num', index: 'num', align: 'center', sorttype: 'number', width: 8 },
                            { name: 'nombre', index: 'nombre', width: 40, align: 'center', sorttype: 'text' },
                            { name: 'precio', index: 'precio', width: 20, align: 'center', sorttype: 'text' },
                            { name: 'direccion', index: 'direccion', width: 30, align: 'center', sorttype: 'text' },
                            { name: 'fecini', index: 'fecini', align: 'center', sorttype: 'text', width: 25},
                            { name: 'fecfin', index: 'fecfin', width: 25, align: 'center', sorttype: 'text' },
                            { name: 'organizador', index: 'organizador', align: 'center', sorttype: 'text', width: 40 }//,
                            //{ name: 'descripcion', index: 'descripcion', width: 15, align: 'center', sorttype: 'text' }
                    ],
                    width: 1040,
                    height: 'auto',
                    pager: '#eventosdisponiblespager',
                    viewrecords: true,
                    sortorder: 'desc',
                    rowNum: 10,
                    rowList: [10, 20, 30],
                    caption: "Eventos disponibles",
                    multiselect: true,
                    onSelectRow: function (id, status) {
                        var row = jQuery(this).getRowData(id);
                        if (status) {
                            totalevento += parseFloat(row.precio);
                            var valor = $("#<%=ListaEventosReservados.ClientID%>").val();
                            valor += "" + row.id+"/"+row.precio + " ";
                            $("#<%=ListaEventosReservados.ClientID%>").val(valor);
                        } else {
                            var events = $("#<%=ListaEventosReservados.ClientID%>").val();
                            if (events.indexOf(row.id + "/" + row.precio + " ") >= 0) {
                                var newevents = events.replace(row.id + "/" + row.precio + " ", '');
                            }
                            $("#<%=ListaEventosReservados.ClientID%>").val(newevents)
                            totalevento = totalevento - parseFloat(row.precio);
                        }
                        if (totalevento > 0) {
                            $(".total").show();
                        }
                        else {
                            $("#<%=ListaEventosReservados.ClientID%>").val("");
                            $(".total").hide();
                        }
                        $("#totalevento").html(totalevento);
                    },
                    onSelectAll: function (aRowids, status) {
                        $("#<%=ListaEventosReservados.ClientID%>").val("");
                        totalevento = 0;
                        if (status) {
                            for (var i = 0; i < aRowids.length; i++) {
                                var row = jQuery(this).getRowData(aRowids[i]);
                                console.log(row);
                                totalevento += parseFloat(row.precio);
                                var valor = $("#<%=ListaEventosReservados.ClientID%>").val();
                                valor += "" + row.id + "/" + row.precio + " ";
                                $("#<%=ListaEventosReservados.ClientID%>").val(valor);
                                console.log(totalevento);
                            }
                        }
                        else {
                            $("#<%=ListaEventosReservados.ClientID%>").val("");
                            totalevento = 0;
                        }
                        if (totalevento > 0) {
                            $(".total").show();
                        }
                        else {
                            $("#<%=ListaEventosReservados.ClientID%>").val("");
                            $(".total").hide();
                        }
                        $("#totalevento").html(totalevento);
                        
                    }
                });

                
                } catch (e) { }
        }
        function CargarDataEvento() {
            var glancedata = $("#<%=EventosData.ClientID%>").val() != '' ? $("#<%=EventosData.ClientID%>").val() : '{}';
            try {
                var obj = $.parseJSON(glancedata);
                var len = obj.length;
                for (var i = 0; i < len; i++) {
                    var index = i + 1;
                    var row = {
                        id: obj[i].Id,
                        num: i + 1,
                        nombre: obj[i].Nombre,
                        precio: obj[i].Precio,
                        fecini: obj[i].FechaInicio,
                        fecfin: obj[i].FechaFin,
                        direccion: obj[i].Direccion,
                        organizador: obj[i].Organizador
                        //descripcion: obj[i].Descripcion
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
                    colNames: ['', '#', 'Nombre', 'Precio', 'Direccion', 'Telefono', 'Capacidad'],
                    colModel: [
                            { name: 'id', index: 'id', hidden: true },
                            { name: 'num', index: 'num', align: 'center', sorttype: 'number', width: 10 },
                            { name: 'nombre', index: 'nombre', width: 70, align: 'center', sorttype: 'text' },
                            { name: 'precio', index: 'precio', width: 20, align: 'center', sorttype: 'text' },
                            { name: 'direccion', index: 'direccion', width: 45, align: 'center', sorttype: 'text' },
                            { name: 'telefono', index: 'telefono', align: 'center', sorttype: 'text', width: 25 },
                            { name: 'capacidad', index: 'capacidad', width: 25, align: 'center', sorttype: 'text' }
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
                        var row = jQuery(this).getRowData(id);
                        if (status) {
                            totalambiente += parseFloat(row.precio);
                            var valor = $("#<%=ListaAmbientesReservados.ClientID%>").val();
                            valor += "" + row.id + "/" + row.precio + " ";
                            $("#<%=ListaAmbientesReservados.ClientID%>").val(valor);
                        } else {
                            var events = $("#<%=ListaAmbientesReservados.ClientID%>").val();
                            if (events.indexOf(row.id + "/" + row.precio + " ") >= 0) {
                                var newevents = events.replace(row.id + "/" + row.precio + " ", '');
                            }
                            $("#<%=ListaAmbientesReservados.ClientID%>").val(newevents)
                            totalambiente = totalambiente - parseFloat(row.precio);
                            //console.log(totalevento);
                        }
                        if (totalambiente > 0) {
                            $(".total").show();
                        }
                        else {
                            $("#<%=ListaAmbientesReservados.ClientID%>").val("");
                            $(".total").hide();
                        }
                        $("#totalambiente").html(totalambiente);
                    },
                    onSelectAll: function (aRowids, status) {
                        $("#<%=ListaAmbientesReservados.ClientID%>").val("");
                        totalambiente = 0;
                        if (status) {
                            for (var i = 0; i < aRowids.length; i++) {
                                var row = jQuery(this).getRowData(aRowids[i]);
                                //console.log(row);
                                var valor = $("#<%=ListaAmbientesReservados.ClientID%>").val();
                                valor += "" + row.id + "/" + row.precio + " ";
                                $("#<%=ListaAmbientesReservados.ClientID%>").val(valor);
                                totalambiente += parseFloat(row.precio);
                                //console.log(totalevento);
                            }
                        }
                        else {
                            $("#<%=ListaAmbientesReservados.ClientID%>").val("");
                            totalambiente = 0;
                        }
                        if (totalambiente > 0) {
                            $(".total").show();
                        }
                        else {
                            $("#<%=ListaAmbientesReservados.ClientID%>").val("");
                            $(".total").hide();
                        }
                        $("#totalambiente").html(totalambiente);

                    }
                });


            } catch (e) { }
        }
        function CargarDataAmbiente() {
            var glancedata = $("#<%=AmbientesData.ClientID%>").val() != '' ? $("#<%=AmbientesData.ClientID%>").val() : '{}';
            try {
                var obj = $.parseJSON(glancedata);
                var len = obj.length;
                for (var i = 0; i < len; i++) {
                    var index = i + 1;
                    var row = {
                        id: obj[i].Id,
                        num: i + 1,
                        nombre: obj[i].Nombre,
                        precio: obj[i].Precio,
                        direccion: obj[i].Direccion,
                        telefono: obj[i].Telefono,
                        capacidad: obj[i].Capacidad
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
                    colNames: ['', '#', 'Nombre', 'Precio', 'Fecha Inicio', 'Fecha Fin', 'Capacidad'],
                    colModel: [
                            { name: 'id', index: 'id', hidden: true },
                            { name: 'num', index: 'num', align: 'center', sorttype: 'number', width: 10 },
                            { name: 'nombre', index: 'nombre', width: 50, align: 'center', sorttype: 'text' },
                            { name: 'precio', index: 'precio', width: 20, align: 'center', sorttype: 'text' },
                            { name: 'fecini', index: 'fecini', width: 45, align: 'center', sorttype: 'text' },
                            { name: 'fecfin', index: 'fecfin', align: 'center', sorttype: 'text', width: 50 },
                            { name: 'capacidad', index: 'fecfin', width: 30, align: 'center', sorttype: 'text' }
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
                        var row = jQuery(this).getRowData(id);
                        if (status) {
                            totalcurso += parseFloat(row.precio);
                            var valor = $("#<%=ListaCursosReservados.ClientID%>").val();
                            valor += "" + row.id + "/" + row.precio + " ";
                            $("#<%=ListaCursosReservados.ClientID%>").val(valor);
                        } else {
                            var events = $("#<%=ListaCursosReservados.ClientID%>").val();
                            if (events.indexOf(row.id + "/" + row.precio + " ") >= 0) {
                                var newevents = events.replace(row.id + "/" + row.precio + " ", '');
                            }
                            $("#<%=ListaCursosReservados.ClientID%>").val(newevents);
                            totalcurso = totalcurso - parseFloat(row.precio);
                        }
                        if (totalcurso > 0) {
                            $(".total").show();
                        }
                        else {
                            $("#<%=ListaCursosReservados.ClientID%>").val("");
                            $(".total").hide();
                        }
                        $("#totalcurso").html(totalcurso);
                    },
                    onSelectAll: function (aRowids, status) {
                        $("#<%=ListaCursosReservados.ClientID%>").val("");
                        totalcurso = 0;
                        if (status) {
                            for (var i = 0; i < aRowids.length; i++) {
                                var row = jQuery(this).getRowData(aRowids[i]);
                                //console.log(row);
                                var valor = $("#<%=ListaCursosReservados.ClientID%>").val();
                                valor += "" + row.id + "/" + row.precio + " ";
                                $("#<%=ListaCursosReservados.ClientID%>").val(valor);
                                totalcurso += parseFloat(row.precio);
                                //console.log(totalevento);
                            }
                        }
                        else {
                            $("#<%=ListaCursosReservados.ClientID%>").val("");
                            totalcurso = 0;
                        }
                        if (totalcurso > 0) {
                            $(".total").show();
                        }
                        else {
                            $("#<%=ListaCursosReservados.ClientID%>").val("");
                            $(".total").hide();
                        }
                        $("#totalcurso").html(totalcurso);

                    }
                });


            } catch (e) { }
        }
        function CargarDataCurso() {
            var glancedata = $("#<%=CursosData.ClientID%>").val() != '' ? $("#<%=CursosData.ClientID%>").val() : '{}';
            try {
                var obj = $.parseJSON(glancedata);
                var len = obj.length;
                for (var i = 0; i < len; i++) {
                    var index = i + 1;
                    var row = {
                        id: obj[i].Id,
                        num: i + 1,
                        nombre: obj[i].Nombre,
                        precio: obj[i].Precio,
                        fecini: obj[i].FechaInicio,
                        fecfin: obj[i].FechaFin,
                        capacidad: obj[i].Capacidad
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
    <a href="MisReservas.aspx" style="float:right;margin-top:0px;" class="btn">Ir a mis reservas</a>
    <div style="margin-top:30px;">
    <asp:DropDownList ID="ddlTipoReserva" runat="server">
        <asp:ListItem Value="0">-Seleccionar tipo de reserva-</asp:ListItem>
        <asp:ListItem Value="1">Evento</asp:ListItem>
        <asp:ListItem Value="2">Ambiente</asp:ListItem>
        <asp:ListItem Value="3">Curso</asp:ListItem>
    </asp:DropDownList>
    <div style="margin-top:15px;">
    <div id="divevento" style="display:none;">
        <center><asp:Label ID="lblMensajeEvento" runat="server" Text=""></asp:Label></center>
        <table id="eventosdisponibles"></table>
        <div id="eventosdisponiblespager" ></div>
        <div class="ui-widget total">
	        <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
		        <div><strong>TOTAL :</strong> <span id="totalevento" style="color:red;"></span></div>
	        </div>
            <asp:LinkButton ID="lbtn_reservar_evento" runat="server" OnClick="lbtn_reservar_evento_Click" class="btn">Reservar</asp:LinkButton>
        </div>
        
    </div>
    <div id="divambiente" style="display:none;">
        <center><asp:Label ID="lblMensajeAmbiente" runat="server" Text=""></asp:Label></center>
        <table id="ambientesdisponibles"></table>
        <div id="ambientesdisponiblespager" ></div>
        <div class="ui-widget total">
	        <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
		        <div><strong>TOTAL :</strong> <span id="totalambiente" style="color:red;"></span></div>
	        </div>
            <asp:LinkButton ID="lbtn_reservar_ambiente" runat="server" OnClick="lbtn_reservar_ambiente_Click" class="btn">Reservar</asp:LinkButton>
        </div>
    </div>
    <div id="divcurso" style="display:none;">
        <center><asp:Label ID="lblMensajeCurso" runat="server" Text=""></asp:Label></center>
        <table id="cursosdisponibles"></table>
        <div id="cursosdisponiblespager" ></div>
        <div class="ui-widget total">
	        <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;">
		        <div><strong>TOTAL :</strong> <span id="totalcurso" style="color:red;"></span></div>
	        </div>
            <asp:LinkButton ID="lbtn_reservar_cursos" runat="server" OnClick="lbtn_reservar_cursos_Click" class="btn">Reservar</asp:LinkButton>
        </div>
    </div>
    </div>
    </div>
    <%-- HiddenFields --%>
    <asp:HiddenField ID="EventosData" runat="server" />
    

    <asp:HiddenField ID="AmbientesData" runat="server" />
    

    <asp:HiddenField ID="CursosData" runat="server" />
    
    <div style="display:none;">
        <input type="text" id="ListaEventosReservados" runat="server" />
        <input type="text" id="ListaAmbientesReservados" runat="server" />
        <input type="text" id="ListaCursosReservados" runat="server" />
    </div>
    </div>
</asp:Content>
