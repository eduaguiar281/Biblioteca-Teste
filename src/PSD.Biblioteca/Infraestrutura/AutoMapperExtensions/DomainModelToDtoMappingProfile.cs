using AutoMapper;
using PSD.Biblioteca.Aplicacao.Dtos;

namespace PSD.Biblioteca.Infraestrutura.AutoMapperExtensions
{
    public class DomainModelToDtoMappingProfile : Profile
    {
        public DomainModelToDtoMappingProfile()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<Aluno, AlunoDto>().ConvertUsing(new AlunoParaAlunoDtoTypeConverter());
        }
    }
}
