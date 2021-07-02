using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PSD.Core.ObjetosDeValor.EntityConverters
{
    public static class EFTypeConverters
    {
        public static readonly ValueConverter<Nome, string> NomeConverter = new ValueConverter<Nome, string>(
            nome => nome.Valor,
            nomeValor => Nome.Criar(nomeValor).Value);

        public static readonly ValueConverter<Email, string> EmailConverter = new ValueConverter<Email, string>(
            email => email.Valor,
            emailValor => Email.Criar(emailValor).Value);

    }
}
