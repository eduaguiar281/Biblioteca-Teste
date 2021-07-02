using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSD.Biblioteca.ObjetosDeValor;
using PSD.Core.ObjetosDeValor;
using PSD.Core.ObjetosDeValor.EntityConverters;

namespace PSD.Biblioteca.Infraestrutura.EntityConfiguration
{
    public class CategoriaEntityTypeConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable($"{nameof(Categoria)}s");
            builder.HasKey(s => s.Id);

            builder.Property(p => p.Nome)
                    .HasColumnType($"varchar({NomeConstantes.NomeTamanhoMaximoPadrao})")
                    .HasConversion(EFTypeConverters.NomeConverter);
        }
    }
}
