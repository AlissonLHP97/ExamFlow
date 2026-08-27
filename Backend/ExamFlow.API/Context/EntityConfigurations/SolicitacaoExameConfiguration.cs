using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamFlow.API.Data.Configurations
{
    public class SolicitacaoExameConfiguration
        : IEntityTypeConfiguration<SolicitacaoExame>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoExame> builder)
        {
            builder.ToTable("ExameSolicitacoes");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.PacienteId)
                .HasColumnName("paciente_id");

            builder.Property(s => s.UsuarioId)
                .HasColumnName("usuario_id");

            builder.Property(s => s.DataSolicitacao)
                .HasColumnName("data_solicitacao")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(s => s.Status)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();

            builder.HasOne(s => s.Paciente)
                .WithMany(p => p.Solicitacoes)
                .HasForeignKey(s => s.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Usuario)
                .WithMany(u => u.Solicitacoes)
                .HasForeignKey(s => s.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Itens)
                .WithOne(i => i.SolicitacaoExame)
                .HasForeignKey(i => i.SolicitacaoExameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}