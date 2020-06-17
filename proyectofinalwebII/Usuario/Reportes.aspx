<%@ Page Title="" Language="C#" MasterPageFile="~/DeUsuario.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="proyectofinalwebII.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="row justify-content-center my-2">
        <input id="Fecha" type="date">   
    </div>
    <div  class="row justify-content-center my-2">
            <asp:Button ID="btnGenerar" CssClass="btn btn-success mybtn btn-primary tx-tfm" runat="server" Text="Generar Reporte" />  
    </div>
    
        <table id="grvLista" class="sem table table-bordered table-striped table-hover dib" ></table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    
    <script type="text/javascript" src="Usuario/Reportes.min.js"></script>
</asp:Content>
