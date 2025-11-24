

var fundGrupoADCodGrupoAcessoTargetId;
var fundGrupoADDesGrupoAcessoTargetId;
var fundGrupoADAppendModalId;

function findGrupoAD(pCodGrupoAcessoTargetId, pDesGrupoAcessoTargetId, pAppendModalId) {

    fundGrupoADCodGrupoAcessoTargetId = pCodGrupoAcessoTargetId;
    fundGrupoADDesGrupoAcessoTargetId = pDesGrupoAcessoTargetId;
    fundGrupoADAppendModalId = pAppendModalId;


    var codGrupo = $('#' + fundGrupoADCodGrupoAcessoTargetId).val();
    var desGrupo = $('#' + fundGrupoADDesGrupoAcessoTargetId).val();
    data = {
        gridSetings: {
            Filtro: {
                CodGrupoAcesso: codGrupo,
                DesGrupoAcesso: desGrupo
            },
            Setings: {
                Column: "DesGrupoAcesso",
                Way: "asc",
                PageSize: 10,
                CurrentPage: 1
            }
        }
    };

    PostAjax(data, '/GrupoAD/FindGrupoAD', findGrupoADResult);
}

function findGrupoADResult(data, b, c, e, f) {
    $('.modal-backdrop.show').remove();
    $('#' + fundGrupoADAppendModalId).html(data);
    $('#mdlPesquisaGrupoAD').modal('show');

    DefaultAjaxSuccess(data, b, c, e, f);
}


function findGrupoADSelect(codigo, nome) {
    $('#' + fundGrupoADCodGrupoAcessoTargetId).val(codigo);
    $('#' + fundGrupoADDesGrupoAcessoTargetId).val(nome);

    $('#mdlPesquisaGrupoAD').modal('hide');
}