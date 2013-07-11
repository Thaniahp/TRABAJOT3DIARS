<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="registrar.aspx.cs" Inherits="AeasOnline.GestionCursos.registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoprincipal" runat="server">
    <table border="1" style="width:100%">
        <tr>
            <td align="center">
                <table border="1" style="width:500px">
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="Label7" runat="server" 
                                style="font-family: 'Eras Demi ITC'; font-size: xx-large; color: #1D1D1D" 
                                Text="Registrar Cursos"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="text-align: left">
                                        <asp:Label ID="Label1" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Nombre del curso"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBox1" runat="server" 
                                            style="font-family: Calibri; font-size: large" Width="290px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label3" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Fecha de inicio"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label8" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Dia"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label9" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Mes"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label10" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Año"></asp:Label>
                                        <br />
                                        <asp:DropDownList ID="DropDownList1" runat="server" Height="28px" style="font-size: large; font-family:Calibri" Width="100px">
                                            <asp:ListItem Value="0">Selecciona un dia</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                            <asp:ListItem>24</asp:ListItem>
                                            <asp:ListItem>25</asp:ListItem>
                                            <asp:ListItem>26</asp:ListItem>
                                            <asp:ListItem>27</asp:ListItem>
                                            <asp:ListItem>28</asp:ListItem>
                                            <asp:ListItem>29</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>31</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownList2" runat="server" Height="28px" style="font-size: large; font-family:Calibri" Width="100px">
                                            <asp:ListItem Value="0">Selecciona un mes</asp:ListItem>
                                            <asp:ListItem Value="1">Enero</asp:ListItem>
                                            <asp:ListItem Value="2">Febrero</asp:ListItem>
                                            <asp:ListItem Value="3">Marzo</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownList3" runat="server" Height="28px" style="font-size: large; font-family:Calibri" Width="100px">
                                            <asp:ListItem Value="0">Selecciona un año</asp:ListItem>
                                            <asp:ListItem>2013</asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                        <asp:Label ID="Label4" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Fecha de finalizacion"></asp:Label>
                                        <br />
                                        <asp:Label ID="Label11" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Dia"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label12" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Mes"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label13" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Año"></asp:Label>
                                        <br />
                                        <asp:DropDownList ID="DropDownList4" runat="server" Height="28px" style="font-size: large; font-family:Calibri" Width="100px">
                                            <asp:ListItem Value="0">Selecciona un dia</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownList5" runat="server" Height="28px" style="font-size: large; font-family:Calibri" Width="100px">
                                            <asp:ListItem Value="0">Selecciona un mes</asp:ListItem>
                                            <asp:ListItem Value="1">Enero</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownList6" runat="server" Height="28px" style="font-size: large; font-family:Calibri" Width="100px">
                                            <asp:ListItem Value="0">Selecciona un año</asp:ListItem>
                                            <asp:ListItem>2013</asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Label ID="Label2" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Preio del curso"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBox2" runat="server" 
                                            style="font-family: Calibri; font-size: large" Width="281px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label5" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Numero de vacantes"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TextBox3" runat="server" 
                                            style="font-family: Calibri; font-size: large" Width="284px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="Label6" runat="server" 
                                            style="font-family: Calibri; font-size: large; color: #1D1D1D;" Text="Estado"></asp:Label>
                                        &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="Activo" />
                                        <br />
                                        <br />
                                        
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="Button1_registrar" runat="server" CssClass="btn" Text="Registrar" OnClick="Button1_registrar_Click"/>
                        
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
