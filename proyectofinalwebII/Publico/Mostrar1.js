$(document).ready(inicio);
function inicio() {
    $("#container").hide();
    $("#container1").hide();
    $("#container2").hide();
    if (sessionStorage.getItem("Producto") == "Hamburguesa") {
        noc = "#container img";
        n = "hamburgesas/";
        direccion = direccion + n;
        $("#container").show();
    } else if (sessionStorage.getItem("Producto") == "Pizza") {
        noc = "#container1 img";
        n = "pizzas/";
        direccion = direccion + n;
        $("#container1").show();
    } else if (sessionStorage.getItem("Producto") == "Bebida") {
        noc = "#container2 img";
        n = "bebidas/";
        direccion = direccion + n;
        $("#container2").show();
    } else {
        location.href = "../Publico/Principal.aspx";
    }

    $(noc).click(abrirFull);
    $("#imgFull").click(cerrarFull);
}

var noc = "";
var direccion = "../img/productos/";
var n = "";

function abrirFull() {
    debugger;
    var nombre = $(this).attr('alt');
    direccion = direccion + nombre + ".png";
    console.log(direccion);
    $("#imgFull").attr('src', direccion);
    $("#previa").fadeIn();
    noc = "";
    direccion = "../img/productos/" + n;
}
function cerrarFull() {
    debugger;
    $("#previa").fadeOut();
}