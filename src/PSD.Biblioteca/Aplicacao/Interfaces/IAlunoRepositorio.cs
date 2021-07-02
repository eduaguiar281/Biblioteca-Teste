using CSharpFunctionalExtensions;
using PSD.Core.Interfaces.Infraestrutura;
using System.Threading.Tasks;

namespace PSD.Biblioteca.Aplicacao.Interfaces
{
    public interface IAlunoRepositorio : IRepository<Aluno>
    {
        Task<Maybe<Aluno>> ObterPorIdAsync(int id);
    }
}
