using Domain.Features.Base;
using Domain.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Features.Lojas
{
    public class Loja : Entidade
    {
        public virtual Cliente Cliente { get; set; }
    }
}
