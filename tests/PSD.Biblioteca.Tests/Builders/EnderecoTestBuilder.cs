using CSharpFunctionalExtensions;
using PSD.Biblioteca.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSD.Biblioteca.Tests.Builders
{
    public class EnderecoTestBuilder
    {
        public EnderecoTestBuilder()
        {
            IniciarValores();
        }

        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }

        public EnderecoTestBuilder ComRua(string rua)
        {
            Rua = rua;
            return this;
        }
        public EnderecoTestBuilder ComNumero(string numero)
        {
            Numero = numero;
            return this;
        }
        public EnderecoTestBuilder ComComplemento(string complemento)
        {
            Complemento = complemento;
            return this;
        }
        public EnderecoTestBuilder ComBairro(string bairro)
        {
            Bairro = bairro;
            return this;
        }
        public EnderecoTestBuilder ComCEP(string cep)
        {
            CEP = cep;
            return this;
        }
        public EnderecoTestBuilder ComCidade(string cidade)
        {
            Cidade = cidade;
            return this;
        }
        public EnderecoTestBuilder ComUF(string uf)
        {
            UF = uf;
            return this;
        }

        public void IniciarValores()
        {
            Rua = "XV de Novembro";
            Numero = "1021";
            Complemento = "Casa 2";
            Bairro = "Centro";
            CEP = "83271-225";
            Cidade = "Curitiba";
            UF = "PR";
        }

        public Result<Endereco> Build()
        {
            return Endereco.Criar(Rua, Numero, Complemento, Bairro, CEP, Cidade, UF);
        }

    }
}
