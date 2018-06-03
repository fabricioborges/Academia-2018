using GerenciadorSalas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Domain.Features.Salas
{
    public class DataInvalidaException : BusinessException
    {
        public DataInvalidaException() : base("Data final deve ser maior que a inicial")
        {
        }
    }
}
