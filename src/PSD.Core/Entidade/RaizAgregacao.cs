using PSD.Core.Comunicacao;
using PSD.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace PSD.Core.Entidade
{
    public abstract class RaizAgregacao<T> : Entidade<T>, IRaizAgregacao where T: struct
    {
        protected RaizAgregacao()
        {
                
        }
        protected RaizAgregacao(T id)
            :base(id)
        {

        }

        private List<Evento> _notificacoes;
        public IReadOnlyCollection<Evento> Notificacoes => _notificacoes?.AsReadOnly();

        public void AdicionarEvento(Evento evento)
        {
            _notificacoes ??= new List<Evento>();
            _notificacoes.Add(evento);
        }

        public void RemoverEvento(Evento eventItem)
        {
            _notificacoes?.Remove(eventItem);
        }

        public void LimparEventos()
        {
            _notificacoes?.Clear();
        }

    }
}
