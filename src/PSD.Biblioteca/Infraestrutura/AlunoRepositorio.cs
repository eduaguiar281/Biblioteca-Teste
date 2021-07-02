using CSharpFunctionalExtensions;
using PSD.Biblioteca.Aplicacao.Interfaces;
using PSD.Core.Interfaces.Infraestrutura;
using System;
using System.Threading.Tasks;

namespace PSD.Biblioteca.Infraestrutura
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        public IUnitOfWork UnitOfWork => _context;
        private readonly BibliotecaDbContext _context;

        public AlunoRepositorio(BibliotecaDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Aluno data)
        {
            _context.Alunos.Add(data);
        }

        public void Atualizar(Aluno data)
        {
            _context.Alunos.Remove(data);
        }

        public async Task<Maybe<Aluno>> ObterPorIdAsync(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public void Remover(Aluno data)
        {
            _context.Alunos.Remove(data);
        }
    }
}
