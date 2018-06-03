using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Application.Interfaces
{
    public interface IService<T>
    {
        T Add(T objeto);

        IEnumerable<T> GetAll();

        T GetById(long Id);

        T Update(T objeto);

        void Delete(T objeto);
    }
}
