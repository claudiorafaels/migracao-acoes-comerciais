function ModeIndex() {
    $('#visaoRelatorio').hide();
    $('#formPesquisa').show();
}

function ModePesquisar() {

    $('#visaoRelatorio').show();
    $('#formPesquisa').hide();

}

function jsExpandeSimilaresRelatorio(pai) {
    $('.filho-' + pai).fadeToggle();
}

