using Domain.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Features.Lojas
{
    public interface ILojaRepository
    {
        Loja Adicionar(Loja loja);

        bool Editar(Loja loja);

        Loja BuscarPorId(int id);

        IQueryable<Loja> BuscarTudo();

        bool Deletar(int id);
    }
}
