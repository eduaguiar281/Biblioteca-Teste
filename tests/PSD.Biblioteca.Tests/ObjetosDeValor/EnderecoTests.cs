using CSharpFunctionalExtensions;
using PSD.Biblioteca.ObjetosDeValor;
using PSD.Biblioteca.Tests.Builders;
using Shouldly;
using Xunit;

namespace PSD.Biblioteca.Tests.ObjetosDeValor
{
    public class EnderecoTests
    {
        [Theory(DisplayName = "Valores válidos. Deve Ter Sucesso")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        [InlineData("Sargento Paulo Moreira", "101", null, "Volta Grande", "27290-845", "Volta Redonda", "RJ")]
        [InlineData("1041 A", "101", null, "Volta Grande", "27290-270", "Volta Redonda", "RJ")]
        [InlineData("1039 A", "101", "", "Volta Grande", "27290-290", "Volta Redonda", "RJ")]
        [InlineData("Professora Emilia Pinheiro de Cordeiro", "Volta Grande", "1022", "Bl 10 Apto 201", "27290-290", "Volta Redonda", "RJ")]
        [InlineData("Deputado Ernani Arnaldo Campista", "844", "Casa 2", "Afonso Pena", "83045-290", "São José dos Pinhais", "PR")]
        public void Endereco_ValoresValidos_DeveTerSucesso(string rua, string numero,
            string complemento, string bairro, string cep, string cidade, string uf)
        {
            // Arrange & Act
            Result<Endereco> endercoResult = Endereco.Criar(rua, numero,
                complemento, bairro, cep, cidade, uf);

            // Assert
            endercoResult.IsSuccess.ShouldBeTrue();
            endercoResult.Value.Rua.ShouldBe(rua);
            endercoResult.Value.Numero.ShouldBe(numero);
            endercoResult.Value.Complemento.ShouldBe(complemento);
            endercoResult.Value.Bairro.ShouldBe(bairro);
            endercoResult.Value.CEP.ShouldBe(cep);
            endercoResult.Value.Cidade.ShouldBe(cidade);
            endercoResult.Value.UF.ShouldBe(uf);
        }

        [Fact(DisplayName = "Rua com quantidade caracteres acima do permitido. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        public void Rua_QuantidadeCaracteresAcimaPermitido_DeveFalhar()
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComRua("XV de Novembro".PadRight(EnderecoConstantes.TamanhoMaxRua + 1, '-'))
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.RuaDeveTerNoMaximoNCaracteres);
        }

        [Theory(DisplayName = "Rua vazio. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        [InlineData("")]
        [InlineData(null)]
        public void Endereco_RuaVazio_DeveFalhar(string rua)
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComRua(rua)
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.RuaEhObrigatorio);
        }

        [Theory(DisplayName = "Número vazio. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        [InlineData("")]
        [InlineData(null)]
        public void Endereco_NumeroVazio_DeveFalhar(string numero)
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComNumero(numero)
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.NumeroEhObrigatorio);
        }

        [Fact(DisplayName = "Número com quantidade caracteres acima do permitido. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        public void Numero_QuantidadeCaracteresAcimaPermitido_DeveFalhar()
        {

            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComNumero("1021".PadRight(EnderecoConstantes.TamanhoMaxNumero + 1, '-'))
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.NumeroDeveTerNoMaximoNCaracteres);
        }

        [Fact(DisplayName = "Complemento com quantidade caracteres acima do permitido. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        public void Complemento_QuantidadeCaracteresAcimaPermitido_DeveFalhar()
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComComplemento("BL".PadLeft(EnderecoConstantes.TamanhoMaxComplemento + 1, 'x'))
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.ComplementoDeveTerNoMaximoNCaracteres);
        }

        [Fact(DisplayName = "CEP Inválido. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        public void CEP_Invalido_DeveFalhar()
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComCEP("27290000")
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.CEPNaoEhValida);
        }

        [Fact(DisplayName = "Cidade quantidade caracteres acima permitido. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        public void Cidade_QuantidadeDeCaracteresAcimaDefinido_DeveFalhar()
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComCidade("Curitiba ".PadLeft(EnderecoConstantes.TamanhoMaxCidade + 1, 'x'))
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.CidadeDeveTerNoMaximoNCaracteres);
        }

        [Theory(DisplayName = "Cidade vazio. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        [InlineData("")]
        [InlineData(null)]
        public void Endereco_CidadeVazio_DeveFalhar(string cidade)
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComCidade(cidade)
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.CidadeEhObrigatorio);
        }

        [Theory(DisplayName = "UF inválida. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("PN")]
        [InlineData("EX")]
        public void Endereco_UFInvalida_DeveFalhar(string uf)
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComUF(uf)
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.UFNaoEhValida);
        }

        [Fact(DisplayName = "Bairro quantidade caracteres acima permitido. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        public void Bairro_QuantidadeDeCaracteresAcimaDefinido_DeveFalhar()
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComBairro("Parolin ".PadLeft(EnderecoConstantes.TamanhoMaxBairro + 1, 'x'))
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.BairroDeveTerNoMaximoNCaracteres);
        }

        [Theory(DisplayName = "Bairro vazio. Deve Falhar!")]
        [Trait(nameof(Endereco), nameof(Endereco.Criar))]
        [InlineData("")]
        [InlineData(null)]
        public void Bairro_CidadeVazio_DeveFalhar(string bairro)
        {
            // Arrange & Act
            Result<Endereco> endercoResult = new EnderecoTestBuilder()
                .ComBairro(bairro)
                .Build();

            // Assert
            endercoResult.IsFailure.ShouldBeTrue();
            endercoResult.Error.ShouldContain(EnderecoConstantes.BairroEhObrigatorio);
        }
    }
}
