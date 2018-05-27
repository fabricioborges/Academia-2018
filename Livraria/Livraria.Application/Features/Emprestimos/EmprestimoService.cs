using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Domain.Features.Emprestimos;

namespace Livraria.Application.Features.Emprestimos
{
    public class EmprestimoService : IEmprestimoService
    {
        private IEmprestimoRepository _emprestimoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public Emprestimo Add(Emprestimo objeto)
        {
            return _emprestimoRepository.Add(objeto);
        }

        public void Delete(Emprestimo objeto)
        {
            _emprestimoRepository.Delete(objeto);
        }

        public IEnumerable<Emprestimo> GetAll()
        {
            var lista = _emprestimoRepository.GetAll();
            return lista;
        }

        public Emprestimo GetById(long Id)
        {
            Emprestimo emprestimo = _emprestimoRepository.GetById(Id);
            return emprestimo;
        }

        public Emprestimo Update(Emprestimo objeto)
        {
            objeto.ValidarDisponibilidade();
            objeto.Livro.ValidarTitulo();
            return objeto;
        }
    }
}
