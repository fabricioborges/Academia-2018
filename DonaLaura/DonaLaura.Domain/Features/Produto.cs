using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features
{
    public class Produto
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public double PrecoVenda { get; set; }

        public double PrecoCusto { get; set; }

        public bool Disponibilidade { get; set; }

        public DateTime DataFabricacao { get; set; }

        public DateTime Validade { get; set; }

       
        public void Validar()
        {
            if (Nome.Length <= 4)
                throw new NomeInvalidoException();

            if (PrecoCusto > PrecoVenda)
                throw new PrecoInvalidoException();

            if (Validade < DataFabricacao)
                throw new DataValidadeException();

            if (Disponibilidade == false)
                throw new DisponibilidadeException();
        }




    }
}
