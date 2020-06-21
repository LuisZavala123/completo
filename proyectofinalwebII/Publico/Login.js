$(document).ready(function () {

    function popear(c) {

    }
    popear(1);
    $('#frm').validate({
        rules: {
            ctl00$contenido$txtEmail: {
                required: true,
                email: true
            }
        },
        messages: {
            ctl00$contenido$txtEmail: {
                required: 'Por favor, ingrese un correo',
                email: 'Por favor, ingrese correo valido'
            }
        }
    });
    $('#contenido_btnLogin').click(function (e) {
        debugger;
        e.preventDefault();
        var Password = $('#contenido_txtPassword').val();
        var Correo = $('#contenido_txtEmail').val();
        debugger;
        if (expr.test(Correo)) {
            $.ajax({
                url: 'WS/WSUsuario.asmx/Confirmar',
                data: '{ "correo":"' + Correo + '", "pw":"' + Password + '"}',
                contentType: 'application/json; utf-8',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    debugger;
                    if (data.d) {
                        sessionStorage.setItem("indx", null);
                        sessionStorage.setItem("accion", "Login");
                        location.href = "index.html";

                    } else {
                        $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                            '<strong> Los datos son incorrectos  </strong >');
                        $("#mensaje").show();
                    }

                },
                error: function (err) {
                    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                        '<strong > '+err+'</strong >');
                    $("#mensaje").show();
                    
                }
            });
        } else {
            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > Los datos son incorrectos  </strong > Correo invalido');
            $("#mensaje").show();
        }
    });
});
var expr = /^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+$/;