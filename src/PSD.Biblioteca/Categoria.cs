using PSD.Core.Entidade;
using PSD.Core.ObjetosDeValor;

namespace PSD.Biblioteca
{
    public class Categoria : RaizAgregacao<int>
    {
        private Categoria(in Nome nome)
        {
            Nome = nome;
        }
        public Nome Nome { get; private set; }

        public void AlerarNome (in Nome nome)
        {
            Nome = nome;
        }

        public static Categoria Criar(in Nome nome)
        {
            return new Categoria(nome);
        }
    }
}
