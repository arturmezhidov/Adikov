jQuery(document).ready(function() {
    $('.mt-repeater').each(function () {
        $(this).repeater({
            show: function () {
                $(this).slideDown();
                $('.mt-repeater [fieldname]').each(function (index, element) {
                    var $element = $(element);
                    var fieldName = $element.attr('fieldname');
                    $element.attr('name', fieldName + '[' + index + ']');
                });
            },
            hide: function (deleteElement) {
                $(this).slideUp(deleteElement);
            },
            ready: function () {
                $('.mt-repeater [fieldname]').each(function (index, element) {
                    var $element = $(element);
                    var fieldName = $element.attr('fieldname');
                    $element.attr('name', fieldName + '[' + index + ']');
                });
            }
        });
    });
});