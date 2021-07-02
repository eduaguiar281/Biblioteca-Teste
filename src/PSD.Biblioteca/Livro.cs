using CSharpFunctionalExtensions;
using PSD.Biblioteca.ObjetosDeValor;
using PSD.Core.Entidade;
using PSD.Core.ValidacoesPadrao;

namespace PSD.Biblioteca
{
    public class Livro : RaizAgregacao<int>
    {
        protected Livro()
        {

        }

        private Livro(in Titulo titulo, in Autor autor, in int categoriaId)
        {
            Titulo = titulo;
            Autor = autor;
            _categoriaId = categoriaId;
        }

        public Titulo Titulo { get; private set; }
        public Autor Autor { get; private set; }

        public int CategoriaId => _categoriaId;
        private readonly int _categoriaId;

        public static Result<Livro> Criar(in Titulo titulo, in Autor autor, in int categoriaId)
        {
            var result = categoriaId.DeveSerMaiorQue(0, LivroConstantes.CategoriaEhObrigatorio);
            if (result.IsFailure)
            {
                return result.ConvertFailure<Livro>();
            }

            return Result.Success(new Livro(titulo, autor, categoriaId));
        }
    }
}
