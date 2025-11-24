
function jsOpenModalFilial() {

    $('.loadingFundoPreto').show();
    $('#modalFilialOrigem').show();
}

function jsCloseModalFilial() {
    $('.loadingFundoPreto').hide();
    $('#modalFilialOrigem').hide();
}

function jsDestinoSelecionado(selectObject) {
    if (selectObject.value == 2) {
        $('#objPT').show();
    }
    else {
        $('#objPT').hide();
    }
}

function jsObjetivoSelecionado(selectObject) {
    if (selectObject.value == 2) {
        $('#btnAcaoCarimbo').show();
    }
    else {
        $('#btnAcaoCarimbo').hide();
    }
}

function jsPreencheComprador(selectObject) {
    if (selectObject.value == 1) {
        document.getElementById("txtEditNomComprador").value = "Comprador (Automático)";
    }
}

function DeleteConfirmed(id) {
    data = { id: parseFloat(id) };
    PostAjax(data, '/Negociacao/RemoverObjetivoDestino', DeleteSuccess);
}

function DeleteSuccess(data) {
    $('#frmPesquisa').submit();
}

function jsPesquisar() {
    $('#form').submit();
}

function jsNovaNegociacao() {
    data = {};
    
    PostAjax(data, '/Negociacao/NovaNegociacao', ModeEdit);
}

function ModeEdit(data) {
    $('#formPesquisa').hide();
    $('#formEdit').show();
    $('#formEdit').html(data);

    EnableUnobtrusiveValidation($('#formEdit'));
}

function jsAddObjetivoDestino() {
    var dropDestino = document.getElementById("drpNomDestino");
    var dropObjetivo = document.getElementById("drpNomObjetivo");
    var list = jsLerGrid();
    var obj = {
        ObsDestino: document.getElementById("txtObsDestino").value,
        CodDestino: dropDestino[dropDestino.selectedIndex].value,
        NomDestino: dropDestino[dropDestino.selectedIndex].innerText,
        CodObjetivo: dropDestino[dropDestino.selectedIndex].value,
        NomObjetivo: dropObjetivo[dropObjetivo.selectedIndex].innerText,
        VlrDestino:  dropDestino[dropDestino.selectedIndex].value,
    };
    data = {
        list: list,
        obj: obj
    };
    PostAjax(data, '/Negociacao/AddObjetivoDestino', jsBindObjetivoDestino);
}

function jsLerGrid() {
    var tBody = document.getElementById("tbGridBody");
    var list = []
    if (tBody.childElementCount > 0)
        list = jsLerLinha(tBody);
    return list;
}

function jsLerLinha(sender) {
    var lines = sender.children;
    var list = [];
    for (var i = 0; i < sender.childElementCount; i++) {

        var row = lines[i];
        var cell = row.children;
        var NodeCodDestino = cell[1].childNodes;
        var NodeCodObjetivo = cell[1].childNodes;
        var obj = {
            ObsDestino: cell[4].innerText,
            NomDestino: cell[1].innerText,
            CodDestino: NodeCodDestino[1].value,
            NomObjetivo: cell[2].innerText,
            CodObjetivo: NodeCodObjetivo[1].value,
            VlrDestino: cell[3].innerText
        };
        list[i] = obj;
    }
    return list;
}

function jsBindObjetivoDestino(data) {
    $('#gridDestinoObjetivo').html(data);
}

function jsSalvarNegociacao() {
    $('#formEdit').submit();
}

function jsOpenModalComprador() {
    findFuncionario('txtEditNegociacaoVerbaCodComprador', 'txtEditNegociacaoVerbaNomComprador', 'appendFindFuncionario');
}