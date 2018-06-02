using GerenciadorSalas.Domain.SalaConferencias;
using GerenciadorSalas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Common.Tests.Features.SalaConferencias
{
    public static partial class ObjectMother
    {
        public static SalaConferencia SalaConferencia()
        {
            return new SalaConferencia
            {
                Id = 1,
                Quantidade = 5,
                DataOcupada = DateTime.Now,
                Usuario = new Usuario()
                {
                    Id = 1
                }
            };
        }
    }
}
