var directionsDisplay;
var directionsService = new google.maps.DirectionsService();
var map;
var geocoder;

function initialize() {
    geocoder = new google.maps.Geocoder();
    directionsDisplay = new google.maps.DirectionsRenderer();

    var Lviv = new google.maps.LatLng(49.842131, 24.031656);
    var mapOptions = {
        zoom: 17,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        center: Lviv
    };

    map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

    // ??????????? ??????? ??????, ??????? ????? ?????????????? ??? ??????????? ?????
    var myLatlng = new google.maps.LatLng(49.842131, 24.031656);

    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Львівська Ратуша'
    });
    // ????? ??? ??????? ?????? ? ????? google


    //  map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

    $.getJSON( '/CoffeeShops/MapData', function (data) {

        $.each(data, function (i, item) {
            var shop = new google.maps.Marker({
                position: new google.maps.LatLng(item.CoffeeShopLongitude, item.CoffeeShopCoffeeLatitude),
                map: map,
                title: item.CoffeeShopName


            });
            shop.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')
        })
        

    });




};


google.maps.event.addDomListener(window, 'load', initialize);