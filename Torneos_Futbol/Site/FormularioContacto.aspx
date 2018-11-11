<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="FormularioContacto.aspx.cs" Inherits="Torneos_Futbol.Pages.Equipos.FormularioContacto" %>
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
                <h1 class="page-header">Formulario de Contacto</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Contacto
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
                                    <label>E-mail</label>
                                    <asp:textbox id="txtMail" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="El email es obligatorio" ControlToValidate="txtMail" Display="Dynamic" CssClass="label label-danger"/>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="El formato del email en incorrecto" ControlToValidate="txtMail" CssClass="label label-danger" Display ="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                   <label>Comentario</label>
                                   <asp:textbox id="txtComentario" runat="server" class="form-control" height="85" Wrap="true" TextMode="MultiLine"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="rfvComentario" runat="server" ErrorMessage="El comentario es obligatorio" ControlToValidate="txtComentario" Display ="Dynamic" CssClass="label label-danger"></asp:RequiredFieldValidator>
					                <asp:RegularExpressionValidator ValidationExpression="^.{1,1000}$" ID="RegularExpressionValidator1" runat="server" ErrorMessage="El comentario no puede superar los 1000 caracteres" Display ="Dynamic" ControlToValidate="txtComentario" CssClass="label label-danger"></asp:RegularExpressionValidator>
                                </div>
                                <br />
			                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar mensaje" class="btn btn-default" OnClick="btnEnviar_Click"/>
			                </div>             
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
