﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class NomeClienteInvalidoException : DomainException
    {
        public NomeClienteInvalidoException() : base("Cliente deve ter um nome válido")
        {
        }
    }
}
