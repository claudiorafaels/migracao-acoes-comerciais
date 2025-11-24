
function SetupGlobalization() {
    (function ($) {
        // this method is a copy from http://www.w3schools.com/js/js_cookies.asp
        function getCookie(cname) {
            var name = cname + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1);
                if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
            }
            return "";
        }

        var language = getCookie("language");

        if (language == "") {
            language = "pt-BR";
        }

        $.validator.methods.number = function (value, element) {
            if (value == "" || Globalize.parseFloat(value, 10, Globalize.cultures[language])) {
                console.log('SetupGlobalization - Decimal - valid: ' + value);
                return true;
            }
            console.log('SetupGlobalization - Decimal - invalid: ' + value);
            return false;
        }
        $.validator.methods.range = function (value, element, parameters) {
            var valuef = Globalize.parseFloat(value, 10, Globalize.cultures[language]);
            if (value == "" || (valuef >= parameters[0] && valuef <= parameters[1])) {
                console.log('SetupGlobalization - Range - valid: ' + value);
                return true;
            }
            console.log('SetupGlobalization - Range - invalid: ' + value);
            return false;
        }
        $.validator.methods.date = function (value, element) {
            if (value == "" || Globalize.parseDate(value, null, Globalize.cultures[language])) {
                console.log('SetupGlobalization - Datetime - valid: ' + value);
                return true;
            }
            console.log('SetupGlobalization - Datetime - invalid: ' + value);
            return false;
        }

    })(jQuery);


    $.extend($.validator.messages, {
        required: "Este campo é obrigatório.",
        remote: "Corrija este campo.",
        email: "Por favor informe um endereço de e-mail válido.",
        url: "Por favor informe uma URL válida.",
        date: "Por favor informe uma data válida.",
        dateISO: "Por favor, informe uma data válida ( ISO ).",
        number: "Por favor informe um número válido.",
        digits: "Por favor, informe somente dígitos.",
        creditcard: "Por favor informe um número de cartão de crédito válido.",
        equalTo: "Por favor entre com o mesmo valor novamente.",
        maxlength: $.validator.format("Por favor, informe até {0} caracteres."),
        minlength: $.validator.format("Por favor, informe pelo menos {0} caracteres."),
        rangelength: $.validator.format("Por favor informe um valor entre {0} e {1} caracteres."),
        range: $.validator.format("Por favor informe um valor entre {0} e {1}."),
        max: $.validator.format("Por favor informe um valor menor ou igual a {0}."),
        min: $.validator.format("Por favor informe um valor maior ou igual a {0}.")
    });
}

