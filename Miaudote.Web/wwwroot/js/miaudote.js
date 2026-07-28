document
.getElementById("adocaoForm")
.addEventListener("submit",function(e){

e.preventDefault();

alert(
"Pedido enviado com sucesso! Nossa equipe entrará em contato 💖"
);

this.reset();

});
document.addEventListener("DOMContentLoaded", function () {
    const formularioContato = document.getElementById("contatoForm");

    if (formularioContato) {
        formularioContato.addEventListener("submit", function (evento) {
            evento.preventDefault();

            alert(
                "Formulário visual concluído. " +
                "O salvamento no banco será configurado em uma próxima etapa."
            );
        });
    }
});