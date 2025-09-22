using API.models;

Console.Clear();
var builder = WebApplication.CreateBuilder(args);
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
app.MapGet("/api/produto/listar", () =>
{
    return produtos;
});

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", (Produto produto) =>
{
    
    produtos.Add(produto);
});




app.Run();










