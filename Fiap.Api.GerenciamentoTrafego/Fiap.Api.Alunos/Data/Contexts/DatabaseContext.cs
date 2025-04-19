using Fiap.Api.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Alunos.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<AcidenteModel> Acidentes { get; set; }
        public virtual DbSet<CondicaoClimaticaModel> CondicoesClimaticas { get; set; }
        public virtual DbSet<RotaModel> Rotas { get; set; }
        public virtual DbSet<SemaforoModel> Semaforos { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcidenteModel>(entity =>
            {
                // Define o nome da tabela
                entity.ToTable("Acidente");
                // Define a chave prim�ria
                entity.HasKey(e => e.AcidenteId);
                // Define os campos obrigat�rios
                entity.Property(e => e.Localizacao).IsRequired();
                entity.Property(e => e.Gravidade).IsRequired();
                // Define os campos que n�o podem se repetir
                entity.HasIndex(e => e.Localizacao).IsUnique();
                // Especifica��o do tipo de dado
                entity.Property(e => e.DataHora).HasColumnType("date");
            });

            modelBuilder.Entity<CondicaoClimaticaModel>(entity =>
            {
                // Define o nome da tabela
                entity.ToTable("CondicaoClimatica");
                // Define a chave prim�ria
                entity.HasKey(e => e.CondicaoClimaticaId);
                // Especifica��o do tipo de dado
                entity.Property(e => e.DataHora).HasColumnType("date");
            });

            modelBuilder.Entity<RotaModel>(entity =>
            {
                // Define o nome da tabela
                entity.ToTable("Rota");
                // Define a chave prim�ria
                entity.HasKey(e => e.RotaId);
                // Define os campos obrigat�rios
                entity.Property(e => e.Origem).IsRequired();
                entity.Property(e => e.Destino).IsRequired();
                // Especifica��o do tipo de dado
                entity.Property(e => e.DataHora).HasColumnType("date");
            });

            modelBuilder.Entity<SemaforoModel>(entity =>
            {
                // Define o nome da tabela
                entity.ToTable("Semaforo");
                // Define a chave prim�ria
                entity.HasKey(e => e.SemaforoId);
                // Define os campos obrigat�rios
                entity.Property(e => e.Localizacao).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                // Define os campos que n�o podem se repetir
                entity.HasIndex(e => e.Localizacao).IsUnique();
                // Especifica��o do tipo de dado
                entity.Property(e => e.DataHora).HasColumnType("date");
            });

            //base.OnModelCreating(modelBuilder);
        }
        
    }
}
