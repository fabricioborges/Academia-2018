using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class PrecoInvalidoException : DomainException
    {
        public PrecoInvalidoException() : base("Preço de venda tem que ser maior que preço de custo.")
        {
        }
    }
}
