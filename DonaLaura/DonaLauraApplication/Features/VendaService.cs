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
    public class VendaService : IVendaService
    {
        private IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public Venda Add(Venda objeto)
        {
            return _vendaRepository.Save(objeto);
        }

        public void Delete(Venda objeto)
        {
            _vendaRepository.Delete(objeto);
        }

        public IEnumerable<Venda> GetAll()
        {
            var list = _vendaRepository.GetAll();
            foreach (var item in list)
            {
                Validador.ValidateId(item.Id);
            }
            return list;
        }

        public Venda GetById(long Id)
        {
            Validador.ValidateId(Id);
            Venda venda = _vendaRepository.GetById(Id);
            Validador.ValidateId(venda.Id);
            return venda;
        }

        public Venda Update(Venda objeto)
        {
            Validador.ValidateId(objeto.Id);
            objeto.Validar();
            return _vendaRepository.Update(objeto);
        }
    }
}
