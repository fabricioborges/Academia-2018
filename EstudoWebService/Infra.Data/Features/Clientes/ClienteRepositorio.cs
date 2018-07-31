using Domain.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Features.Clientes
{
    public class ClienteRepositorio : IClienteRepository
    {
        public Cliente Adicionar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Cliente> BuscarTudo()
        {
            throw new NotImplementedException();
        }

        public bool Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Editar(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
