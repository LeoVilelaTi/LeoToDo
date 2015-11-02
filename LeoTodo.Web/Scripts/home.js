$(document).ready(function () {

    //Remove linha da lista de tarefas
    removeLinhaTabela = function (e) {
        var tr = $(e).closest('tr');

        tr.fadeToggle(1000, function () {
            tr.remove();
        });
    };

    //Adiciona nova linha na lista de tarefas
    adicionaNovaLinhaTabela = function () {
        var novaLinha = $("<tr>");

        var novaColunaCheckBox = $("<td>");
        novaColunaCheckBox.append('<input class="id1" data-id="" type="checkbox" />');

        var novaColunaCampo = $("<td>");
        novaColunaCampo.append('<input class="id2" type="text" />');

        novaLinha.append(novaColunaCheckBox);
        novaLinha.append(novaColunaCampo);

        $("#toDoList-table tr:first-child").before(novaLinha);

        AdicionarBotaoDeleteNaSegundaLinha();
        FocalizaPrimeiraLinha();
    };

    //Adiciona conteúdo recuperado do banco a primeira linha
    adicionaConteudoDoBancoParaPrimeiraLinhaTabela = function (linhaDados) {
        var trs = $("#toDoList-table").find('tr');
        var primeiraLinhaTabela = trs[0];

        var checkBox = $(primeiraLinhaTabela).find('input[type=checkbox]');
        var campo = $(primeiraLinhaTabela).find('input[type=text]');

        checkBox.attr('data-id', linhaDados.Id);
        $(checkBox).prop("checked", linhaDados.Concluido);
        $(campo).val(linhaDados.Titulo);

        InterfaceCampoDone(checkBox, campo);
    };

    //Ao digitar novo texto e teclar enter, acrescenta uma nova linha de tarefa e o focus sera setado na primeira linha da nova tarefa.
    $("#toDoList-table").on('keypress', 'td', function (e) {

        if (e.which == 13) { //Caso a tecla digitada seja o enter...

            var trClicada = $(this).closest('tr');

            if (trClicada.index() == 0) {

                var tds = $(trClicada).find('td');
                var primeiraTd = tds[0];
                var segundaTd = tds[1];

                var checkBox = $(primeiraTd).find('input[type=checkbox]');
                var campo = $(segundaTd).find('input[type=text]');

                IncluiTarefaNoBanco(checkBox, campo);
                adicionaNovaLinhaTabela();
            }
        }

    });

    //Ao marcar o checkbox, o campo de tarefa fica esmaecido e a descrição da tarefa fica rabiscada
    $("#toDoList-table").on('click', 'td', function (e) {
        if ($(this).index() == 0) {

            ValidaNecessidadeMarcarTodosDone(this);

            var checkBox = $(this).find('input[type=checkbox]');
            var id = checkBox.attr('data-id');
            var campo = $(this).closest('tr').find('input[type=text]');

            AlteraTarefaNoBanco(id, checkBox, campo);
            InterfaceCampoDone(checkBox, campo);
        }
        else if ($(this).index() == 2) {
            var checkBox = $(this).closest('tr').find('input[type=checkbox]');
            var id = checkBox.attr('data-id');

            DeletaTarefaNoBanco(id);
        }
    });

    CarregaInformacoesDoBanco();
});


var InterfaceCampoDone = function (checkBox, campo) {
    if (checkBox.is(':checked')) {
        campo.css('text-decoration', 'line-through');
        campo.css('opacity', '0.5');
    } else {
        campo.css('text-decoration', 'none');
        campo.css('opacity', '1.0');
    }
};

var CarregaInformacoesDoBanco = function () {

    var urlAjax = "Home/ConsultaTodasTarefas";

    $.get(urlAjax).done(function (jsonRetorno) {
        if (jsonRetorno != null && jsonRetorno.status == "OK") {

            var cont = jsonRetorno.data.length;

            for (var i = 0; i < cont; i++) {

                var item = jsonRetorno.data[i];
                adicionaConteudoDoBancoParaPrimeiraLinhaTabela(item);
                adicionaNovaLinhaTabela();
            }
        }
    });

};

var FocalizaPrimeiraLinha = function () {
    var table = document.getElementById("toDoList-table");
    var rows = table.getElementsByTagName('tr');
    var tds = rows[0].getElementsByTagName('td');

    var campo = $(tds[1]).find('input[type=text]');
    $(campo).focus();
};

var AdicionarBotaoDeleteNaSegundaLinha = function () {

    var novoBotaoDelete = $("<td>")
    var col = '<input class="id3" onclick="removeLinhaTabela(this)" type="button" value="x" />';

    novoBotaoDelete.append(col);

    var trs = $("#toDoList-table").find('tr');
    var tds = $(trs[1]).find('td');
    $(tds[1]).after(novoBotaoDelete);
};

var ValidaNecessidadeMarcarTodosDone = function (primeiraColuna) {

    var checkBox = $(primeiraColuna).find('input[type=checkbox]');

    if ($(checkBox).prop('checked') == true) {
        var tds = null;
        var id = null;
        var checkBox = null;

        var trs = $("#toDoList-table").find('tr');

        var numLinhaCLickada = primeiraColuna.closest('tr').rowIndex;

        if (numLinhaCLickada == 0) {

            for (var i = 0; i < trs.length; i++) {
                tds = $(trs[i]).find('td');

                checkBox = $(tds[0]).find('input[type=checkbox]');
                id = checkBox.attr('data-id');
                campo = $(tds[1]).find('input[type=text]')

                $(checkBox).prop('checked', true);

                InterfaceCampoDone(checkBox, campo);

                if (i > 0) {
                    AlteraTarefaNoBanco(id, checkBox, campo);
                }
            }
        }
    }
};

var IncluiTarefaNoBanco = function (checkBox, campo) {

    var urlAjax = "Home/IncluirTarefa";
    var retorno = null;

    var valStatus = $(checkBox).prop('checked');
    var valTitulo = $(campo).val();

    $.post(urlAjax, { titulo: valTitulo, status: valStatus })
    .done(function (jsonRetorno) {
        if (jsonRetorno != null && jsonRetorno.status == "OK") {
            retorno = jsonRetorno.data;
            checkBox.attr('data-id', retorno.Id);
        }
    });

    return retorno;
};

var AlteraTarefaNoBanco = function (id, checkBox, campo) {

    var urlAjax = "Home/AlterarTarefa";

    var valStatus = $(checkBox).prop('checked');
    var valTitulo = $(campo).val();

    $.post(urlAjax, { id: id, titulo: valTitulo, status: valStatus });
};

var DeletaTarefaNoBanco = function (id) {
    var urlAjax = "Home/DeletarTarefa";

    $.post(urlAjax, { id: id });
};
