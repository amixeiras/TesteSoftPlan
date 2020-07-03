$(function(){
    carregarTaxa();
});

$("#btnCalcular").click(function () {

    let valorInicial = parseFloat($("#txtValorInicial").val());
    let meses = parseInt($("#txtMeses").val());

    $.post("/Teste/CalcularTaxa?valorinicial=" + valorInicial + "&meses=" + meses, function (data) {
        if (data.erro == "") {
            $("#resultado").css("display", "block");
            $("#txtResultado").val(data.data);
        }
        else
            alert(data.erro);
    })

});

function carregarTaxa() {

    $.get("/Teste/GetTaxa", function (data) {
        if (data.erro == "")
            $("#txtTaxaJuros").val(data.data);
        else
            alert(data.erro);
    });

}




