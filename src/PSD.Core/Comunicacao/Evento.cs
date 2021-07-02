using PSD.Core.Comunicacao.Interfaces;
using System;

namespace PSD.Core.Comunicacao
{
    public abstract class Evento: Mensagem, IEvento
    {
        public DateTime Timestamp { get; private set; }

        protected Evento()
        {
            Timestamp = DateTime.UtcNow;
        }

    }
}
