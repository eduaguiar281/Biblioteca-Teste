using PSD.Biblioteca.ObjetosDeValor;
using PSD.Core.ObjetosDeValor;
using Shouldly;
using Xunit;

namespace PSD.Biblioteca.Tests
{
    public class CategoriaTests
    {
        [Fact(DisplayName = "Criar. Deve Ter Sucesso")]
        [Trait(nameof(Categoria), nameof(Categoria.Criar))]
        public void Categoria_Criar_DeveTerSucesso()
        {
            // Arrange
            Nome nome = Nome.Criar("Literatura Infanto Juvenil").Value;

            // Act
            var categoria = Categoria.Criar(nome);

            // Assert
            categoria.Nome.Equals(nome).ShouldBeTrue();
        }

        [Fact(DisplayName = "Criar. Deve Ter Sucesso")]
        [Trait(nameof(Categoria), nameof(Categoria.AlerarNome))]
        public void Aluno_AlterarNome_DeveTerSucesso()
        {
            // Arrange
            var nome = Nome.Criar("Literatura Infanto Juvenil").Value;
            var novoNome = Nome.Criar("Matemática Básica").Value;
            var categoria = Categoria.Criar(nome);

            // Act
            categoria.AlerarNome(novoNome);


            // Assert
            categoria.Nome.Equals(novoNome).ShouldBeTrue();
            categoria.Nome.Equals(nome).ShouldBeFalse();
        }

    }
}
