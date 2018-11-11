<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProvLoc.ascx.cs" Inherits="Torneos_Futbol.WebUserControls.ucProvLoc" %>
    <div class="form-group">
        <label>Provincia</label>
        <asp:DropDownList ID="ddlProvincia" runat="server" class="form-control" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>

    <div class="form-group">
        <label>Localidad</label>
        <asp:DropDownList ID="ddlLocalidad" runat="server" class="form-control"></asp:DropDownList>
    </div>