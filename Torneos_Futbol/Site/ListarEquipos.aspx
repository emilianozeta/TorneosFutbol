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
			                        <asp:CheckBox ID="chkActivos" runat="server" />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <br />
                                    <asp:Button class="btn btn-outline btn-primary "  OnClick="btnBuscarB_Click" ID="btnBuscarB" runat="server" Text="Buscar" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-8">
                                <div class="form-group">
                                    <asp:GridView runat="server" ID="dgvListado" CssClass="table table-striped table-bordered table-hover" ></asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>