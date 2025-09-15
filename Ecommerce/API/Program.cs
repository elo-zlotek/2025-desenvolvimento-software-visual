using API.models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Funcionalidade - Requisições
// - URL/caminho/endereço
// - um método HTTP

app.MapGet("/", () => "Segunda API em C#!");

app.MapGet("/endereco", () => "outra funcionalidade!");

app.MapPost("/endereco", () => "Funcionalidade do POST!");


Produto produto = new Produto();
produto.Nome = "TV";
Console.WriteLine(produto.Nome);

app.Run();