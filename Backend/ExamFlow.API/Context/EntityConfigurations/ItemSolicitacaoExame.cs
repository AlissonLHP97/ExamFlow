using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamFlow.API.Data.Configurations
{
    public class ItemSolicitacaoExameConfiguration
        : IEntityTypeConfiguration<ItemSolicitacaoExame>
    {
        public void Configure(EntityTypeBuilder<ItemSolicitacaoExame> builder)
        {
            builder.ToTable("ExameSolicitados");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.SolicitacaoExameId)
                .HasColumnName("exame_solicitacao_id");

            builder.Property(i => i.ExameId)
                .HasColumnName("exame_id");

            builder.HasOne(i => i.SolicitacaoExame)
                .WithMany(s => s.Itens)
                .HasForeignKey(i => i.SolicitacaoExameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Exame)
                .WithMany(e => e.Itens)
                .HasForeignKey(i => i.ExameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.Resultado)
                .HasColumnName("Resultado")
                .HasMaxLength(1000);

            builder.Property(d => d.DataResultado)
                .HasColumnName("data_resultado");
        }
    }
}