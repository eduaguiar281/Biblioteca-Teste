using Microsoft.EntityFrameworkCore;
using System;

namespace PSD.Biblioteca.Infraestrutura
{
    public static class DatabaseInitializer
    {
        public static void Initialize(BibliotecaDbContext context)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                context.Database.Migrate();
            }
        }

    }
}
