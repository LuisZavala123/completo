<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="proyectofinalwebII.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="row justify-content-center my-2">
        <input id="Fecha" type="date">   
        </div>
    <div class="row justify-content-center my-2">
            <asp:Button ID="btnGenerar" CssClass="btn btn-success mybtn btn-primary tx-tfm" runat="server" Text="Generar Reporte" />
        </div>
        <table id="grvLista" class="table table-striped table-bordered" ></table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="../js/datatables.min.js">
     $(document).ready(function () {
        $('#grvLista').DataTable();
     });
   </script>

    <script type="text/javascript" src="Reportes.min.js">

    </script>
</asp:Content>
