using CSharpFunctionalExtensions;
using PSD.Biblioteca.ObjetosDeValor;
using PSD.Core.ObjetosDeValor;

namespace PSD.Biblioteca.Tests.Builders
{
    public class AlunoTestBuilder
    {
        public AlunoTestBuilder()
        {
            IniciarValores();
        }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
        
        public AlunoTestBuilder ComNome(Nome nome)
        {
            Nome = nome;
            return this;
        }
        public AlunoTestBuilder ComEmail(Email email)
        {
            Email = email;
            return this;
        }

        public AlunoTestBuilder ComEndereco(Endereco endereco)
        {
            Endereco = endereco;
            return this;
        }

        public void IniciarValores()
        {
            Nome = Nome.Criar("Pedro Ferreira Silva").Value;
            Email = Email.Criar("pedro@escola.com.br").Value;
            Endereco = Endereco.Criar("XV de Novembro", "1021", "Casa 2", "Centro", "83271-225", "Curitiba", "PR").Value;
        }

        public Aluno Build()
        {
            return Aluno.Criar(Nome, Email, Endereco);
        }

    }
}
