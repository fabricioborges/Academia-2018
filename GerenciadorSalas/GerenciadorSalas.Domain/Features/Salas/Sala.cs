using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorSalas.Domain.Usuarios;

namespace GerenciadorSalas.Domain.Features.Salas
{
    public class Sala
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataFim { get; set; }
        public int Quantidade { get; set; }

        public void Validar()
        {
            ValidarData();
            ValidarNome();
            ValidarLugares();
        }

        private void ValidarLugares()
        {
            if (Quantidade <= 0)
                throw new QuantidadeInvalidaException();
        }

        private void ValidarNome()
        {
            if (String.IsNullOrEmpty(Nome))
                throw new NomeSalaInvalidoException();
        }

        private void ValidarData()
        {
            if (DataFim <= DataInicio)
                throw new DataInvalidaException();
        }
    }
}
