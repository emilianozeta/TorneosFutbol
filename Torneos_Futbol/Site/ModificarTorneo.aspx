<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ModificarTorneo.aspx.cs" Inherits="Torneos_Futbol.Pages.Administracion.ModificarTorneo" %>

<%@ Register Src="~/WebUserControls/ucProvLoc.ascx" TagPrefix="uc1" TagName="ucProvLoc" %>

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
                <h1 class="page-header">Torneos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Modificar Torneo
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div id="divBuscar" runat="server">
                                    <div class="form-group">
                                        <label>Seleccione el torneo que desea modificar</label>
                                    </div>
                                    <div class="form-group">
                                        <label>Torneo</label>
                                        <asp:DropDownList ID="ddlTorneo" runat="server" class="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <asp:CompareValidator ID="cvTorneo" ControlToValidate="ddlTorneo" runat="server" ValueToCompare="0" Operator="NotEqual" Display ="Dynamic" ErrorMessage="Debe seleccionar un torneo" CssClass="label label-danger"></asp:CompareValidator>
                                    </div>

                                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" class="btn btn-default" OnClick="btnSiguiente_Click"/>
                                </div>
                                <div id="divModificar" runat="server">
                                    <div class="form-group">
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtNombre" runat="server" class="form-control"/>
                                    </div>
                                    <div class="form-group">
                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="El nombre es obligatorio" ControlToValidate="txtNombre" Display ="Dynamic" CssClass="label label-danger"></asp:RequiredFieldValidator>
					                    <asp:RegularExpressionValidator ValidationExpression="^.{1,50}$" ID="longTxtNombre" runat="server" ErrorMessage="El nombre no puede superar los 50 caracteres" Display ="Dynamic" ControlToValidate="txtNombre" CssClass="label label-danger"></asp:RegularExpressionValidator>
                                    </div>

                                    <uc1:ucProvLoc runat="server" id="ucProvLoc" />

                                    <div class="form-group">
                                        <label>Estado</label>
                                       <asp:RadioButtonList ID="radBtnLstEstado" runat="server">
							                <asp:ListItem Text ="Activo" Value= "True" Selected="True"> Activo</asp:ListItem>
							                <asp:ListItem Text ="Activo" Value= "False" > Inactivo</asp:ListItem>
						                </asp:RadioButtonList>
                                    </div>
                                    <br />
                                    <asp:Button ID="btnModificarTorneo" runat="server" class="btn btn-default" Text="Modificar" OnClick="btnModificarTorneo_Click" />
                                </div>
	                        </div>
                         </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>