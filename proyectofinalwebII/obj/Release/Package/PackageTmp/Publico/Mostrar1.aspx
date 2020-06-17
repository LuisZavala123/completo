<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mostrar1.aspx.cs" Inherits="proyectofinalwebII.Mostrar1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #container{
            width:850px;
            margin:150px auto;
        }
        #container img{
            cursor: pointer;
        }
        #container1{
            width:850px;
            margin:150px auto;
        }
        #container1 img{
            cursor: pointer;
        }
        #container2{
            width:850px;
            margin:150px auto;
        }
        #container2 img{
            cursor: pointer;
        }
        #previa{
            background: rgba(0,0,0,0.5);
            display: none;
            height: 100%;
            left: 0;
            position: fixed;
            top: 0;
            width: 100%;
        }
        #previa div{
            margin: 200px auto;
            width: 381px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div id="previa">
        <div>
            <img src="" id="imgFull"/>
        </div>
    </div>
    <div id="container">
        <img src="../img/productos/hamburgesas/doble-c-queso-tocino.png"   alt="doble-c-queso-tocino" width="200" height="150" />
        <img src="../img/productos/hamburgesas/doble-c-queso.png"          alt="doble-c-queso" width="200" height="150" />
        <img src="../img/productos/hamburgesas/hawaiana.png"               alt="hawaiana" width="200" height="150" />
        <img src="../img/productos/hamburgesas/pollo-crujiente.png"        alt="pollo-crujiente" width="200" height="150" />
        <img src="../img/productos/hamburgesas/queso-tocino.png"           alt="queso-tocino" width="200" height="150" />
        <img src="../img/productos/hamburgesas/sencilla-c-queso.png"       alt="sencilla-c-queso" width="200" height="150" />
    </div>
    <div id="container1">
        <img src="../img/productos/pizzas/antojo-especial.png"             alt="antojo-especial" width="200" height="150" />
        <img src="../img/productos/pizzas/carnes-frias.png"             alt="carnes-frias" width="200" height="150" />
        <img src="../img/productos/pizzas/hawaiana.png"             alt="hawaiana" width="200" height="150" />
        <img src="../img/productos/pizzas/mexicana.png"             alt="mexicana" width="200" height="150" />
        <img src="../img/productos/pizzas/peperoni.png"             alt="peperoni" width="200" height="150" />
        <img src="../img/productos/pizzas/vegetariana.png"             alt="vegetariana" width="200" height="150" />
                                
    </div>
    <div id="container2">
        <img src="../img/productos/bebidas/agua-fresca.png"             alt="agua-fresca" width="200" height="150" />
        <img src="../img/productos/bebidas/cafe.png"             alt="cafe" width="200" height="150" />
        <img src="../img/productos/bebidas/coca-cola.png"             alt="coca-cola" width="200" height="150" />
        <img src="../img/productos/bebidas/frappe.png"             alt="frappe" width="200" height="150" />
        <img src="../img/productos/bebidas/malteada.png"             alt="malteada" width="200" height="150" />
                                 
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="js/jquery-3.4.1.js"></script>
    <script type="text/javascript" src="Mostrar1.min.js"> 
    </script>
</asp:Content>
