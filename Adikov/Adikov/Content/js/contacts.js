var Contact = function () {

    return {
        init: function () {
            var map;
            $(document).ready(function () {
                map = new GMaps({
                    div: '#gmapbg',
                    lat: window.MapConfig.lat,
                    lng: window.MapConfig.lng
                });
                var marker = map.addMarker({
                    lat: window.MapConfig.lat,
                    lng: window.MapConfig.lng,
                    title: 'ADIKOV',
                    infoWindow: {
                        content: "<b>ADIKOV</b> " + window.MapConfig.content
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