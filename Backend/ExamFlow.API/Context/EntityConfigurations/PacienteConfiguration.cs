using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamFlow.API.Data.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Pacientes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(p => p.Cpf)
                .IsUnique();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("data_nascimento")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Genero)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Telefone)
                .HasMaxLength(20);
        }
    }
}