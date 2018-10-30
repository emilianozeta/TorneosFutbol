<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Torneos_Futbol.Index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="IncludeCssSection" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PaginaCentral_ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <br />
                <br />
                <br />
                <br />
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div class="text-center">
                                <asp:Image ID="Image1" runat="server" src="/img/cancha.png"/> 
                            </div>
                        </div>
                    </div>  
                </div>             
            </div>
        </div>
    </div>
</asp:Content> 

<asp:Content ID="Content4" ContentPlaceHolderID="includeJsSection" runat="server">
</asp:Content>
