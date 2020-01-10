using Microsoft.EntityFrameworkCore;
using PontoEletronico.Models;

namespace PontoEletronico.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<RegistroPonto> RegistroPonto { get; set; }
        public DbSet<DadosContratacaoFuncionario> DadosContratacaoFuncionarios { get; set; }
    }
}
