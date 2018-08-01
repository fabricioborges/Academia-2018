using Domain.Features.Lojas;
using Infra.Data.Features.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Features.Lojas
{
    public class LojaRepository : ILojaRepository
    {
        public WebContexto _webContexto;

        public LojaRepository(WebContexto webContexto)
        {
            _webContexto = webContexto;
        }

        public Loja Adicionar(Loja loja)
        {
            _webContexto.Clientes.Attach(loja.Cliente);

            var novaLoja = _webContexto.Lojas.Add(loja);

            _webContexto.SaveChanges();

            return novaLoja;
        }

        public Loja BuscarPorId(int id)
        {
            return _webContexto.Lojas.Where(l => l.Id == id).FirstOrDefault();
        }

        public IQueryable<Loja> BuscarTudo()
        {
            return _webContexto.Lojas.Include("Cliente");
        }

        public bool Deletar(int id)
        {
            var lojaDelete = _webContexto.Lojas.Where(l => l.Id == id).FirstOrDefault();

            if (lojaDelete == null)
                throw new Exception();

            _webContexto.Entry(lojaDelete).State = EntityState.Deleted;

            return _webContexto.SaveChanges() > 0;
        }

        public bool Editar(Loja loja)
        {
            _webContexto.Entry(loja).State = EntityState.Modified;

            return _webContexto.SaveChanges() > 0;
        }
    }
}
