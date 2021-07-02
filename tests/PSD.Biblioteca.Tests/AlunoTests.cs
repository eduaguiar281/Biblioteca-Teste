using PSD.Biblioteca.ObjetosDeValor;
using PSD.Biblioteca.Tests.Builders;
using PSD.Core.ObjetosDeValor;
using Shouldly;
using Xunit;

namespace PSD.Biblioteca.Tests
{
    public class AlunoTests
    {
        [Fact(DisplayName = "Criar. Deve Ter Sucesso")]
        [Trait(nameof(Aluno), nameof(Aluno.Criar))]
        public void Aluno_Criar_DeveTerSucesso()
        {
            // Arrange
            var builder = new AlunoTestBuilder();

            // Act
            Aluno aluno = builder
                .ComNome(Nome.Criar("Fernando Silva").Value)
                .ComEmail(Email.Criar("fernando@gmail.com").Value)
                .ComEndereco(new EnderecoTestBuilder().Build().Value)
                .Build();


            // Assert
            aluno.Nome.Equals(builder.Nome).ShouldBeTrue();
            aluno.Email.Equals(builder.Email).ShouldBeTrue();
            aluno.Endereco.Equals(builder.Endereco).ShouldBeTrue();
        }

        [Fact(DisplayName = "Criar. Deve Ter Sucesso")]
        [Trait(nameof(Aluno), nameof(Aluno.AlterarDados))]
        public void Aluno_Alterar_DeveTerSucesso()
        {
            // Arrange
            var novoNome = Nome.Criar("Fernando Silva").Value;
            var novoEmail = Email.Criar("fernando@escola.com.br").Value;
            var alunoTestBuilder = new AlunoTestBuilder();
            Endereco novoEndereco = new EnderecoTestBuilder()
                .ComBairro("Centro")
                .ComCidade("Rio de Janeiro")
                .ComCEP("21051-355")
                .ComUF("RJ")
                .Build().Value;
            Aluno aluno = alunoTestBuilder.Build();

            // Act
            aluno.AlterarDados(novoNome, novoEmail, novoEndereco);


            // Assert
            aluno.Nome.Equals(novoNome).ShouldBeTrue();
            aluno.Email.Equals(novoEmail).ShouldBeTrue();
            aluno.Endereco.Equals(novoEndereco).ShouldBeTrue();

            aluno.Nome.Equals(alunoTestBuilder.Nome).ShouldBeFalse();
            aluno.Email.Equals(alunoTestBuilder.Email).ShouldBeFalse();
            aluno.Endereco.Equals(alunoTestBuilder.Endereco).ShouldBeFalse();
        }

    }
}
