using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSD.Biblioteca.Infraestrutura.AutoMapperExtensions;

namespace PSD.Biblioteca.Infraestrutura
{
    public static class BibliotecaDependencyInjection
    {
        public static IServiceCollection AddBiblioteca(this IServiceCollection services, IConfiguration configuration)
        {
            // database
            var connectionString = configuration.GetConnectionString("BibliotecaConnection");

            services.AddDbContext<BibliotecaDbContext>(options =>
                options.UseSqlServer(connectionString));

            var config = new MapperConfiguration(cfg => cfg.AddProfile(new DomainModelToDtoMappingProfile()));
            AutoMapperConfiguration.Init(config);
            services.AddSingleton(AutoMapperConfiguration.Mapper);

            return services;
        }

    }
}
