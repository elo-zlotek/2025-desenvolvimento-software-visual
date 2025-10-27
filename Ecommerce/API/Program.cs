using API.models;
using API.Models;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

//Lista de produtos fake

List<Produto> produtos = new List<Produto>
      {
           new Produto { Nome = "Notebook Dell", Quntidade = 10, Preco = 3500.00 },
           new Produto { Nome = "Smartphone Samsung", Quntidade = 20, Preco = 2200.00 },
           new Produto { Nome = "Mouse Gamer", Quntidade = 50, Preco = 150.00 },
           new Produto { Nome = "Teclado Mecânico", Quntidade = 30, Preco = 300.00 },
           new Produto { Nome = "Monitor LG 24\"", Quntidade = 15, Preco = 900.00 },
           new Produto { Nome = "Cadeira Gamer", Quntidade = 8, Preco = 1200.00 },
           new Produto { Nome = "Headset HyperX", Quntidade = 25, Preco = 350.00 },
           new Produto { Nome = "Impressora HP", Quntidade = 5, Preco = 700.00 },
           new Produto { Nome = "HD Externo 1TB", Quntidade = 40, Preco = 400.00 },
           new Produto { Nome = "Pen Drive 64GB", Quntidade = 100, Preco = 80.00 }
       };


            //Funcionalidade - Requisições
            // - URL/caminho/endereço
            // - um método HTTP

app.MapGet("/", () => "API de produtos");

//GET:/api/produto/listar
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Produtos.Any())
    {
        return Results.Ok(ctx.Produtos.ToList());
    }

    return Results.NotFound("Lista vazia!");
});

//GET: /api/produto/buscar/nome_do_produto
app.MapGet("/api/produto/buscar/{nome}", ([FromRoute] string nome,
    [FromServices] AppDataContext ctx) =>
 {
     //expressão lambda
     Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Nome == nome);
     if (resultado == null)
     {
         return Results.NotFound("Produto não encontrado!");
     }
     return Results.Ok(resultado);
 });

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar",
    ([FromBody] Produto produto,
    [FromServices] AppDataContext ctx) =>
{
    Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Nome == produto.Nome);
    if (resultado is not null)
    {
        return Results.Conflict("Esse produto já existe");
    }

    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);

});

//proxima aula implementar a remoção e atualização do produto 

app.MapDelete("/api/produto/excluir/{id}",
    ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    Produto? produto = ctx.Produtos.Find(id);

    if (produto == null)
    {
        return Results.NotFound("Produto não encontrado!");
    }

    ctx.Produtos.Remove(produto);
    ctx.SaveChanges();
    return Results.Ok("Produto removido com sucesso!");
});

app.MapPatch("/api/produto/alterar/{id}", 
    ([FromRoute] string id, [FromBody] Produto produtoAlterado,
    [FromServices] AppDataContext ctx) =>
{
    Produto? resultado = ctx.Produtos.Find(id);

    if (resultado == null)
    {
        return Results.NotFound("Produto não encontrado!");
    }

    resultado.Nome = produtoAlterado.Nome;
    resultado.Quntidade = produtoAlterado.Quntidade;
    resultado.Preco = produtoAlterado.Preco;
    ctx.Produtos.Update(resultado);
    ctx.SaveChanges();
    return Results.Ok(resultado);
});

app.Run();






