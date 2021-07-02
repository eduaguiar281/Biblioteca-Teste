using CSharpFunctionalExtensions;
using PSD.Core.ValidacoesPadrao;

namespace PSD.Biblioteca.ObjetosDeValor
{
    public class Endereco : ValueObject<Endereco>
    {
        protected Endereco() { }

        private Endereco(in string rua, in string numero, in string complemento,
            in string bairro, in string cep, in string cidade, in string uf)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            CEP = cep;
            Cidade = cidade;
            UF = uf;
            Bairro = bairro;
        }

        public string Rua { get; }
        public string Numero { get; }
        public string Complemento { get; }
        public string Bairro { get; }
        public string CEP { get; }
        public string Cidade { get; }
        public string UF { get; }


        public static Result<Endereco> Criar(in string rua, in string numero, in string complemento,
            in string bairro, in string cep, in string cidade, string uf)
        {
            var (_, isFailure, erro) = Result.Combine(rua.NaoDeveSerNuloOuVazio(EnderecoConstantes.RuaEhObrigatorio),
                rua.TamanhoMenorOuIgual(EnderecoConstantes.TamanhoMaxRua, EnderecoConstantes.RuaDeveTerNoMaximoNCaracteres),
                numero.NaoDeveSerNuloOuVazio(EnderecoConstantes.RuaEhObrigatorio),
                numero.TamanhoMenorOuIgual(EnderecoConstantes.TamanhoMaxNumero, EnderecoConstantes.NumeroDeveTerNoMaximoNCaracteres),
                string.IsNullOrEmpty(complemento) ? Result.Success() :
                   complemento.TamanhoMenorOuIgual(EnderecoConstantes.TamanhoMaxComplemento, EnderecoConstantes.ComplementoDeveTerNoMaximoNCaracteres),
                cep.EhCompativel(EnderecoConstantes.CEPExpressao, EnderecoConstantes.CEPNaoEhValida),
                cidade.NaoDeveSerNuloOuVazio(EnderecoConstantes.CidadeEhObrigatorio),
                cidade.TamanhoMenorOuIgual(EnderecoConstantes.TamanhoMaxCidade, EnderecoConstantes.CidadeDeveTerNoMaximoNCaracteres),
                bairro.NaoDeveSerNuloOuVazio(EnderecoConstantes.BairroEhObrigatorio),
                bairro.TamanhoMenorOuIgual(EnderecoConstantes.TamanhoMaxBairro, EnderecoConstantes.BairroDeveTerNoMaximoNCaracteres),
                EnderecoConstantes.UFValidas.AlgumDeveSer(x => x == uf, EnderecoConstantes.UFNaoEhValida)
                );

            if (isFailure)
            {
                return Result.Failure<Endereco>(erro);
            }

            return Result.Success(new Endereco(rua, numero, complemento, bairro, cep, cidade, uf));
        }

        protected override bool EqualsCore(Endereco other)
        {
            if (other == null)
            {
                return false;
            }
            return Rua == other.Rua &&
                Numero == other.Numero &&
                Complemento == other.Complemento &&
                Bairro == other.Bairro &&
                CEP == other.CEP &&
                Cidade == other.Cidade &&
                UF == other.UF;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Rua.GetHashCode();
                hashCode = (hashCode * 397) ^ Numero.GetHashCode();
                hashCode = (hashCode * 397) ^ Complemento.GetHashCode();
                hashCode = (hashCode * 397) ^ Bairro.GetHashCode();
                hashCode = (hashCode * 397) ^ CEP.GetHashCode();
                hashCode = (hashCode * 397) ^ Cidade.GetHashCode();
                hashCode = (hashCode * 397) ^ UF.GetHashCode();
                return hashCode;
            }
        }
    }
}
