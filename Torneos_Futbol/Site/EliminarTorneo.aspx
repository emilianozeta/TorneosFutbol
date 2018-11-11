<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="EliminarTorneo.aspx.cs" Inherits="Torneos_Futbol.Pages.Administracion.EliminarTorneo" %>
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
                        Eliminar Torneo
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>Seleccione el torneo que desea eliminar</label>
                                </div>
                                <div class="form-group">
                                    <label>Torneo</label>
                                    <asp:DropDownList ID="ddlTorneo" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:CompareValidator ID="cvTorneo" ControlToValidate="ddlTorneo" runat="server" ValueToCompare="0" Operator="NotEqual" Display ="Dynamic" ErrorMessage="Debe seleccionar un torneo" CssClass="label label-danger"></asp:CompareValidator>
                                </div>
			                    <br />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-default" OnClientClick="return confirm('¿Esta seguro que desea eliminar este torneo?');return false;" OnClick="btnEliminar_Click"/>
	                        </div>
                         </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>       