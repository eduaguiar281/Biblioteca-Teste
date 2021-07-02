using PSD.Core.Comunicacao;

namespace PSD.Biblioteca.Aplicacao.Commands
{
    public class ExcluirCategoriaCommand : Command<int>
    {
        public ExcluirCategoriaCommand(in int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
