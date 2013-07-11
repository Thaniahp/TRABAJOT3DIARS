<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="buscar.aspx.cs" Inherits="AeasOnline.GestionCursos.buscar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoprincipal" runat="server">

    <table border="0" style="width:1000px" class="container2">
        <tr>
            <td align="left">
                <table border="0" style="width:800px; margin-left:40px">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Descripcion" style="font-size: large; font-family:Calibri"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <asp:Button ID="Button2" runat="server" CssClass="btn_Imagen2" Text="Buscar" BackColor="#FFCC00" BorderColor="#FFCC00" BorderStyle="Dotted" ForeColor="White" style="font-size: large; font-family:Calibri; color: #000000; background-color: #FFCC00;" Width="100px" OnClick="Button2_Click"/>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width:586px">
                            <asp:GridView ID="GridView1" runat="server"
                                 AutoGenerateColumns="false"
                                 GridLines="None" AllowPaging="true"
                                 CssClass="mGrid" PagerStyle-CssClass="pgr"
                                 AlternatingRowStyle-CssClass="alt" PageSize="5">
                                <Columns>
                                            <asp:BoundField DataField="IdCurso" HeaderText="Id" ControlStyle-Font-Size="Large" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ControlStyle-Font-Size="Large" />
                                            <asp:BoundField DataField="FechaInicio" HeaderText="FechaFin" ControlStyle-Font-Size="Large" />
                                            <asp:BoundField DataField="FechaFin" HeaderText="FechaFin" />
                                            <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                            <asp:ButtonField CommandName="Editar" ButtonType="Image" HeaderText="Editar" ImageUrl="~/Imagenes/editar.png" ControlStyle-CssClass="imgw" />
                                            <asp:ButtonField CommandName="Eliminar" ButtonType="Image" HeaderText="Eliminar" ImageUrl="~/Imagenes/eliminar.png" ControlStyle-CssClass="imgw" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" CssClass="btn_Imagen" Text="Nuevo curso" BackColor="#FFCC00" BorderColor="#FFCC00" BorderStyle="Dotted" ForeColor="#FFCC00" style="font-size: large; font-family:Calibri; color: #000000;" Width="180px" OnClick="Button1_Click"/>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
