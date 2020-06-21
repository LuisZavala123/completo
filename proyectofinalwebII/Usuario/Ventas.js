var con = 0;
var tb;

function recargarDatos(datos) {
    tb.fnClearTable();
    if (datos.length > 0) {
        tb.fnAddData(datos);
    }
}

function cargarDatos(datos) {
    debugger;

    tb = $('#grvLista').dataTable({
        data: datos,
        columnDefs: [
            { width: "15%", targets: [0] },
            { width: "25%", targets: [1] },
            { width: "20%", targets: [2] },
            { width: "40%", targets: [3] }
        ],
        columns: [

            { title: "Tipo", data: "Tipo" },
            { title: "Cantidad", data: "cantidad" },
            { title: "Total", data: "total" },
            { 

                title: "", data: null, render:
                    
                    function (data, type, row) {
                        return '<div class="row justify-content-center">' +
                            '<button type="button" onclick="eliminar('+data.producto+')" class="btn btn-danger">Eliminar</button>' +
                            '</div>';
                    }
            }

        ],

        "fnInitComplete": function (oSettings, json) {


            var fila = $(this).children("thead").children("tr").clone();
            var pie = $("<tfoot/>").append(fila).css("display", "table-header-group");
            $(this).children("thead").after(pie);
            $(fila).children().each(function () {
                $(this).prop("class", null);
            });

            $(fila).children("th").each(function () {
                var title = $(this).text();
                $(this).html('<input type="text" class="filtro form-control input-sm"' +
                    ' style = "width:90%;" placeholder = "Buscar ' + title + '" /> ');
            });

            $(fila).children("th:last").html('');
            var tabla = this;
            tabla.api().columns().eq(0).each(function (colIdx) {
                $('#grvLista tfoot th:eq(' + colIdx + ') input').on('keyup change', function () {
                    tabla.api().column(colIdx).search(this.value).draw();
                });
                $('input', tabla.api().column(colIdx).footer()).on('click', function (e) {
                    e.stopPropagation();
                });
            });
        }
    });

}


function eliminar(dato) {
    dato.preventDefault;
    debugger;
    $.ajax({
        url: 'WS/WSVenta.asmx/quitarDetalle',
        data: '{ "id":"' + dato + '"}',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        type: 'POST',
        success: function (data) {

            recargarDatos(JSON.parse(data.d));

     
        },
        error: function (err) {

            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > ' + err + ' </strong >');
            $("#mensaje").show();
        }
    });
}


$(document).ready(function nombres(e) {

    $('#frm').validate({
        rules: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: true
            }
        },
        messages: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: 'Por favor, ingrese una Cantidad'
            }
        }
    });
    e.preventDefault;
    $.ajax({
        url: 'WS/WSArticulos.asmx/GetNombres',
        data: {},
        contentType: 'application/json; utf-8',
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            var models = (typeof data.d) == 'string' ? eval('(' + data.d + ') ') : data.d;
            $('#contenido_contenido_CboxProducto').get(0).options.length = 0;

            for (var i = 0; i < models.length; i++) {

                var val = models[i];

                $('#contenido_contenido_CboxProducto').get(0).options[$('#contenido_contenido_CboxProducto').get(0).options.length] = new Option(val);

            }
          
        },
        error: function (err) {
            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > ' + err + ' </strong >');
            $("#mensaje").show();
        }
    });

});
$(document).ready(function () {
    $('#frm').validate({
        rules: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: true
            }
        },
        messages: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: 'Por favor, ingrese una Cantidad'
            }
        }
    });
    $('#contenido_contenido_btnAgregar').click(function (e) {
        e.preventDefault();
        var prod = $('#contenido_contenido_CboxProducto').val();
        var cant = $('#contenido_contenido_txtCantidad').val();
        if (cant > 0) {
            $.ajax({
                url: 'WS/WSVenta.asmx/detalle',
                data: '{ "producto":"' + prod + '", "Cantidad": "' + cant + '"}',
                contentType: 'application/json; utf-8',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data != null) {
                        console.log(JSON.parse(data.d));
                        if (con < 1) {
                            cargarDatos(JSON.parse(data.d));
                            con = con + 1;
                        } else {
                            recargarDatos(JSON.parse(data.d));
                        } 
                    } else {
                        $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                            '<strong > revise los datos </strong >');
                        $("#mensaje").show();
                    }
                },
                error: function (err) {
                    $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                        '<strong > ' + err + ' </strong >');
                    $("#mensaje").show();
                }
            });
        } else {
            $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                '<strong > la cantidad debe ser mayor a 0 </strong >');
            $("#mensaje").show();
        }
        
    });
});
$(document).ready(function () {
    $('#frm').validate({
        rules: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: true
            }
        },
        messages: {
            ctl00$ctl00$contenido$contenido$txtCantidad: {
                required: 'Por favor, ingrese una Cantidad'
            }
        }
    });
    $('#contenido_contenido_btnAceptar').click(function (e) {
        e.preventDefault();

        var desc = $('#contenido_contenido_txtDescripcion').val();
        var Total = $('#contenido_contenido_lbltotal').html();
        debugger;
        $.ajax({
            url: 'WS/WSVenta.asmx/Agregar',
            data: '{"Total":"' + Total + '", "Descripcion": "' + desc + '"}',
            contentType: 'application/json; utf-8',
            dataType: 'json',
            type: 'POST',
            success: function (data) {
                debugger;
                sessionStorage.setItem("indx", null);
                sessionStorage.setItem("accion", "Venta");
                location.href = "index.html";
                console.log(data);
            },
            error: function (err) {
                $("#mensaje").html('<button type="button" class="close" data-dismiss="alert" >&times;</button>' +
                    '<strong > ' + err + ' </strong >');
                $("#mensaje").show();
            }
        });
    });
});
