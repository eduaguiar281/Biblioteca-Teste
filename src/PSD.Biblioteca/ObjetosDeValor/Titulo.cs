using CSharpFunctionalExtensions;
using PSD.Core.ValidacoesPadrao;
using System.Collections.Generic;

namespace PSD.Biblioteca.ObjetosDeValor
{
    public class Titulo : ValueObject<Titulo>
    {
        protected Titulo()
        {

        }

        private Titulo(in string titulo)
        {
            Valor = titulo;
        }

        public string Valor { get; private set; }

        public override string ToString()
        {
            return Valor;
        }

        public static implicit operator string(Titulo n) => n.Valor;

        public static Result<Titulo> Criar(in string titulo)
        {
            var (_, isFailure, erro) = Result.Combine(
                string.IsNullOrEmpty(titulo) ? Result.Success() : titulo.DeveTerNoMinimo(TituloConstantes.TituloTamanhoMinimoPadrao,
                string.Format(TituloConstantes.TituloDeveTerNoMinimo, TituloConstantes.TituloTamanhoMinimoPadrao)),
                titulo.TamanhoMenorOuIgual(TituloConstantes.TituloTamanhoMaximoPadrao,
                string.Format(TituloConstantes.TituloDeveTerNoMaximo, TituloConstantes.TituloTamanhoMaximoPadrao)),
                titulo.NaoDeveSerNuloOuVazio(TituloConstantes.TituloEhObrigatorio));

            if (isFailure)
            {
                return Result.Failure<Titulo>(erro);
            }

            return Result.Success(new Titulo(titulo));
        }

        protected override bool EqualsCore(Titulo other)
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
