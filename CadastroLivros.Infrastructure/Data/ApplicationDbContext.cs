using CadastroLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Construtor sem parâmetros para Design-Time
        public ApplicationDbContext() { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<LivroAutor> LivroAutores { get; set; }
        public DbSet<LivroAssunto> LivroAssuntos { get; set; }

        // Configuração das chaves compostas e relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chave composta para a entidade LivroAssunto
            modelBuilder.Entity<LivroAssunto>()
                .HasKey(la => new { la.LivroId, la.AssuntoId });

            // Chave composta para a entidade LivroAutor
            modelBuilder.Entity<LivroAutor>()
                .HasKey(la => new { la.LivroId, la.AutorId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
