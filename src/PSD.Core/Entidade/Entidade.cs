using CSharpFunctionalExtensions;
using PSD.Core.Comunicacao;
using System;
using System.Collections.Generic;

namespace PSD.Core
{
    public abstract class Entidade<T>: Entity<T> where T:struct
    {
        protected Entidade()
        {
        }

        protected Entidade(T id)
        {
            Id = id;
        }

        public DateTime DataCriacao { get; protected set; }
        public DateTime DataAlteracao { get; protected set; }

    }
}
