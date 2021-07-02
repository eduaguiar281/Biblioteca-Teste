using PSD.Biblioteca.ObjetosDeValor;
using PSD.Core.Entidade;
using PSD.Core.ObjetosDeValor;

namespace PSD.Biblioteca
{
    public class Aluno : RaizAgregacao<int>
    {
        protected Aluno()
        {

        }

        private Aluno(in Nome nome, in Email email, in Endereco endereco)
        {
            Nome = nome;
            Email = email;
            Endereco = endereco;
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }

        public void AlterarDados(in Nome nome, in Email email, in Endereco endereco)
        {
            Nome = nome;
            Email = email;
            Endereco = endereco;
        }

        public static Aluno Criar(in Nome nome, in Email email, in Endereco endereco)
        {
            return new Aluno(nome, email, endereco);
        }
    }
}
