using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace PSD.Core.Comunicacao.Interfaces
{
    public interface ICommand<T>: IRequest<Result<T>>
    {
        DateTime Timestamp { get; }
    }
}
