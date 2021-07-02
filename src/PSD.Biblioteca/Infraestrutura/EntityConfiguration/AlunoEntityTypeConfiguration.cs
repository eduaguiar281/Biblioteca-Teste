using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSD.Biblioteca.ObjetosDeValor;
using PSD.Core.ObjetosDeValor;
using PSD.Core.ObjetosDeValor.EntityConverters;

namespace PSD.Biblioteca.Infraestrutura.EntityConfiguration
{
    public class AlunoEntityTypeConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable($"{nameof(Aluno)}s");
            builder.HasKey(s => s.Id);

            builder.Property(p => p.Nome)
                    .HasColumnType($"varchar({NomeConstantes.NomeTamanhoMaximoPadrao})")
                    .HasConversion(EFTypeConverters.NomeConverter);

            builder.Property(p => p.Email)
                    .HasColumnType("varchar(300)")
                    .HasConversion(EFTypeConverters.EmailConverter);

            builder.OwnsOne(p => p.Endereco, enderecoBuilder =>
            {
                enderecoBuilder.Property(p => p.Rua)
                   .HasColumnType($"varchar({EnderecoConstantes.TamanhoMaxRua})");

                enderecoBuilder.Property(p => p.Numero)
                   .HasColumnType($"varchar({EnderecoConstantes.TamanhoMaxNumero})");

                enderecoBuilder.Property(p => p.Complemento)
                   .HasColumnType($"varchar({EnderecoConstantes.TamanhoMaxComplemento})");

                enderecoBuilder.Property(p => p.Bairro)
                   .HasColumnType($"varchar({EnderecoConstantes.TamanhoMaxBairro})");

                enderecoBuilder.Property(p => p.CEP)
                   .HasColumnType($"varchar(20)");

                enderecoBuilder.Property(p => p.Cidade)
                   .HasColumnType($"varchar({EnderecoConstantes.TamanhoMaxCidade})");

                enderecoBuilder.Property(p => p.UF)
                   .HasColumnType($"varchar(5)");
            });
        }
    }
}
