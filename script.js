document
.getElementById("adocaoForm")
.addEventListener("submit",function(e){

e.preventDefault();

alert(
"Pedido enviado com sucesso! Nossa equipe entrará em contato 💖"
);

this.reset();

});