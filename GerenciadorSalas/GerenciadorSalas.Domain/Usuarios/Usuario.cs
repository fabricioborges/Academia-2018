using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Domain.Usuarios
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }

        public virtual void Validar()
        {
            ValidarNome();
            ValidarSetor();
        }

        private void ValidarSetor()
        {
            if (String.IsNullOrEmpty(Setor))
                throw new SetorInvalidoException();
        }

        private void ValidarNome()
        {
            if (String.IsNullOrEmpty(Nome))
                throw new NomeInvalidoException();
        }
    }
}
