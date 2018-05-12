using System;
using System.Runtime.Serialization;

namespace DonaLaura.Domain.Exceptions
{
    
    public class DomainException : Exception
    {
        

        public DomainException(string message) : base(message)
        {
        }

        
    }
}