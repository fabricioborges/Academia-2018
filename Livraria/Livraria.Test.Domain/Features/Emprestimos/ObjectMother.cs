using Livraria.Domain.Features.Emprestimos;
using Livraria.Domain.Features.Livros;
using System;

namespace Livraria.Test.Domain.Features.Emprestimos
{
    public static partial class ObjectMother
    {
        public static Emprestimo Emprestimo()
        {
            return new Emprestimo
            {
                Id = 1,
                Cliente = "Fabricio",
                DataDevolucao = DateTime.Now,
                Multa = 10.50,
                
                Livro = new Livro()
                {
                    Id = 1,
                    Titulo = "Guia do Mochileiro das Galaxias",
                    Disponibilidade = true
                }
            };
        }
    }
}
