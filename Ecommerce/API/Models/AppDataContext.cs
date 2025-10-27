using System;
using API.models;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

//classe que representa o banco de dados da aplicação
//1 - Criar a herença da classe DbContext
//2 - informar quais as  classes vão representar as tabelas no banco
//3 - configurar a string de conexão para SQLite

public class AppDataContext : DbContext
{
    //atributos representam as tabelas no banco
    public DbSet<Produto> Produtos { get; set; }

    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Ecommerce.db");

    }
}
