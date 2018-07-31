using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Features.Clientes
{
    public interface IClienteRepository
    {
        Cliente Adicionar(Cliente cliente);

        bool Editar(Cliente cliente);

        Cliente BuscarPorId(int id);

        IQueryable<Cliente> BuscarTudo();

        bool Deletar(int id);
    }
}
