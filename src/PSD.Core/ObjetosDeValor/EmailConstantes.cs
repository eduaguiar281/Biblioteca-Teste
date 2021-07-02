using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSD.Core.ObjetosDeValor
{
    public static class EmailConstantes
    {
        public const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string EmailInvalido = "Email não é válido!";
    }
}
