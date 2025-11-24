

var fundFornecedorCodFornecedorTargetId;
var fundFornecedorNomFornecedorTargetId;
var fundFornecedorAppendModalId;

function findFornecedor(pCodFornecedorTargetId, pNomFornecedorTargetId, pAppendModalId) {

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
    PostAjax(data, '/Fornecedor/Pesquisar', findFornecedorResult);
}

function findFornecedorResult(data, b, c, e, f) {
    $('.modal-backdrop.show').remove();
    $('#' + fundFornecedorAppendModalId).html(data);
    $('#mdlPesquisaFornecedor').modal('show');

    DefaultAjaxSuccess(data, b, c, e, f);
}


function findFornecedorSelect(codigo, nome) {
    $('#' + fundFornecedorCodFornecedorTargetId).val(codigo);
    $('#' + fundFornecedorNomFornecedorTargetId).val(nome);


    $('#mdlPesquisaFornecedor').modal('hide');
}

function findFornecedorCodFornecedorChange(pCodFornecedorTargetId, pNomFornecedorTargetId) {

    fundFornecedorCodFornecedorTargetId = pCodFornecedorTargetId;
    fundFornecedorNomFornecedorTargetId = pNomFornecedorTargetId;

    $('#' + fundFornecedorNomFornecedorTargetId.id).val('');

    var codFornecedor = $('#' + fundFornecedorCodFornecedorTargetId.id).val();
    
    if (codFornecedor !== "")
        GetAjax("/Fornecedor/Select?codigo=" + codFornecedor, findFornecedorCodFornecedorChangeCallback);
}

function findFornecedorCodFornecedorChangeCallback(data) {
    $('#' + fundFornecedorNomFornecedorTargetId.id).val(data);
}