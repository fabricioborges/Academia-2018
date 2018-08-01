using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Features.Clientes;
using Domain.Features.Lojas;

namespace Aplication.Features.Lojas
{
    public class LojaService : ILojaService
    {
        ILojaRepository _lojaRepository;
        IClienteRepository _clienteRepository;

        public LojaService(ILojaRepository lojaRepository, IClienteRepository clienteRepository)
        {
            _lojaRepository = lojaRepository;
            _clienteRepository = clienteRepository;
        }

        public int Add(Loja loja)
        {
            loja.Validar();
            loja.Cliente = _clienteRepository.BuscarPorId(loja.Cliente.Id)?? throw new Exception();
            var novaLoja = _lojaRepository.Adicionar(loja);

            return novaLoja.Id;
        }

        public IQueryable<Loja> GetAll()
        {
            return _lojaRepository.BuscarTudo();
        }

        public Loja GetById(int id)
        {
            return _lojaRepository.BuscarPorId(id);
        }

        public bool Remove(Loja cmd)
        {
            return _lojaRepository.Deletar(cmd.Id);
        }

        public bool Update(Loja loja)
        {
            loja.Validar();

            if (loja == null)
                throw new Exception();

            return _lojaRepository.Editar(loja);
        }
    }
}
