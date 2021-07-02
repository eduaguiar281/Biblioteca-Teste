using CSharpFunctionalExtensions;
using MediatR;
using PSD.Biblioteca.Aplicacao.Commands;
using PSD.Biblioteca.Aplicacao.Dtos;
using PSD.Biblioteca.Aplicacao.Interfaces;
using PSD.Biblioteca.Infraestrutura.AutoMapperExtensions;
using PSD.Core.ObjetosDeValor;
using System.Threading;
using System.Threading.Tasks;

namespace PSD.Biblioteca.Aplicacao
{
    public class CategoriaCommandHandler : 
        IRequestHandler<IncluirCategoriaCommand, Result<CategoriaDto>>,
        IRequestHandler<AlterarCategoriaCommand, Result<CategoriaDto>>,
        IRequestHandler<ExcluirCategoriaCommand, Result<int>>
    {

        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Result<int>> Handle(ExcluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            Maybe<Categoria> categoria = await _categoriaRepositorio.ObterPorIdAsync(request.Id);

            if (categoria.HasNoValue)
            {
                return Result.Failure<int>(string.Format(CategoriaConstantes.CategoriaNaoFoiLocalizada, request.Id));
            }
            _categoriaRepositorio.Remover(categoria.Value);

            int result = await _categoriaRepositorio.UnitOfWork.CommitAsync(cancellationToken);
            if (result <= 0)
            {
                return Result.Failure<int>(CategoriaConstantes.CategoriaNaoFoiPossivelExcluir);
            }
            return Result.Success(request.Id);
        }

        public async Task<Result<CategoriaDto>> Handle(AlterarCategoriaCommand request, CancellationToken cancellationToken)
        {
            Maybe<Categoria> categoria = await _categoriaRepositorio.ObterPorIdAsync(request.Id);

            if (categoria.HasNoValue)
            {
                return Result.Failure<CategoriaDto>(string.Format(CategoriaConstantes.CategoriaNaoFoiLocalizada, request.Id));
            }

            Result<Nome> nomeResult = Nome.Criar(request.Nome);
            if (nomeResult.IsFailure)
            {
                return nomeResult.ConvertFailure<CategoriaDto>();
            }
            categoria.Value.AlerarNome(nomeResult.Value);

            _categoriaRepositorio.Atualizar(categoria.Value);

            int result = await _categoriaRepositorio.UnitOfWork.CommitAsync(cancellationToken);
            if (result <= 0)
            {
                return Result.Failure<CategoriaDto>(CategoriaConstantes.CategoriaNaoFoiPossivelSalvar);
            }

            return Result.Success(categoria.Value.Map<CategoriaDto>());
        }

        public async Task<Result<CategoriaDto>> Handle(IncluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            Result<Nome> nomeResult = Nome.Criar(request.Nome);
            if (nomeResult.IsFailure)
            {
                return nomeResult.ConvertFailure<CategoriaDto>();
            }
            var novaCategoria = Categoria.Criar(nomeResult.Value);
            _categoriaRepositorio.Adicionar(novaCategoria);

            int result = await _categoriaRepositorio.UnitOfWork.CommitAsync(cancellationToken);
            if (result <= 0)
            {
                return Result.Failure<CategoriaDto>(CategoriaConstantes.CategoriaNaoFoiPossivelSalvar);
            }

            return Result.Success(novaCategoria.Map<CategoriaDto>());
        }
    }
}
