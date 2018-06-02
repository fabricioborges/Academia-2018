using GerenciadorSalas.Domain.SalaTreinamentos;
using GerenciadorSalas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Common.Tests.Features.SalaTreinamentos
{
    public static partial class ObjectMother
    {
        public static SalaTreinamento SalaTreinamento()
        {
            return new SalaTreinamento
            {
                Id = 1,
                Quantidade = 30,
                DataOcupada = DateTime.Now,
                Usuario = new Usuario()
                {
                    Id = 1
                }
            };
        }
    }
}
