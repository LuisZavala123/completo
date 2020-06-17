var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;
var exprn = /^[A-ZÁÉÍÓÚ][a-záéíúó]+$/;
var ready = 0;
let nom = 0;
let ap = 0;
let cor = 0;
var mensj = "";



$(document).ready(function () {

    
    $('#frm').validate({
        rules: {
            ctl00$ctl00$contenido$contenido$txtApellidoP: {
                required: true,
                lettersonly: true,
                minlength: 2
            },
            ctl00$ctl00$contenido$contenido$txtApellidoM: {
                required: false,
                lettersonly: true,
                minlength: 2
            },
            ctl00$ctl00$contenido$contenido$txtNombre: {
                required: true,
                lettersonly: true,
                minlength: 2
            },
            ctl00$ctl00$contenido$contenido$txtEmail: {
                required: true,
                email: true
            },
            ctl00$ctl00$contenido$contenido$txtPassword: {
                required: true
            },
            ctl00$ctl00$contenido$contenido$txtRPassword: {
                required: true,
                equalTo: '#ctl00$ctl00$contenido$contenido$txtPassword'
            }
        },
        messages: {
            ctl00$ctl00$contenido$contenido$txtApellidoP: {
                required: 'Por favor, ingrese un Apellido Paterno',
                lettersonly: 'Por favor, ingrese Apellido valido',
                minlength: "Por favor, ingrese un Apellido real"
            },
            ctl00$ctl00$contenido$contenido$txtApellidoM: {
                lettersonly: 'Por favor, ingrese Apellido valido',
                minlength: "Por favor, ingrese un Apellido real"
            },
            ctl00$ctl00$contenido$contenido$txtNombre: {
                required: 'Por favor, ingrese un nombre',
                lettersonly: 'Por favor, ingrese nombre valido',
                minlength: "Por favor, ingrese un nombre real"
            },
            ctl00$ctl00$contenido$contenido$txtEmail: {
                required: 'Por favor, ingrese un correo',
                email: 'Por favor, ingrese correo valido'
            },
            ctl00$ctl00$contenido$contenido$txtPassword: {
                required: 'Por favor, ingrese una contraseña'
            },
            ctl00$ctl00$contenido$contenido$txtRPassword: {
                required: 'Por favor, ingrese nuevamente la contraseña',
                equalTo: 'Por favor, ingrese contraseña correcta'
            }
        }
    });

    $('#contenido_contenido_btnAceptar').click(function (e) {
        e.preventDefault();
        mensj = "";
        debugger;
        
        var Nombre = $('#contenido_contenido_txtNombre').val();
        var ApellidoP = $('#contenido_contenido_txtApellidoP').val();
        var ApellidoM = $('#contenido_contenido_txtApellidoM').val();
        var Password = $('#contenido_contenido_txtPassword').val();
        var Correo = $('#contenido_contenido_txtEmail').val();
        var tipo = $('#contenido_contenido_CboxTipo').val();

        if (exprn.test(Nombre)) {
            ready += 1;
            nom = 0;
        } else {
            nom = 1;
            ready = 0;
            mensj = mensj + "Nombre, ";
        }
        if (exprn.test(ApellidoP)) {
            ready += 1;
            ap = 0;
        } else {
            ap = 1;
            ready = 0;
            mensj = mensj + "Apellido , ";
        }
        debugger;
        
        if (expr.test(Correo)) {
            ready += 1;
            cor = 0;
        } else {
            cor = 1;
            ready = 0;
            mensj = mensj + "Correo, ";
        }
        var exa2 = $('#contenido_contenido_txtRPassword').val();
        if (Password = exa2) {
            ready += 1;
        } else {
            ready = 0;
            mensj = mensj + "Contraseña ";
        }
        console.log(ready);
        if (ready == 4) {
            console.log("Si");
            ready = 0;
            $.ajax({
                url: 'WS/WSUsuario.asmx/Agregar',
                data: '{ "nom":"' + Nombre + '", "primer_apellido":"' + ApellidoP + '", "segundo_apellido":"' + ApellidoM + '", "contraseña": "' + Password + '", "Correo": "' + Correo + '", "Tipo":"' + tipo + '"}',
                contentType: 'application/json; utf-8',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    sessionStorage.setItem("indx", null);
                    sessionStorage.setItem("accion", "Usuario");
                    location.href = "index.html";
                    console.log(data);
                },
                error: function (err) {
                    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                        '<strong > a acurrido un error </strong >');
                    $("#mensaje").show();
                    console.log(err);
                }
            });
        } else {
            ready = 0;
            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > Verifique los datos en: </strong >' + mensj);
            $("#mensaje").show();
            console.log("Verifique los datos");
        }
    });
});