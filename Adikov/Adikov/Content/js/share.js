﻿var FormValidation = function () {

    var handleValidation = function () {

        var form = $('#share-form');

        if (!form.length) {
            return;
        }

        if ($.fn.wysihtml5) {
            $('.wysihtml5').wysihtml5({
                "stylesheets": ["/Content/assets/global/plugins/bootstrap-wysihtml5/wysiwyg-color.css"]
            });
        }

        var validator = form.validate({
            errorElement: 'span',
            errorClass: 'help-block help-block-error',
            focusInvalid: false,
            ignore: ".ignore",
            messages: {
                Title: {
                    required: 'Поле обязательно для заполнения.'
                },
                Description: {
                    required: 'Поле обязательно для заполнения.'
                },
                Image: {
                    required: 'Выберите фото.'
                },
                EndDate: {
                    required: 'Поле обязательно для заполнения.'
                }
            },
            rules: {
                Title: {
                    required: true
                },
                Description: {
                    required: true
                },
                Image: {
                    required: window.isEditMode !== true
                },
                EndDate: {
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

    return {
        init: function () {
            handleValidation();
        }
    };

}();

jQuery(document).ready(function () {
    FormValidation.init();
});