using GerenciadorSalas.Application.Interfaces;
using GerenciadorSalas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Application.Features.Usuarios
{
    public interface IUsuarioService : IService<Usuario>
    {
    }
}
