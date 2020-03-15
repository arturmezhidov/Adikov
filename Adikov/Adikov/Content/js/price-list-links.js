var FormValidation = function () {

    var handleValidation = function () {

        var form = $('#price-list-link-form');

        if (!form.length) {
            return;
        }

        var validator = form.validate({
            errorElement: 'span',
            errorClass: 'help-block help-block-error',
            focusInvalid: false,
            ignore: ".ignore",
            messages: {
                Text: {
                    required: 'Поле обязательно для заполнения.'
                },
                Url: {
                    required: 'Поле обязательно для заполнения.'
                }
            },
            rules: {
                Text: {
                    required: true
                },
                Url: {
                    required: true
                }
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                var cont = $(element).parent('.input-group');
                if (cont.size() > 0) {
                    cont.after(error);
                } else {
                    var btn = $(element).parent('.btn');
                    if (btn.size() > 0) {
                        btn.before(error);
                    } else {
                        element.after(error);
                    }
                }
            },

            highlight: function (element) {
                $(element).closest('.form-group').addClass('has-error');
            },

            unhighlight: function (element) {
                $(element).closest('.form-group').removeClass('has-error');
            },

            success: function (label) {
                label.closest('.form-group').removeClass('has-error');
            }
        });

        form.find('[type="reset"]').click(function () {
            validator.resetForm();
        });

        form.find('[type="file"]').on('change', function () {
            form.validate();
            document.activeElement.blur();
        });
    }

    var parsePriceList = function () {

        var $contaner = $('#tables-container');

        if (!$contaner.length) {
            return;
        }

        var $tables = $contaner
            .find('#tables table')
            .addClass('table table-striped table-hover');

        $tables.find('tr').find('th:last').remove();
        $tables.find('tr').find('td:last').remove();

        $contaner
            .html($tables)
            .show();
    }

    return {
        init: function () {
            handleValidation();
            parsePriceList();
        }
    };

}();

jQuery(document).ready(function () {
    FormValidation.init();
});