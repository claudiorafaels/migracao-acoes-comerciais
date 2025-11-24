
//Modais



function jsOpenModalFornecedorPendencia() {

    findFornecedor('txtFiltroPendenciaVerbaCodFornecedor', 'txtFiltroPendenciaVerbaNomFornecedor', 'appendFind');
}

function jsOpenModalFornecedorEditar() {
    findFornecedor('txtEditNegociacaoVerbaCodFornecedor', 'txtEditNegociacaoVerbaNomFornecedor', 'appendFind');
}

function jsOpenModalAutorPendencia() {
    findFuncionario('txtFiltroPendenciaVerbaCodAutor', 'txtFiltroPendenciaVerbaNomAutor', 'appendFind');
}

function jsOpenModalFilialEmpresaFiltro() {

    findFilialEmpresa('txtFiltroNegociacaoVerbaCodFilialVerba', 'txtFiltroNegociacaoVerbaNomFilialVerba', 'appendFind');
}

function jsOpenModalCompradorFiltro() {

    findFuncionario('txtFiltroNegociacaoVerbaCodComprador', 'txtFiltroNegociacaoVerbaNomComprador', 'appendFind');
}

function jsOpenModalAutorFiltro() {
    findFuncionario('txtFiltroNegociacaoVerbaCodAutor', 'txtFiltroNegociacaoVerbaNomAutor', 'appendFind');
}



function jsEditarNegociacao(codigo) {
    data = {
        pCodNegociacaoVerba: codigo
    };
    PostAjax(data, '/Negociacao/EditarNegociacao', ModeEdit);
}

function jsEditarPendencia(codigo) {
    data = {
        pCodNegociacaoVerba: codigo
    };
    PostAjax(data, '/Negociacao/EditarNegociacao', ModeEdit);
}

function jsPesquisar() {
    $('#form').submit();
}

function jsNovaNegociacao() {
    data = {};

    PostAjax(data, '/Negociacao/NovaNegociacao', ModeEdit);
}



function jsEnviarParaAprovacao() {
    data = {
        pCodNegociacaoVerba: $('#hdfEditNegociacaoVerbaCodNegociacaoVerba').val().replace(/\./g, "")
    };
    PostAjax(data, '/Negociacao/EnviarParaAprovacao', jsEnviarParaAprovacaoCallback);
}
function jsEnviarParaAprovacaoCallback(data) {
    //if (data == true) {
    jsEditarNegociacao($('#hdfEditNegociacaoVerbaCodNegociacaoVerba').val().replace(/\./g, ""));
    //}
    //TODO: precisa ver o que fazer em caso de erro ao enviar para aprovação
}


function jsGACReprovarNegociacao(cod) {

    data = {
        pCodNegociacaoVerba: $('#hdfEditNegociacaoVerbaCodNegociacaoVerba').val().replace(/\./g, ""),
        pDesJustificativaReprovacao: $('#txtDesJustificativaReprovacao').val().replace(/\./g, "")
    };
    PostAjax(data, '/Negociacao/Reprovar', jsGACReprovarNegociacaoCallback);
}
function jsGACReprovarNegociacaoCallback() {
    $('#formEdit').hide();
    jsCloseModalJustificativaReprovacao();
    if ($('#formPesquisaPendencias').length === 1) {
        $('#formPesquisaPendencias').show();
        $('#formPesquisaPendencias').submit();
    } else if ($('#formPesquisa').length === 1) {
        $('#formPesquisa').show();
        $('#formPesquisa').submit();
    }
}


//Modos
function ModeSearch(data) {
    $('#formPesquisaPendencias').show();
    $('#formPesquisa').show();
    $('#formEdit').hide();
    $('#formCarimbo').hide();

    DisableUnobtrusiveValidation($('#formPesquisa'));
}

function ModeEdit(data) {
    $('#formEdit').html(data);

    $('#formPesquisaPendencias').hide();
    $('#formPesquisa').hide();
    $('#formEdit').show();
    $('#formCarimbo').hide();

    jsControleBotoesNegociacaoVerbaDestino();

    EnableUnobtrusiveValidation($('#formEdit'));
}

//function jsExportar() {

//    gridSetings = {
//        Filtro: {
//            CodNegociacaoVerba: $('#txtFiltroCodNegociacaoVerba').val(),
//		    DesNegociacaoVerba: $('#txtFiltroDesNegociacaoVerba').val(),
//		    CodStatusNegociacaoVenda: $('#txtFiltroCodStatusNegociacaoVenda').val(),
//		    CodFornecedor: $('#txtFiltroCodFornecedor').val(),
//            NomFornecedor: $('#txtFiltroNomFornecedor').val(),
//            NomFilialVerba: $('#txtFiltroNomFilialVerba').val(),
//            NomAutor: $('#txtFiltroNomAutor').val(),
//            NomComprador: $('#txtFiltroNomComprador').val(),
//            VlrVerba: $('#txtFiltroVlrVerba').val(),
//		    DtCadastroNegociacao: $('#txtFiltroDtCadastroNegociacao').val(),
//            DtAprovacao: $('#txtFiltroDtAprovacao').val(),
//        },
//        Setings: {
//            Column: $('#Setings_Column').val(),
//            Way: $('#Setings_Way').val(),
//            PageSize: $('#hdfRelatorioTotalRows').val(),
//            CurrentPage: 1,
//            CurrentPageSize: 0,
//            TotalRows: 0
//        }
//    };

//    data = {
//        gridSetings: gridSetings
//    }
//    PostAjax(data, '/Negociacao/ExportarRelatorioCSV', jsExportarCallback);
//}

//function jsExportarCallback(data) {
//    window.location = location.origin + "/" + diretorioVirtual + '/Negociacao/Download?fileGuid=' + data.FileGuid + '&filename=' + data.FileName;
//}

function ModeCarimbo(data) {
    $('#formCarimbo').html(data);

    $('#formPesquisa').hide();
    $('#formEdit').hide();
    $('#formCarimbo').show();

    EnableUnobtrusiveValidation($('#formCarimbo'));
}

//Destino/Objetivo
function jsAddObjetivoDestino() {
    if (jsValidarAddDestinoObjeto()) {

        var codDestino = $('#drpAddDestinoObjetivoCodDestino').val();
        var codObjetivo = $('#drpAddDestinoObjetivoCodObjetivo').val();

        var list = jsLerGrid();
        var obj = {
            CodDestinoObjetivo: $('#drpAddDestinoObjetivoCodObjetivo option[value=' + codObjetivo + ']').attr('data-cod-destino-objetivo'),
            NomDestinoObjetivo: $('#drpAddDestinoObjetivoCodObjetivo option[value=' + codObjetivo + ']').attr('data-nom-destino-objetivo'),
            CodDestino: codDestino,
            NomDestino: $('#drpAddDestinoObjetivoCodDestino option[value=' + codDestino + ']').html(),
            CodObjetivo: codObjetivo,
            NomObjetivo: $('#drpAddDestinoObjetivoCodObjetivo option[value=' + codObjetivo + ']').html(),
            VlrVerba: $('#txtAddDestinoObjetivoVlrVerba').val().replace(/\./g, ""),
            DesObservacao: $('#txtAddDestinoObjetivoDesObservacao').val()
        };
        data = {
            list: list,
            obj: obj
        };

        PostAjax(data, '/Negociacao/AddObjetivoDestino', jsBindObjetivoDestinoCallback);
    }
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
        var obj = {
            CodDestinoObjetivo: cell[1].childNodes[1].value,
            NomDestinoObjetivo: cell[1].innerText,
            NomDestino: cell[2].innerText,
            CodDestino: cell[2].childNodes[1].value,
            NomObjetivo: cell[3].innerText,
            CodObjetivo: cell[3].childNodes[1].value,
            VlrVerba: cell[4].innerText.replace("R$", "").replace(/\./g, ""),
            DesObservacao: cell[5].innerText
        };
        list[i] = obj;
    }
    return list;
}

function jsBindObjetivoDestinoCallback(data) {
    $('#gridDestinoObjetivo').html(data);

    jsCalculaTotalNegociacaoVerba();
    jsControleBotoesNegociacaoVerbaDestino();
}

function jsRemoverNegociacaoVerbaDestino(id) {
    var list = jsLerGrid();
    data = {
        list: list,
        codigo: id
    };
    PostAjax(data, '/Negociacao/RemoverObjetivoDestino', jsRemoverNegociacaoVerbaDestinoCallback);
}

function jsRemoverNegociacaoVerbaDestinoCallback(data) {
    $('#gridDestinoObjetivo').html(data);
    jsCalculaTotalNegociacaoVerba();
    jsControleBotoesNegociacaoVerbaDestino();
}

function jsControleBotoesNegociacaoVerbaDestino() {
    if (($('#btnSalvarNegociacaoVerba'))[0]) {
        $('.div-add-distribuicao-verba').show();
        $('.btn-remover-distribuicao-verba').show();
    } else {
        $('.div-add-distribuicao-verba').hide();
        $('.btn-remover-distribuicao-verba').hide();
    }
}

function jsCalculaTotalNegociacaoVerba() {
    var list = jsLerGrid();

    var total = 0;
    for (var i = 0; i < list.length; i++) {
        total += parseFloat(list[i].VlrVerba.replace(/\./g, "").replace(/\,/g, "."));
    }

    $('#txtEditNegociacaoVerbaVlrVerba').val(total.toFixed(2).replace('.', ','));
}


function jsBindGridCarimbo(data) {
    $('#gridCarimbo').html(data);
    $('#formCarimbo').show();
}

function jsdrpAddDestinoObjetivoCodDestinoChange(sender) {

    if ($(sender).val() !== '0' && $(sender).val() !== '')
        GetAjax("/Negociacao/ListObjetivos?codDestino=" + $(sender).val(), jsdrpAddDestinoObjetivoCodDestinoChangeCallback);
    else
        $('#drpAddDestinoObjetivoCodObjetivo').html('<option value="">Selecione...</option>');

}
function jsdrpAddDestinoObjetivoCodDestinoChangeCallback(data) {
    if (data !== "") {
        var list = JSON.parse(data);
        var htmloptions = '<option value="0">Selecione...</option>';
        for (var i = 0; i < list.length; i++) {
            htmloptions += '<option value="' + list[i].CodObjetivo + '" data-cod-destino-objetivo="' + list[i].CodDestinoObjetivo + '" data-nom-destino-objetivo="' + list[i].NomDestinoObjetivo + '">' + list[i].NomObjetivo + '</option>'
        }
        $('#drpAddDestinoObjetivoCodObjetivo').html(htmloptions);
    } else {
        $('#drpAddDestinoObjetivoCodObjetivo').html('<option value="">ERRO AO CARREGAR</option>');
    }
}

//Salvar
function jsSalvarNegociacao() {
    var arrCampos = [$('#txtEditNegociacaoVerbaDesNegociacaoVerba').val(),
    $('#txtEditNegociacaoVerbaVlrVerba').val(),
    $('#drpEditNegociacaoVerbaCodFilialVerba').val(),
    $('#drpEditNegociacaoVerbaCodFornecedor').val(),
    $('#drpEditNegociacaoVerbaCodComprador').val(),
    $('#txtEditNegociacaoVerbaDesObservacaoSolicitacao').val(),
    ]
    if (jsValidar(arrCampos)) {
        //var objNegociacao = jsLerCamposNegociacao();
        var listaDestinoObjetivo = jsLerGrid();
        var objNegociacaoVerba = {
            CodNegociacaoVerba: $('#hdfEditNegociacaoVerbaCodNegociacaoVerba').val().replace(/\./g, ""),
            DesNegociacaoVerba: $('#txtEditNegociacaoVerbaDesNegociacaoVerba').val(),
            VlrVerba: $('#txtEditNegociacaoVerbaVlrVerba').val().replace(/\./g, ""),
            CodFilialVerba: $('#drpEditNegociacaoVerbaCodFilialVerba').val(),
            CodFornecedor: $('#drpEditNegociacaoVerbaCodFornecedor').val(),
            CodComprador: $('#drpEditNegociacaoVerbaCodComprador').val(),
            DesObservacaoSolicitacao: $('#txtEditNegociacaoVerbaDesObservacaoSolicitacao').val(),
            Destinos: listaDestinoObjetivo
        }
        data = {
            obj: objNegociacaoVerba
        }
        PostAjax(data, '/Negociacao/SalvarNegociacao', ModeEdit);
    }
    else
        return false;
}

function jsSalvarCarimbo() {

}

function jsFiltrarCarimbo() {
    data = {
        pCodFilial: $('#txtEditNegociacaoVerbaCodFilialFiltro').val()
    };
    PostAjax(data, '/Negociacao/FiltrarGridCarimbo', jsBindGridCarimbo);
}



//Validação
function jsValidar(sender) {
    var countError = 0;
    var fieldsCollection = [
        "txtEditNegociacaoVerbaDesNegociacaoVerba",
        "txtEditNegociacaoVerbaVlrVerba",
        "drpEditNegociacaoVerbaCodFilialVerba",
        "drpEditNegociacaoVerbaCodFornecedor",
        "drpEditNegociacaoVerbaCodComprador",
        "txtEditNegociacaoVerbaDesObservacaoSolicitacao"
    ]
    var i = 0;
    for (i; i < fieldsCollection.length; i++) {
        if (jsValidaCampo(sender[i], fieldsCollection[i]) == 1) {
            countError++;
            $('#' + fieldsCollection[i]).css("border", "1px solid red");
        }
        else
            $('#' + fieldsCollection[i]).css("border", "1px solid #e4e4e4");
    }

    if (countError == 0)
        return true;
    else {
        jsAbreAlerta("Atenção", "Preencha todos os campos corretamente!", "info");
        return false;
    }
}

function jsValidaCampo(sender, field) {
    if (sender == "") {
        return 1;
    }
    else
        return 0;
}

function jsOpenModalAprovar() {
    var codNegociacaoVerba = $('#hdfEditNegociacaoVerbaCodNegociacaoVerba').val();
    GetAjax('/Negociacao/Aprovar?codNegociacaoVerba=' + codNegociacaoVerba, jsOpenModalAprovarCallback);
}

function jsOpenModalAprovarCallback(data) {
    $('#formAprovar').html(data);
    $('#modalAprovar').modal("show");
}


function jsCloseModalAprovar() {
    $('#modalAprovar').modal("hide");
}


function jsValidarAprovacao() {
    var countError = 0;
    var fieldsCollection = [
        "drpAprovarNegociacaoVerbaCodFormaRecebimento",
        "txtAprovarNegociacaoVerbaDtPrevisaoRecebimento",
        "txtAprovarNegociacaoVerbaDtNegociacaoAcordo"
    ]
    var valuesCollection = [
        $("#drpAprovarNegociacaoVerbaCodFormaRecebimento").val(),
        $("#txtAprovarNegociacaoVerbaDtPrevisaoRecebimento").val(),
        $("#txtAprovarNegociacaoVerbaDtNegociacaoAcordo").val()
    ]
    var i = 0;
    for (i; i < fieldsCollection.length; i++) {
        if (jsValidaCampo(valuesCollection[i], fieldsCollection[i]) == 1) {
            countError++;
            $('#' + fieldsCollection[i]).css("border", "1px solid red");
        }
        else
            $('#' + fieldsCollection[i]).css("border", "1px solid #e4e4e4");
    }

    if (countError == 0)
        return true;
    else {
        jsAbreAlerta("Atenção", "Preencha todos os campos corretamente!", "info");
        return false;
    }
}



function jsValidarAddDestinoObjeto() {
    var countError = 0;
    var fieldsCollection = [
        "drpAddDestinoObjetivoCodDestino",
        "drpAddDestinoObjetivoCodObjetivo",
        "txtAddDestinoObjetivoVlrVerba",
        "txtAddDestinoObjetivoDesObservacao"
    ]
    var valuesCollection = [
        $("#drpAddDestinoObjetivoCodDestino").val(),
        $("#drpAddDestinoObjetivoCodObjetivo").val(),
        $("#txtAddDestinoObjetivoVlrVerba").val(),
        $("#txtAddDestinoObjetivoDesObservacao").val()
    ]
    var i = 0;
    for (i; i < fieldsCollection.length; i++) {
        if (jsValidaCampo(valuesCollection[i], fieldsCollection[i]) == 1) {
            countError++;
            $('#' + fieldsCollection[i]).css("border", "1px solid red");
        }
        else
            $('#' + fieldsCollection[i]).css("border", "1px solid #e4e4e4");
    }

    if (countError == 0)
        return true;
    else {
        jsAbreAlerta("Atenção", "Preencha todos os campos corretamente!", "info");
        return false;
    }
}



function jsGACAprovar() {

    if (jsValidarAprovacao()) {
        var recebimentos = [];

        recebimentos[0] = {
            CodFormaRecebimento: $('#drpAprovarNegociacaoVerbaCodFormaRecebimento').val(),
            DtPrevisaoRecebimento: $('#txtAprovarNegociacaoVerbaDtPrevisaoRecebimento').val(),
        };

        var data = {
            pCodNegociacaoVerba: $('#hdfAprovarNegociacaoVerbaCodNegociacaoVerba').val(),
            pAcordo: {
                DtNegociacaoAcordo: $('#txtAprovarNegociacaoVerbaDtNegociacaoAcordo').val(),

                NomUsuario: $('#txtAprovarNegociacaoVerbaNomUsuario').val(),
                DesComentarioUsuario: $('#txtAprovarNegociacaoVerbaDesComentarioUsuario').val(),
                NomContatoFornecedor: $('#txtAprovarNegociacaoVerbaNomContatoFornecedor').val(),
                NumTelefoneContatoFornecedor: $('#txtAprovarNegociacaoVerbaNumTelefoneContatoFornecedor').val(),
                NomCargoContatoFornecedor: $('#txtAprovarNegociacaoVerbaNomCargoContatoFornecedor').val(),

                Recebimentos: recebimentos

            }
        };
        PostAjax(data, '/Negociacao/Aprovar', jsGACAprovarCallback);
    }
}

function jsGACAprovarCallback(data) {

    $('#modalAprovar').modal("hide");

    $('#formAprovar').html(data);
    $('#modalAcordosNegociacao').modal("show");


}

function jsCloseModalAcordosNegociacao() {

    $('#modalAcordosNegociacao').modal("hide");
    $('#formEdit').hide();

    if ($('#formPesquisaPendencias').length === 1) {
        $('#formPesquisaPendencias').show();
        $('#formPesquisaPendencias').submit();
    } else if ($('#formPesquisa').length === 1) {
        $('#formPesquisa').show();
        $('#formPesquisa').submit();
    }
}



function jsLimparFiltrosPesquisa() {
    $('.divFiltrosPesquisa input').val('');
    $('.divFiltrosPesquisa select').val('');
}



function jsdrpEditNegociacaoVerbaCodFilialVerbaChange() {

    var codFilialEmpresa = $('#drpEditNegociacaoVerbaCodFilialVerba').val();

    if (codFilialEmpresa !== '')
        GetAjax("/Negociacao/FiltrarComprador?codFilialEmpresa=" + codFilialEmpresa, jsdrpEditNegociacaoVerbaCodFilialVerbaChangeCallback);
    else
        $('#drpEditNegociacaoVerbaCodComprador').html('<option value="">Selecione...</option>');

}
function jsdrpEditNegociacaoVerbaCodFilialVerbaChangeCallback(data) {
    if (data !== "") {
        var list = JSON.parse(data);
        var htmloptions = '<option value="">Selecione...</option>';
        for (var i = 0; i < list.length; i++) {
            htmloptions += '<option value="' + list[i].CodComprador + '" >' + list[i].CodNomComprador + '</option>'
        }

        $('#drpEditNegociacaoVerbaCodComprador').html(htmloptions);
    }
    else {
        $('#drpEditNegociacaoVerbaCodComprador').html('<option value="">ERRO AO CARREGAR</option>');
    }
}


function jsdrpEditNegociacaoVerbaCodCompradorChange() {

    var codFilialEmpresa = $('#drpEditNegociacaoVerbaCodFilialVerba').val();
    var codComprador = $('#drpEditNegociacaoVerbaCodComprador').val();
    if (codFilialEmpresa !== '' && codComprador !== '')
        GetAjax("/Negociacao/FiltrarFornecedor?codFilialEmpresa=" + codFilialEmpresa + "&codComprador=" + codComprador, jsdrpEditNegociacaoVerbaCodCompradorChangeCallback);
    else
        $('#drpEditNegociacaoVerbaCodFornecedor').html('<option value="">Selecione...</option>');

}
function jsdrpEditNegociacaoVerbaCodCompradorChangeCallback(data) {
    if (data !== "") {
        var list = JSON.parse(data);
        var htmloptions = '<option value="">Selecione...</option>';
        for (var i = 0; i < list.length; i++) {
            htmloptions += '<option value="' + list[i].CodFornecedor + '" >' + list[i].CodNomFornecedor + '</option>'
        }

        $('#drpEditNegociacaoVerbaCodFornecedor').html(htmloptions);
    }
    else {
        $('#drpEditNegociacaoVerbaCodFornecedor').html('<option value="">ERRO AO CARREGAR</option>');
    }
}

function jsOpenModalImprimirAcordos(codNegociacao) {

    var codNegociacaoVerba = $('#hdfEditNegociacaoVerbaCodNegociacaoVerba').val();
    data = {
        pCodNegociacaoVerba: codNegociacao
    };
    PostAjax(data, '/Negociacao/Imprimir', jsOpenModalImprimirAcordosCallback);
}

function jsOpenModalImprimirAcordosCallback(data) {
    $('#formImprimir').html(data);
    $('#modalImprimirAcordos').modal("show");
}


function jsCloseModalImprimirAcordos() {
    $('#modalImprimirAcordos').modal("hide");
}

function jsOpenModalJustificativaReprovacao(codNegociacaoVerba) {
    data = {
        pCodNegociacaoVerba: codNegociacaoVerba
    };
    GetAjax('/Negociacao/JustificativaReprovacao?pCodNegociacaoVerba=' + codNegociacaoVerba, jsOpenModalJustificativaReprovacaoCallback);
}
function jsOpenModalJustificativaReprovacaoCallback(data) {
    $('#formReprovar').html(data);
    $('#modalJustificaReprovacao').modal("show");
}
function jsCloseModalJustificativaReprovacao() {
    $('#modalJustificaReprovacao').modal("hide");
}

function jsOpenHistoricoNegociacao(codNegociacaoVerba) {
    data = {
        pCodNegociacaoVerba: codNegociacaoVerba
    };
    PostAjax(data, '/Negociacao/HistoricoNegociacao', jsOpenModalHistoricoNegociacaoCallback);
}
function jsOpenModalHistoricoNegociacaoCallback(data) {
    $('#formHistorico').html(data);
    $('#modalHistoricoNegociacao').modal("show");
}
function jsCloseModalHistoricoNegociacao() {
    $('#modalHistoricoNegociacao').modal("hide");
}

function jsNovoGrupoAD() {
    data = {};

    PostAjax(data, '/GrupoAD/NovoGrupoAD', ModeEdit);
}

function jsEditarGrupoAD(codigo) {
    data = {
        pCodGrupoAD: codigo
    };
    PostAjax(data, '/GrupoAD/EditarGrupoAD', ModeEdit);
}
