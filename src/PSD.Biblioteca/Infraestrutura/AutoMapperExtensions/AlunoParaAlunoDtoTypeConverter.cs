using PSD.Biblioteca.Aplicacao.Dtos;
using AutoMapper;

namespace PSD.Biblioteca.Infraestrutura.AutoMapperExtensions
{
    public class AlunoParaAlunoDtoTypeConverter : ITypeConverter<Aluno, AlunoDto>
    {
        public AlunoParaAlunoDtoTypeConverter()
        {

        }
        public AlunoDto Convert(Aluno source, AlunoDto destination, ResolutionContext context)
        {
            return new AlunoDto
            {
                Id = source.Id,
                Nome = source.Nome,
                Email = source.Email,
                Rua = source.Endereco.Rua,
                Numero = source.Endereco.Numero,
                Complemento = source.Endereco.Complemento,
                Bairro = source.Endereco.Bairro,
                Cidade = source.Endereco.Cidade,
                UF = source.Endereco.UF,
                CEP = source.Endereco.CEP
            };

        }
    }
}
