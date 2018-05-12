using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features
{
    public class Cliente
    {
        public string Nome { get; set; }

        public long Id { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new NomeClienteInvalidoException();

            if (Nome.Length < 4)
                throw new NomeClienteInvalidoException();
               
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
