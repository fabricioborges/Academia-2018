using Domain.Features.Lojas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Features.Lojas
{
    public class LojaRepository : ILojaRepository
    {
        public Loja Adicionar(Loja loja)
        {
            throw new NotImplementedException();
        }

        public Loja BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Loja> BuscarTudo()
        {
            throw new NotImplementedException();
        }

        public bool Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Editar(Loja loja)
        {
            throw new NotImplementedException();
        }
    }
}
