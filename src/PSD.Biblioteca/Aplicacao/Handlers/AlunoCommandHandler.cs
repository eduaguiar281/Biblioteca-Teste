using CSharpFunctionalExtensions;
using MediatR;
using PSD.Biblioteca.Aplicacao.Commands;
using PSD.Biblioteca.Aplicacao.Dtos;
using PSD.Biblioteca.Aplicacao.Interfaces;
using PSD.Biblioteca.Infraestrutura.AutoMapperExtensions;
using PSD.Biblioteca.ObjetosDeValor;
using PSD.Core.ObjetosDeValor;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PSD.Biblioteca.Aplicacao.Handlers
{
    public class AlunoCommandHandler : 
        IRequestHandler<IncluirAlunoCommand, Result<AlunoDto>>,
        IRequestHandler<AlterarAlunoCommand, Result<AlunoDto>>,
        IRequestHandler<ExcluirAlunoCommand, Result<int>>
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoCommandHandler(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task<Result<AlunoDto>> Handle(IncluirAlunoCommand request, CancellationToken cancellationToken)
        {
            var endercoResult = Endereco.Criar(request.Rua, request.Numero, request.Complemento, request.Bairro,
                request.CEP, request.Cidade, request.UF);

            var nomeResult = Nome.Criar(request.Nome);

            var emailResult = Email.Criar(request.Email);

            var (_, isFailure, erro) = Result.Combine(endercoResult, nomeResult, emailResult);
            if (isFailure)
            {
                return Result.Failure<AlunoDto>(erro);
            }

            var aluno = Aluno.Criar(nomeResult.Value, emailResult.Value, endercoResult.Value);
            _alunoRepositorio.Adicionar(aluno);

            int result = await _alunoRepositorio.UnitOfWork.CommitAsync(cancellationToken);
            if (result <= 0)
            {
                return Result.Failure<AlunoDto>(AlunoConstantes.AlunoNaoFoiPossivelSalvar);
            }

            return Result.Success(aluno.Map<AlunoDto>());
        }

        public async Task<Result<AlunoDto>> Handle(AlterarAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepositorio.ObterPorIdAsync(request.Id);
            if (aluno.HasNoValue)
            {
                return Result.Failure<AlunoDto>(string.Format(AlunoConstantes.AlunoNaoFoiLocalizada, request.Id));
            }

            var endercoResult = Endereco.Criar(request.Rua, request.Numero, request.Complemento, request.Bairro,
                request.CEP, request.Cidade, request.UF);

            var nomeResult = Nome.Criar(request.Nome);

            var emailResult = Email.Criar(request.Email);

            var (_, isFailure, erro) = Result.Combine(endercoResult, nomeResult, emailResult);
            if (isFailure)
            {
                return Result.Failure<AlunoDto>(erro);
            }

            aluno.Value.AlterarDados(nomeResult.Value, emailResult.Value, endercoResult.Value);
            _alunoRepositorio.Atualizar(aluno.Value);

            int result = await _alunoRepositorio.UnitOfWork.CommitAsync(cancellationToken);
            if (result <= 0)
            {
                return Result.Failure<AlunoDto>(AlunoConstantes.AlunoNaoFoiPossivelSalvar);
            }

            return Result.Success(aluno.Map<AlunoDto>());
        }

        public async Task<Result<int>> Handle(ExcluirAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepositorio.ObterPorIdAsync(request.Id);
            if (aluno.HasNoValue)
            {
                return Result.Failure<int>(string.Format(AlunoConstantes.AlunoNaoFoiLocalizada, request.Id));
            }

            _alunoRepositorio.Remover(aluno.Value);

            int result = await _alunoRepositorio.UnitOfWork.CommitAsync(cancellationToken);
            if (result <= 0)
            {
                return Result.Failure<int>(AlunoConstantes.AlunoNaoFoiPossivelExcluir);
            }

            return Result.Success(request.Id);
        }
    }
}
