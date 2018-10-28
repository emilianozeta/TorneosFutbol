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
                                    <label>E-mail</label>
                                    <asp:textbox id="txtMail" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                   <label>Comentario</label>
                                   <asp:textbox id="txtComentario" runat="server" class="form-control" height="85" Wrap="true" TextMode="MultiLine"></asp:textbox>
                                </div>
                                <br />
			                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar mensaje" class="btn btn-default"/>
			                </div>             
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
