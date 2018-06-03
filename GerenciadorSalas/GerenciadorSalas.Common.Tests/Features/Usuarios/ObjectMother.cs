using GerenciadorSalas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Common.Tests.Features.Usuarios
{
    public static partial class ObjectMother
    {
        public static Usuario Usuario()
        {
            return new Usuario
            {
                Id = 1,
                Nome = "Usuario",
                Setor = "Desenvolvimento"
            };
        }
    }
}
