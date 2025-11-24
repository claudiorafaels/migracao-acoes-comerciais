

var fundFuncionarioCodFuncionarioTargetId;
var fundFuncionarioNomFuncionarioTargetId;
var fundFuncionarioAppendModalId;

function findFuncionario(pCodFuncionarioTargetId, pNomFuncionarioTargetId, pAppendModalId) {

    fundFuncionarioCodFuncionarioTargetId = pCodFuncionarioTargetId;
    fundFuncionarioNomFuncionarioTargetId = pNomFuncionarioTargetId;
    fundFuncionarioAppendModalId = pAppendModalId;


    var codFuncionario = $('#' + fundFuncionarioCodFuncionarioTargetId).val();
    var nomFuncionario = $('#' + fundFuncionarioNomFuncionarioTargetId).val();
    data = {
        gridSetings: {
            Filtro: {
                CodFuncionario: codFuncionario,
                NomFuncionario: nomFuncionario
            },
            Setings: {
                Column: "NomFuncionario",
                Way: "asc",
                PageSize: 10,
                CurrentPage: 1
            }
        }
    };
    PostAjax(data, '/Funcionario/Pesquisar', findFuncionarioResult);
}

function findFuncionarioResult(data, b, c, e, f) {
    $('.modal-backdrop.show').remove();
    $('#' + fundFuncionarioAppendModalId).html(data);
    $('#mdlPesquisaFuncionario').modal('show');

    DefaultAjaxSuccess(data, b, c, e, f);
}


function findFuncionarioSelect(codigo, nome) {
    $('#' + fundFuncionarioCodFuncionarioTargetId).val(codigo);
    $('#' + fundFuncionarioNomFuncionarioTargetId).val(nome);


    $('#mdlPesquisaFuncionario').modal('hide');
}

findFuncionarioCodFuncionarioChange



function findFuncionarioCodFuncionarioChange(pCodFuncionarioTargetId, pNomFuncionarioTargetId) {

    fundFuncionarioCodFuncionarioTargetId = pCodFuncionarioTargetId;
    fundFuncionarioNomFuncionarioTargetId = pNomFuncionarioTargetId;

    $('#' + fundFuncionarioNomFuncionarioTargetId).val('');

    var codigo = $('#' + fundFuncionarioCodFuncionarioTargetId).val();

    if (codigo !== "")
        GetAjax("/Funcionario/Select?codigo=" + codigo, findFuncionarioCodFuncionarioChangeCallback);
}

function findFuncionarioCodFuncionarioChangeCallback(data) {
    $('#' + fundFuncionarioNomFuncionarioTargetId).val(data);
}