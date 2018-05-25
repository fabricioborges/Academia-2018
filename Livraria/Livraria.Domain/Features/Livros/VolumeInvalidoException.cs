using Livraria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Features.Livros
{
    public class VolumeInvalidoException : DomainException
    {
        public VolumeInvalidoException() : base("Volume deve ser maior que zero!")
        {
        }
    }
}
