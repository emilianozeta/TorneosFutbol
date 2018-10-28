<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="EliminarEquipo.aspx.cs" Inherits="Torneos_Futbol.Pages.Administracion.EliminarEquipo" %>
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
                <h1 class="page-header">Equipos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Modificar Equipo
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>Seleccione el equipo que desea eliminar</label>
                                </div>
                                <div class="form-group">
                                    <label>Equipo</label>
                                    <asp:DropDownList ID="ddlEquipo" runat="server" class="form-control"></asp:DropDownList>
                                </div>
			                    <br />
                                <asp:Button ID="Button2" runat="server" Text="Eliminar" class="btn btn-default" OnClientClick="return confirm('¿Esta seguro que desea eliminar este equipo? Todos sus jugadores serán eliminados también');return false;"/>
			                </div>
                         </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>       