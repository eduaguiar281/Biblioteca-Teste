using CSharpFunctionalExtensions;
using PSD.Core.Interfaces.Infraestrutura;
using System.Threading.Tasks;

namespace PSD.Biblioteca.Aplicacao.Interfaces
{
    public interface ICategoriaRepositorio : IRepository<Categoria>
    {
        Task<Maybe<Categoria>> ObterPorIdAsync(int id);

    }
}
