using GerenciadorSalas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Domain.Features.Salas
{
    public class QuantidadeInvalidaException : BusinessException
    {
        public QuantidadeInvalidaException() : base("Quantidade de lugares deve ser maior que 0")
        {
        }
    }
}
