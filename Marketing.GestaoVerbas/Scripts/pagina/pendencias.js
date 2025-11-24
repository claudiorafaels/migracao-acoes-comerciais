function ModeSearchPendencia(data) {
    $('#formPesquisaPendencias').show();
    $('#formPesquisa').hide();
    $('#formEdit').hide();
    $('#formCarimbo').hide();

    EnableUnobtrusiveValidation($('#frmPesquisa'));
}

function jsEditarPendencia(sender) {
    data = {
        pCodNegociacao: sender
    };
    PostAjax(data, '/Negociacao/EditarNegociacao', ModeEdit);
}

function jsOpenModalFilialPendencia() {

    findFilial('txtFiltroPendenciaVerbaCodFilialOrigem', 'txtFiltroPendenciaVerbaNomFilialOrigem', 'appendFind');
}


function jsOpenModalAutorPendencia() {
    findFuncionario('txtFiltroPendenciaVerbaCodAutor', 'txtFiltroPendenciaVerbaNomAutor', 'appendFind');
}