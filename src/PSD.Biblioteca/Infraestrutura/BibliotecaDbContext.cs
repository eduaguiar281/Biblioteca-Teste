using Microsoft.EntityFrameworkCore;
using PSD.Biblioteca.Infraestrutura.EntityConfiguration;
using PSD.Biblioteca.ObjetosDeValor;
using PSD.Core.Comunicacao;
using PSD.Core.Comunicacao.Mediator;
using PSD.Core.Interfaces.Infraestrutura;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSD.Biblioteca.Infraestrutura
{
    public class BibliotecaDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options,
            IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaEntityTypeConfiguration());

            modelBuilder.Ignore<Evento>();
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.UtcNow;
                    entry.Property("DataAlteracao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.UtcNow;
                    entry.Property("DataCriacao").IsModified = false;
                }
            }

            int result = await base.SaveChangesAsync();
            if (result > 0)
            {
                await _mediatorHandler.PublicarEventos(this);
            }

            return result;
        }

    }
}
