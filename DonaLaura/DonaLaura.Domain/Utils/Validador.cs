using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Utils
{
    public class Validador
    {

        public static void ValidateId(long Id)
        {
            if (Id.Equals(0))
                throw new IdInvalidoException();
        }
    }
}
