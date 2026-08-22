using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamFlow.API.Data.Configurations
{
    public class ExameConfiguration : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            builder.ToTable("Exames");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasMaxLength(255);
        }
    }
}