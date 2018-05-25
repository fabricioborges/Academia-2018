using Livraria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Features.Emprestimos
{
    public class EmprestimoClienteInvalidoException : DomainException
    {
        public EmprestimoClienteInvalidoException() : base("Cliente deve ter um nome!")
        {
        }
    }
}
