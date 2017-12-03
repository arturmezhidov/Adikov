var FormValidation = function () {

    var handleValidation = function () {

        var productAttributeAddForm = $('#product-attribute-form');

        var validator = productAttributeAddForm.validate({
            errorElement: 'span',
            errorClass: 'help-block help-block-error',
            focusInvalid: false,
            ignore: ".ignore",
            messages: {
                Name: {
                    required: 'Поле обязательно для заполнения.'
                }
            },
            rules: {
                Name: {
                    required: true
                }
            },

            errorPlacement: function (error, element) { // render error placement for each input type
                var cont = $(element).parent('.input-group');
                if (cont.size() > 0) {
                    cont.after(error);
                } else {
                    element.after(error);
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

        productAttributeAddForm.find('[type="reset"]').click(function() {
            validator.resetForm();
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