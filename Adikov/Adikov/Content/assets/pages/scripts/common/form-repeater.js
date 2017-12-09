jQuery(document).ready(function () {

    $('.mt-repeater').each(function () {
        $(this).repeater({
            show: function () {
                $(this).slideDown();
                $('.mt-repeater [fieldname]').each(updateElement);
            },
            hide: function (deleteElement) {
                $(this).slideUp(deleteElement, function () {
                    $(deleteElement).closest('[data-repeater-item]').remove();
                    $('.mt-repeater [fieldname]').each(updateElement);
                });
            },
            ready: function () {
                $('.mt-repeater [fieldname]').each(updateElement);
            }
        });
    });

    function updateElement(index, element) {
        var $element = $(element);
        var fieldName = $element.attr('fieldname');
        $element.attr('name', fieldName + '[' + index + ']');
        $element.closest('.form-group').find('.numberable').text(index + 1);
        var defaultvalue = $element.attr('defaultvalue');
        if (defaultvalue !== undefined) {
            $element.val(defaultvalue);
            $element.removeAttr("defaultvalue");
        } else if(!$element.val()) {
            var firstValue = $element.find('option:first').val();
            $element.val(firstValue);
        }
    }
});