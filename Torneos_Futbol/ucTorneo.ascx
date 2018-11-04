<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTorneo.ascx.cs" Inherits="Torneos_Futbol.ucTorneo"  %>
<div class="form-group">
    <label>Nombre</label>
    <asp:TextBox ID="txtNombre" runat="server" class="form-control" />
</div>

<div class="form-group">
    <label>Provincia</label>
    <asp:DropDownList ID="ddlProvincia" runat="server" class="form-control" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
</div>
<div class="form-group">
    <label>Localidad</label>
    <asp:DropDownList ID="ddlLocalidad" runat="server" class="form-control"></asp:DropDownList>
</div>

<div class="form-group">
    <label>Estado</label>
    <asp:RadioButtonList ID="radBtnLstEstado" runat="server">
        <asp:ListItem Text="Activo" Value="True" Selected="True"> Activo</asp:ListItem>
        <asp:ListItem Text="Activo" Value="False"> Inactivo</asp:ListItem>
    </asp:RadioButtonList>
</div>
