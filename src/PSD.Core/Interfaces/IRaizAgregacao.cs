using PSD.Core.Comunicacao;
using System.Collections.Generic;

namespace PSD.Core.Interfaces
{
    public interface IRaizAgregacao
    {

        IReadOnlyCollection<Evento> Notificacoes { get; }

        void AdicionarEvento(Evento evento);

        void RemoverEvento(Evento eventItem);

        void LimparEventos();

    }
}
