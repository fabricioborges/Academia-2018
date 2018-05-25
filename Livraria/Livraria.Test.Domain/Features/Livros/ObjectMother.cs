using Livraria.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Test.Domain.Features.Livros
{
    public static partial class ObjectMother
    {
        public static Livro Livro()
        {
            
            return new Livro
            {
                Id = 1,
                Titulo = "Guia do Mochileiro das Galaxias",
                Tema = "Ficção",
                Autor = "Douglas Adams",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddYears(-39),
                Disponibilidade = true

            };

        }
    }
}
