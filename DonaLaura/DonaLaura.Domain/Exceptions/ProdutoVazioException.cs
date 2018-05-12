using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class ProdutoVazioException : DomainException
    {
        public ProdutoVazioException() : base("Necessário pelo menos um produto para realizar uma venda")
        {
        }
    }
}
