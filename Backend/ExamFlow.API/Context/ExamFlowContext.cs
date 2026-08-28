using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamFlow.API.Context
{
    public class ExamFlowContext : DbContext
    {
        public ExamFlowContext(DbContextOptions<ExamFlowContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Exame> Exames {  get; set; }
        public DbSet<SolicitacaoExame> SolicitacaoExames { get; set; }
        public DbSet<ItemSolicitacaoExame> ItensSolicitacaoExame { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamFlowContext).Assembly);
        }
    }
}
