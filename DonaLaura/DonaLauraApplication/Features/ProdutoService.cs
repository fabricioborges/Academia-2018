using DonaLaura.Domain.Features;
using DonaLaura.Domain.Utils;
using DonaLauraApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLauraApplication.Features
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto Add(Produto objeto)
        {
            return _produtoRepository.Save(objeto);
        }

        public void Delete(Produto objeto)
        {
            _produtoRepository.Delete(objeto);
        }

        public IEnumerable<Produto> GetAll()
        {
            var list = _produtoRepository.GetAll();
            foreach (var item in list)
            {
                Validador.ValidateId(item.Id);
            }
            return list;
        }

        public Produto GetById(long Id)
        {
            Validador.ValidateId(Id);
            Produto produto = _produtoRepository.GetById(Id);
            Validador.ValidateId(produto.Id);
            return produto;
        }

        public Produto Update(Produto objeto)
        {
            Validador.ValidateId(objeto.Id);
            objeto.Validar();
            return _produtoRepository.Update(objeto);
        }
    }
}
