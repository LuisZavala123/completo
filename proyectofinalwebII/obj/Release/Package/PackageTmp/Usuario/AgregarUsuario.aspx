<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="proyectofinalwebII.AgregarUsuario" %>
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
                            <h1>Nuevo Usuario</h1>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Nombre"></asp:Label>
                        <div class="popup"><span id="popt1" class="popuptext">X</span></div>
                        <asp:TextBox runat="server" id="txtNombre" type="text" class="form-control" placeholder="Ingresa tu Nombre"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Apellido Paterno"></asp:Label>
                        <div class="popup"><span id="popt2" class="popuptext">X</span></div>
                        <asp:TextBox runat="server" id="txtApellidoP" type="text" class="form-control" placeholder="Ingresa tu Apellido Paterno"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Apellido Materno"></asp:Label>
                        <asp:TextBox runat="server" id="txtApellidoM" type="text" class="form-control" placeholder="Ingresa tu Materno"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Correo Electronico"></asp:Label>
                        <div class="popup"><span id="popt3" class="popuptext">X</span></div>
                        <asp:TextBox runat="server" id="txtEmail" type="email" class="form-control" placeholder="Ingresa tu Correo Electronico"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox runat="server" id="txtPassword" type="password" class="form-control" placeholder="Ingresa tu contraseña"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Repite Contraseña"></asp:Label>
                        <asp:TextBox runat="server" id="txtRPassword" type="password" class="form-control" placeholder="Ingresa tu contraseña"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Tipo"></asp:Label>
                            <asp:DropDownList ID="CboxTipo" CssClass="form-control" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-danger mybtn btn-primary tx-tfm" Text="Cancelar" OnClick="btnCancelar_Click" />
                        <asp:Button runat="server" class=" btn btn-success mybtn btn-primary tx-tfm" Text="Aceptar" ID="btnAceptar" />
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="AgregarUsuario.min.js">
    </script>
</asp:Content>
