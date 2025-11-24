

var fundMercadoriaCodMercadoriaTargetId;
var fundMercadoriaNomMercadoriaTargetId;
var fundMercadoriaAppendModalId;

function findMercadoria(pCodMercadoriaTargetId, pNomMercadoriaTargetId, pAppendModalId) {

    fundMercadoriaCodMercadoriaTargetId = pCodMercadoriaTargetId;
    fundMercadoriaNomMercadoriaTargetId = pNomMercadoriaTargetId;
    fundMercadoriaAppendModalId = pAppendModalId;


    var codMercadoria = $('#' + fundMercadoriaCodMercadoriaTargetId).val();
    var nomMercadoria = $('#' + fundMercadoriaNomMercadoriaTargetId).val();
    data = {
        gridSetings: {
            Filtro: {
                CodMercadoria: codMercadoria,
                NomMercadoria: nomMercadoria
            },
            Setings: {
                Column: "NomMercadoria",
                Way: "asc",
                PageSize: 10,
                CurrentPage: 1
            }
        }
    };
    PostAjax(data, '/Mercadoria/Pesquisar', findMercadoriaResult);
}

function findMercadoriaResult(data, b, c, e, f) {
    $('.modal-backdrop.show').remove();
    $('#' + fundMercadoriaAppendModalId).html(data);
    $('#mdlPesquisaMercadoria').modal('show');

    DefaultAjaxSuccess(data, b, c, e, f);
}


function findMercadoriaSelect(codigo, nome) {
    $('#' + fundMercadoriaCodMercadoriaTargetId).val(codigo);
    $('#' + fundMercadoriaNomMercadoriaTargetId).val(nome);


    $('#mdlPesquisaMercadoria').modal('hide');
}

function findMercadoriaCodMercadoriaChange(pCodMercadoriaTargetId, pNomMercadoriaTargetId) {

    fundMercadoriaCodMercadoriaTargetId = pCodMercadoriaTargetId;
    fundMercadoriaNomMercadoriaTargetId = pNomMercadoriaTargetId;

    $('#' + fundMercadoriaNomMercadoriaTargetId.id).val('');

    var codigo = $('#' + fundMercadoriaCodMercadoriaTargetId.id).val();

    if (codigo !== "")
        GetAjax("/Mercadoria/Select?codigo=" + codigo, findMercadoriaCodMercadoriaChangeCallback);
}

function findMercadoriaCodMercadoriaChangeCallback(data) {
    $('#' + fundMercadoriaNomMercadoriaTargetId.id).val(data);
}