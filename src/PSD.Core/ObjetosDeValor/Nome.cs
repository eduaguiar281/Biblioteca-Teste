using CSharpFunctionalExtensions;
using PSD.Core.ValidacoesPadrao;
using System.Collections.Generic;

namespace PSD.Core.ObjetosDeValor
{
    public class Nome : ValueObject<Nome>
    {
        protected Nome()
        {

        }

        private Nome(in string nome)
        {
            Valor = nome;
        }

        public string Valor { get; private set; }

        public override string ToString()
        {
            return Valor;
        }

        public static implicit operator string(Nome n) => n.Valor;

        public static Result<Nome> Criar(in string nome)
        {
            var (_, isFailure, erro) = Result.Combine(
                string.IsNullOrEmpty(nome) ? Result.Success() : nome.DeveTerNoMinimo(NomeConstantes.NomeTamanhoMinimoPadrao,
                string.Format(NomeConstantes.NomeDeveTerNoMinimo, NomeConstantes.NomeTamanhoMinimoPadrao)),
                nome.TamanhoMenorOuIgual(NomeConstantes.NomeTamanhoMaximoPadrao,
                string.Format(NomeConstantes.NomeDeveTerNoMaximo, NomeConstantes.NomeTamanhoMaximoPadrao)),
                nome.NaoDeveSerNuloOuVazio(NomeConstantes.NomeEhObrigatorio));

            if (isFailure)
                return Result.Failure<Nome>(erro);

            return Result.Success(new Nome(nome));
        }

        protected override bool EqualsCore(Nome other)
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
