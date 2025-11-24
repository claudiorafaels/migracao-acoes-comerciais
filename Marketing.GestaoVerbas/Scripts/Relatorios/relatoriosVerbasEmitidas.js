$(document).ready(function () {
    jsChangeVisaoRelatorio();
});

function jsChangeVisaoRelatorio() {

    if ($('#btnVisaoNegociacao').prop("checked")) {
        $('.filtroCarimboMercadoria').prop("disabled", true);
        $('.filtroCarimboFornecedor').prop("disabled", true);
        $('.filtroEmpenho').prop("disabled", true);
        $('.filtroNegociacao').prop("disabled", false);
        $('#periodoCarimbo').hide();
        $('#periodoNegociacao').show();
    }
    else if ($('#btnVisaoEmpenho').prop("checked")) {
        $('.filtroCarimboMercadoria').prop("disabled", true);
        $('.filtroCarimboFornecedor').prop("disabled", true);
        $('.filtroNegociacao').prop("disabled", true);        
        $('.filtroEmpenho').prop("disabled", false);
        $('#periodoCarimbo').hide();
        $('#periodoNegociacao').show();
    }
    else if ($('#btnVisaoMercadoria').prop("checked")) {
        $('.filtroCarimboFornecedor').prop("disabled", true);
        $('.filtroNegociacao').prop("disabled", true);
        $('.filtroEmpenho').prop("disabled", true);
        $('.filtroCarimboMercadoria').prop("disabled", false);
        $('#periodoCarimbo').show();
        $('#periodoNegociacao').hide();
    }
    else if ($('#btnVisaoFornecedor').prop("checked")) {
        $('.filtroCarimboMercadoria').prop("disabled", true);
        $('.filtroNegociacao').prop("disabled", true);
        $('.filtroEmpenho').prop("disabled", true);
        $('.filtroCarimboFornecedor').prop("disabled", false);
        $('#periodoCarimbo').show();
        $('#periodoNegociacao').hide();
    }
}


function jsOpenModalMercadoriaRelatorio() {
    findMercadoria('txtFiltroNegociacaoVerbaCodMercadoria', 'txtFiltroNegociacaoVerbaNomMercadoria', 'appendFind');
}

function jsOpenModalNegociacaoRelatorio() {
    findNegociacao('txtFiltroNegociacaoVerbaCodNegociacaoVerba', 'txtFiltroNegociacaoVerbaDesNegociacaoVerba', 'appendFind');
}

function jsOpenModalFornecedorEdit() {
    findFornecedor('txtEditNegociacaoVerbaCodFornecedor', 'txtEditNegociacaoVerbaNomFornecedor', 'appendFind');
}

function jsExportarCSV() {
    gridSetings = {
        Filtro: {
            CodNegociacaoVerba: $('#txtFiltroNegociacaoVerbaCodNegociacaoVerba').val(),
            NomNegociacaoVerba: $('#txtFiltroNegociacaoVerbaDesNegociacaoVerba').val(),
            CodStatusNegociacao: $('#drpFiltroNegociacaoVerbaCodStatusNegociacao').val(),
            CodFilialEmpresa: $('#drpEditCarimboCodFilialFiltro').val(),
            CodComprador: $('#drpEditNegociacaoVerbaCodComprador').val(),
            CodFornecedor: $('#txtEditNegociacaoVerbaCodFornecedor').val(),
            CodCelula: $('#drpEditCarimboCodCelula').val(),
            CodDestino: $('#drpFiltroNegociacaoVerbaCodDestino').val(),
            CodObjetivo: $('#drpAddDestinoObjetivoCodObjetivo').val(),
            CodMercadoria: $('#txtFiltroNegociacaoVerbaCodMercadoria').val(),

            CodCarimbo: $('#txtFiltroNegociacaoVerbaCodCarimbo').val(),
            CodStatusCarimbo: $('#drpFiltroNegociacaoVerbaCodStatusCarimbo').val(),

            DtCadastroCarimboInicio: $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboInicio').val(),
            DtCadastroCarimboFim: $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboFim').val(),

            DtAprovacaoNegociacaoInicio: $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoInicio').val(),
            DtAprovacaoNegociacaoFim: $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoFim').val(),

            IndRelVisao:$('input[name="Filtro.IndRelVisao"]:checked').val()
        },
        Setings: {
            Column: $('#Setings_Column').val(),
            Way: $('#Setings_Way').val(),
            PageSize: $('#hdfRelatorioVerbasEmitidasTotalRows').val(),
            CurrentPage: 1,
            CurrentPageSize: 0,
            TotalRows: 0
        }
    };

    data = {
        gridSetings: gridSetings
    }
    PostAjax(data, '/RelVerbasEmitidas/ExportarRelatorioCSV', jsExportarCSVCallback);
}

function jsExportarCSVCallback(data) {
    window.location = location.origin + "/" + diretorioVirtual + '/RelVerbasEmitidas/Download?fileGuid=' + data.FileGuid + '&filename=' + data.FileName;
}

function PesquisarAjaxBegin() {
    if (jsValidarCamposObrigatorios()) {
        DefaultAjaxBegin();
        return true;
    }
    return false;
}



function jsValidarCamposObrigatorios() {

    $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoInicio').css("border", "1px solid #e4e4e4");
    $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoFim').css("border", "1px solid #e4e4e4");
    $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboInicio').css("border", "1px solid #e4e4e4");
    $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboFim').css("border", "1px solid #e4e4e4");

    var visao = $('.indVisao:checked').val();
    var DtCadastroCarimboInicio = $("#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboInicio").val();
    var DtCadastroCarimboFim = $("#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboFim").val();
    var DtAprovacaoNegociacaoInicio = $("#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoInicio").val();
    var DtAprovacaoNegociacaoFim = $("#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoFim").val();

    switch (visao) {
        case 'N':
        case 'E':
            if (DtAprovacaoNegociacaoInicio === '' || DtAprovacaoNegociacaoFim === '') {
                $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoInicio').css("border", "1px solid red");
                $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoFim').css("border", "1px solid red");

                jsAbreAlerta("Atenção", "Preencha todos os campos corretamente!", "info");
                return false;
            }
            break;
        case 'M':
        case 'F':
            if ((DtAprovacaoNegociacaoInicio === '' || DtAprovacaoNegociacaoFim === '') && (DtCadastroCarimboInicio === '' || DtCadastroCarimboFim === '')) {
                $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboInicio').css("border", "1px solid red");
                $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboFim').css("border", "1px solid red");
                $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoInicio').css("border", "1px solid red");
                $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoFim').css("border", "1px solid red");

                jsAbreAlerta("Atenção", "Informe pelo menos um conjunto de campos obrigatórios", "info");
                return false;
            }
        default:
    }
    return true;
}



function jsLimparFiltrosPesquisa() {
    $('.divFiltrosPesquisa input[type="number"], .divFiltrosPesquisa input[type="text"]').val('');
    $('.divFiltrosPesquisa select').val('');
    $('#drpFiltroNegociacaoVerbaCodStatusNegociacao').val('3');
    $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboInicio').val(FormataData(AddDays(new Date(), -7)));
    $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboFim').val(FormataData(new Date()));
    $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoInicio').val(FormataData(AddDays(new Date(), -7)));
    $('#txtRelatorioVerbasEmitidasSearchDtAprovacaoNegociacaoFim').val(FormataData(new Date()));
}



function ModePesquisar() {

    $('#visaoRelatorio').show();
    $('#formPesquisa').hide();

}

function ModeFiltro() {
    $('#visaoRelatorio').hide();
    $('#formPesquisa').show();
    jsChangeVisaoRelatorio();

    $('#Setings_CurrentPage').val('1');
    $('#Setings_Column').val('CodFornecedor');
    $('#Setings_Way').val('desc');
    $('#Setings_PageSize').val('10');
}



