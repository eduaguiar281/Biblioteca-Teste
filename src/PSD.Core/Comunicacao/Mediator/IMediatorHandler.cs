using CSharpFunctionalExtensions;
using PSD.Core.Comunicacao.Interfaces;
using System.Threading.Tasks;

namespace PSD.Core.Comunicacao.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Evento;

        Task<Result<T>> EnviarComando<T>(ICommand<T> comando);  
    }
}
