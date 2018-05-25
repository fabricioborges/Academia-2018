using Livraria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Features.Livros
{
    public class AutorInvalidoException : DomainException
    {
        public AutorInvalidoException() : base("Nome do autor deve conter pelo menos 4 caracteres!")
        {
        }
    }
}
