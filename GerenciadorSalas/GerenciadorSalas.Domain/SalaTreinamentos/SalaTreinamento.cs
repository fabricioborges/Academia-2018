using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorSalas.Domain.Usuarios;

namespace GerenciadorSalas.Domain.SalaTreinamentos
{
    public class SalaTreinamento
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataOcupada { get; set; }
        public Usuario Usuario { get; set; }
    }
}
