<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ModificarJugador.aspx.cs" Inherits="Torneos_Futbol.Pages.Administracion.ModificarJugador" %>
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
                                <div id="divBuscar" runat="server">
                                    <div class="form-group">
                                        <label>Seleccione el jugador que desea modificar</label>
                                    </div>
                                    <div class="form-group">
                                        <label>Jugador</label>
                                        <asp:DropDownList ID="ddlJugador" runat="server" class="form-control"></asp:DropDownList>
                                    </div>
                                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" class="btn btn-default" OnClick="btnSiguiente_Click"/>
                                </div>
                            </div>
                            <div class="col-lg-10">
                                <div id="divModificar" runat="server">
			                        <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Nombre</label>
                                            <asp:textbox id="txtNombre" runat="server" class="form-control"></asp:textbox>
                                        </div>
                                        <div class="form-group">
                                            <label>Sexo</label>
                                            <asp:DropDownList ID="ddlSexo" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Provincia</label>
                                            <asp:DropDownList ID="ddlProvincia" runat="server" class="form-control" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Dirección</label>
                                            <asp:textbox id="txtDireccion" runat="server" class="form-control"></asp:textbox>
                                        </div>
                                        <div class="form-group">
                                            <label>Equipo</label>
                                            <asp:DropDownList ID="ddlEquipo" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <asp:Button ID="btnModifJugador" runat="server" class="btn btn-default" Text="Modificar" OnClick="btnModifJugador_Click" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Apellido</label>
                                            <asp:textbox id="txtApellido" runat="server" class="form-control"></asp:textbox>
                                        </div>
                                        <div class="form-group">
                                            <label>Edad</label>
                                            <asp:textbox id="txtEdad" runat="server" class="form-control"></asp:textbox>
                                            <!--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="La edad es Obligatoria" ControlToValidate="txtEdad" Display="Static" EnableClientScript="true" Enabled="true" CssClass="label label-danger"/>
					                        <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtEdad" ErrorMessage="La edad debe ser un número entero" EnableClientScript="True" CssClass="label label-danger"/>
					                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtEdad" Type="Integer" MinimumValue="15" MaximumValue="99" ErrorMessage="La edad está fuera de rango [15-99]" CssClass="label label-danger"/>-->
                                        </div>
                                        <div class="form-group">
                                            <label>Localidad</label>
                                            <asp:DropDownList ID="ddlLocalidad" runat="server" class="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>E-Mail</label>
                                            <asp:textbox id="txtMail" runat="server" class="form-control"></asp:textbox>
                                        </div>
                                        <div class="form-group">
                                            <label>Fecha de nacimiento</label>
                                            <asp:textbox id="txtFecNacimiento" runat="server" class="form-control"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
			                </div>
                         </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>