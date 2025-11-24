
$(document).ready(function () {
    ConfigDateAndTine();
    MaskMeioFormat();
    ChosenConfig();
    ChosenResize();

    //$('.fixed-nav-content').css('height', window.innerHeight - 147);
});



window.onresize = function () {
    ChosenResize();
}




var callLoading = 0;

function LoadingOn() {
    if (callLoading == 0) {
        $('.loadingGif').show();
        $('.loadingFundoBranco').show();
    }
    callLoading++;
}

function LoadingOff() {
    callLoading--;
    if (callLoading == 0) {
        $('.loadingGif').hide();
        $('.loadingFundoBranco').hide();
    }
}


//ShowMessage({ AlertStyle: 'info', Message: 'Teste', EnableClose: false, AutoClose : false, target: 'msgGeral' });
function ShowMessage(alert) {
    if (alert.AlertStyle === undefined)
        alert.AlertStyle = 'info';
    if (alert.EnableClose === undefined)
        alert.EnableClose = true;
    if (alert.AutoClose === undefined)
        alert.AutoClose = false;
    if (alert.target === undefined)
        alert.target = 'msgGeral';
    if (alert.Message === undefined)
        alert.Message = 'Mensagem nao informada';

    $('#' + alert.target).append('<div class="alert  alert-' + alert.AlertStyle + ' fade in' + (alert.EnableClose ? ' alert-dismissible' : '') + (alert.AutoClose ? ' auto-close' : '') + ' "> ' + (alert.EnableClose ? ' <a href="#" class="close" data-dismiss="alert" aria-label="close">×</a> ' : '') + alert.Message + '</div>');

    window.setTimeout(function () {
        $(".alert.auto-close").alert('close')
    }, 8000);
}

function AtualizaMensagem(div) {
    $.ajax({
        url: location.origin + "/" + diretorioVirtual + "/Alert/GerAlerts",
        type: 'GET',
        success: function (data) {
            if (data !== '') {
                var alert = JSON.parse(data);
                jsAbreAlerta(alert.titulo, alert.mensagem, alert.css);
            }
        },
        error: function (requestObject, error, errorThrown) {
        },
        complete: function () {
        }
    });
}




function DeleteConfirm(mensagem, id, funcao) {

    var htmlMensagem = "";
    htmlMensagem += "<div class='modal-confirmar-exclusao modal' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='false' >";
    htmlMensagem += "<div class='modal-dialog'>";
    htmlMensagem += "<div class='modal-content'>";
    htmlMensagem += "<div class='modal-header'>";
    htmlMensagem += "<h4 class='modal-title' id='myModalLabel'>Confirme a exclusão</h4>";
    htmlMensagem += "</div>";
    htmlMensagem += "<div class='modal-body'>";
    htmlMensagem += "<p>" + mensagem + "</p>";
    htmlMensagem += "</div>";

    htmlMensagem += "<div class='modal-footer'>";
    htmlMensagem += "<button id='btnConfirmarExclusao' type='button' class='btn btn-danger'>Excluir</button>";
    htmlMensagem += "<button id='btnCancelarExclusao' type='button' class='btn btn-warning'>Cancelar</button>";
    htmlMensagem += "</div>";
    htmlMensagem += "</div>";
    htmlMensagem += "</div>";
    htmlMensagem += "</div>";

    $("#msgGeral").append(htmlMensagem);
    $('.modal-confirmar-exclusao').modal('show');

    $("#btnConfirmarExclusao").click(function () {
        $('.modal-confirmar-exclusao').modal('hide');
        $('.modal-confirmar-exclusao').remove();
        funcao(id);
    });

    $("#btnCancelarExclusao").click(function () {
        $('.modal-confirmar-exclusao').modal('hide');
        $('.modal-confirmar-exclusao').remove();
    });
}

function DefaultAjaxBegin(data, b, c, d) {
    //console.log('DefaultAjaxBegin');
    LoadingOn();
}

function DefaultAjaxComplete() {
    AtualizaMensagem();
    ConfigViewPagination();
    ChosenResize();
    MaskMeioFormat();
    ConfigDateAndTine();
    ChosenConfig();
    ChosenResize()
    LoadingOff();
    //console.log('DefaultAjaxComplete');
}

function DefaultAjaxSuccess(data, b, c, e, f) {
    //console.log('DefaultAjaxSuccess');
}

function DefaultAjaxFailure(requestObject, error, errorThrown) {

    var newDoc = document.open("text/html", "replace");
    newDoc.write(requestObject.responseText);
    newDoc.close();

    //console.log('DefaultAjaxFailure');
}

function CloseAlertAuto() {
    $(".alert.auto-close").alert('close');
}

function ConfigViewPagination() {
    var grids = $('.grid-paginavel');

    //botoes de alteração de pagina
    for (var i = 0; i < grids.length; i++) {
        var grid = grids[i];
        $(grid).find('.pagination .enable button[type=submit]').click(function () {
            $(grid).find('[name="Setings.CurrentPage"]').val($(this).html());
        });
        $(grid).find('.pagination .next-prev button[type=submit]').click(function () {
            $(grid).find('[name="Setings.CurrentPage"]').val($(this).attr("data-goto"));
        });

        $(grid).find('.pagination .change-page-ok button[type=submit]').click(function () {
            $(grid).find('[name="Setings.CurrentPage"]').val(1);
        });
    }

    //colunas do grid ordenaveis
    for (var i = 0; i < grids.length; i++) {
        var grid = grids[i];

        //setas indicativas.
        var colunasOrdenaveis = $(grid).find(('[sort-expression]'));

        var colunaOrdenacao = $(grid).find('[name="Setings.Column"]').val();
        var direcaoOrdenacao = $(grid).find('[name="Setings.Way"]').val();
        for (var j = 0; j < colunasOrdenaveis.length; j++) {
            var addclass = 'sorting';
            if ($(colunasOrdenaveis[j]).attr('sort-expression') === colunaOrdenacao) {
                if (direcaoOrdenacao === 'asc')
                    addclass = 'sorting_asc';
                else
                    addclass = 'sorting_desc';
            }
            $(colunasOrdenaveis[j]).parent().addClass(addclass);
        }

        //evento click
        $(grid).find(('[sort-expression]')).click(function () {
            var colunaOrdenacao = $(this).attr('sort-expression');
            var direcaoOrdenacao = 'asc';
            if ($(this).parent().hasClass("sorting_asc"))
                direcaoOrdenacao = 'desc';
            else
                direcaoOrdenacao = 'asc';
            $(grid).find('[name="Setings.Column"]').val(colunaOrdenacao);
            $(grid).find('[name="Setings.Way"]').val(direcaoOrdenacao);
            $(grid).find('[name="Setings.CurrentPage"]').val(1);
        });
    }

    var formsPagination = $('.form-pagination');

    for (var i = 0; i < formsPagination.length; i++) {

        var form = formsPagination[i];
        $(form).find('.divFiltrosPesquisa button[type=submit]').click(function () {
            $(form).find('[name="Setings.CurrentPage"]').val(1);
        });
    }

}



function PostAjax(data, urlAction, success, failure, complete) {
    DefaultAjaxBegin();
    $.ajax({
        url: location.origin + "/" + diretorioVirtual + urlAction,
        type: 'POST',
        data: data,
        success: function (data) {
            if (success !== undefined)
                success(data);
            DefaultAjaxSuccess();
        },
        error: function (requestObject, error, errorThrown) {
            DefaultAjaxFailure(requestObject, error, errorThrown);
        },
        complete: function () {
            DefaultAjaxComplete();
        }
    });
}

function GetAjax(urlAction, success, failure, complete) {
    DefaultAjaxBegin();
    $.ajax({
        url: location.origin + "/" + diretorioVirtual + urlAction,
        type: 'GET',
        success: function (data) {
            if (success !== undefined)
                success(data);
            DefaultAjaxSuccess();
        },
        error: function (requestObject, error, errorThrown) {
            DefaultAjaxFailure(requestObject, error, errorThrown);
        },
        complete: function () {
            DefaultAjaxComplete();
        }
    });
}




function EnableUnobtrusiveValidation(form) {

    //SetupGlobalization();
    //DisableUnobtrusiveValidation(form);
    //$.validator.unobtrusive.parse(form);
}

function DisableUnobtrusiveValidation(form) {
    //form.closest("form");
    //form.removeData('validator');
    //form.removeData('unobtrusiveValidation');
}




function ConfigDateAndTine() {
    try {
        $('.date-picker').bind("focusin", function (event) {
            $(this).datepicker({ autoclose: true, format: 'dd/mm/yyyy', language: 'pt-BR' });
        });

        $('.timepickerHHMMSS').timepicker({
            minuteStep: 1,
            showSeconds: true,
            showMeridian: false,
            defaultTime: false
        });

        $('.timepickerHHMM').timepicker({
            minuteStep: 1,
            showSeconds: false,
            showMeridian: false,
            defaultTime: false
        });
    } catch (e) {
        console.log("ERRO função - ConfigDateAndTine()");
        console.log(e);
    }
}



$.mask.masks = $.extend($.mask.masks, {
    decimal_1: { mask: '9,999.999.999.999', type: 'reverse', defaultValue: '+', autoTab: false },
    decimal_2: { mask: '99,999.999.999.999', type: 'reverse', defaultValue: '+', autoTab: false },
    decimal_3: { mask: '999,999.999.999.999', type: 'reverse', defaultValue: '+', autoTab: false },
    decimal_4: { mask: '9999,999.999.999.999', type: 'reverse', defaultValue: '+', autoTab: false },
    decimal_5: { mask: '99999,999.999.999.999', type: 'reverse', defaultValue: '+', autoTab: false },
    decimal_6: { mask: '999999,999.999.999.999', type: 'reverse', defaultValue: '+', autoTab: false },
    decimal_7: { mask: '9999999,999.999.999.999', type: 'reverse', defaultValue: '+', autoTab: false },
    decimal_8: { mask: '99999999,999.999.999.999', type: 'reverse', defaultValue: '+', autoTab: false },
    decimal_9: { mask: '999999999,999.999.999.999', type: 'reverse', defaultValue: '+', autoTab: false },

    decimal_positivo_1: { mask: '9,999.999.999.999', type: 'reverse', autoTab: false },
    decimal_positivo_2: { mask: '99,999.999.999.999', type: 'reverse', autoTab: false },
    decimal_positivo_3: { mask: '999,999.999.999.999', type: 'reverse', autoTab: false },
    decimal_positivo_4: { mask: '9999,999.999.999.999', type: 'reverse', autoTab: false },
    decimal_positivo_5: { mask: '99999,999.999.999.999', type: 'reverse', autoTab: false },
    decimal_positivo_6: { mask: '999999,999.999.999.999', type: 'reverse', autoTab: false },
    decimal_positivo_7: { mask: '9999999,999.999.999.999', type: 'reverse', autoTab: false },
    decimal_positivo_8: { mask: '99999999,999.999.999.999', type: 'reverse', autoTab: false },
    decimal_positivo_9: { mask: '999999999,999.999.999.999', type: 'reverse', autoTab: false },

    inteiro: { mask: '999999999999', type: 'reverse', defaultValue: '+', autoTab: false },
    inteiro_positivo: { mask: '999999999999', type: 'repeat', autoTab: false },

    currency: { mask: '99,999.999.999', type: 'reverse', defaultValue: '+' },
    currency_positivo: { mask: '99,999.999.999', type: 'reverse', defaultValue: '' },
    datepicker: { mask: '99/99/9999', autoTab: false },
    datetime: { mask: '99/99/9999 99:99:99', autoTab: false },
    time_hh_mm_ss: { mask: '99:99:99', autoTab: false },
    time_hh_mm: { mask: '99:99', autoTab: false },
    phone: { mask: '999999999?9', autoTab: false },
    phone9: { mask: '999999999?9', autoTab: false },
    phone_with_ddd: { mask: '(99) 99999-99999?9', autoTab: false },
    placaVeiculo: { mask: 'aaa9999', autoTab: false },
    cep: { mask: '99999-999', autoTab: false },
    cpf: { mask: '999.999.999-99', autoTab: false },
    cnpj: { mask: '99.999.999/9999-99', autoTab: false },
    cnae: { mask: '9999-9/99', autoTab: false }
});

function MaskMeioFormat() {
    try {
        $('input[type="text"]').setMask();

        //Telefone 9 e 8 digitos
        $("[alt=phone9]").each(function () {
            if (this.value.length == 9) {
                $(this).setMask("99999-99999?9");
            } else {
                $(this).setMask("9999-99999?9");
            }
        });
        $("[alt=phone9]").on('keypress', function (event) {
            var target, phone, element;
            target = (event.currentTarget) ? event.currentTarget : event.srcElement;
            phone = target.value.replace(/\D/g, '');
            element = $(target);
            element.unsetMask();
            if (phone.length < 8) {
                element.setMask("9999-99999?9");
            } else {
                element.setMask("99999-99999?9");
            }
        });
        $("[alt=phone9]").on('keyup', function (event) {
            if (event.keyCode == 8) { //backspace
                var target, phone, element;
                target = (event.currentTarget) ? event.currentTarget : event.srcElement;
                phone = target.value.replace(/\D/g, '');
                element = $(target);
                element.unsetMask();
                if (phone.length = 8) {
                    element.setMask("9999-99999?9");
                }
            }
        });

        //Telefone com DDD e 9 ou 8 digitos
        $("[alt=phone_with_ddd]").each(function () {
            if (this.value.length == 15) {
                $(this).setMask("(99) 99999-99999?9");
            } else {
                $(this).setMask("(99) 9999-99999?9");
            }
        });
        $("[alt=phone_with_ddd]").on('keypress', function (event) {
            var target, phone, element;
            target = (event.currentTarget) ? event.currentTarget : event.srcElement;
            phone = target.value.replace(/\D/g, '');
            element = $(target);
            element.unsetMask();
            if (phone.length < 10) {
                element.setMask("(99) 9999-99999?9");
            } else {
                element.setMask("(99) 99999-99999?9");
            }
        });
        $("[alt=phone_with_ddd]").on('keyup', function (event) {
            if (event.keyCode == 8) { //backspace
                var target, phone, element;
                target = (event.currentTarget) ? event.currentTarget : event.srcElement;
                phone = target.value.replace(/\D/g, '');
                element = $(target);
                element.unsetMask();
                if (phone.length = 10) {
                    element.setMask("(99) 9999-99999?9");
                }
            }
        });
    } catch (e) {
        console.log("ERRO função - MaskMeioFormat()");
        console.log(e);
    }
}



function ChosenConfig() {
    $(".chosen-select").chosen({
        no_results_text: "Sem resultados para",
        placeholder_text_single: "Selecione uma opção",
        placeholder_text_multiple: "Selecione as opções",
    });
}

function ChosenResize() {
    $("body").find('.chosen-container').each(function () {
        var size = parseInt($(this).parent().css('width').replace('px', ''));
        size = size - 24;

        $(this).css('width', size + 'px');
        $(this).find('a:first-child').css('width', size + 'px');
        $(this).find('.chosen-drop').css('width', size + 'px');
        $(this).find('.chosen-search input').css('width', (size - 10) + 'px');
    });
}

function Lpad(data, width, char) {
    var aux = '';
    for (var i = 0; i < width; i++) {
        aux += char;
    }
    return (aux + data).slice(-width);
}

function FormataHora(data) {
    if (!typeof data.getMonth === 'function')
        data = new Date(data);

    return Lpad(data.getHours(), 2, '0') + ":" + Lpad(data.getMinutes(), 2, '0') + ":" + Lpad(data.getSeconds(), 2, '0');
}
function FormataData(data) {
    if (!typeof data.getMonth === 'function')
        data = new Date(data);
    return Lpad(data.getDate(), 2, '0') + "/" + Lpad(data.getMonth() + 1, 2, '0') + "/" + Lpad(data.getFullYear(), 4, '0');
}
function FormataMoeda(valor) {
    valor = parseFloat(valor.toFixed(2));
    return 'R$' + valor.toLocaleString('pt-BR', { minimumFractionDigits: 2 });
}
function FormataFloat(valor, casasDecimais) {
    valor = parseFloat(valor.toFixed(casasDecimais));
    return valor.toLocaleString('pt-BR', { minimumFractionDigits: casasDecimais });
}
function FormataInteiro(valor) {
    return ('' + valor).replace(/\./g, ",");
}



function ConverterFloat(valor) {
    if (valor === '')
        return null;

    return parseFloat(valor.replace('R$', '').replace(/\./g, "").replace(/\,/g, "."));
}


function AddDays(date, days) {
    var result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
}