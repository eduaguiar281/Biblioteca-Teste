using CSharpFunctionalExtensions;
using PSD.Core.ValidacoesPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSD.Biblioteca.ObjetosDeValor
{
    public class Autor : ValueObject<Autor>
    {
        private Autor(in string autor)
        {
            Valor = autor;
        }

        public string Valor { get; }
        

        public override string ToString()
        {
            return Valor;
        }

        public static implicit operator string(Autor n) => n.Valor;

        public static Result<Autor> Criar(in string autor)
        {
            var (_, isFailure, erro) = Result.Combine(
                string.IsNullOrEmpty(autor) ? Result.Success() : autor.DeveTerNoMinimo(AutorConstantes.AutorTamanhoMinimoPadrao,
                string.Format(AutorConstantes.AutorDeveTerNoMinimo, AutorConstantes.AutorTamanhoMinimoPadrao)),
                autor.TamanhoMenorOuIgual(AutorConstantes.AutorTamanhoMaximoPadrao,
                string.Format(AutorConstantes.AutorDeveTerNoMaximo, AutorConstantes.AutorTamanhoMaximoPadrao)),
                autor.NaoDeveSerNuloOuVazio(AutorConstantes.AutorEhObrigatorio));

            if (isFailure)
                return Result.Failure<Autor>(erro);

            return Result.Success(new Autor(autor));
        }

        protected override bool EqualsCore(Autor other)
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
