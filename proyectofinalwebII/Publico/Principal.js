var accion = sessionStorage.getItem("accion");

console.log(accion);
if (accion == "Login") {
    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
        '<strong > Se a ingresado de forma correcta</strong >');
        sessionStorage.setItem("accion", null);
} else if(accion == "Producto") {
    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
        '<strong > Se a agregado un producto</strong >');
        sessionStorage.setItem("accion", null);
} else if (accion == "Usuario") {
    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
        '<strong > Se a agregado un usuario</strong >');
        sessionStorage.setItem("accion", null);
} else if (accion == "Venta") {
    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
        '<strong > Se a realizado una venta</strong >');
        sessionStorage.setItem("accion", null);
} else if (accion == "salir") {
    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
        '<strong > has cerrado la session </strong >');
    sessionStorage.setItem("accion", null);
} 
if (accion != null) {
    $("#mensaje").show();
} else {
    $("#mensaje").hide();
}