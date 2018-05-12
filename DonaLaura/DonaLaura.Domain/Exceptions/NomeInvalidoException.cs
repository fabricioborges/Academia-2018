﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class NomeInvalidoException : DomainException
    {
        public NomeInvalidoException() : base("Nome inválido, tem que ser maior que  4 caracteres.")
        {
        }
    }
}
