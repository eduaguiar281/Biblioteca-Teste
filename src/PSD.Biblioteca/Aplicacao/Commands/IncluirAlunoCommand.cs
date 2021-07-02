using PSD.Biblioteca.Aplicacao.Dtos;
using PSD.Core.Comunicacao;

namespace PSD.Biblioteca.Aplicacao.Commands
{
    public class IncluirAlunoCommand : Command<AlunoDto> 
    {
        public IncluirAlunoCommand(in string nome, in string email, in string rua, in string numero, in string complemento,
            in string bairro, in string cidade, in string cep, in string uf)
        {
            Nome = nome;
            Email = email;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            CEP = cep;
            UF = uf;
        }

        public string Nome { get; }
        public string Email { get; }
        public string Rua { get; }
        public string Numero { get; }
        public string Complemento { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string CEP { get; }
        public string UF { get; }
    }
}
