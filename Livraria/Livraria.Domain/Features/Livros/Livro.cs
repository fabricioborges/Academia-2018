using Livraria.Domain.Exceptions;
using System;
using System.Linq;

namespace Livraria.Domain.Features.Livros
{
    public class Livro
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Tema { get; set; }
        public string Autor { get; set; }
        public int Volume { get; set; }
        public DateTime DataPublicacao { get; set; }
        public bool Disponibilidade { get; set; }

        public void ValidarAutor()
        {
            if (Autor.Count() < 4)
                throw new AutorInvalidoException();
        }

        public void ValidarTitulo()
        {
            if (Titulo.Count() < 4)
                throw new TituloInvalidoException();
        }

        public void ValidarTema()
        {
            if (Tema.Count() < 4)
                throw new TemaInvalidoException();
        }

        public void ValidarVolume()
        {
            if (Volume < 1)
                throw new VolumeInvalidoException();
        }
    }
}
