using PSD.Biblioteca.Aplicacao.Dtos;
using PSD.Core.Comunicacao;

namespace PSD.Biblioteca.Aplicacao.Commands
{
    public class IncluirCategoriaCommand : Command<CategoriaDto>
    {
        public IncluirCategoriaCommand(in string nome)
        {
            Nome = nome;
        }
        public string Nome { get; }
    }
}
