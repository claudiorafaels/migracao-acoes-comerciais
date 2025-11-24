
$(document).ready(function () {
    resizeGridCarimboMercadoria();
});

window.onresize = function () {
    resizeGridCarimboMercadoria();
}

function jsEditCarimbo(pCodNegociacaoVerba, pCodDestinoObjetivo) {

    data = {
        pCodNegociacaoVerba: pCodNegociacaoVerba,
        pCodDestinoObjetivo: pCodDestinoObjetivo,
    };
    PostAjax(data, '/Carimbo/Edit', jsEditCarimboCallback);
}
function jsEditCarimboCallback(data) {
    ModeCarimbo(data)
}

function jsSalvarCarimbo() {

    LoadingOn();
    window.setTimeout(function () {

        if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'A') {
            jsCalcularCarimbo(true);
        }
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'M') {
            jsAtualizaTotaisGrid(true);
        }
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'P') {
            jsAtualizaTotaisGrid(true);
        }

        var vlrTotal = ConverterFloat($('#lblEditCarimboTotalVerbaDistribuido').html());
        var vlrTotalImpostos = ConverterFloat($('#lblEditCarimboTotalImpostosDistribuido').html());

        var vlrVerba = null;
        if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'P') {

            $('#txtEditVlrCarimboMax').val(FormataFloat(vlrTotal));
            $('#VlrImpostos').val(FormataFloat(vlrTotalImpostos));
            vlrVerba = vlrTotal + vlrTotalImpostos

            $('#VlrVerba').val(FormataFloat(vlrVerba, 2));

            vlrVerba = FormataFloat(vlrVerba, 2).replace(/\./g, "");
        }


        var vlrCarimbo = ConverterFloat($('#txtEditVlrCarimboMax').val());

        var variacao = (vlrTotal - vlrCarimbo)
        if (variacao > 1.00) {
            jsAbreAlerta("Atenção", "O valor total carimbado + Impostos não pode ser maior que o valor da verba.", "info");
        }
        else if (variacao < -1.00) {
            jsAbreAlerta("Atenção", "O valor total carimbado + Impostos não pode ser menor que o valor da verba.", "info");
        }
        else {


            var list = jsLerGridCarimboPersistencia();
            var obj = {
                CodCarimbo: $('#hdfEditCarimboCodCarimbo').val(),
                DesObservacao: $('#txtEditCarimboDesObservacaoSolicitacaoVerba').val(),
                CodDestinoObjetivo: $('#hdfEditNegociacaoVerbaCodDestinoObjetivo').val(),
                CodNegociacaoVerba: $('#hdfEditCarimboCodNegociacaoVerba').val(),
                VlrVerba: vlrVerba,
                Itens: list
            }
            data = {
                edit: obj
            };
            PostAjax(data, '/Carimbo/SalvarCarimbo', ModeCarimbo);
        }
        LoadingOff();
    }, 1);
}

function jsLerGridCarimboPersistencia() {

    var linhas = $('.leitura input[type="checkbox"]:checked')
    var listResult = [];
    for (var i = 0; i < linhas.length; i++) {
        var codFil = $(linhas[i]).attr('data-codfil');
        var codMer = $(linhas[i]).attr('data-codmer');
        var vlrCar = $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrPrevistoCarimbo"]').html().replace('R$', '').replace(/\./g, "");
        var vlrImp = $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrImpostos"]').html().replace('R$', '').replace(/\./g, "");
        var obj = {
            CodFilialEmpresa: codFil,
            CodMercadoria: codMer,
            VlrPrevistoCarimbo: vlrCar,
            VlrImpostos: vlrImp
        }
        listResult[listResult.length] = obj;
    }
    return listResult;
}




function jsVoltarCarimboParaNegociacao() {
    jsEditarNegociacao($('#hdfEditCarimboCodNegociacaoVerba').val());
}

function jsSelecionarTodos(sender) {
    LoadingOn();
    window.setTimeout(function () {
        $('input[type="checkbox"].marcar').prop("checked", $(sender).prop("checked"));

        if (!$(sender).prop("checked")) {
            $('td[data-col="PerParticipacao"]').html('');
            $('td > input[type="text"][data-col="PerParticipacao"]').val('');
            $('td[data-col="VlrPrevistoCarimbo"]').html('');
            $('td[data-col="VlrImpostos"]').html('');
            $('td[data-col="VlrVerbaUnitario"]').html('');
            $('td[data-col="VlrPerQuedaPonderada"]').html('');
            $('td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val('');
        }

        if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'A')
            jsCalcularCarimbo();
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'M') {
            if (!$(sender).prop("checked")) {
                $('tr.leitura > td >  input[type="text"][data-col="PerParticipacao"], tr.row-similar-group > td >  input[type="text"][data-col="PerParticipacao"]').prop('disabled', 'disabled');
            }
            else {
                $('tr.leitura > td >  input[type="text"][data-col="PerParticipacao"], tr.row-similar-group > td >  input[type="text"][data-col="PerParticipacao"]').prop('disabled', '');
            }
            jsAtualizaTotaisGrid();
        }
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'P') {
            if (!$(sender).prop("checked")) {
                $('tr.leitura > td >  input[type="text"][data-col="VlrPerQuedaPonderada"], tr.row-similar-group > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', 'disabled');
                $('tr.row-similar-group > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').hide();
            }
            else {
                $('tr.leitura > td >  input[type="text"][data-col="VlrPerQuedaPonderada"], tr.row-similar-group > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', '');
                $('tr.row-similar-group > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').show();
            }
            jsAtualizaTotaisGrid();
        }

        LoadingOff();
    }, 1);
}
function jsCheckSimilar(sender) {
    LoadingOn();
    window.setTimeout(function () {
        var codgrupo = $(sender).attr('data-similar-group');
        var codfilial = $(sender).attr('data-similar-codfil');

        if (!$(sender).prop("checked")) {
            $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"] td > input[type="text"][data-col="PerParticipacao"]').val('');
            $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"] td[data-col="VlrPrevistoCarimbo"]').html('');
            $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"] td[data-col="VlrImpostos"]').html('');
            $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"] td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val('');
            $('tr.row-similar-item[data-codgrpsim="' + codgrupo + '"][data-codfil="' + codfilial + '"] td[data-col="PerParticipacao"]').html('');
            $('tr.row-similar-item[data-codgrpsim="' + codgrupo + '"][data-codfil="' + codfilial + '"] td[data-col="VlrPrevistoCarimbo"]').html('');
            $('tr.row-similar-item[data-codgrpsim="' + codgrupo + '"][data-codfil="' + codfilial + '"] td[data-col="VlrImpostos"]').html('');
            $('tr.row-similar-item[data-codgrpsim="' + codgrupo + '"][data-codfil="' + codfilial + '"] td[data-col="VlrVerbaUnitario"]').html('');
            $('tr.row-similar-item[data-codgrpsim="' + codgrupo + '"][data-codfil="' + codfilial + '"] td[data-col="VlrPerQuedaPonderada"]').html('');
        }

        $('tr.row-similar-item > td > input[type="checkbox"][data-codgrpsim="' + codgrupo + '"][data-codfil="' + codfilial + '"].marcar').prop("checked", $(sender).prop("checked"));

        if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'A')
            jsCalcularCarimbo();
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'M') {
            if (!$(sender).prop("checked")) {
                $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"]  > td >  input[type="text"][data-col="PerParticipacao"]').prop('disabled', 'disabled');
            }
            else {
                $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"]  > td >  input[type="text"][data-col="PerParticipacao"]').prop('disabled', '');
            }
            jsAtualizaTotaisGrid();
        }
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'P') {
            if (!$(sender).prop("checked")) {
                $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"]  > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', 'disabled');
                $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"]  > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').hide();
            }
            else {
                $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"]  > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', '');
                $('tr.row-similar-group[data-similar-group="' + codgrupo + '"][data-similar-codfil="' + codfilial + '"]  > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').show();
            }
            jsAtualizaTotaisGrid();
        }

        LoadingOff();
    }, 1);

}
function jsCheckAllSemSimilar(sender) {
    LoadingOn();
    window.setTimeout(function () {
        $('.row-no-similar-item input[type="checkbox"].marcar').prop("checked", $(sender).prop("checked"));

        if (!$(sender).prop("checked")) {
            $('td[data-col="PerParticipacao"]').html('');
            $('td > input[type="text"][data-col="PerParticipacao"]').val('');
            $('td[data-col="VlrPrevistoCarimbo"]').html('');
            $('td[data-col="VlrImpostos"]').html('');
            $('td[data-col="VlrVerbaUnitario"]').html('');
            $('td[data-col="VlrPerQuedaPonderada"]').html('');
            $('td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val('');
        }

        if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'A')
            jsCalcularCarimbo();
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'M') {
            if (!$(sender).prop("checked")) {
                $('tr.leitura.row-no-similar-item > td >  input[type="text"][data-col="PerParticipacao"]').prop('disabled', 'disabled');
            }
            else {
                $('tr.leitura.row-no-similar-item > td >  input[type="text"][data-col="PerParticipacao"]').prop('disabled', '');
            }
            jsAtualizaTotaisGrid();
        }
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'P') {
            if (!$(sender).prop("checked")) {
                $('tr.leitura.row-no-similar-item > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', 'disabled');
            }
            else {
                $('tr.leitura.row-no-similar-item > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', '');
            }
            jsAtualizaTotaisGrid();
        }

        LoadingOff();
    }, 1);

}
function jsCheckItemSemSimilar(sender) {
    LoadingOn();
    window.setTimeout(function () {

        var CodFilialEmpresa = $(sender).attr("data-codfil");
        var CodMercadoria = $(sender).attr("data-codmer");

        if (!$(sender).prop("checked")) {
            $('tr[data-codfil="' + CodFilialEmpresa + '"][data-codmer="' + CodMercadoria + '"]  > td >  input[type="text"][data-col="PerParticipacao"]').val('');
            $('tr[data-codfil="' + CodFilialEmpresa + '"][data-codmer="' + CodMercadoria + '"] > td[data-col="VlrPrevistoCarimbo"]').html('');
            $('tr[data-codfil="' + CodFilialEmpresa + '"][data-codmer="' + CodMercadoria + '"] > td[data-col="VlrImpostos"]').html('');
            $('tr[data-codfil="' + CodFilialEmpresa + '"][data-codmer="' + CodMercadoria + '"] > td[data-col="VlrVerbaUnitario"]').html('');
            $('tr[data-codfil="' + CodFilialEmpresa + '"][data-codmer="' + CodMercadoria + '"] > td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val('');
        }

        if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'A')
            jsCalcularCarimbo();
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'M') {
            if (!$(sender).prop("checked")) {
                $('tr[data-codfil="' + CodFilialEmpresa + '"][data-codmer="' + CodMercadoria + '"]  > td >  input[type="text"][data-col="PerParticipacao"]').prop('disabled', 'disabled');
            }
            else {
                $('tr[data-codfil="' + CodFilialEmpresa + '"][data-codmer="' + CodMercadoria + '"]  > td >  input[type="text"][data-col="PerParticipacao"]').prop('disabled', '');
            }
            jsAtualizaTotaisGrid();
        }
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'P') {
            if (!$(sender).prop("checked")) {
                $('tr[data-codfil="' + CodFilialEmpresa + '"][data-codmer="' + CodMercadoria + '"]  > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', 'disabled');
            }
            else {
                $('tr[data-codfil="' + CodFilialEmpresa + '"][data-codmer="' + CodMercadoria + '"]  > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', '');
            }
            jsAtualizaTotaisGrid();
        }

        LoadingOff();
    }, 1);
}


function jsExpandeSimilares(sender) {
    var codgrupo = $(sender).attr('data-similar-group');
    var codfilial = $(sender).attr('data-similar-codfil');
    if (!isNaN(codgrupo))
        $('tr.row-similar-item[data-codgrpsim="' + codgrupo + '"][data-codfil="' + codfilial + '"]').fadeToggle();
    else
        $('tr.row-no-similar-item').fadeToggle();

    if ($(sender).hasClass('fa-plus')) {
        $(sender).addClass('fa-minus');
        $(sender).removeClass('fa-plus');
    } else {
        $(sender).addClass('fa-plus');
        $(sender).removeClass('fa-minus');
    }
}

function jsExpandeAll(sender) {
    if ($(sender).hasClass('fa-plus')) {
        $('tr.row-similar-item').fadeIn();
        $('tr.row-no-similar-item').fadeIn();

        $('tr.row-similar-group i.fa, tr.row-no-similar-group i.fa').addClass('fa-minus');
        $('tr.row-similar-group i.fa, tr.row-no-similar-group i.fa').removeClass('fa-plus');


        $(sender).addClass('fa-minus');
        $(sender).removeClass('fa-plus');
    } else {
        $('tr.row-similar-item').fadeOut();
        $('tr.row-no-similar-item').fadeOut();

        $('tr.row-similar-group i.fa, tr.row-no-similar-group i.fa').addClass('fa-plus');
        $('tr.row-similar-group i.fa, tr.row-no-similar-group i.fa').removeClass('fa-minus');

        $(sender).addClass('fa-plus');
        $(sender).removeClass('fa-minus');
    }
}


function jsModoCalculoCarimboAuto() {
    LoadingOn();
    window.setTimeout(function () {
        jsCalcularCarimbo(true);
        jsEnableDisableAllPerParticipacao();
        LoadingOff();
    }, 1);
}
function jsModoCalculoCarimboManual() {
    LoadingOn();
    window.setTimeout(function () {
        jsAtualizaTotaisGrid(true);
        jsEnableDisableAllPerParticipacao();
        LoadingOff();
    }, 1);
}
function jsModoCalculoCarimboQuedaPonderada() {
    LoadingOn();
    window.setTimeout(function () {
        jsAtualizaTotaisGrid(true);
        jsEnableDisableAllPerParticipacao();
        LoadingOff();
    }, 1);
}


function jsCalcularCarimboManual() {
    LoadingOn();
    window.setTimeout(function () {
        if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'A') {
            jsCalcularCarimbo(true);
        }
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'M') {
            jsAtualizaTotaisGrid(true);
        }
        else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'P') {
            jsAtualizaTotaisGrid(true);
        }
        LoadingOff();
    }, 1);
}



function jsExportarCarimbo() {

    var codFornecedor = $('#hdfEditCarimboCodFornecedor').val();

    var codFiliais = $('#drpEditCarimboCodFilialFiltro').val();


    var codComprador = $('#hdfEditCarimboCodComprador').val();
    var codCarimbo = $('#hdfEditCarimboCodCarimbo').val();
    var vlrCarimbo = $('#txtEditVlrCarimboMax').val().replace('R$', '').replace(/\./g, "");
    var vlrImpostos = $('#VlrImpostos').val().replace('R$', '').replace(/\./g, "");
    var codStatusNegociacaoVenda = $('#hdfEditNegociacaoVerbaCodStatusNegociacaoVenda').val();
    var dataAprovacao = $('#hdfEditNegociacaoVerbaDtAprovacao').val();

    data = {
        pCodFornecedor: codFornecedor,
        pCodFiliais: codFiliais,
        pCodComprador: codComprador,
        pCodCarimbo: codCarimbo,
        pVlrCarimbo: vlrCarimbo,
        pVlrImpostos: vlrImpostos,
        pCodStatusNegociacaoVenda: codStatusNegociacaoVenda,
        pDataAprovacao: dataAprovacao
    };
    PostAjax(data, '/Carimbo/ExportarCarimboCSV', jsExportarCarimboCallback);
}

function jsExportarCarimboCallback(data) {
    window.location = location.origin + "/" + diretorioVirtual + '/Carimbo/Download?fileGuid=' + data.FileGuid + '&filename=' + data.FileName;
}

function jsEnableDisableAllPerParticipacao() {

    if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'A') {
        var linhas = $('tr.leitura input[type="checkbox"]:checked, tr.row-similar-group input[type="checkbox"]:checked').parent().parent();
        for (var i = 0; i < linhas.length; i++) {
            $(linhas[i]).find('input[type="text"][data-col="PerParticipacao"]').prop('disabled', 'disabled');
            $(linhas[i]).find('input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', 'disabled');
        }
        $('tr.row-similar-group > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').hide();
    }
    else if ($('input[type="radio"][name="modoDistribuicaoPartCarimbo"]:checked').val() === 'M') {
        var linhas = $('tr.leitura input[type="checkbox"]:checked, tr.row-similar-group input[type="checkbox"]:checked').parent().parent();
        for (var i = 0; i < linhas.length; i++) {
            $(linhas[i]).find('input[type="text"][data-col="PerParticipacao"]').prop('disabled', '');
            $(linhas[i]).find('input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', 'disabled');
        }
        $('tr.row-similar-group > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').hide();
    }
    else {
        var linhas = $('tr.leitura input[type="checkbox"]:checked, tr.row-similar-group input[type="checkbox"]:checked').parent().parent();
        for (var i = 0; i < linhas.length; i++) {
            $(linhas[i]).find('input[type="text"][data-col="PerParticipacao"]').prop('disabled', 'disabled');
            $(linhas[i]).find('input[type="text"][data-col="VlrPerQuedaPonderada"]').prop('disabled', '');
        }
        $('tr.row-similar-group > td >  input[type="text"][data-col="VlrPerQuedaPonderada"]').show();
    }
}


function ModeCarimbo(data) {
    $('#divEditNegociacaoVerba').hide();
    $('#formCarimbo').show();

    $('#formCarimbo').html(data);

    //jsCalcular();

    $('#pnlCarimboItemEditInfoNegociacao').click(function () {
        $(this).next().toggle();
    });

    jsEnableDisableAllPerParticipacao();
    resizeGridCarimboMercadoria();
    enableScrollCarimboMercadoria();
}


//Cálculos

function jsCalcularCarimbo(force) {
    if ($('#cbtIndCalculoAuto:checked').length === 0 && force === undefined)
        return null;

    var vlrPrevistoVerba = ConverterFloat($('#txtEditVlrCarimboMax').val());
    var vlrPrevistoImpostos = ConverterFloat($('#VlrImpostos').val());


    var totVlrPrevistoCarimboDistrib = 0;
    var totVlrEstoqueMercadoria = 0
    var totPerParticipacaoDistrib = 0;
    var totVlrImpostosDistrib = 0;


    var linhasSelecionadas = jsLerGridCarimboCalculo();

    var vlrEstoqueTotal = 0;
    for (var i = 0; i < linhasSelecionadas.length; i++) {
        vlrEstoqueTotal += linhasSelecionadas[i].VlrEstoqueMercadoria;
    }
    for (var i = 0; i < linhasSelecionadas.length; i++) {
        linhasSelecionadas[i].PerParticipacao = (linhasSelecionadas[i].VlrEstoqueMercadoria / vlrEstoqueTotal);
        linhasSelecionadas[i].VlrPrevistoCarimbo = (vlrPrevistoVerba * linhasSelecionadas[i].PerParticipacao);
        linhasSelecionadas[i].VlrImpostos = (vlrPrevistoImpostos * linhasSelecionadas[i].PerParticipacao);
        linhasSelecionadas[i].VlrVerbaUnitario = (linhasSelecionadas[i].VlrPrevistoCarimbo / linhasSelecionadas[i].QtdEstoqueMercadoria);

        if (linhasSelecionadas[i].VlrDiarioCustoMedioEfetivo - linhasSelecionadas[i].VlrMedioVerbaParaPrecoMercadoria > 0)
            linhasSelecionadas[i].VlrPerQuedaPonderada = ((((linhasSelecionadas[i].VlrDiarioCustoMedioEfetivo - linhasSelecionadas[i].VlrMedioVerbaParaPrecoMercadoria - linhasSelecionadas[i].VlrVerbaUnitario) / (linhasSelecionadas[i].VlrDiarioCustoMedioEfetivo - linhasSelecionadas[i].VlrMedioVerbaParaPrecoMercadoria)) - 1) * 100);

        $('tr[data-codfil="' + linhasSelecionadas[i].CodFilialEmpresa + '"][data-codmer="' + linhasSelecionadas[i].CodMercadoria + '"]  > td[data-col="PerParticipacao"]').html(FormataFloat((linhasSelecionadas[i].PerParticipacao * 100), 2));
        $('tr[data-codfil="' + linhasSelecionadas[i].CodFilialEmpresa + '"][data-codmer="' + linhasSelecionadas[i].CodMercadoria + '"]  > td > input[type="text"][data-col="PerParticipacao"]').val(FormataFloat((linhasSelecionadas[i].PerParticipacao * 100), 2));
        $('tr[data-codfil="' + linhasSelecionadas[i].CodFilialEmpresa + '"][data-codmer="' + linhasSelecionadas[i].CodMercadoria + '"] > td[data-col="VlrPrevistoCarimbo"]').html(FormataMoeda(linhasSelecionadas[i].VlrPrevistoCarimbo));
        $('tr[data-codfil="' + linhasSelecionadas[i].CodFilialEmpresa + '"][data-codmer="' + linhasSelecionadas[i].CodMercadoria + '"] > td[data-col="VlrImpostos"]').html(FormataMoeda(linhasSelecionadas[i].VlrImpostos));
        $('tr[data-codfil="' + linhasSelecionadas[i].CodFilialEmpresa + '"][data-codmer="' + linhasSelecionadas[i].CodMercadoria + '"] > td[data-col="VlrVerbaUnitario"]').html(FormataMoeda(linhasSelecionadas[i].VlrVerbaUnitario));
        $('tr[data-codfil="' + linhasSelecionadas[i].CodFilialEmpresa + '"][data-codmer="' + linhasSelecionadas[i].CodMercadoria + '"] > td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val(FormataFloat(linhasSelecionadas[i].VlrPerQuedaPonderada, 2));
        $('tr[data-codfil="' + linhasSelecionadas[i].CodFilialEmpresa + '"][data-codmer="' + linhasSelecionadas[i].CodMercadoria + '"] > td[data-col="VlrPerQuedaPonderada"]').html(FormataFloat(linhasSelecionadas[i].VlrPerQuedaPonderada, 2));

        totVlrPrevistoCarimboDistrib += parseFloat((linhasSelecionadas[i].VlrPrevistoCarimbo).toFixed(2));
        totVlrEstoqueMercadoria += parseFloat((linhasSelecionadas[i].VlrEstoqueMercadoria).toFixed(2));
        totPerParticipacaoDistrib += parseFloat((linhasSelecionadas[i].PerParticipacao).toFixed(4));
        totVlrImpostosDistrib += parseFloat((linhasSelecionadas[i].VlrImpostos).toFixed(2));
    }


    var gruposSimilaresSeleted = $('tr.row-similar-group  input[type="checkbox"]:checked');
    for (var i = 0; i < gruposSimilaresSeleted.length; i++) {
        var codFilial = $(gruposSimilaresSeleted[i]).attr('data-similar-codfil');
        var codGrupoSimilar = $(gruposSimilaresSeleted[i]).attr('data-similar-group');

        var totVlrPrevistoCarimboGrupo = 0;
        var totPerParticipacaoGrupo = 0;
        var totVlrImpostosGrupo = 0;
        for (var j = 0; j < linhasSelecionadas.length; j++) {
            if (linhasSelecionadas[j].CodFilialEmpresa == codFilial && linhasSelecionadas[j].CodGrupoSimilar == codGrupoSimilar) {
                totVlrPrevistoCarimboGrupo += linhasSelecionadas[j].VlrPrevistoCarimbo;
                totPerParticipacaoGrupo += linhasSelecionadas[j].PerParticipacao;
                totVlrImpostosGrupo += linhasSelecionadas[j].VlrImpostos;
            }
        }

        $('tr.row-similar-group[data-similar-group="' + codGrupoSimilar + '"][data-similar-codfil="' + codFilial + '"] > td[data-col="VlrPrevistoCarimbo"]').html(FormataMoeda(totVlrPrevistoCarimboGrupo));
        $('tr.row-similar-group[data-similar-group="' + codGrupoSimilar + '"][data-similar-codfil="' + codFilial + '"] > td > input[type="text"][data-col="PerParticipacao"]').val(FormataFloat((totPerParticipacaoGrupo * 100), 2));
        $('tr.row-similar-group[data-similar-group="' + codGrupoSimilar + '"][data-similar-codfil="' + codFilial + '"] > td[data-col="VlrImpostos"]').html(FormataMoeda(totVlrImpostosGrupo));
    }

    $('#lblEditCarimboTotalVerbaDistribuido').html(FormataMoeda(totVlrPrevistoCarimboDistrib));
    $('#lblEditCarimboTotalVlrEstoqueMercadoria').html(FormataMoeda(totVlrEstoqueMercadoria));
    $('#lblEditCarimboTotalPerParticipacao').html(FormataFloat((totPerParticipacaoDistrib * 100), 2));
    $('#lblEditCarimboTotalImpostosDistribuido').html(FormataMoeda(totVlrImpostosDistrib));
}

function jsLerGridCarimboCalculo() {

    var linhas = $('.leitura input[type="checkbox"]:checked')
    var listResult = [];
    for (var i = 0; i < linhas.length; i++) {
        var codFil = $(linhas[i]).attr('data-codfil');
        var codMer = $(linhas[i]).attr('data-codmer');
        var codGrpSim = $(linhas[i]).attr('data-codgrpsim');
        if (codGrpSim === undefined)
            codGrpSim = 0
        var VlrEstoqueMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrEstoqueMercadoria"]').html());

        if (codGrpSim === 0)
            var PerParticipacao = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td > input[type="text"][data-col="PerParticipacao"]').val());
        else
            var PerParticipacao = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="PerParticipacao"]').html());
        if (isNaN(PerParticipacao))
            PerParticipacao = 0;

        var QtdEstoqueMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="QtdEstoqueMercadoria"]').html());
        var VlrPrevistoCarimbo = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrPrevistoCarimbo"]').html());
        var VlrImpostos = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrImpostos"]').html());
        var VlrVerbaUnitario = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrVerbaUnitario"]').html());
        //var VlrPerQuedaPonderada = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val());

        var VlrDiarioCustoMedioEfetivo = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrDiarioCustoMedioEfetivo"]').html());
        var VlrMedioVerbaParaPrecoMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrMedioVerbaParaPrecoMercadoria"]').html());

        var obj = {
            CodFilialEmpresa: codFil,
            CodMercadoria: codMer,
            CodGrupoSimilar: codGrpSim,
            VlrEstoqueMercadoria: VlrEstoqueMercadoria,
            QtdEstoqueMercadoria: QtdEstoqueMercadoria,
            VlrDiarioCustoMedioEfetivo: VlrDiarioCustoMedioEfetivo,
            VlrMedioVerbaParaPrecoMercadoria: VlrMedioVerbaParaPrecoMercadoria,
            PerParticipacao: PerParticipacao,
            VlrPrevistoCarimbo: VlrPrevistoCarimbo,
            VlrImpostos: VlrImpostos,
            VlrVerbaUnitario: VlrVerbaUnitario,
            VlrPerQuedaPonderada: null
        }
        listResult[listResult.length] = obj;
    }
    return listResult;
}


function jsPerParticipacaoSimilarChange(sender) {
    var codGrpSim = $(sender).parent().parent().attr('data-similar-group');
    var codFil = $(sender).parent().parent().attr('data-similar-codfil');
    var perParticipacaoGrupo = ConverterFloat($(sender).val());

    if (perParticipacaoGrupo > 0) {
        var vlrPrevistoVerba = ConverterFloat($('#txtEditVlrCarimboMax').val());
        var vlrPrevistoImpostos = ConverterFloat($('#VlrImpostos').val());

        //obtem as mercadorias do grupo  -- INICIO
        var linhas = $('tr.row-similar-item.leitura[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"]');
        var itensSimilares = [];
        for (var i = 0; i < linhas.length; i++) {
            var codMer = $(linhas[i]).attr('data-codmer');

            var VlrEstoqueMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrEstoqueMercadoria"]').html());
            var QtdEstoqueMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="QtdEstoqueMercadoria"]').html());
            var VlrDiarioCustoMedioEfetivo = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrDiarioCustoMedioEfetivo"]').html());
            var VlrMedioVerbaParaPrecoMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrMedioVerbaParaPrecoMercadoria"]').html());
            var obj = {
                CodFilialEmpresa: codFil,
                CodMercadoria: codMer,
                CodGrupoSimilar: codGrpSim,
                VlrEstoqueMercadoria: VlrEstoqueMercadoria,
                QtdEstoqueMercadoria: QtdEstoqueMercadoria,
                VlrDiarioCustoMedioEfetivo: VlrDiarioCustoMedioEfetivo,
                VlrMedioVerbaParaPrecoMercadoria: VlrMedioVerbaParaPrecoMercadoria,
                PerParticipacao: null,
                VlrPrevistoCarimbo: null,
                VlrImpostos: null,
                VlrVerbaUnitario: null
            }
            itensSimilares[itensSimilares.length] = obj;
        }
        //obtem as mercadorias do grupo  -- FIM
        var vlrEstoqueGrupo = 0;
        for (var i = 0; i < itensSimilares.length; i++) {
            vlrEstoqueGrupo += itensSimilares[i].VlrEstoqueMercadoria;
        }

        var totVlrPrevistoCarimboGrupo = 0;
        //var totPerParticipacaoGrupo = 0;
        var totVlrImpostosGrupo = 0;

        for (var i = 0; i < itensSimilares.length; i++) {
            var representatividadeItemGrupo = (itensSimilares[i].VlrEstoqueMercadoria / vlrEstoqueGrupo);

            itensSimilares[i].PerParticipacao = ((representatividadeItemGrupo * perParticipacaoGrupo) / 100);
            itensSimilares[i].VlrPrevistoCarimbo = (vlrPrevistoVerba * itensSimilares[i].PerParticipacao);
            itensSimilares[i].VlrImpostos = (vlrPrevistoImpostos * itensSimilares[i].PerParticipacao);
            itensSimilares[i].VlrVerbaUnitario = (itensSimilares[i].VlrPrevistoCarimbo / itensSimilares[i].QtdEstoqueMercadoria);
            if (itensSimilares[i].VlrDiarioCustoMedioEfetivo - itensSimilares[i].VlrMedioVerbaParaPrecoMercadoria > 0)
                itensSimilares[i].VlrPerQuedaPonderada = ((((itensSimilares[i].VlrDiarioCustoMedioEfetivo - itensSimilares[i].VlrMedioVerbaParaPrecoMercadoria - itensSimilares[i].VlrVerbaUnitario) / (itensSimilares[i].VlrDiarioCustoMedioEfetivo - itensSimilares[i].VlrMedioVerbaParaPrecoMercadoria)) - 1) * 100);

            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"]  > td[data-col="PerParticipacao"]').html(FormataFloat((itensSimilares[i].PerParticipacao * 100), 2));
            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"] > td[data-col="VlrPrevistoCarimbo"]').html(FormataMoeda(itensSimilares[i].VlrPrevistoCarimbo));
            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"] > td[data-col="VlrImpostos"]').html(FormataMoeda(itensSimilares[i].VlrImpostos));
            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"] > td[data-col="VlrVerbaUnitario"]').html(FormataMoeda(itensSimilares[i].VlrVerbaUnitario));
            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"] > td[data-col="VlrPerQuedaPonderada"]').html(FormataFloat(itensSimilares[i].VlrPerQuedaPonderada, 2));

            totVlrPrevistoCarimboGrupo += itensSimilares[i].VlrPrevistoCarimbo;
            totVlrImpostosGrupo += itensSimilares[i].VlrImpostos;
        }

        $('tr.row-similar-group[data-similar-group="' + codGrpSim + '"][data-similar-codfil="' + codFil + '"] > td[data-col="VlrPrevistoCarimbo"]').html(FormataMoeda(totVlrPrevistoCarimboGrupo));
        $('tr.row-similar-group[data-similar-group="' + codGrpSim + '"][data-similar-codfil="' + codFil + '"] > td[data-col="VlrImpostos"]').html(FormataMoeda(totVlrImpostosGrupo));
    }
    else {
        $('tr.row-similar-group[data-similar-group="' + codGrpSim + '"][data-similar-codfil="' + codFil + '"] td > input[type="text"][data-col="PerParticipacao"]').val('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="PerParticipacao"]').html('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="VlrPrevistoCarimbo"]').html('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="VlrImpostos"]').html('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="VlrVerbaUnitario"]').html('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="VlrPerQuedaPonderada"]').html('');
    }

    jsAtualizaTotaisGrid();
}

function jsPerParticipacaoSemSimilarChange(sender) {
    var codMer = $(sender).parent().parent().attr('data-codmer');
    var codFil = $(sender).parent().parent().attr('data-codfil');
    var perParticipacao = ConverterFloat($(sender).val()) / 100;

    if (perParticipacao > 0) {
        var vlrPrevistoVerba = ConverterFloat($('#txtEditVlrCarimboMax').val());
        var vlrPrevistoImpostos = ConverterFloat($('#VlrImpostos').val());

        var vlrEstoqueMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrEstoqueMercadoria"]').html());
        var qtdEstoqueMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="QtdEstoqueMercadoria"]').html());
        var VlrDiarioCustoMedioEfetivo = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrDiarioCustoMedioEfetivo"]').html());
        var VlrMedioVerbaParaPrecoMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrMedioVerbaParaPrecoMercadoria"]').html());

        var VlrPrevistoCarimbo = (vlrPrevistoVerba * perParticipacao);
        var VlrImpostos = (vlrPrevistoImpostos * perParticipacao);
        var VlrVerbaUnitario = (VlrPrevistoCarimbo / qtdEstoqueMercadoria);

        var VlrPerQuedaPonderada = 0;
        if (VlrDiarioCustoMedioEfetivo - VlrMedioVerbaParaPrecoMercadoria > 0)
            VlrPerQuedaPonderada = ((((VlrDiarioCustoMedioEfetivo - VlrMedioVerbaParaPrecoMercadoria - VlrVerbaUnitario) / (VlrDiarioCustoMedioEfetivo - VlrMedioVerbaParaPrecoMercadoria)) - 1) * 100);

        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"]  > td[data-col="PerParticipacao"]').html(FormataFloat((perParticipacao * 100), 2));
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrPrevistoCarimbo"]').html(FormataMoeda(VlrPrevistoCarimbo));
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrImpostos"]').html(FormataMoeda(VlrImpostos));
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrVerbaUnitario"]').html(FormataMoeda(VlrVerbaUnitario));
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val(FormataFloat(VlrPerQuedaPonderada, 2));
    }
    else {
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"]  > td[data-col="PerParticipacao"]').html('');
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrPrevistoCarimbo"]').html('');
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrImpostos"]').html('');
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrVerbaUnitario"]').html('');
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val('');
    }

    jsAtualizaTotaisGrid();
}


function jsQuedaPonderadaSimilarChange(sender) {

    var codGrpSim = $(sender).parent().parent().attr('data-similar-group');
    var codFil = $(sender).parent().parent().attr('data-similar-codfil');
    var vlrPerQuedaPonderada = ConverterFloat($(sender).val());

    if (vlrPerQuedaPonderada !== 0) {
        if (vlrPerQuedaPonderada > 0) {
            vlrPerQuedaPonderada = vlrPerQuedaPonderada * -1;
            $(sender).val(FormataFloat(vlrPerQuedaPonderada, 2));
        }

        //obtem as mercadorias do grupo  -- INICIO
        var linhas = $('tr.row-similar-item.leitura[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"]');
        var itensSimilares = [];
        for (var i = 0; i < linhas.length; i++) {
            var codMer = $(linhas[i]).attr('data-codmer');

            var VlrEstoqueMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrEstoqueMercadoria"]').html());
            var QtdEstoqueMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="QtdEstoqueMercadoria"]').html());
            var VlrDiarioCustoMedioEfetivo = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrDiarioCustoMedioEfetivo"]').html());
            var VlrMedioVerbaParaPrecoMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrMedioVerbaParaPrecoMercadoria"]').html());

            if (VlrDiarioCustoMedioEfetivo - VlrMedioVerbaParaPrecoMercadoria > 0) {
                var VlrVerbaUnitario = (VlrDiarioCustoMedioEfetivo - VlrMedioVerbaParaPrecoMercadoria) * ((vlrPerQuedaPonderada / 100) * -1);
            }

            var vlrVerbaEstimada = (VlrVerbaUnitario * QtdEstoqueMercadoria) * 1.111111111111111111111111;    //0.0111...% é a diferença devido ao calculo dos 10% dos impostos ser sobre o valor da verba.
            var VlrPrevistoCarimbo = vlrVerbaEstimada * 0.9;
            var VlrImpostos = vlrVerbaEstimada * 0.1;
            var perParticipacao = 0;

            var obj = {
                CodFilialEmpresa: codFil,
                CodMercadoria: codMer,
                CodGrupoSimilar: codGrpSim,
                VlrEstoqueMercadoria: VlrEstoqueMercadoria,
                QtdEstoqueMercadoria: QtdEstoqueMercadoria,
                VlrDiarioCustoMedioEfetivo: VlrDiarioCustoMedioEfetivo,
                VlrMedioVerbaParaPrecoMercadoria: VlrMedioVerbaParaPrecoMercadoria,
                VlrVerbaUnitario: VlrVerbaUnitario,
                PerParticipacao: perParticipacao,
                VlrPrevistoCarimbo: VlrPrevistoCarimbo,
                VlrImpostos: VlrImpostos,
                VlrPerQuedaPonderada: vlrPerQuedaPonderada
            }
            itensSimilares[itensSimilares.length] = obj;
        }
        //obtem as mercadorias do grupo  -- FIM
        var vlrEstoqueGrupo = 0;
        for (var i = 0; i < itensSimilares.length; i++) {
            vlrEstoqueGrupo += itensSimilares[i].VlrEstoqueMercadoria;
        }

        var totVlrPrevistoCarimboGrupo = 0;
        var totVlrImpostosGrupo = 0;

        for (var i = 0; i < itensSimilares.length; i++) {
            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"]  > td[data-col="PerParticipacao"]').html(FormataFloat((itensSimilares[i].PerParticipacao * 100), 2));
            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"] > td[data-col="VlrPrevistoCarimbo"]').html(FormataMoeda(itensSimilares[i].VlrPrevistoCarimbo));
            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"] > td[data-col="VlrImpostos"]').html(FormataMoeda(itensSimilares[i].VlrImpostos));
            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"] > td[data-col="VlrVerbaUnitario"]').html(FormataMoeda(itensSimilares[i].VlrVerbaUnitario));
            $('tr[data-codfil="' + itensSimilares[i].CodFilialEmpresa + '"][data-codmer="' + itensSimilares[i].CodMercadoria + '"] > td[data-col="VlrPerQuedaPonderada"]').html(FormataFloat(itensSimilares[i].VlrPerQuedaPonderada, 2));

            totVlrPrevistoCarimboGrupo += itensSimilares[i].VlrPrevistoCarimbo;
            totVlrImpostosGrupo += itensSimilares[i].VlrImpostos;
        }

        $('tr.row-similar-group[data-similar-group="' + codGrpSim + '"][data-similar-codfil="' + codFil + '"] > td[data-col="VlrPrevistoCarimbo"]').html(FormataMoeda(totVlrPrevistoCarimboGrupo));
        $('tr.row-similar-group[data-similar-group="' + codGrpSim + '"][data-similar-codfil="' + codFil + '"] > td[data-col="VlrImpostos"]').html(FormataMoeda(totVlrImpostosGrupo));
    }
    else {
        $('tr.row-similar-group[data-similar-group="' + codGrpSim + '"][data-similar-codfil="' + codFil + '"] td > input[type="text"][data-col="PerParticipacao"]').val('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="PerParticipacao"]').html('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="VlrPrevistoCarimbo"]').html('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="VlrImpostos"]').html('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="VlrVerbaUnitario"]').html('');
        $('tr.row-similar-item[data-codgrpsim="' + codGrpSim + '"][data-codfil="' + codFil + '"] td[data-col="VlrPerQuedaPonderada"]').html('');
    }

    jsAtualizaTotaisGrid();
}

function jsQuedaPonderadaSemSimilarChange(sender) {
    var codMer = $(sender).parent().parent().attr('data-codmer');
    var codFil = $(sender).parent().parent().attr('data-codfil');
    var vlrPerQuedaPonderada = ConverterFloat($(sender).val());

    if (vlrPerQuedaPonderada !== 0) {
        if (vlrPerQuedaPonderada > 0) {
            vlrPerQuedaPonderada = vlrPerQuedaPonderada * -1;
            $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val(FormataFloat(vlrPerQuedaPonderada, 2));
        }

        var QtdEstoqueMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="QtdEstoqueMercadoria"]').html());
        var VlrDiarioCustoMedioEfetivo = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrDiarioCustoMedioEfetivo"]').html());
        var VlrMedioVerbaParaPrecoMercadoria = ConverterFloat($('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrMedioVerbaParaPrecoMercadoria"]').html());

        if (VlrDiarioCustoMedioEfetivo - VlrMedioVerbaParaPrecoMercadoria > 0) {
            var VlrVerbaUnitario = (VlrDiarioCustoMedioEfetivo - VlrMedioVerbaParaPrecoMercadoria) * ((vlrPerQuedaPonderada / 100) * -1);
        }
        var vlrVerbaEstimada = (VlrVerbaUnitario * QtdEstoqueMercadoria) * 1.111111111111111111111111;    //0.0111...% é a diferença devido ao calculo dos 10% dos impostos ser sobre o valor da verba.
        var VlrPrevistoCarimbo = vlrVerbaEstimada * 0.9;
        var VlrImpostos = vlrVerbaEstimada * 0.1;
        var perParticipacao = 0;

        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td > input[type="text"][data-col="PerParticipacao"]').val(FormataFloat((perParticipacao * 100), 2));
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrPrevistoCarimbo"]').html(FormataMoeda(VlrPrevistoCarimbo));
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrImpostos"]').html(FormataMoeda(VlrImpostos));
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrVerbaUnitario"]').html(FormataMoeda(VlrVerbaUnitario));
    }
    else {
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td > input[type="text"][data-col="PerParticipacao"]').val('');
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrPrevistoCarimbo"]').html('');
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrImpostos"]').html('');
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td[data-col="VlrVerbaUnitario"]').html('');
        $('tr[data-codfil="' + codFil + '"][data-codmer="' + codMer + '"] > td > input[type="text"][data-col="VlrPerQuedaPonderada"]').val('');
    }

    jsAtualizaTotaisGrid();
}

function jsAtualizaTotaisGrid(force) {
    if ($('#cbtIndCalculoAuto:checked').length === 0 && force === undefined )
        return null;

    // atualização dos totais - INICIO
    var linhasSelecionadas = jsLerGridCarimboCalculo();

    var totVlrPrevistoCarimboDistrib = 0;
    var totVlrEstoqueMercadoria = 0;
    var totPerParticipacaoDistrib = 0;
    var totVlrImpostosDistrib = 0;

    for (var i = 0; i < linhasSelecionadas.length; i++) {
        totVlrPrevistoCarimboDistrib += linhasSelecionadas[i].VlrPrevistoCarimbo;
        totVlrEstoqueMercadoria += linhasSelecionadas[i].VlrEstoqueMercadoria;
        totPerParticipacaoDistrib += linhasSelecionadas[i].PerParticipacao;
        totVlrImpostosDistrib += linhasSelecionadas[i].VlrImpostos;
    }

    $('#lblEditCarimboTotalVlrEstoqueMercadoria').html(FormataMoeda(totVlrEstoqueMercadoria));
    $('#lblEditCarimboTotalPerParticipacao').html(FormataFloat((totPerParticipacaoDistrib), 2));
    $('#lblEditCarimboTotalVerbaDistribuido').html(FormataMoeda(totVlrPrevistoCarimboDistrib));
    $('#lblEditCarimboTotalImpostosDistribuido').html(FormataMoeda(totVlrImpostosDistrib));
    // atualização dos totais - FIM
}

function resizeGridCarimboMercadoria() {
    //if (window.innerHeight > 600) {
    //    $('#gridCarimboMercadoria').height(window.innerHeight - 350);
    //}

    $('#gridCarimboMercadoria  table tbody').css('height', window.innerHeight - 320);
}

function enableScrollCarimboMercadoria() {
    $('#gridCarimboMercadoria  table').on('scroll', function () {
        $("#gridCarimboMercadoria table > *").width($("#gridCarimboMercadoria table").width() + $("#gridCarimboMercadoria table").scrollLeft());
    });
}


var colunaOrdenacaoCarimbo;
var direcaoOrdenacaoCarimbo;
function jsOrdenarCarimboItem(sender) {

    LoadingOn();
    window.setTimeout(function () {
        colunaOrdenacaoCarimbo = $(sender).attr('sort-expression');

        direcaoOrdenacaoCarimbo = 'desc';
        if ($(sender).parent().hasClass("sorting_desc"))
            direcaoOrdenacaoCarimbo = 'asc';
        else
            direcaoOrdenacaoCarimbo = 'desc';

        var list = jsLerGridCarimboPersistencia();
        var obj = {
            CodCarimbo: $('#hdfEditCarimboCodCarimbo').val(),
            DesObservacao: $('#txtEditCarimboDesObservacaoSolicitacaoVerba').val(),
            CodDestinoObjetivo: $('#hdfEditNegociacaoVerbaCodDestinoObjetivo').val(),
            CodNegociacaoVerba: $('#hdfEditCarimboCodNegociacaoVerba').val(),
            VlrCarimbo: $('#txtEditVlrCarimboMax').val().replace('R$', '').replace(/\./g, ""),
            VlrImpostos: $('#VlrImpostos').val().replace('R$', '').replace(/\./g, ""),
            Itens: list
        }
        data = {
            edit: obj,
            coluna: colunaOrdenacaoCarimbo,
            sentido: direcaoOrdenacaoCarimbo
        };
        PostAjax(data, '/Carimbo/OrdenarCarimboItem', jsOrdenarCarimboItemCallback);

        LoadingOff();
    }, 1);
}
function jsOrdenarCarimboItemCallback(data) {
    jsBindGridCarimbo(data);

    var colunasOrdenaveis = $('#gridCarimboMercadoria').find(('[sort-expression]'));

    for (var j = 0; j < colunasOrdenaveis.length; j++) {
        var addclass = 'sorting';
        if ($(colunasOrdenaveis[j]).attr('sort-expression') === colunaOrdenacaoCarimbo) {
            if (direcaoOrdenacaoCarimbo === 'asc')
                addclass = 'sorting_asc';
            else
                addclass = 'sorting_desc';
        }
        $(colunasOrdenaveis[j]).parent().addClass(addclass);
    }
}

function jsFiltrarCarimbo() {
    var codFornecedor = $('#hdfEditCarimboCodFornecedor').val();

    var codFiliais = $('#drpEditCarimboCodFilialFiltro').val();


    var codComprador = $('#hdfEditCarimboCodComprador').val();
    var codCarimbo = $('#hdfEditCarimboCodCarimbo').val();
    var vlrCarimbo = $('#txtEditVlrCarimboMax').val().replace('R$', '').replace(/\./g, "");
    var vlrImpostos = $('#VlrImpostos').val().replace('R$', '').replace(/\./g, "");
    var codStatusNegociacaoVenda = $('#hdfEditNegociacaoVerbaCodStatusNegociacaoVenda').val();
    var dataAprovacao = $('#hdfEditNegociacaoVerbaDtAprovacao').val();
    data = {
        pCodFornecedor: codFornecedor,
        pCodFiliais: codFiliais,
        pCodComprador: codComprador,
        pCodCarimbo: codCarimbo,
        pVlrCarimbo: vlrCarimbo,
        pVlrImpostos: vlrImpostos,
        pCodStatusNegociacaoVenda: codStatusNegociacaoVenda,
        pDataAprovacao: dataAprovacao
    };
    PostAjax(data, '/Carimbo/FiltrarGridCarimbo', jsFiltrarCarimboCallback);
}
function jsFiltrarCarimboCallback(data) {
    jsBindGridCarimbo(data);
}

function jsBindGridCarimbo(data) {
    $('#gridCarimbo').html(data);
    $('#formCarimbo').show();
    resizeGridCarimboMercadoria();
    enableScrollCarimboMercadoria();
    jsEnableDisableAllPerParticipacao();
}
