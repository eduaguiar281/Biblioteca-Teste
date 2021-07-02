using CSharpFunctionalExtensions;
using PSD.Core.ObjetosDeValor;
using Shouldly;
using Xunit;

namespace PSD.Core.Tests
{
    public class NomeTests
    {
        [Theory(DisplayName = "Valores v�lidos. Deve Ter Sucesso")]
        [Trait(nameof(Nome), nameof(Nome.Criar))]
        [InlineData("Maria da Silva")]
        [InlineData("Jo�o Pedro de Souza")]
        [InlineData("Luiz Carlos Pereira")]
        [InlineData("Eduardo Becker Souza")]
        [InlineData("Fernanda de Souza")]
        [InlineData("Andr�ia Lucena da Silva")]
        [InlineData("Ricardo Munhoz")]
        public void Nome_ValorValido_DeveTerSucesso(string nome)
        {
            // Arrange & Act
            Result<Nome> nomeResult = Nome.Criar(nome);

            // Assert
            nomeResult.IsSuccess.ShouldBeTrue();
            nomeResult.Value.Valor.ShouldBe(nome);
        }

        [Fact(DisplayName = "N�mero de caracteres inferior ao m�nimo. Deve falhar")]
        [Trait(nameof(Nome), nameof(Nome.Criar))]
        public void Nome_NumeroCaracteresInferiorAoMinimo_DeveFalhar()
        {
            //Arrange
            string nome = "A";

            //Act
            Result<Nome> nomeResult = Nome.Criar(nome);

            //Assert
            nomeResult.IsFailure.ShouldBeTrue();
            nomeResult.Error.ShouldContain(string.Format(NomeConstantes.NomeDeveTerNoMinimo,
                NomeConstantes.NomeTamanhoMinimoPadrao));
        }

        [Fact(DisplayName = "N�mero de caracteres superior ao m�ximo. Deve falhar")]
        [Trait(nameof(Nome), nameof(Nome.Criar))]
        public void Nome_NumeroCaracteresSuperiorAoMaximo_DeveFalhar()
        {
            // Arrange
            string nome = "A".PadRight(NomeConstantes.NomeTamanhoMaximoPadrao + 1, 'x');

            // Act
            Result<Nome> nomeResult = Nome.Criar(nome);

            // Assert
            nomeResult.IsFailure.ShouldBeTrue();
            nomeResult.Error.ShouldContain(string.Format(NomeConstantes.NomeDeveTerNoMaximo,
                NomeConstantes.NomeTamanhoMaximoPadrao));
        }

        [Theory(DisplayName = "Nome nulo ou vazio. Deve falhar")]
        [Trait(nameof(Nome), nameof(Nome.Criar))]
        [InlineData(null)]
        [InlineData("")]
        public void Nome_ValorNuloOuVazio_DeveFalhar(string nome)
        {
            // Arrange & Act
            Result<Nome> nomeResult = Nome.Criar(nome);

            // Assert
            nomeResult.IsFailure.ShouldBeTrue();
            nomeResult.Error.ShouldContain(NomeConstantes.NomeEhObrigatorio);
        }
    }
}
