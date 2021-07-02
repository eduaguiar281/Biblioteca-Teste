using CSharpFunctionalExtensions;
using PSD.Core.ValidacoesPadrao;
using System;
using System.Collections.Generic;

namespace PSD.Core.ObjetosDeValor
{
    public class Email : ValueObject<Email>
    {
        protected Email()
        {

        }

        private Email(in string nome)
        {
            Valor = nome;
        }

        public string Valor { get; }

        public override string ToString()
        {
            return Valor;
        }

        public static implicit operator string(Email n) => n.Valor;

        public static Result<Email> Criar(string email)
        {
            var (_, isFailure, erro) = string.IsNullOrEmpty(email) ? Result.Success() :
                email.EhCompativel(EmailConstantes.EmailRegex, EmailConstantes.EmailInvalido);

            if (isFailure)
            {
                return Result.Failure<Email>(erro);
            }

            return Result.Success(new Email(email));
        }

        protected override bool EqualsCore(Email other)
        {
            if (other == null)
            {
                return false;
            }
            return Valor == other.Valor;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                return Valor.GetHashCode();
            }
        }
    }
}
