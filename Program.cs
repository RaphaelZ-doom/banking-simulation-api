using System.Security.Principal;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);//* classe nattiva da microsoft (webaplicationn) (CreateBuilder) metodo da classe responsavel por preparar o servidor (args) e o parametro que o metodo recebe
//* builder e a variavel que se torna o objeto gerado por tudo isso

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add( new JsonStringEnumConverter());
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); //* pega o objeto (builder) e chama um metodo dele () parenteses vazios
//* app se torna o novo objeto final que representa o servidor web pronto pra uso

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/minhaconta/{valor}", (decimal valor) => //* (MapGet) e um metodo do objeto (app), e recebe dois parametros separados por virgula | "/minhaconta" e " () => {} " que e a expressao de lambda e serve pra passar um bloco de codigo inteiro
{                                                                                                                                                  //*como se fosse um parametro                                                                                     
    conta myaccount = new conta(); //* cria uma nova instancia "objeto", da classe conta e guarda na variavel my acc
    myaccount.deposit(valor); //* chama o metodo deposit, passando o parametro "valor" que veio da url
    return Results.Created($"/minhaconta/{valor}", myaccount); //* retorna o objeto "mtaccount"
});

app.MapPost("/minhaconta/sacar/{valor}", (decimal valor ) =>
{
    conta myaccount = new conta ();
    myaccount.balance = 100;

    try
    {
        myaccount.withdraw(valor);
        return Results.Ok(myaccount);
    }
    catch (Exception erro)
    {
        return Results.BadRequest(erro.Message);
    }
});

app.Run(); //* e o metodo final do objeto (app), que nao recebe parametros, dentro dele existe um laço de repetiçao infinito que impede a tela preta de fechar sozinha

public class conta
{
    
    public bool active{get; set;} = true;//*se a conta esta ou nao ativa
    public decimal balance{get; set;} //*saldo da conta em decimal, para maior precisao

    public enum  tipoConta {checkingaccount, savingsaccount, salaryaccount }//* define um novo tipo de dado
     public tipoConta acctype {get;set;} = tipoConta.checkingaccount; //* cria uma variavel acctype, que pode ser mudada de acordo com os dados enum

      public void deposit (decimal value) //* metodo para fazer o deposito do dinheiro
    {
       
       balance += value; //* serve para armazenar o valor a variavel balance
    
    }

        public void withdraw (decimal value) //*metodo para fazer o saque do dinheiro
    {
        
        if ( value > balance ) //* if para ver se o usuario tem saldo suficiente para sacar
        {
            throw new Exception("Saldo insuficiente para realizar o SAQUE!");
          //* se  nao tiver saldo, ira ser receber um aviso de que o saque foi recusado;
        }
         balance -= value; //* se tiver saldo, ira ser sacado o valor do balance
    }
   }
   
