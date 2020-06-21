let nom = 0;
let cos = 0;

var expr = /^[0-9]+\.[0-9]?[0-9]$/;
var exprn = /^[A-ZÁÉÍÓÚ][a-záéíúó]+$/;
var ready = 0;
var mensj = "";
$(document).ready(function () {

    $('#frm').validate({
        rules: {
            ctl00$ctl00$contenido$contenido$txtCosto: {
                required: true,
                step: .01
            },
            ctl00$ctl00$contenido$contenido$txtNombre: {
                required: true,
                lettersonly: true,
                minlength: 2
            }
        },
        messages: {
            ctl00$ctl00$contenido$contenido$txtCosto: {
                required: 'Por favor, ingrese un costo',
                step: 'Por favor, ingrese costo valido'
            },
            ctl00$ctl00$contenido$contenido$txtNombre: {
                required: 'Por favor, ingrese un nombre',
                lettersonly: 'Por favor, ingrese nombre valido',
                minlength: "Por favor, ingrese un nombre real"
            }
        }
    });

    $('#contenido_contenido_btnAceptar').click(function (e) {
        e.preventDefault();
        var Nombre = $('#contenido_contenido_txtNombre').val();
        var Costo = $('#contenido_contenido_txtCosto').val();
        var Desc = $('#contenido_contenido_txtDescripcion').val();
        var tipo = $('#contenido_contenido_CboxTipo').val();
        mensj = "";
        if (exprn.test(Nombre)) {
            ready += 1;
            nom = 0;
        } else {
            ready = 0;
            nom = 1;
            mensj = mensj + "Nombre, ";

        }
        debugger;
        if (expr.test(Costo)) {
            ready += 1;
            cos = 0;
        } else {
            ready = 0;
            cos = 1;
            mensj = mensj + "Costo";
        }
        console.log(ready);
        if (ready == 2) {
            $.ajax({
                url: 'WS/WSArticulos.asmx/Agregar',
                data: '{ "nom":"' + Nombre + '", "costo":"' + Costo + '", "Descripcion":"' + Desc + '", "Tipo": "' + tipo + '" }',
                contentType: 'application/json; utf-8',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    sessionStorage.setItem("indx", null);
                    sessionStorage.setItem("accion", "Producto");
                    location.href = "index.html";
                },
                error: function (err) {
                    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                        '<strong >'+err+' </strong >');
                    $("#mensaje").show();
                }
            });
        } else {
            ready = 0;
            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > Verifique los datos en: </strong >' + mensj);
            $("#mensaje").show();
        }
    });
});