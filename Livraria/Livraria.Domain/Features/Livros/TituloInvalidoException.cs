namespace Livraria.Domain.Exceptions
{
    public class TituloInvalidoException : DomainException
    {
        public TituloInvalidoException() : base("Título deve conter pelo menos 4 caracteres!")
        {
        }
    }
}
