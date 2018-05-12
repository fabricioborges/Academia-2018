using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class QuantidadeProdutoException : DomainException
    {
        public QuantidadeProdutoException() : base("Quantidade deve ser maior que zero")
        {
        }
    }
}
