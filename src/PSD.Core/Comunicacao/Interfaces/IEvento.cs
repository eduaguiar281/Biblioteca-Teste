using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSD.Core.Comunicacao.Interfaces
{
    public interface IEvento: INotification
    {
        DateTime Timestamp { get; }
    }
}
