using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserCadastro.Models;

namespace UserCadastro.Data
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options) { }

        public DbSet<Cadastro> Cadastro { get; set;}
    }
}
