using GerenciadorSalas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Domain.Usuarios
{
    public class NomeInvalidoException : BusinessException
    {
        public NomeInvalidoException() : base("Nome inválido ou vazio")
        {
        }
    }
}
