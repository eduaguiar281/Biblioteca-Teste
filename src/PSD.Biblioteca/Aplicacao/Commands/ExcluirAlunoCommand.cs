using PSD.Core.Comunicacao;

namespace PSD.Biblioteca.Aplicacao.Commands
{
    public class ExcluirAlunoCommand : Command<int>
    {
        public ExcluirAlunoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
