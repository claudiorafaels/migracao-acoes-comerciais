$(document).ready(function () {
    jsChangeVisaoRelatorioCarimbosContabilizados();
});

function jsChangeVisaoRelatorioCarimbosContabilizados() {
    //AReceber, Recebidos, Valores, Acordos, Todos
    var visao = $('[name="Filtro.IndRelVisao"]:checked').val();

    if (visao == "Receber") {
        $('.AReceber').show();
        $('.Valores').show();
        $('.Todos').show();
        $('.Acordos').hide();
        $('.Recebidos').hide();
    }
    else if (visao == "Recebidos") {
        $('.AReceber').hide();
        $('.Valores').show();
        $('.Todos').show();
        $('.Acordos').hide();
        $('.Recebidos').show();
    }
    else if (visao == "Novos") {
        $('.AReceber').hide();
        $('.Valores').hide();
        $('.Todos').show();
        $('.Acordos').show();
        $('.Recebidos').hide();
    }
    else if (visao == "Cancelados") {
        $('.AReceber').hide();
        $('.Valores').hide();
        $('.Todos').show();
        $('.Acordos').show();
        $('.Recebidos').hide();
    }
}

function jsLimparFiltrosPesquisa() {
    $('.divFiltrosPesquisa input[type="number"], .divFiltrosPesquisa input[type="text"], .divFiltrosPesquisa input[type="datetime"]').val('');
    $('.divFiltrosPesquisa select').val('');

    $('#txtFiltroDtInicioRecebidos').val(FormataData(AddDays(new Date(), -7)));
    $('#txtFiltroDtFimRecebidos').val(FormataData(new Date()));

    $('#txtFiltroDtInicioAcordo').val(FormataData(AddDays(new Date(), -7)));
    $('#txtFiltroDtFimAcordo').val(FormataData(new Date()));

}


function PesquisarAjaxBegin() {
    if (jsValidarCamposObrigatorios()) {
        DefaultAjaxBegin();
        return true;
    }
    return false;
}

function jsValidarCamposObrigatorios() {

    //$('#txtRelatorioVerbasEmitidasSearchDtCadastroNegociacaoInicio').css("border", "1px solid #e4e4e4");
    //$('#txtRelatorioVerbasEmitidasSearchDtCadastroNegociacaoFim').css("border", "1px solid #e4e4e4");
    //$('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboInicio').css("border", "1px solid #e4e4e4");
    //$('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboFim').css("border", "1px solid #e4e4e4");
    //
    //var visao = $('.indVisao:checked').val();
    //var DtCadastroCarimboInicio = $("#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboInicio").val();
    //var DtCadastroCarimboFim = $("#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboFim").val();
    //var DtCadastroNegociacaoInicio = $("#txtRelatorioVerbasEmitidasSearchDtCadastroNegociacaoInicio").val();
    //var DtCadastroNegociacaoFim = $("#txtRelatorioVerbasEmitidasSearchDtCadastroNegociacaoFim").val();
    //
    //switch (visao) {
    //    case 'N':
    //    case 'E':
    //        if (DtCadastroNegociacaoInicio === '' || DtCadastroNegociacaoFim === '') {
    //            $('#txtRelatorioVerbasEmitidasSearchDtCadastroNegociacaoInicio').css("border", "1px solid red");
    //            $('#txtRelatorioVerbasEmitidasSearchDtCadastroNegociacaoFim').css("border", "1px solid red");
    //
    //            jsAbreAlerta("Atenção", "Preencha todos os campos corretamente!", "info");
    //            return false;
    //        }
    //        break;
    //    case 'M':
    //    case 'F':
    //        if ((DtCadastroNegociacaoInicio === '' || DtCadastroNegociacaoFim === '') && (DtCadastroCarimboInicio === '' || DtCadastroCarimboFim === '')) {
    //            $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboInicio').css("border", "1px solid red");
    //            $('#txtRelatorioVerbasEmitidasSearchDtCadastroCarimboFim').css("border", "1px solid red");
    //            $('#txtRelatorioVerbasEmitidasSearchDtCadastroNegociacaoInicio').css("border", "1px solid red");
    //            $('#txtRelatorioVerbasEmitidasSearchDtCadastroNegociacaoFim').css("border", "1px solid red");
    //
    //            jsAbreAlerta("Atenção", "Informe pelo menos um conjunto de campos obrigatórios", "info");
    //            return false;
    //        }
    //    default:
    //}
    return true;
}


function ModePesquisar() {
    $('#visaoRelatorio').show();
    $('#formPesquisa').hide();
}

function ModeFiltro() {
    $('#visaoRelatorio').hide();
    $('#formPesquisa').show();
}

function jsExportarCSV() {

    gridSetings = {
        Filtro: {
            CodTipoVerbaFornecedor: $('input[name="Filtro.CodTipoVerbaFornecedor"]:checked').val(),
            IndRelVisao: $('input[name="Filtro.IndRelVisao"]:checked').val(),
            IndAnaliticoSintetico: $('input[name="Filtro.IndAnaliticoSintetico"]:checked').val(),
            CodFornecedor: $('#txtFiltroCodFornecedor').val(),
            DtPrevisaoRecebimento: $('#txtFiltroDtPrevisaoRecebimento').val(),
            CodObjetivo: $('#drpFiltroCodTipoObjetivo').val(),
            DtInicioRecebidos: $('#txtFiltroDtInicioRecebidos').val(),
            DtFimRecebidos: $('#txtFiltroDtFimRecebidos').val(),
            CodTipoLancamento: $('#drpFiltroCodTipoLancamento').val(),
            DtInicioAcordo: $('#txtFiltroDtInicioAcordo').val(),
            DtFimAcordo: $('#txtFiltroDtFimAcordo').val(),
            IdtAnoMesReferencia: $('#drpFiltroIdtAnomMesReferencia').val()
        },
        Setings: {
            Column: $('#Setings_Column').val(),
            Way: $('#Setings_Way').val(),
            PageSize: $('#hdfRelatorioTotalRows').val(),
            CurrentPage: 1,
            CurrentPageSize: 0,
            TotalRows: 0
        }
    };

    data = {
        gridSetings: gridSetings
    }
    PostAjax(data, '/RelCarimbosContabilizados/ExportarRelatorioCSV', jsExportarCSVCallback);
}

function jsExportarCSVCallback(data) {
    window.location = location.origin + "/" + diretorioVirtual + '/RelCarimbosContabilizados/Download?fileGuid=' + data.FileGuid + '&filename=' + data.FileName;
}




function VoltarFiltros() {
    
    $('#Setings_CurrentPage').val('1');
    $('#Setings_Column').val('CodFornecedor');
    $('#Setings_Way').val('desc');
    $('#Setings_PageSize').val('10');

    ModeFiltro();
}
