using GerenciadorSalas.Domain.Features.Salas;
using GerenciadorSalas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Common.Tests.Features.Salas
{
    public static partial class ObjectMother
    {
        public static Sala Sala()
        {
            return new Sala
            {
                Id = 1,
                Nome = "Treinamento",
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddHours(2),
                Quantidade = 5,
                Usuario = new Usuario()
                {
                    Id = 1,
                    Nome = "Fabricio",
                    Setor = "Desenvolvimento"
                }

                
            };

        }
    }
}
