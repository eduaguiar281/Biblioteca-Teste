using CSharpFunctionalExtensions;
using PSD.Biblioteca.ObjetosDeValor;
using Shouldly;
using Xunit;

namespace PSD.Biblioteca.Tests.ObjetosDeValor
{
    public class AutorTests
    {
        [Theory(DisplayName = "Valores v�lidos. Deve Ter Sucesso")]
        [Trait(nameof(Autor), nameof(Autor.Criar))]
        [InlineData("Machado de Assis")]
        [InlineData("Paulo Coelho")]
        [InlineData("Clarice Lispector")]
        [InlineData("Fernando Pessoa")]
        [InlineData("William Shakespeare")]
        [InlineData("Cec�lia Meireles")]
        [InlineData("J�lio Verne")]

        public void Autor_ValoresValidos_DeveTerSucesso(string autor)
        {
            // Arrange & Act
            Result<Autor> autorResult = Autor.Criar(autor);

            // Assert
            autorResult.IsSuccess.ShouldBeTrue();
            autorResult.Value.Valor.ShouldBe(autor);
        }

        [Fact(DisplayName = "N�mero de caracteres inferior ao m�nimo. Deve falhar")]
        [Trait(nameof(Autor), nameof(Autor.Criar))]
        public void Autor_NumeroCaracteresInferiorAoMinimo_DeveFalhar()
        {
            // Arrange
            string autor = "A";

            // Act
            Result<Autor> autorResult = Autor.Criar(autor);

            // Assert
            autorResult.IsFailure.ShouldBeTrue();
            autorResult.Error.ShouldContain(string.Format(AutorConstantes.AutorDeveTerNoMinimo,
                AutorConstantes.AutorTamanhoMinimoPadrao));
        }

        [Fact(DisplayName = "N�mero de caracteres superior ao m�ximo. Deve falhar")]
        [Trait(nameof(Autor), nameof(Autor.Criar))]
        public void Autor_NumeroCaracteresSuperiorAoMaximo_DeveFalhar()
        {
            // Arrange
            string autor = "A".PadRight(AutorConstantes.AutorTamanhoMaximoPadrao + 1, 'x');

            // Act
            Result<Autor> autorResult = Autor.Criar(autor);

            // Assert
            autorResult.IsFailure.ShouldBeTrue();
            autorResult.Error.ShouldContain(string.Format(AutorConstantes.AutorDeveTerNoMaximo,
                AutorConstantes.AutorTamanhoMaximoPadrao));
        }

        [Theory(DisplayName = "Nome nulo ou vazio. Deve falhar")]
        [Trait(nameof(Autor), nameof(Autor.Criar))]
        [InlineData(null)]
        [InlineData("")]
        public void Autor_ValorNuloOuVazio_DeveFalhar(string autor)
        {
            // Arrange & Act
            Result<Autor> autorResult = Autor.Criar(autor);

            // Assert
            autorResult.IsFailure.ShouldBeTrue();
            autorResult.Error.ShouldContain(AutorConstantes.AutorEhObrigatorio);
        }
    }
}
