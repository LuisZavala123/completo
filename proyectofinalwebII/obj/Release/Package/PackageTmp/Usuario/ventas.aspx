<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="proyectofinalwebII.ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../css/popup.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div id="cont" onload="nombres" class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
            <div id="primero">
                <div class="myform form">
                    <div class="logo mb-3">
                        <div class="col-md-12 text-center">
                            <h1>Venta</h1>
                        </div>
                    </div>
                    <div class="row">
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Producto"></asp:Label>
                            <asp:DropDownList ID="CboxProducto" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Cantidad"></asp:Label>
                        <div class="popup"><span id="popt1" class="popuptext">X</span></div>
                        <asp:TextBox runat="server" id="txtCantidad" type="number" class="form-control"></asp:TextBox>
                    </div>
                        <div class="form-group">
                        <asp:Label runat="server" Text="Descripcion"></asp:Label>
                        <asp:TextBox runat="server" id="txtDescripcion" type="text" class="form-control"></asp:TextBox>
                    </div>
                        <div class="form-group">
                        <asp:Label runat="server" Text="Total: $"></asp:Label>
                        <asp:Label runat="server" Text="0" id="lbltotal"></asp:Label>
                    </div>
                        <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-success mybtn btn-primary tx-tfm" Text="Agregar" id="btnAgregar"/>
                    </div>
                    <div class="col-md-12 text-center">
                        <asp:Button runat="server" class=" btn btn-success mybtn btn-primary tx-tfm" Text="Aceptar"  id="btnAceptar"/>
                    </div>
                    </div>
                </div>
            </div>
            </div>
            <div id="gridViewDiv" class="form-group">
                <table id="grvLista" class="table table-striped table-bordered" ></table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="../js/datatables.min.js">
     $(document).ready(function () {
        $('#grvLista').DataTable();
     });
   </script>
        <script type="text/javascript" src="Ventas.min.js">
            
        </script>
    
</asp:Content>
