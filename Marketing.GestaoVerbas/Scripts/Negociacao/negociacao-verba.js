//Modais
function jsOpenModalFilial() {

    findFuncionario('txtEditNegociacaoVerbaCodFilialOrigem', 'txtEditNegociacaoVerbaNomFilialOrigem', 'appendFindFuncionario');
}

function jsOpenModalDivisaoFornecedor() {

    findFuncionario('txtEditNegociacaoVerbaCodDivisaoFornecedor', 'txtEditNegociacaoVerbaNomDivisaoFornecedor', 'appendFindFuncionario');
}

function jsOpenModalComprador() {
    findFuncionario('txtEditNegociacaoVerbaCodComprador', 'txtEditNegociacaoVerbaNomComprador', 'appendFindFuncionario');
}


function jsEditarNegociacao(sender) {
    data = {
        pCodNegociacao: sender
    };
    PostAjax(data, '/Negociacao/EditarNegociacao', ModeEdit);
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

//Modos
function ModeEdit(data) {
    $('#formPesquisa').hide();
    $('#formEdit').show();
    $('#btnAprove').hide();
    $('#btnReprove').hide();
    $('#btnSend').show();
    $('#btnSave').show();
    $('#formEdit').html(data);
    $('#formCarimbo').hide();

    EnableUnobtrusiveValidation($('#formEdit'));
}

function ModeCarimbo(data) {
    $('#formPesquisa').hide();
    $('#formEdit').hide();
    $('#formCarimbo').show();
    $('#formCarimbo').html(data);

    EnableUnobtrusiveValidation($('#formCarimbo'));
}

//Destino/Objetivo
function jsAddObjetivoDestino() {
    var dropDestino = document.getElementById("drpNomDestino");
    var dropObjetivo = document.getElementById("drpNomObjetivo");
    var list = jsLerGrid();
    var obj = {
        ObsDestino: document.getElementById("txtObsDestino").value,
        CodDestino: dropDestino[dropDestino.selectedIndex].value,
        NomDestino: dropDestino[dropDestino.selectedIndex].innerText,
        CodObjetivo: dropObjetivo[dropObjetivo.selectedIndex].value,
        NomObjetivo: dropObjetivo[dropObjetivo.selectedIndex].innerText,
        VlrDestino: $('#txtVlrDestino').val()
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
        var NodeCodObjetivo = cell[2].childNodes;
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
    $('#formEdit').show();
}

function jsDropChange(sender) {
    var dropObjetivo1 = document.getElementById("drpNomObjetivo");
    if (sender.selectedIndex == 1) {
        var option = document.createElement("option");
        option.text = "Plano de Trade";
        option.value = "3";
        dropObjetivo1.add(option);
    }
    else
        $("#drpNomObjetivo option[value='3']").remove();
}

function DeleteConfirmed(codigo) {
    data = {
        list: jsLerGrid(),
        codigo: parseFloat(codigo)
    };
    PostAjax(data, '/Negociacao/RemoverObjetivoDestino', jsBindObjetivoDestino);
}

//Salvar
function jsSalvarNegociacao() {
    var arrCampos = [$('#txtEditNegociacaoVerbaNomNegociacao').val(),
    $('#txtEditNegociacaoVerbaVlrTotalVerba').val(),
    $('#txtEditNegociacaoVerbaDtCadastro').val(),
    $('#txtEditNegociacaoVerbaCodFilialOrigem').val(),
    $('#txtEditNegociacaoVerbaNomFilialOrigem').val(),
    $('#txtEditNegociacaoVerbaCodDivisaoFornecedor').val(),
    $('#txtEditNegociacaoVerbaNomDivisaoFornecedor').val(),
    $('#txtEditNegociacaoVerbaCodComprador').val(),
    $('#txtEditNegociacaoVerbaNomComprador').val(),
    ]
    if (jsValidar(arrCampos)) {
        //var objNegociacao = jsLerCamposNegociacao();
        var listaDestinoObjetivo = jsLerGrid();
        var objCampos = {
            NomNegociacao: $('#txtEditNegociacaoVerbaNomNegociacao').val(),
            VlrTotalVerba: $('#txtEditNegociacaoVerbaVlrTotalVerba').val(),
            DtCadastro: $('#txtEditNegociacaoVerbaDtCadastro').val(),
            CodFilialOrigem: $('#txtEditNegociacaoVerbaCodFilialOrigem').val(),
            NomFilialOrigem: $('#txtEditNegociacaoVerbaNomFilialOrigem').val(),
            CodDivisaoFornecedor: $('#txtEditNegociacaoVerbaCodDivisaoFornecedor').val(),
            NomDivisaoFornecedor: $('#txtEditNegociacaoVerbaNomDivisaoFornecedor').val(),
            CodComprador: $('#txtEditNegociacaoVerbaCodComprador').val(),
            NomComprador: $('#txtEditNegociacaoVerbaNomComprador').val(),
            CodNegociacao: 1,
            ObsNegociacao: $('#txtEditNegociacaoVerbaDesObservacao').val()
        }
        data = {
            list: listaDestinoObjetivo,
            obj: objCampos
        }
        PostAjax(data, '/Negociacao/SalvarNegociacao', jsBindNegociacao);
    }
    else
        return false;
}

function jsEnviarAprovacao() {
    data = {};
    PostAjax(data,'/Negociacao/EnviarParaAprovacao', jsBindNegociacao);
}

//Validação
function jsValidar(sender) {
    var countError = 0;
    var fieldsCollection = [
        "txtEditNegociacaoVerbaNomNegociacao",
        "txtEditNegociacaoVerbaVlrTotalVerba",
        "txtEditNegociacaoVerbaDtCadastro",
        "txtEditNegociacaoVerbaCodFilialOrigem",
        "txtEditNegociacaoVerbaNomFilialOrigem",
        "txtEditNegociacaoVerbaCodDivisaoFornecedor",
        "txtEditNegociacaoVerbaNomDivisaoFornecedor",
        "txtEditNegociacaoVerbaCodComprador",
        "txtEditNegociacaoVerbaNomComprador"
    ]
    var i = 0;
    for (i; i < 9; i++) {
        if (jsValidaCampo(sender[i], fieldsCollection[i]) == 1) {
            countError++;
            document.getElementById(fieldsCollection[i]).style.borderColor = "red";

        }
        else
            document.getElementById(fieldsCollection[i]).style.borderColor = "#e4e4e4";
    }

    if (countError == 0)
        return true;
    else {
        alert("Preencha todos os campos corretamente!");
        return false;
    }
}

function jsValidaCampo(sender, field) {
    if (sender == "") {
        return 1;
    }
    else if (field == "txtEditNegociacaoVerbaCodFilialOrigem" || field == "txtEditNegociacaoVerbaCodDivisaoFornecedor" || field == "txtEditNegociacaoVerbaCodComprador") {
        if (!isNaN(sender)) {
            
        }
    }
    else if (field == "txtEditNegociacaoVerbaVlrTotalVerba")
    {
        if (isNaN(parseFloat(sender.replace(',', '.'))))
            return 1;
    }
    else if (field == "txtEditNegociacaoVerbaDtCadastro") {
        jsValidaData(sender);
    }
    else
        return 0;
}

function jsValidaData(sender) {
    var RegExPattern = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])      [\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/;

    if (!((sender.match(RegExPattern)) && (sender != ''))) {
        return 1;
    }
    else
        return 0;
}

function jsBindNegociacao(data) {
    $('#formEdit').html(data);
}

function jsCarimbo( codigo ) {
    var objNegociacao = {
        NomNegociacao: $('#txtEditNegociacaoVerbaNomNegociacao').val(),
        VlrTotalVerba: $('#txtEditNegociacaoVerbaVlrTotalVerba').val(),
        DtCadastro: $('#txtEditNegociacaoVerbaDtCadastro').val(),
        CodFilialOrigem: $('#txtEditNegociacaoVerbaCodFilialOrigem').val(),
        NomFilialOrigem: $('#txtEditNegociacaoVerbaNomFilialOrigem').val(),
        CodDivisaoFornecedor: $('#txtEditNegociacaoVerbaCodDivisaoFornecedor').val(),
        NomDivisaoFornecedor: $('#txtEditNegociacaoVerbaNomDivisaoFornecedor').val(),
        CodComprador: $('#txtEditNegociacaoVerbaCodComprador').val(),
        NomComprador: $('#txtEditNegociacaoVerbaNomComprador').val(),
        CodNegociacao: 1,
        ObsNegociacao: $('#txtEditNegociacaoVerbaDesObservacao').val()
    };
    
    data = {
        pObjNegociacao: objNegociacao,
        pCodDestino: codigo
    };
    PostAjax(data, '/Negociacao/Carimbo', ModeCarimbo);
}