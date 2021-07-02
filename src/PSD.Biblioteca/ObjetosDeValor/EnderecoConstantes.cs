namespace PSD.Biblioteca.ObjetosDeValor
{
    public static class EnderecoConstantes
    {
        public const string UFNaoEhValida = "Campo UF não é válido!";
        public static readonly string[] UFValidas = new string[]
        {
            "RJ","SP","ES","MG","PR","SC","RS","MS","GO",
            "AC","AL","AP","AM","BA","CE","DF","MA","MT",
            "PA","PB","PE","PI","RN","RO","RR","SE","TO"
        };

        public const int TamanhoMaxRua = 100;
        public static readonly string RuaDeveTerNoMaximoNCaracteres = $"Rua deve ter até {TamanhoMaxRua} caracteres!";
        public const string RuaEhObrigatorio = "Campo Rua é Obrigatório!";

        public const int TamanhoMaxNumero = 15;
        public static readonly string NumeroDeveTerNoMaximoNCaracteres = $"Número deve ter até {TamanhoMaxNumero} caracteres!";
        public const string NumeroEhObrigatorio = "Campo Rua é Obrigatório!";

        public const int TamanhoMaxComplemento = 15;
        public static readonly string ComplementoDeveTerNoMaximoNCaracteres = $"Número deve ter até {TamanhoMaxComplemento} caracteres!";

        public const int TamanhoMaxCidade = 100;
        public static readonly string CidadeDeveTerNoMaximoNCaracteres = $"Cidade deve ter até {TamanhoMaxCidade} caracteres!";
        public const string CidadeEhObrigatorio = "Campo Cidade é Obrigatório!";

        public const int TamanhoMaxBairro = 100;
        public static readonly string BairroDeveTerNoMaximoNCaracteres = $"Bairro deve ter até {TamanhoMaxBairro} caracteres!";
        public const string BairroEhObrigatorio = "Campo Bairro é Obrigatório!";


        public const string CEPNaoEhValida = "Campo CEP não é válido!";
        public const string CEPExpressao = @"^\d{5}-\d{3}$";
    }
}
