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

            builder.Property(u => u.UsuarioId)
                .HasColumnName("usuario_id");

            builder.HasIndex(u => u.UsuarioId)
                .IsUnique();

            builder
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Paciente)
                .HasForeignKey<Paciente>(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}