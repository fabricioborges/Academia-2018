using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Features.Base
{
    public abstract class Entidade
    {
        public virtual int Id{ get; set; }
        public virtual string Nome { get; set; }
        public virtual void Validar() { }
    }
}
