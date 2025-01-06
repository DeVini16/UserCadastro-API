using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserCadastro.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar log ao console para capturar detalhes das operações do EF Core
builder.Logging.AddConsole();

// Configurando o DbContext para usar SQLite
builder.Services.AddDbContext<CadastroContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Usar o Swagger e Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Gera o Swagger
    app.UseSwaggerUI(); // Interface do Swagger UI
}

app.MapControllers();

app.Run();
