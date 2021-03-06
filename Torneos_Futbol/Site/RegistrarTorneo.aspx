﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="RegistrarTorneo.aspx.cs" Inherits="Torneos_Futbol.Pages.Administracion.RegistrarTorneo" %>

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
                        Crear Torneo
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control"/>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="El nombre es obligatorio" ControlToValidate="txtNombre" Display ="Dynamic" CssClass="label label-danger"></asp:RequiredFieldValidator>
					                <asp:RegularExpressionValidator ValidationExpression="^.{1,50}$" ID="longTxtNombre" runat="server" ErrorMessage="El nombre no puede superar los 50 caracteres" ControlToValidate="txtNombre" Display ="Dynamic" CssClass="label label-danger"></asp:RegularExpressionValidator>
                                </div>

                                <uc1:ucProvLoc runat="server" ID="ucProvLoc" />

                                <div class="form-group">
                                    <label>Estado</label>
                                   <asp:RadioButtonList ID="radBtnLstEstado" runat="server">
							            <asp:ListItem Text ="Activo" Value= "True" Selected="True"> Activo</asp:ListItem>
							            <asp:ListItem Text ="Activo" Value= "False" > Inactivo</asp:ListItem>
						            </asp:RadioButtonList>
                                </div>

                                <br />
                                <asp:Button ID="btnCrearTorneo" runat="server" Text="Crear" class="btn btn-default" OnClick="btnCrearTorneo_Click"/>
				            </div>
                         </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content>