using CSharpFunctionalExtensions;
using PSD.Core.ObjetosDeValor;
using Shouldly;
using Xunit;

namespace PSD.Core.Tests
{
    public class EmailTests
    {
        [Theory(DisplayName = "Valores válidos. Deve Ter Sucesso")]
        [Trait(nameof(Email), nameof(Email.Criar))]
        [InlineData("eduardo.aguiar@gmail.com")]
        [InlineData("james.bond@mi5.en")]
        [InlineData("flash@starslab.co")]
        [InlineData("maximus@domain.com.br")]
        [InlineData("batman@waine.com")]
        [InlineData("superman@dailyplanet.com")]
        [InlineData("IronMan@avengers.com")]
        [InlineData("")]
        [InlineData(null)]
        public void Email_ValorValido_DeveTerSucesso(string email)
        {
            // Arrange & Act
            Result<Email> emailResult = Email.Criar(email);

            // Assert
            emailResult.IsSuccess.ShouldBeTrue();
            emailResult.Value.Valor.ShouldBe(email);
        }

        [Theory(DisplayName = "Valores válidos. Deve Ter Sucesso")]
        [Trait(nameof(Email), nameof(Email.Criar))]
        [InlineData("eduardo.aguiar")]
        [InlineData("james.bond@")]
        [InlineData("flash.starslab.co")]
        [InlineData("Ironman@.")]
        public void Email_ValorInvalido_DeveFalhar(string email)
        {
            // Arrange & Act
            Result<Email> emailResult = Email.Criar(email);

            // Assert
            emailResult.IsFailure.ShouldBeTrue();
            emailResult.Error.ShouldContain(EmailConstantes.EmailInvalido);
        }
    }
}
