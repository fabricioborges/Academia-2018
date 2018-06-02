using GerenciadorSalas.Domain.SalasReunioes;
using GerenciadorSalas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Common.Tests.Features.SalasReunioes
{
    public static partial class ObjectMother
    {
        public static SalaReuniao SalaReuniao()
        {
            return new SalaReuniao
            {
                Id = 1,
                Quantidade = 3,
                DataOcupada = DateTime.Now,
                Usuario = new Usuario()
                {
                    Id = 1
                }
            };
        }
    }
}
