using Domain.Features.Clientes;
using Infra.Data.Features.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Features.Clientes
{
    public class ClienteRepositorio : IClienteRepository
    {
        public WebContexto _webContexto;

        public ClienteRepositorio(WebContexto webContexto)
        {
            _webContexto = webContexto;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            var novoCliente = _webContexto.Clientes.Add(cliente);

            _webContexto.SaveChanges();

            return novoCliente;
        }

        public Cliente BuscarPorId(int id)
        {
            return _webContexto.Clientes.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<Cliente> BuscarTudo()
        {
            return _webContexto.Clientes;
        }

        public bool Deletar(int id)
        {
            var cliente = _webContexto.Clientes.Where(c => c.Id == id).FirstOrDefault();

            if (cliente == null)
                throw new Exception();

            _webContexto.Entry(cliente).State = EntityState.Deleted;

            return _webContexto.SaveChanges() > 0   ;
        }

        public bool Editar(Cliente cliente)
        {
            _webContexto.Entry(cliente).State = EntityState.Modified;

            return _webContexto.SaveChanges() > 0;
        }
    }
}
