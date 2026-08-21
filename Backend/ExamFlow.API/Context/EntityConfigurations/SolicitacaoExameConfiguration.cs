using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamFlow.API.Context.EntityConfigurations
{
    public class SolicitacaoExameConfiguration : IEntityTypeConfiguration<SolicitacaoExame>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoExame> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Paciente)
                .WithMany(p => p.Solicitacoes)
                .HasForeignKey(s => s.ExameId);

            builder.HasOne(s => s.Exame)
                .WithMany(e => e.Solicitacoes)
                .HasForeignKey(s => s.ExameId);

            builder.HasOne(s => s.Usuario)
                .WithMany(e => e.Solicitacoes)
                .HasForeignKey(s => s.UsuarioId);
        }
    }
}
