using Domain.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Features.Clientes
{
    public interface IClienteService
    {
        int Add(Cliente cliente);

        bool Update(Cliente cliente);

        Cliente GetById(int id);

        IQueryable<Cliente> GetAll();

        bool Remove(Cliente cmd);
    }
}
