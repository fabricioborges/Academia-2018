using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Domain.Features.Livros;

namespace Livraria.Application.Features.Livros
{
    public class LivroService : ILivroService
    {
        private ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public Livro Add(Livro objeto)
        {
            return _livroRepository.Add(objeto);
        }

        public void Delete(Livro objeto)
        {
            _livroRepository.Delete(objeto);
        }

        public IEnumerable<Livro> GetAll()
        {
            var lista = _livroRepository.GetAll();
            return lista;
        }

        public Livro GetById(long Id)
        {
            Livro livro = _livroRepository.GetById(Id);
            return livro;
        }

        public Livro Update(Livro objeto)
        {
            objeto.ValidarAutor();
            objeto.ValidarTema();
            objeto.ValidarTitulo();
            objeto.ValidarVolume();

            return _livroRepository.Update(objeto);
        }
    }
}
