using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class DisponibilidadeException : DomainException
    {
        public DisponibilidadeException() : base("Produto deve ser disponível")
        {
        }
    }
}
