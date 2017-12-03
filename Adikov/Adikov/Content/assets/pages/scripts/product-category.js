var FormValidation = function () {

    var handleValidation = function () {

        var productCategoryAddForm = $('#product-category-form');

        var validator = productCategoryAddForm.validate({
            errorElement: 'span',
            errorClass: 'help-block help-block-error',
            focusInvalid: false,
            ignore: ".ignore",
            messages: {
                Name: {
                    required: 'Поле обязательно для заполнения.'
                },
                Icon: {
                    required: 'Поле обязательно для заполнения.'
                },
                Image: {
                    required: 'Выберите картинку.'
                }
            },
            rules: {
                Name: {
                    required: true
                },
                Icon: {
                    required: true
                },
                Image: {
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

        productCategoryAddForm.find('[type="reset"]').click(function() {
            validator.resetForm();
        });

        productCategoryAddForm.find('[type="file"]').on('change', function() {
            productCategoryAddForm.validate();
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