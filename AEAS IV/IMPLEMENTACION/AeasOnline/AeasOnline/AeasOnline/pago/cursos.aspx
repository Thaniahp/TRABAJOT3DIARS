<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="cursos.aspx.cs" Inherits="AeasOnline.pago.cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoprincipal" runat="server">

    <table border="0" style="width:1000px" class="container2">
        <tr>
            <td align="left">
                <table border="0" style="width:600px; margin-left:40px">
       
                    <tr>
                        <td valign="top" style="width:586px">
                            <asp:GridView ID="GridView1" runat="server"
                                 AutoGenerateColumns="false"
                                 GridLines="None" AllowPaging="true"
                                 CssClass="mGrid" PagerStyle-CssClass="pgr"
                                 AlternatingRowStyle-CssClass="alt" PageSize="5" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                            <asp:BoundField DataField="IdReserva" HeaderText="IdHabitacion" ControlStyle-Font-Size="Large" />
                                            <asp:BoundField DataField="Fecha" HeaderText="Numero" ControlStyle-Font-Size="Large" />
                                            <asp:BoundField DataField="Total" HeaderText="Tipo" ControlStyle-Font-Size="Large" />
                                            
                                            <asp:ButtonField CommandName="pagar" ButtonType="Image" HeaderText="Pagar" ImageUrl="~/Imagenes/Editar.png" ControlStyle-CssClass="imgw" ControlStyle-Width="20px" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
