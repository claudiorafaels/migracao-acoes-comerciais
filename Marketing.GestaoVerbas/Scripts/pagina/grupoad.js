function jsEditarGrupoAD(codigo) {
    data = {
        pCodGrupoAD: codigo
    };

    PostAjax(data, '/GrupoAD/EditarGrupoAD', ModeEdit);

}

function jsNovoGrupoAcesso() {
    data = {};

    PostAjax(data, '/GrupoAD/NovoGrupoAD', ModeEdit);
}

function jsSalvarGrupoAD(codigo) {
    var arrCampos = [$('#txtEditGrupoAdNomGrupo').val(),
    $('#txtEditGrupoAdDesGrupoAcesso').val()
    ]
    if (jsValidar(arrCampos)) {
        // var listaDestinoObjetivo = jsLerGrid();
        var objGrupo = {
            CodGrupoAcesso: codigo,
            NomGrupoAcesso: $('#txtEditGrupoAdNomGrupo').val(),
            DesGrupoAcesso: $('#txtEditGrupoAdDesGrupoAcesso').val()
            //  Destinos: listaDestinoObjetivo

        }
        data = {
            obj: objGrupo
        }
        PostAjax(data, '/GrupoAD/SalvarGrupoAD', ModeEdit);
    }
    else
        return false;
}

function jsCarregaMenus(codigo) {
    data = {
        pCodGrupoAD: codigo
    };

    PostAjax(data, '/GrupoAD/EditarMenu', ModeMenu);
}


function retornaListaCheckados() {
    var linhas = $('#divCheckMenu input:checked')
    var listResult = [];
    for (var i = 0; i < linhas.length; i++) {
        var codMenu = $(linhas[i]).attr('name').split(".")[1];
        var obj = {
            CodMenu: codMenu
        }
        listResult[listResult.length] = obj;
    }
    return listResult;

}


// Pega a lista de itens checkados e coloca na lista de carimbos selecionados
function SalvarControleAcesso(idAcao) {
    var list = retornaListaCheckados();
    var obj = {
        CodGrupoAcesso: $('#hdfEditMenuCodGrupoAcesso').val(),
        ControleAcessos: list
    }
    data = {
        edit: obj
    };
    PostAjax(data, '/GrupoAD/SalvarListaMenu', ModeMenu);
}

function toggleCheckBox(sender) {
    $($(sender).parent()).find('input[type="checkbox"]').prop("checked", $(sender).prop("checked"));

    if ($(sender).prop("checked") === true) {
        marcarReverso(sender);
    }
}

function marcarReverso(sender) {
    var pai = $($(sender).parent().parent().parent()).children().first();
    if (pai.length === 1 && pai.attr('type') === 'checkbox') {
        pai.prop("checked", true);
        marcarReverso(pai);
    }
}


//Modos
function ModeEdit(data) {
    $('#formEdit').html(data);
    $('#formPesquisa').hide();
    $('#formEdit').show();
    $('#formMenu').hide();

}

function ModeSearch(data) {
    $('#formPesquisa').show();
    $('#formEdit').hide();
    $('#formMenu').hide();
}


function ModeMenu(data) {
    $('#formMenu').html(data);
    $('#formPesquisa').hide();
    $('#formEdit').hide();
    $('#formMenu').show();
}



function jsLimparFiltrosPesquisa() {
    $('.divFiltrosPesquisa input').val('');
    $('.divFiltrosPesquisa select').val('');
}


//Validação
function jsValidar(sender) {
    var countError = 0;
    var fieldsCollection = [
        "txtEditGrupoAdNomGrupo",
        "txtEditGrupoAdDesGrupoAcesso"
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
