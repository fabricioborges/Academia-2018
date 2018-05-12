using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features
{
    public class Venda
    {
        public long Id { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public double Lucro { get; set; }

        public Cliente Cliente { get; set; }

        public void Validar()
        {
            if (Quantidade == 0)
                throw new QuantidadeProdutoException();

            if (Produto == null)
                throw new ProdutoVazioException();
        }

    }
}
