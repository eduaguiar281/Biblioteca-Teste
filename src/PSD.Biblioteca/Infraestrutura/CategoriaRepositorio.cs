using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PSD.Biblioteca.Aplicacao.Interfaces;
using PSD.Core.Interfaces.Infraestrutura;
using System.Threading.Tasks;

namespace PSD.Biblioteca.Infraestrutura
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        public IUnitOfWork UnitOfWork => _context;
        private readonly BibliotecaDbContext _context;

        public CategoriaRepositorio(BibliotecaDbContext context)
        {
            _context = context;
        }
        public void Adicionar(Categoria data)
        {
            _context.Categorias.Add(data);
        }

        public void Atualizar(Categoria data)
        {
            _context.Categorias.Update(data);
        }

        public void Remover(Categoria data)
        {
            _context.Categorias.Remove(data);
        }

        public async Task<Maybe<Categoria>> ObterPorIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }
    }
}
