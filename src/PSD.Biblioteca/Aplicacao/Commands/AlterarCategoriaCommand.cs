using PSD.Biblioteca.Aplicacao.Dtos;
using PSD.Core.Comunicacao;

namespace PSD.Biblioteca.Aplicacao.Commands
{
    public class AlterarCategoriaCommand : Command<CategoriaDto>
    {
        public AlterarCategoriaCommand(in int id, in string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; }
        public string Nome { get; }
    }
}
