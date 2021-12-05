
window.chartColors = [
    'rgb(247, 150,  70)',
    'rgb( 75, 172, 198)',
    'rgb(128, 100, 162)',
    'rgb(155, 187,  89)',
    'rgb(192,  80,  77)',
    'rgb( 79, 129, 189)',
    'rgb( 31,  73, 125)',
    'rgb(238, 236, 225)'
];

(function ($) {

    Number.prototype.toFixedDown = function (digits) {
        var re = new RegExp("([-]*\\d+\\.\\d{" + digits + "})(\\d)"),
            m = this.toString().match(re);
        return m ? parseFloat(m[1]) : this.valueOf();
    };

    $('.sidebar-menu').tree();

    $('[data-toggle="tooltip"]').tooltip();

    $('.loading').click(function () {loading(true);});

    $.fn.addValidattionForm = function () {
        var form = this.closest("form");
        form.removeData('validator');
        form.removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse(form);
    };

    $.fn.clearValidation = function () {
        var v = $(this).validate();
        $('[name]', this).each(function () {
            v.successList.push(this);
            v.showErrors();
        });
        v.resetForm();
        v.reset();
    };

    $.fn.serializeObject = function() {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function() {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    $.fn.addItemSource = function (url, propertyId, propertyValue, isRemoveAllItems, actionComplete, extraProperty) {
        var selector = this;
        $.ajax({
            url: url,
            type: "GET",
            async: true,
            success: function (response) {
                if (isRemoveAllItems)
                    $(selector).children().remove();
                else
                    $(selector).children().not(':first').remove();

                response.forEach(function (element) {
                    $(selector).append('<option extra-property="' + (extraProperty != null ? element[extraProperty] : '') + '" value=' + element[propertyId] + '>' + element[propertyValue] + '</option>');
                });
            },
            error: function (response) {
                console.log(response);
            },
        })
            .done(function () {
                if (actionComplete != null)
                    actionComplete();
            });
    };

    $.fn.addItemSourceOptionGroup = function (url, propertyId, propertyValue, propertyOptionGroup, actionComplete) {
        var selector = this;
        $.ajax({
            url: url,
            type: "GET",
            async: true,
            success: function (response) {
                $(selector).children().remove();

                var group = response
                    .map((item) => item[propertyOptionGroup])
                    .filter((item, i, ar) => ar.indexOf(item) === i)
                    .sort((a, b) => a - b)
                    .map(item =>
                    {
                        let new_list = response
                            .filter(itm => itm[propertyOptionGroup] == item)
                            .map(itm => { return { Id: itm[propertyId], Value: itm[propertyValue] }; });

                            return {
                                group: item, list: new_list
                            };
                    });

                group.forEach(function (element) {
                    $(selector).append('<optgroup id=' + element['group'] + ' label=' + element['group'] + '></optgroup>');
                    element.list.forEach(item => $('optgroup#' + element['group']).append('<option value=' + item.Id + '>' + item.Value + '</option>'));
                });
            },
            error: function (response) {
                console.log(response);
            }
        })
            .done(function () {
            if (actionComplete != null)
                actionComplete();
        });
    };

    $.validator.addMethod("Requerid", function (value) {
        return value.trim().length == 0 ? false : true;
    }, "Campo requerido");

    $('select').on('select2:select', function () { $(this).blur();} );  

    $("select").on("select2:unselecting", function () { $(this).blur(); });

    $(document).on('focus', '.select2-selection.select2-selection--single', function (e) {
        $(this).closest(".select2-container").siblings('select:enabled').select2('open');
    });

    $('select.select2').on('select2:closing', function (e) {
        $(e.target).data("select2").$selection.one('focus focusin', function (e) {
            e.stopPropagation();
        });
    });

    $(":input[data-val-number]").attr("data-val-number", "Debe ingresar un valor válido");

    $.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
        },
        "Debe ingresar un numero de 0 a 100."
    );

    $.validator.addMethod("numeric", function(value, element) {
        return value.trim().length == 0 ? false : true;
    }, "Debe ser ingresar un valor válido");

    $.extend($.validator, {
        messages: {
            required: 'Debe seleccionar un valor',
            remote: 'Porfavor, corrije el valor de este campo.',
            email: 'Ingresa una dirección de correo válida.',
            url: 'Ingresa una URL válida.',
            date: 'Ingresa una fecha válida.',
            dateISO: 'Ingresa una fehca válida(ISO).',
            number: 'Ingresa un número válido.',
            digits: 'Ingresa sólo letras.',
            creditcard: 'Ingresa un número de tarjeta de crédito válido.',
            equalTo: 'Ingresa el mismo valor de nuevo.',
            accept: 'Ingresa un valor con extensión válida.',
            maxlength: $.validator.format('Porfavor ingresa menos de {0} caractéres.'),
            minlength: $.validator.format('Porfavor ingresa almenos {0} caractéres.'),
            rangelength: $.validator.format('Porfavor ingresa un valor entre {0} y {1} caractéres de longitud.'),
            range: $.validator.format('Ingresa un valor entre {0} y {1}.'),
            max: $.validator.format('Ingresa un valor menor o igual que {0}.'),
            min: $.validator.format('Ingresa un valor mayor o igual a {0}.')
        }
    });


    selectOptGroupAll = function (id, selector) {
        if ($('#' + id).val().length == 0) {
            var values = [];
            $(selector).siblings().children().each(function (a, b) {
                var id = b.getAttribute('id').split('-').pop();
                b.setAttribute('aria-selected', true);
                values.push(id);
            });
            $('#' + id).val(values).trigger('change');
        } else {
            $(selector).siblings().children().each(function (a, b) {
                b.setAttribute('aria-selected', false);
            });

            $('#' + id).val([]).trigger('change');
        }
    };

    eliminarConfirm = function (callback) {
        $.confirm({
            title: 'Eliminar Registro',
            content: '¿ Esta seguro que desea eliminar este registro ?',
            icon: 'fa fa-question-circle',
            animation: 'scale',
            closeAnimation: 'scale',
            opacity: 0.2,
            theme: 'supervan',
            buttons: {
                'confirm': {
                    text: 'Eliminar',
                    btnClass: 'btn btn-red',
                    action: function () {
                        if (callback != null)
                            callback();
                    }
                },
                cancel: {
                    text: 'Cancelar'
                }
            }
        });
    };

    eliminar = function (Element) {
        $.confirm({
            title: 'Eliminar Registro',
            content: '¿ Esta seguro que desea eliminar este registro ?',
            icon: 'fa fa-question-circle',
            animation: 'scale',
            closeAnimation: 'scale',
            opacity: 0.2,
            theme: 'supervan',
            buttons: {
                'confirm': {
                    text: 'Eliminar',
                    btnClass: 'btn btn-red',
                    action: function () {
                        deleterow(Element);
                    }
                },
                cancel: function () {
                }
            }
        });
    };

    completeDecimal = function () {
        var input = this;
        var value = input.value;
        if (value == '' || value == null || value == undefined)
            input.value = '0.00000';

        $(input).valid();
    };

    completeFourDecimal = function () {
        var input = this;
        var value = input.value;
        if (value == '' || value == null || value == undefined)
            input.value = '0.0000';

        $(input).valid();
    };

    onlyDecimales = function (e) {
        var regex = /[\-\.\d]/;
        var key = window.event ? e.which : e.keyCode;
        var char = String.fromCharCode(key);
        var valor = char;
        if (!regex.test(valor)) {
            e.preventDefault();
            return false;
        }
    };

    validateDecimales = function (input,limit,e) {
        var inputValue = input.value;
        var splitDecimal = inputValue.split('.');
        if (splitDecimal.length == 2) {
            if (!(splitDecimal[1].length <= + limit - 1)) {
                e.preventDefault();
                return false;
            }
        }
        return true;
    };

    completeZero = function () {
        var input = this;
        var value = input.value;
        if (value == '' || value == null || value == undefined)
            input.value = '0.00';

        $(input).valid();
    };

    completeZeroInt = function () {
        var input = this;
        var value = input.value;
        if (value == '' || value == null || value == undefined)
            input.value = '0';

        $(input).valid();
    };


    SiNo = (data) => {
        if (data) { return "Sí"; }
        return "No";
    };

    Fecha = (data) => {
        var date = moment(data);
        return date.tz('America/Lima').format('DD/MM/YYYY');
    };

    blurUpper = (control) => {
        $(control).blur((e) => {
            $(e.target).val($(e.target).val().toUpperCase());
            $(e.target).valid();
        });
    };

    Defecto = (data) => {
        if (data == true) { return "Sí"; }
        return "No";
    };

    ActivoPasivo = (data) => {
        if (data == true) { return "Activo"; }
        return "Pasivo";
    };

    Money = (data) => {
        return data.toFixed(5).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
    };

    Millar = (data) => {
        return data.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
    };

    MillarUSD = (data) => {
        var d = data.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
        var negative = d.startsWith('-');
        if (negative)
            d = '(' + d.split('-')[1] + ')';
        return  d;
    };

    Percent = (data) => {
        var d = data.toFixed(2);
        var negative = d.startsWith('-');
        if (negative)
            d = '(' + d.split('-')[1] + ')';
        return d + "%";
    };

    NoDataText = (data) => {
        if (data != null) { return data; }
        else {return "-"}
    };

    loading = function (action) {
        if (action) {
            $.blockUI({
                message: '<img src="/img/loading.gif" width="120" />',
                centerY: 0,
                css: {
                    width: '175px',
                    top: ($(window).height() - 150) / 2 + 'px',
                    left: ($(window).width() - 150) / 2 + 'px',
                    border: '0px solid #ff8304',
                    padding: '10px',
                    backgroundColor: '',
                    opacity: .99,
                    color: '#FFFFFF'
                },
                fadeIn: 200,
                fadeOut: 400
            });
        } else
            $.unblockUI();
    };

    $IsNullNun = function (value){
        return !value == 0 || value == null || value == undefined;
    };

    $IsNullStr = function (value) {
        return value == null || value == undefined;
    };

})(jQuery);