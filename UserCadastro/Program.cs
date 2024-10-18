using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserCadastro.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionar log ao console para capturar detalhes das operações do EF Core
builder.Logging.AddConsole();

// Configurando o DbContext para usar SQLite
builder.Services.AddDbContext<CadastroContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
