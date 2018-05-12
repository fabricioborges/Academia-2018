using DonaLaura.Domain.Features;
using DonaLaura.Domain.Utils;
using DonaLauraApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLauraApplication.Features
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Add(Cliente objeto)
        {
            return _clienteRepository.Save(objeto);
        }

        public void Delete(Cliente objeto)
        {
            _clienteRepository.Delete(objeto);
        }

        public IEnumerable<Cliente> GetAll()
        {
            var list = _clienteRepository.GetAll();
            foreach (var item in list)
            {
                Validador.ValidateId(item.Id);
            }
            return list;
        }

        public Cliente GetById(long Id)
        {
            Validador.ValidateId(Id);
            Cliente cliente = _clienteRepository.GetById(Id);
            Validador.ValidateId(cliente.Id);
            return cliente;
        }

        public Cliente Update(Cliente objeto)
        {
            Validador.ValidateId(objeto.Id);
            objeto.Validar();
            return _clienteRepository.Update(objeto);
        }
    }
}
