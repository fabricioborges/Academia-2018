using GerenciadorSalas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Domain.Features.Salas
{
    public class NomeSalaInvalidoException : BusinessException
    {
        public NomeSalaInvalidoException() : base("Nome da sala invalido ou vazio")
        {
        }
    }
}
