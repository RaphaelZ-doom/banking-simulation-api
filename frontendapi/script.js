const botaoDeposito = document.getElementById('botao-de-deposito');
const botaoSaque = document.getElementById('botao-de-saque');
const saldo = document.getElementById('valor-saldo');
const deposito = document.getElementById('deposito-valor');
const saque = document.getElementById('saque-valor');
let saldototal = 0;

   let saldoSalvo = localStorage.getItem('meusaldoconta');
   if(saldoSalvo != null)
   {
    saldototal = parseFloat(saldoSalvo);
   }
   else{ saldototal = 0.00};
   if(isNaN (saldototal))
   {
      saldototal = 0;
   }
   saldo.textContent = saldototal;
   

function realizardeposito(){
let valorDeposito= parseFloat(deposito.value);
if(valorDeposito > 0)
{
  saldototal += valorDeposito;
  atualizarConta();
 
}
else{ alert("DEPOSITE ALGUM VALOR");}


deposito.value ="";
}
botaoDeposito.addEventListener('click', realizardeposito);


function realizarsaque(){
  let valorSaque = parseFloat(saque.value);
  if(valorSaque> 0)
  {
    if (saldototal >= valorSaque)
{
  saldototal -= valorSaque;
  atualizarConta();
  alert("saque realizado com sucesso");
}
 else{
    alert("voce nao possui saldo suficiente");
  }
  }
  else{
    alert("digite um valor valido.");
  }
 
   saque.value = "";
}
botaoSaque.addEventListener('click', realizarsaque);

function atualizarConta(){
  saldo.textContent = saldototal;
  localStorage.setItem('meusaldoconta', saldototal);
  saldo.textContent = saldototal;
  localStorage.setItem('meusaldoconta', saldototal);

}
