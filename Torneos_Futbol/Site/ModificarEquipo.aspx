<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ModificarEquipo.aspx.cs" Inherits="Torneos_Futbol.Pages.Administracion.ModificarEquipo" %>
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
                                    <label>Seleccione el equipo que desea modificar</label>
                                </div>
				                <div class="form-group">
                                    <label>Equipo</label>
                                    <asp:DropDownList ID="ddlEquipo" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" class="btn btn-default"/>

			                    <br />
                                <br />

				                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:textbox id="txtNombre" runat="server" class="form-control" placeholder="Ingrese nombre"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <label>Torneo</label>
                                    <asp:DropDownList ID="ddlTorneo" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Monto abonado</label>
                                    <asp:textbox id="txtMonto" runat="server" class="form-control" placeholder="Ingrese monto"></asp:textbox>
                                    <!--<asp:RequiredFieldValidator ID="reqValtxtMonto" runat="server" ErrorMessage="El monto es Obligatorio" ControlToValidate="txtMonto" Display="Static" EnableClientScript="true" Enabled="true" CssClass="label label-danger"></asp:RequiredFieldValidator>
					                <asp:RegularExpressionValidator ID="ValNumTxtMonto" ControlToValidate="txtMonto" 
					                runat="server" ErrorMessage="El monto debe ser numérico" Display="Dynamic" ValidationExpression="(?!^0*$)(?!^0*\.0*$)^\d{1,18}(\.\d{1,2})?$" EnableClientScript="True" CssClass="label label-danger"></asp:RegularExpressionValidator>-->
                                </div>
			                    <br />
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-default"/>
                            </div>
                        </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>