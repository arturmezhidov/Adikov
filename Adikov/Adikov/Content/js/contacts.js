var Contact = function () {

    return {
        init: function () {
            var map;
            $(document).ready(function () {
                map = new GMaps({
                    div: '#gmapbg',
                    lat: 53.857539,
                    lng: 27.624522
                });
                var marker = map.addMarker({
                    lat: 53.857539,
                    lng: 27.624522,
                    title: 'ADIKOV',
                    infoWindow: {
                        content: "<b>ADIKOV</b> г. Минск ул. Щетовка 36 кв2, офис и склад"
                    }
                });

                marker.infoWindow.open(map, marker);
            });
        }
    };

}();

jQuery(document).ready(function () {
    Contact.init();
});