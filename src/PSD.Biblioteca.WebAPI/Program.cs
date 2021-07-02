using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PSD.Biblioteca.Infraestrutura;
using System;

namespace PSD.Biblioteca.WebAPI
{
    public class Program
    {
        private Program()
        {

        }
        public static void Main(string[] args)
        {
            try
            {
                IHost host = CreateHostBuilder(args).Build();
                CriarBancoDeDadosSeNaoExistir(host);
                host.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Aplicação interrompida inexperadamente. {ex}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CriarBancoDeDadosSeNaoExistir(IHost host)
        {
            using var scope = host.Services.CreateScope();
            IServiceProvider services = scope.ServiceProvider;
            var context = services.GetRequiredService<BibliotecaDbContext>();
            DatabaseInitializer.Initialize(context);
        }

    }
}
