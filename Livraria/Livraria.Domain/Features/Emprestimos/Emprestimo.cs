using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Domain.Features.Livros;

namespace Livraria.Domain.Features.Emprestimos
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double Multa { get; set; }
        public Livro Livro { get; set; }
        public double ValorMulta { get; set; }
        public void ValidarNome()
        {
            if (String.IsNullOrEmpty(Cliente))
                throw new EmprestimoClienteInvalidoException();
        }

        public void ValidarDisponibilidade()
        {
            if (Livro.Disponibilidade == false)
                throw new EmprestimoLivroInvalidoException();
        }

        public double ValidarMulta()
        {
            
            if (DataDevolucao.Day < DateTime.Now.Day)
            {
                TimeSpan data = DateTime.Now - DataDevolucao;
                int dataAtraso = Convert.ToInt32(data.Days);
                ValorMulta = 2.50 * dataAtraso;
               
            }
           
            return ValorMulta;
        }
    }
}
