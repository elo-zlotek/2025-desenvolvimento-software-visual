var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Funcionalidade - Requisições
// - URL/caminho/endereço
// - um método HTTP

app.MapGet("/", () => "Segunda API em C#!");

app.MapGet("/endereco", () => "outra funcionalidade!");

app.MapPost("/endereco", () => "Funcionalidade do POST!");

app.Run();
