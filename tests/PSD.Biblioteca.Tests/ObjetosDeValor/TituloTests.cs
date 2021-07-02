using CSharpFunctionalExtensions;
using PSD.Biblioteca.ObjetosDeValor;
using Shouldly;
using Xunit;

namespace PSD.Core.Tests
{
    public class TituloTests
    {
        [Theory(DisplayName = "Valores válidos. Deve Ter Sucesso")]
        [Trait(nameof(Titulo), nameof(Titulo.Criar))]
        [InlineData("Meu pé de laranja lima")]
        [InlineData("Sozinha no Mundo")]
        [InlineData("Ilha Perdida")]
        [InlineData("Escaravelho do Diabo")]
        [InlineData("Éramos Seis")]
        [InlineData("Senhor dos Anéis: A sociedade do anel")]
        [InlineData("Harry Potter e a Pedra Filosofal")]
        public void Titulo_ValorValido_DeveTerSucesso(string titulo)
        {
            // Arrange & Act
            Result<Titulo> tituloResult = Titulo.Criar(titulo);

            // Assert
            tituloResult.IsSuccess.ShouldBeTrue();
            tituloResult.Value.Valor.ShouldBe(titulo);
        }

        [Fact(DisplayName = "Número de caracteres inferior ao mínimo. Deve falhar")]
        [Trait(nameof(Titulo), nameof(Titulo.Criar))]
        public void Titulo_NumeroCaracteresInferiorAoMinimo_DeveFalhar()
        {
            //Arrange
            string titulo = "A";

            //Act
            Result<Titulo> tituloResult = Titulo.Criar(titulo);

            //Assert
            tituloResult.IsFailure.ShouldBeTrue();
            tituloResult.Error.ShouldContain(string.Format(TituloConstantes.TituloDeveTerNoMinimo,
                TituloConstantes.TituloTamanhoMinimoPadrao));
        }

        [Fact(DisplayName = "Número de caracteres superior ao máximo. Deve falhar")]
        [Trait(nameof(Titulo), nameof(Titulo.Criar))]
        public void Titulo_NumeroCaracteresSuperiorAoMaximo_DeveFalhar()
        {
            // Arrange
            string titulo = "A".PadRight(TituloConstantes.TituloTamanhoMaximoPadrao + 1, 'x');

            // Act
            Result<Titulo> tituloResult = Titulo.Criar(titulo);

            // Assert
            tituloResult.IsFailure.ShouldBeTrue();
            tituloResult.Error.ShouldContain(string.Format(TituloConstantes.TituloDeveTerNoMaximo,
                TituloConstantes.TituloTamanhoMaximoPadrao));
        }

        [Theory(DisplayName = "Nome nulo ou vazio. Deve falhar")]
        [Trait(nameof(Titulo), nameof(Titulo.Criar))]
        [InlineData(null)]
        [InlineData("")]
        public void Nome_ValorNuloOuVazio_DeveFalhar(string titulo)
        {
            // Arrange & Act
            Result<Titulo> tituloResult = Titulo.Criar(titulo);

            // Assert
            tituloResult.IsFailure.ShouldBeTrue();
            tituloResult.Error.ShouldContain(TituloConstantes.TituloEhObrigatorio);
        }

    }
}
