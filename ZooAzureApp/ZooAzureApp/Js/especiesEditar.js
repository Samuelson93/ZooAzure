$(document).ready(function () {

    // DEFINO LA FUNCIÓN QUE CONSULTARÁ LOS DATOS DEL API
    function cargarDetalle() {

        var id = window.location.search.substring(1).split('=')[1];

        // PREPARAR LA LLAMDA AJAX 
        $.get(`/api/especies/${id}`, function (respuesta, estado) {

            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                // QUE EN 'RESPUESTA' TENGO LA INFO


                $('#nombre').html(respuesta.data[0].nombre);
                $('#clasificacion').html(respuesta.data[0].clasificacion.denominacion);
                $('#tipoAnimal').html(respuesta.data[0].tipoAnimal.denominacion);
                $('#nPatas').html(respuesta.data[0].nPatas);
                $('#esMascota').html(respuesta.data[0].esMascota);
            }
        });
    };

    // FUNCIÓN PARA VOLVER AL LISTADO
    $('#btnCancelar').click(function () {
        window.location.href = './especies.html';
    });

    // FUNCIÓN PARA ACTUALIZAR LOS DATOS
    $('#btnActualizar').click(function () {

        var id = window.location.search.substring(1).split('=')[1];

        // PREPARAR LA LLAMDA AJAX 
        $.ajax({
            url: `/api/especies/${id}`,
            type: "PUT",
            dataType: 'json',
            data: {
                denominacion: $('#denominacion').val()
            },
            success: function (respuesta) {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                // ME REDIRECCIONO A LA LISTA DE MARCAS
                window.location.href = './especies.html';
            },
            error: function (respuesta) {
                console.log(respuesta);
            }
        });
    });

    // EJECUTO LA FUNCIÓN QUE CONSULTARÁ LOS DATOS DEL API
    cargarDetalle();
});