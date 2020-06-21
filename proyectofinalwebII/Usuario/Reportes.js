var tabla = null;
var tb ;
var con = 0;
function otro() {
    sessionStorage.setItem("indx", "5");
    location.href = "index.html";
}

function recargarDatos(datos) {
    tb.fnClearTable();
    tb.fnAddData(datos);
}

function cargarDatos(datos) {
    debugger;
    
     tb = $('#grvLista').dataTable({
        data: datos,
    columnDefs: [
        { width: "15%", targets: [0] },
        { width: "25%", targets: [1] },
        { width: "20%", targets: [2] },
        { width: "20%", targets: [3] }
    ],
    columns: [
       
        { title: "Nombre", data: "Nombre" },
        { title: "Producto", data: "Tipo" }, 
        { title: "Tipo", data: "Cantidad" },
        { title: "cantidad", data: "Total" }
        
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


$('#contenido_contenido_btnGenerar').click(function (e) {
    e.preventDefault();
    debugger;
    let fech = $('#Fecha').val();
    debugger;
    $.ajax({
        url: 'WS/WSVenta.asmx/GetallDetalles',
        data: '{ "fecha":"' + fech + '"}',
        contentType: 'application/json; utf-8',
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            debugger;
           
            if (con < 1) {
                cargarDatos(JSON.parse(data.d));
                con = con+1;
            } else {
                recargarDatos(JSON.parse(data.d));
            }
        },
        error: function (err) {
            
        }
    });
});