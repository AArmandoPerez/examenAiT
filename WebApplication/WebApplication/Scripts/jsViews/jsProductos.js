

$(document).ready(function () {

    var table = $('#table').DataTable({
        bLengthChange: false,
        pageLength: 5,
        language: {
            lengthMenu: "Mostrar _MENU_ registros por página",
            zeroRecords: "Nada encontrado",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles",
            search: "Buscar:",
            infoFiltered: "(filtrado de los _MAX_ registros totales)",
            paginate: {
                first: "Primero",
                last: "Último",
                next: "Siguiente",
                previous: "Anterior"
            },
        },
        columnDefs: [
           
        ],

    });

    $('#table tbody').on('click', 'button', function () {
        var action = this.className;
        var data = table.row($(this).parents('tr')).data();
        if (action == 'mod') {
            $('#idEdit').val(data[0])
            $('#textoEditar').val(data[1])
            $('#modalEdicion').modal('show');

        } else {
            obtenerPlanes(data[0])
            $('#agregarplanIdCliente').val(data[0])
            $('#textoview').val(data[1])


        }




    });

    $.ajax({
        type: "POST",
        url: "../Home/GetData",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            console.log("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {


            for (var i = 0; i < result.length; i++) {

                table.row.add([
                    result[i].id,
                    result[i].Descripcion
                ]).draw(false);

            }



        }
    });


    $("#buttonNewClient").click(function () {

        window.location.href = '/Home/CreateCliente/';
    });



});