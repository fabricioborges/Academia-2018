using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorSalas.Domain.Usuarios;

namespace GerenciadorSalas.Application.Features.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public Usuario Add(Usuario objeto)
        {
            return _usuarioRepository.Add(objeto);
        }

        public void Delete(Usuario objeto)
        {
            _usuarioRepository.Delete(objeto);
        }

        public IEnumerable<Usuario> GetAll()
        {
            var lista = _usuarioRepository.GetAll();
            return lista;
        }

        public Usuario GetById(long Id)
        {
            Usuario usuario = _usuarioRepository.GetById(Id);
            return usuario;
        }

        public Usuario Update(Usuario objeto)
        {
            objeto.Validar();
            return _usuarioRepository.Update(objeto);
        }
    }
}
