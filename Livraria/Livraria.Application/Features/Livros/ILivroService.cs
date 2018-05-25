using Livraria.Application.Interfaces;
using Livraria.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Features.Livros
{
    public interface ILivroService : IService<Livro>
    {
    }
}
