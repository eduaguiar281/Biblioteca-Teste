using CSharpFunctionalExtensions;
using PSD.Core.Comunicacao.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace PSD.Core.Comunicacao.Mediator
{
    public class MediatorHandler: IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result<T>> EnviarComando<T>(ICommand<T> comando)
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarEvento<T>(T evento) where T : Evento
        {
            await _mediator.Publish(evento);
        }
    }
}
