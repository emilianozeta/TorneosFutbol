﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegistrarJugador.aspx.cs" Inherits="Torneos_Futbol.Pages.Administracion.RegistrarJugador" %>

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
                                    <label>Apellido</label>
                                    <asp:textbox id="txtApellido" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <label>Sexo</label>
                                    <asp:DropDownList ID="ddlSexo" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Fecha de nacimiento</label>
                                    <asp:textbox id="txtFecNacimiento" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <label>Edad</label>
                                    <asp:textbox id="txtEdad" runat="server" class="form-control"></asp:textbox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="La edad es Obligatoria" ControlToValidate="txtEdad" Text="*" Display="Static" EnableClientScript="true" Enabled="true"/>
					                <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtEdad" ErrorMessage="La edad debe ser un número entero" EnableClientScript="True" CssClass="label label-danger"/>
					                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtEdad" Type="Integer" MinimumValue="15" MaximumValue="99" ErrorMessage="La edad está fuera de rango [15-99]" CssClass="label label-danger"/>
                                </div>

                                <div class="form-group">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"/>
                                </div>

                            </div>
                            <div class="col-lg-4">
                                <uc1:ucProvLoc runat="server" ID="ucProvLoc" />

                                 <div class="form-group">
                                    <label>Dirección</label>
                                    <asp:textbox id="txtDireccion" runat="server" class="form-control"></asp:textbox>
                                </div>
                                <div class="form-group">
                                    <label>E-Mail</label>
                                    <asp:textbox id="txtMail" runat="server" class="form-control"></asp:textbox>
                                </div>
                                 <div class="form-group">
                                    <label>Equipo</label>
                                    <asp:DropDownList ID="ddlEquipo" runat="server" class="form-control"></asp:DropDownList>
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
