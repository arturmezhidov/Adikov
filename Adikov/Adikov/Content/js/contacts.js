var Contact = function () {

    function mapInit() {
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

    function keepInTouchInit() {

        var $form = $('#keep-in-touch-form');
        if (!$form.length) {
            return;
        }

        handleValidation();
        handleSubmit();

        function handleValidation() {
            $.validator.addMethod('phoneNumber', function (value) {
                return /^(\+)?[\d\- ()]{7,19}$/g.test(value);
            }, 'Введите корректное значение.');

            var validator = $form.validate({
                errorElement: 'span',
                errorClass: 'help-block help-block-error',
                focusInvalid: false,
                ignore: ".ignore",
                messages: {
                    Username: {
                        required: 'Поле обязательно для заполнения.'
                    },
                    Content: {
                        required: 'Поле обязательно для заполнения.'
                    },
                    Phone: {
                        required: 'Поле обязательно для заполнения.',
                        minlength: 'Телефон не может быть короче 7 символов.',
                        maxlength: 'Телефон не может быть длинее 20 символов.',
                        phoneNumber: 'Введите корректный номер телефона'
                    },
                    Email: {
                        email: 'Введите корректный адрес почты'
                    }
                },
                rules: {
                    Username: {
                        required: true
                    },
                    Content: {
                        required: true
                    },
                    Phone: {
                        required: true,
                        minlength: 7,
                        maxlength: 20,
                        phoneNumber: true
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

            $form.find('[type="reset"]').click(function () {
                validator.resetForm();
            });

            $form.find('[type="file"]').on('change', function () {
                $form.validate();
                document.activeElement.blur();
            });
        }

        function handleSubmit() {
            $form.on('submit', function (e) {
                if (validateForm()) {
                    var data = getMessage();
                    sendMessage(data);
                }
                return false;
            });
        }

        function validateForm() {
            var valResult = $form.validate();
            if (valResult.errorList && valResult.errorList.length) {
                return false;
            }
            return true;
        }

        function getMessage() {
            return {
                Username: $form.find('[name=Username]').val(),
                Email: $form.find('[name=Email]').val(),
                Phone: $form.find('[name=Phone]').val(),
                Content: $form.find('[name=Content]').val()
            }
        }

        function sendMessage(data) {
            $.ajax({
                type: "POST",
                url: '/Contacts/KeepInTouchMessage',
                data: data
            })
            .success(success)
            .fail(fail);
        }

        function success(e) {
            if (e.success) {
                $form[0].reset();
                swal("Поздравляем!", e.message, "success")
            } else {
                fail(e);
            }
        }

        function fail(e) {
            swal("Ошибка!", e.message, "error")
        }
    }

    return {
        init: function () {
            mapInit();
            keepInTouchInit();
        }
    };

}();

jQuery(document).ready(function () {
    Contact.init();
});