using Domain.Features.Lojas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Features.Lojas
{
    public interface ILojaService
    {
        int Add(Loja loja);

        bool Update(Loja loja);

        Loja GetById(int id);

        IQueryable<Loja> GetAll();

        bool Remove(Loja cmd);
    }
}
