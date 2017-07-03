$(document).ready(function () {

    // DEFINO LA FUNCIÓN QUE CONSULTARÁ LOS DATOS DEL API
    function cargarDetalle() {

        var id = window.location.search.substring(1).split('=')[1];

        // PREPARAR LA LLAMDA AJAX 
        $.get(`/api/especies/${id}`, function (respuesta, estado) {
            //$('#resultados').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                // QUE EN 'RESPUESTA' TENGO LA INFO
                var contenido = '';
                //contenido += respuesta.data[0].id;
                //contenido += respuesta.data[0].matricula;
                //contenido += respuesta.data[0].color;
                //contenido += respuesta.data[0].cilindrada;
                //contenido += respuesta.data[0].nPlazas;
                //contenido += respuesta.data[0].marca.denominacion;
                //contenido += respuesta.data[0].tipoCombustible.denominacion;


                $('#nombre').html(respuesta.data[0].nombre);
                $('#clasificacion').html(respuesta.data[0].clasificacion.denominacion);
                $('#tipoAnimal').html(respuesta.data[0].tipoAnimal.denominacion);
                $('#nPatas').html(respuesta.data[0].nPatas);
                $('#esMascota').html(respuesta.data[0].esMascota);
            }
        });
    };



    // EJECUTO LA FUNCIÓN QUE CONSULTARÁ LOS DATOS DEL API
    cargarDetalle();
})