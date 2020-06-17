<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="proyectofinalwebII.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/popup.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
            <div id="primero">
                <div class="myform form">
                    <div class="logo mb-3">
                        <div class="col-md-12 text-center">
                            <h1>Login</h1>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Correo Electronico" ID="label1"></asp:Label>
                        <div class="popup"><span id="popt1" class="popuptext">X</span></div>
                        <asp:TextBox runat="server" id="txtEmail" type="email" class="form-control" placeholder="Ingresa tu Correo Electronico"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Contraseña"></asp:Label>
                        <div class="popup"><span id="popt2" class="popuptext">X</span></div>
                        <asp:TextBox runat="server" id="txtPassword" type="password" class="form-control" placeholder="Ingresa tu contraseña"></asp:TextBox>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-block mybtn btn-primary tx-tfm" Text="Login"  id="btnLogin"/>
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script  type="text/javascript" src="Login.min.js">
    </script>
</asp:Content>
