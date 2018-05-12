using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class DataValidadeException : DomainException
    {
        public DataValidadeException() : base("Validade tem que ser maior que a fabricação.")
        {
        }
    }
}
