<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegistrarJugador.aspx.cs" Inherits="Torneos_Futbol.Pages.Administracion.RegistrarJugador" %>

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
                <h1 class="page-header">Jugadores</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Crear Jugador
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:textbox id="txtNombre" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="El nombre es obligatorio" ControlToValidate="txtNombre" Display ="Dynamic" CssClass="label label-danger"></asp:RequiredFieldValidator>
					                <asp:RegularExpressionValidator ValidationExpression="^.{1,20}$" ID="longTxtNombre" runat="server" ErrorMessage="El nombre no puede superar los 20 caracteres" Display ="Dynamic" ControlToValidate="txtNombre" CssClass="label label-danger"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>Apellido</label>
                                    <asp:textbox id="txtApellido" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="El apellido es obligatorio" ControlToValidate="txtApellido" Display ="Dynamic" CssClass="label label-danger"></asp:RequiredFieldValidator>
					                <asp:RegularExpressionValidator ValidationExpression="^.{1,20}$" ID="RegularExpressionValidator1" runat="server" ErrorMessage="El apellido no puede superar los 20 caracteres" Display ="Dynamic" ControlToValidate="txtApellido" CssClass="label label-danger"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>Sexo</label>
                                    <asp:DropDownList ID="ddlSexo" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:CompareValidator ID="cvSexo" ControlToValidate="ddlSexo" runat="server" ValueToCompare="0" Operator="NotEqual" Display ="Dynamic" ErrorMessage="Debe seleccionar un sexo" CssClass="label label-danger"></asp:CompareValidator>
                                </div>
                                <div class="form-group">
                                    <label>Fecha de nacimiento</label>
                                    <asp:textbox id="txtFecNacimiento" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ErrorMessage="La fecha de nacimiento es obligatoria" ControlToValidate="txtFecNacimiento" Display ="Dynamic" CssClass="label label-danger"></asp:RequiredFieldValidator>
					                <asp:RegularExpressionValidator ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[\/]\d{4}$" ID="revFechaNacimiento" runat="server" ErrorMessage="El formato de la fecha debe ser [dd/mm/aaaa]" Display ="Dynamic" ControlToValidate="txtFecNacimiento" CssClass="label label-danger"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>Edad</label>
                                    <asp:textbox id="txtEdad" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="rfvEdad" runat="server" ErrorMessage="La edad es obligatoria" ControlToValidate="txtEdad" Display="Dynamic" CssClass="label label-danger"/>
					                <asp:CompareValidator ID="cvEdad" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtEdad" ErrorMessage="La edad debe ser un número entero" Display="Dynamic" CssClass="label label-danger"/>
					                <asp:RangeValidator ID="rvEdad" runat="server" ControlToValidate="txtEdad" Type="Integer" MinimumValue="15" MaximumValue="99" ErrorMessage="La edad está fuera de rango [15-99]" Display="Dynamic" CssClass="label label-danger"/>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <uc1:ucProvLoc runat="server" ID="ucProvLoc" />

                                 <div class="form-group">
                                    <label>Dirección</label>
                                    <asp:textbox id="txtDireccion" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ErrorMessage="La dirección es obligatoria" ControlToValidate="txtDireccion" Display ="Dynamic" CssClass="label label-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>E-Mail</label>
                                    <asp:textbox id="txtMail" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="El email es obligatorio" ControlToValidate="txtMail" Display="Dynamic" CssClass="label label-danger"/>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="El formato del email en incorrecto" ControlToValidate="txtMail" CssClass="label label-danger" Display ="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>Equipo</label>
                                    <asp:DropDownList ID="ddlEquipo" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:CompareValidator ID="cvEquipo" ControlToValidate="ddlEquipo" runat="server" ValueToCompare="0" Operator="NotEqual" Display ="Dynamic" ErrorMessage="Debe seleccionar un equipo" CssClass="label label-danger"></asp:CompareValidator>
                                </div>
                            </div>
                         </div>
                        <br />
                        <asp:Button ID="btnCrearJugador" runat="server" class="btn btn-default" Text="Crear" OnClick="btnCrearJugador_Click" />
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>
