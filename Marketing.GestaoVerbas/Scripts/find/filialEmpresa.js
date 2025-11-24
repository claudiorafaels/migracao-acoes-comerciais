

var fundFilialEmpresaCodFilialEmpresaTargetId;
var fundFilialEmpresaNomFilialEmpresaTargetId;
var fundFilialEmpresaAppendModalId;

function findFilialEmpresa(pCodFilialEmpresaTargetId, pNomFilialEmpresaTargetId, pAppendModalId) {

    fundFilialEmpresaCodFilialEmpresaTargetId = pCodFilialEmpresaTargetId;
    fundFilialEmpresaNomFilialEmpresaTargetId = pNomFilialEmpresaTargetId;
    fundFilialEmpresaAppendModalId = pAppendModalId;


    var codFilialEmpresa = $('#' + fundFilialEmpresaCodFilialEmpresaTargetId).val();
    var nomFilialEmpresa = $('#' + fundFilialEmpresaNomFilialEmpresaTargetId).val();
    data = {
        gridSetings: {
            Filtro: {
                CodFilialEmpresa: codFilialEmpresa,
                NomFilialEmpresa: nomFilialEmpresa
            },
            Setings: {
                Column: "NomFilialEmpresa",
                Way: "asc",
                PageSize: 10,
                CurrentPage: 1
            }
        }
    };
    PostAjax(data, '/FilialEmpresa/Pesquisar', findFilialEmpresaResult);
}

function findFilialEmpresaResult(data, b, c, e, f) {
    $('.modal-backdrop.show').remove();
    $('#' + fundFilialEmpresaAppendModalId).html(data);
    $('#mdlPesquisaFilialEmpresa').modal('show');

    DefaultAjaxSuccess(data, b, c, e, f);
}


function findFilialEmpresaSelect(codigo, nome) {
    $('#' + fundFilialEmpresaCodFilialEmpresaTargetId).val(codigo);
    $('#' + fundFilialEmpresaNomFilialEmpresaTargetId).val(nome);


    $('#mdlPesquisaFilialEmpresa').modal('hide');
}