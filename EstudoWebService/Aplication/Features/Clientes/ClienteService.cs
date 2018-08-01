using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Features.Clientes;

namespace Aplication.Features.Clientes
{
    public class ClienteService : IClienteService
    {
        IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public int Add(Cliente cliente)
        {
            cliente.Validar();
            var novoCliente = _clienteRepository.Adicionar(cliente);
            return novoCliente.Id;
        }

        public IQueryable<Cliente> GetAll()
        {
            return _clienteRepository.BuscarTudo();
        }

        public Cliente GetById(int id)
        {
            return _clienteRepository.BuscarPorId(id);
        }

        public bool Remove(Cliente cmd)
        {
            return _clienteRepository.Deletar(cmd.Id);
        }

        public bool Update(Cliente cliente)
        {
            cliente.Validar();

            if (cliente == null)
                throw new Exception();

            return _clienteRepository.Editar(cliente);
        }
    }
}
