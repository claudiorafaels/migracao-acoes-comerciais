

var fundNegociacaoCodNegociacaoTargetId;
var fundNegociacaoNomNegociacaoTargetId;
var fundNegociacaoAppendModalId;

function findNegociacao(pCodNegociacaoTargetId, pNomNegociacaoTargetId, pAppendModalId) {

    fundNegociacaoCodNegociacaoTargetId = pCodNegociacaoTargetId;
    fundNegociacaoNomNegociacaoTargetId = pNomNegociacaoTargetId;
    fundNegociacaoAppendModalId = pAppendModalId;


    var codNegociacao = $('#' + fundNegociacaoCodNegociacaoTargetId).val();
    var nomNegociacao = $('#' + fundNegociacaoNomNegociacaoTargetId).val();
    data = {
        gridSetings: {
            Filtro: {
                CodNegociacaoVerba: codNegociacao,
                DesNegociacaoVerba: nomNegociacao
            },
            Setings: {
                Column: "DesNegociacaoVerba",
                Way: "asc",
                PageSize: 10,
                CurrentPage: 1
            }
        }
    };
    PostAjax(data, '/Negociacao/FindNegociacao', findNegociacaoResult);
}

function findNegociacaoResult(data, b, c, e, f) {
    $('.modal-backdrop.show').remove();
    $('#' + fundNegociacaoAppendModalId).html(data);
    $('#mdlPesquisaNegociacao').modal('show');

    DefaultAjaxSuccess(data, b, c, e, f);
}


function findNegociacaoSelect(codigo, nome) {
    $('#' + fundNegociacaoCodNegociacaoTargetId).val(codigo);
    $('#' + fundNegociacaoNomNegociacaoTargetId).val(nome);


    $('#mdlPesquisaNegociacao').modal('hide');
}