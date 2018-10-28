<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ListarEquipos.aspx.cs" Inherits="Torneos_Futbol.Pages.Equipos.ListarEquipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="IncludeCssSection" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="includeJsSection" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="PaginaCentral_ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Lista de Equipos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                       Listado de Equipos
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>Nombre equipo</label>
                                    <asp:TextBox class="form-control" ID="txtEquipoB" runat="server"></asp:TextBox>
                                    <br />
                                    <label>Torneos activos</label>
			                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>Nombre Torneo</label>
                                    <asp:TextBox class="form-control" ID="txtTorneoB" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:Button class="btn btn-outline btn-primary " ID="btnBuscarB" runat="server" Text="Buscar" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-8">
                                <div class="form-group">
                                    <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                                        <thead>
                                            <tr>
                                                <th>Equipo</th>
                                                <th>Torneo en el que participa</th>
                                                <th>Estado del torneo</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="odd gradeX">
                                                <td>Trident</td>
                                                <td>Internet Explorer 4.0</td>
                                                <td>Win 95+</td>
                                            </tr>
                                            <tr class="even gradeC">
                                                <td>Trident</td>
                                                <td>Internet Explorer 5.0</td>
                                                <td>Win 95+</td>
                                            </tr>
                                            <tr class="odd gradeA">
                                                <td>Trident</td>
                                                <td>Internet Explorer 5.5</td>
                                                <td>Win 95+</td>
                                            </tr>
                                        </tbody>
                                   </table>
                                </div>
                            </div>
                        </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>