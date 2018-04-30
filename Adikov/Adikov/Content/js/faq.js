var FormValidation = function () {

    var handleFaqCategoryFormValidation = function () {

        var form = $('#faq-category-form');

        if (!form.length) {
            return;
        }

        var validator = form.validate({
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

    var faqItemPageInit = function () {
        $('.wysihtml5').wysihtml5({
            "stylesheets": ["/Content/assets/global/plugins/bootstrap-wysihtml5/wysiwyg-color.css"]
        });
        $('#switch-long-answer').change(function() {
            if (this.checked) {
                $('#html-content-group').slideDown();
            } else {
                $('#html-content-group').slideUp();
            }
        });

        var form = $('#faq-item-form');

        if (!form.length) {
            return;
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
                ShortContent: {
                    required: 'Поле обязательно для заполнения.'
                },
                FaqCategoryId: {
                    required: 'Поле обязательно для заполнения.'
                }
            },
            rules: {
                Title: {
                    required: true
                },
                ShortContent: {
                    required: true
                },
                FaqCategoryId: {
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
            handleFaqCategoryFormValidation();
            faqItemPageInit();
        }
    };

}();

jQuery(document).ready(function () {
    FormValidation.init();
});