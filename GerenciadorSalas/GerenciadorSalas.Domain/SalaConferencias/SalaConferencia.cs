using GerenciadorSalas.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Domain.SalaConferencias
{
    public class SalaConferencia
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataOcupada { get; set; }
        public Usuario Usuario { get; set; }
    }
}
