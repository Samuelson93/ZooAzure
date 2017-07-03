$(document).ready(function () {
    // FUNCIÓN PARA VOLVER AL LISTADO
    $('#btnCancelar').click(function () {
        window.location.href = './especies.html';
    });
    // FUNCIÓN PARA CREAR NUEVO ELEMENTO
    $('#btnCrear').click(function () {
        // PREPARAR LA LLAMDA AJAX 
        var datos = {
            "tipoAnimal.id": $('#tipoAnimal').val(),
            "clasificacion.id": $('#clasificacion').val(),
            nombre: $('#nombre').val(),
            nPatas: $('#nPatas').val(),
            esMascota: $('#esMascota').val(),
        };
        $.ajax({
            url: `/api/especies`,
            type: "POST",
            dataType: 'json',
            data: datos,
            success: function (respuesta) {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                // ME REDIRECCIONO A LA LISTA DE MARCAS
                window.location.href = './especies.html';
                console.log("respuesta ", respuesta);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log("ERROR: " + JSON.stringify(errorThrown) +
                           "\n xhr: " + JSON.stringify(xhr) +
                    "\n textStatus: " + JSON.stringify(textStatus));
            }
        });
    });
});