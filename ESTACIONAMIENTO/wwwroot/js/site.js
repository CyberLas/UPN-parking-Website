
function PromptDemo(this_,event) {

    var $this = $(this_);
    console.log(this_);
    var idTarjeta = $this.closest('tr').find('select[name=IdTarjeta]').val();
    var nhoras = $this.closest('tr').find('select[name=NHoras]').val();
    var nhorastext = $this.closest('tr').find('select[name=NHoras] option:selected').text()
    alert(idTarjeta);
    alert(nhoras);
    alert(nhorastext);
    event.preventDefault();


    //var a = 1;
    //var Clave = prompt("Ingresar CV2 de la Tarjeta", "");
    //do {
    //    if (Clave == "433") {
    //         alert("Compra Exitosa");
    //        a = 3;
    //    }
    //    else {
    //        alert("Error al Ingresar");
    //        var Clave = prompt("Ingresar CV2 de la Tarjeta", "");
    //        a++;
    //    }
    //} while (a==2);
}

$('select').on('click', function () {
    $.ajax({
        url: 'User/Editar'
    }).done(function (edit) {
        $('#mod1').html(edit);
    });
});

$.ajax({
    url: 'User/Index'
}).done(function (x) {
    $('#mod1').html(x);
});

$.ajax({
    url: 'Estacionamiento/Index'
}).done(function (x) {
    $('#aparcamientos').html(x);
});
$.ajax({
    url: '/vehiculos/index'
}).done(function (x) {
    $('#vehiculosmod').html(x);
});

$.ajax({
    url: '/tarjeta/index'
}).done(function (x) {
    $('#Ubicacion').html(x);
});

$('#editarPerfil').on('click', function () {
    $.ajax({
        url: 'User/Editar'
    }).done(function (edit) {
        $('#mod1').html(edit);
    });
});

$('#CreaTarjeta').on('click', function () {
    $.ajax({
        url: 'Tarjeta/Crear'
    }).done(function (x) {
        $('#Ubicacion').html(x);
    });
});

$('#nuevoV').on('click', function () {
    $.ajax({
        url: 'Vehiculos/Crear'
    }).done(function (edit) {
        $('#vehiculosmod').html(edit);
    });
});


$.ajax({
    url: 'Historial/Index'
}).done(function (x) {
    $('#historialmod').html(x);
});

//mapa,

function Mapa() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var latitude = position.coords.latitude;
            var longitude = position.coords.longitude;
            var map = L.map('map').
                setView([latitude, longitude],
                    14);

            L.marker([-7.151033, -78.506374], { draggable: true, title: 'Estacionamiento 1' }).addTo(map).bindPopup("<b>1</b>").openPopup().on('click', onClick);
            L.marker([-7.15841, -78.515699], { draggable: true, title: 'Estacionamiento 2' }).addTo(map).bindPopup("<b>2</b>").openPopup().on('click', onClick);
            L.marker([-7.182599, -78.487933], { draggable: true, title: 'Estacionamiento 3' }).addTo(map).bindPopup("<b>3</b>").openPopup().on('click', onClick);
            function onClick(e) {
                L.Routing.control({ waypoints: [L.latLng(latitude, longitude), this.getLatLng()], language: 'es' }).addTo(map);
            }

            L.marker([latitude, longitude], { draggable: true, title: 'Ubicacion actual' }).addTo(map).bindPopup("<b>Tu estas Aqui.</b>").openPopup();
            L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://cloudmade.com">CloudMade</a>',
                maxZoom: 18
            }).addTo(map);

            L.control.scale().addTo(map);
        }, function (error) {
            console.error(error);
        });
    } else {
        alert('Su navegador no soporta el uso de la geolocalización')
    }    
}

Mapa();

