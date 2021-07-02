using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSD.Biblioteca.ObjetosDeValor;

namespace PSD.Biblioteca.Infraestrutura
{
    public static class BibliotecaTypeConverters
    {
        public static readonly ValueConverter<Autor, string> AutorConverter = new ValueConverter<Autor, string>(
            autor => autor.Valor,
            autorValor => Autor.Criar(autorValor).Value);

        public static readonly ValueConverter<Titulo, string> TituloConverter = new ValueConverter<Titulo, string>(
            titulo => titulo.Valor,
            tituloValor => Titulo.Criar(tituloValor).Value);
    }
}
