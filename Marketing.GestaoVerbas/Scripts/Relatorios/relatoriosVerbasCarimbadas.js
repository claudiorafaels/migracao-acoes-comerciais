$(document).ready(function () {
    jsChangeVisaoRelatorioCarimbosContabilizados();
});

var fundFornecedorCodFornecedorTargetId;
var fundFornecedorNomFornecedorTargetId;
var fundFornecedorAppendModalId;

function findMercadoria(pCodFornecedorTargetId, pNomFornecedorTargetId, pAppendModalId) {

    fundFornecedorCodFornecedorTargetId = pCodFornecedorTargetId;
    fundFornecedorNomFornecedorTargetId = pNomFornecedorTargetId;
    fundFornecedorAppendModalId = pAppendModalId;

    var codFornecedor = $('#' + fundFornecedorCodFornecedorTargetId).val();
    var nomFornecedor = $('#' + fundFornecedorNomFornecedorTargetId).val();
    data = {
        gridSetings: {
            Filtro: {
                CodFornecedor: codFornecedor,
                NomFornecedor: nomFornecedor
            },
            Setings: {
                Column: "NomFornecedor",
                Way: "asc",
                PageSize: 10,
                CurrentPage: 1
            }
        }
    };
    PostAjax(data, '/Fornecedor/Pesquisar', findMercadoriaResult);
}

function findMercadoriaResult(data, b, c, e, f) {
    $('.modal-backdrop.show').remove();
    $('#' + fundFornecedorAppendModalId).html(data);
    $('#mdlPesquisaFornecedor').modal('show');

    DefaultAjaxSuccess(data, b, c, e, f);
}



function jsChangeVisaoRelatorioCarimbosContabilizados() {
    var visao = $('[name="Filtro.IndAnaliticoSintetico"]:checked').val();

    if (visao == "Sintetico") {
        $('.Todos').show();
        $('.Mercadoria').hide();
    }
    else if (visao == "Analitico") {
        $('.Todos').show();
        $('.Mercadoria').show();
    }
}

function jsLimparFiltrosPesquisa() {
    $('.divFiltrosPesquisa input[type="number"], .divFiltrosPesquisa input[type="text"], .divFiltrosPesquisa input[type="datetime"]').val('');
    $('.divFiltrosPesquisa select').val('');
    $('#txtFiltroDtInicio').val(FormataData(AddDays(new Date(), -7)));
    $('#txtFiltroDtFim').val(FormataData(new Date()));

}

function PesquisarAjaxBegin() {
    if (jsValidarCamposObrigatorios()) {
        DefaultAjaxBegin();
        return true;
    }
    return false;
}


function jsValidarCamposObrigatorios() {
    return true;
}

function jsExportarCSV() {

    gridSetings = {
        Filtro: {  // adequar aos filtros da tela
            IndRelVisao: $('input[name="Filtro.IndRelVisao"]:checked').val(),
            IndAnaliticoSintetico: $('input[name="Filtro.IndAnaliticoSintetico"]:checked').val(),
            CodFornecedor: $('#txtFiltroCodFornecedor').val(),
            DtInicio: $('#txtFiltroDtInicio').val(),
            DtFim: $('#txtFiltroDtFim').val(),
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
    PostAjax(data, '/RelVerbasCarimbadas/ExportarRelatorioCSV', jsExportarCSVCallback);
}

function jsExportarCSVCallback(data) {
    window.location = location.origin + "/" + diretorioVirtual + '/RelVerbasCarimbadas/Download?fileGuid=' + data.FileGuid + '&filename=' + data.FileName;
}


//Modos
function ModePesquisar() {
    $('#visaoRelatorio').show();
    $('#formPesquisa').hide();
}

function ModeFiltro() {
    $('#visaoRelatorio').hide();
    $('#formPesquisa').show();
}
