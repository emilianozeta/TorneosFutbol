<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="EliminarJugador.aspx.cs" Inherits="Torneos_Futbol.Pages.Administracion.EliminarJugador" %>
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
                <h1 class="page-header">Jugadores</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Modificar Jugador
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>Seleccione el jugador que desea eliminar</label>
                                </div>
                                <div class="form-group">
                                    <label>Jugador</label>
                                    <asp:DropDownList ID="ddlJugador" runat="server" class="form-control"></asp:DropDownList>
                                </div>
			                    <br />
                                <asp:Button ID="Button1" runat="server" Text="Eliminar" class="btn btn-default" OnClientClick="return confirm('¿Esta seguro que desea eliminar este jugador?');return false;"/>
			                </div>
                         </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>