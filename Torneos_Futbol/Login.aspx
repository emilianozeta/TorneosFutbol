<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SiCoVe.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>SiCoVe</title>
    <link href="Content/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Content/vendor/metisMenu/metisMenu.min.css" rel="stylesheet"/>
    <link href="Content/dist/css/sb-admin-2.css" rel="stylesheet"/>
    <link href="Content/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="frmLogin" runat="server">
            <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                        <fieldset>
                            <div class="form-group">
                                <asp:textbox id="txtUsuario" runat="server" class="form-control" placeholder="Usuario" autofocus required="required"></asp:textbox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtPassword"  TextMode="Password" class="form-control" placeholder="Contraseña" name="password"   value="" required="required"></asp:TextBox>
                            </div>
                            
                            <asp:Button runat="server" Text="Login" id="btnLogin" class="btn btn-lg btn-success btn-block" OnClick="btnLogin_Click" OnClientClick="btnLogin_OnClientClick()" />
                            
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblMensaje" runat="server" Text="Usuario o Contraseña Incorrecta!" Visible="false"></asp:Label>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery -->
    <script src="Content/vendor/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="Content/vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="Content/vendor/metisMenu/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="Content/dist/js/sb-admin-2.js"></script>
    </form>
</body>
</html>
