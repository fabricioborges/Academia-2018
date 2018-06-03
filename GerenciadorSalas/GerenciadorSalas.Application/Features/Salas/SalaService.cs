using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorSalas.Domain.Features.Salas;

namespace GerenciadorSalas.Application.Features
{
    public class SalaService : ISalaService
    {
        private ISalaRepository _salaRepository;

        public SalaService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public Sala Add(Sala objeto)
        {
            return _salaRepository.Add(objeto);
        }

        public void Delete(Sala objeto)
        {
            _salaRepository.Delete(objeto);
        }

        public IEnumerable<Sala> GetAll()
        {
            return _salaRepository.GetAll();
        }

        public Sala GetById(long Id)
        {
            Sala sala = _salaRepository.GetById(Id);
            return sala;
        }

        public Sala Update(Sala objeto)
        {
            return _salaRepository.Update(objeto);
        }
    }
}
