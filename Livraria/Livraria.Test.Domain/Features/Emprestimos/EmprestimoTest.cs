using FluentAssertions;
using Livraria.Domain.Exceptions;
using Livraria.Domain.Features.Emprestimos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Test.Domain.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoTest
    {
        Emprestimo _emprestimo;

        [SetUp]
        public void SetTime()
        {
            _emprestimo = ObjectMother.Emprestimo();
        }

        [Test]
        public void Emprestimo_deve_ter_um_nome_de_cliente_valido_BeOk()
        {
            _emprestimo.Cliente.Should().Be("Fabricio");
        }

        [Test]
        public void Emprestimo_deve_ter_um_nome_de_cliente_valido_BeFail()
        {
            _emprestimo.Cliente = "";
            Action comparison = _emprestimo.ValidarNome;
            comparison.Should().Throw<EmprestimoClienteInvalidoException>();
        }

        [Test]
        public void Emprestimo_deve_ter_um_livro_titulo_valido_BeOk()
        {
            _emprestimo.Livro.Titulo.Should().Be("Guia do Mochileiro das Galaxias");
        }

        [Test]
        public void Emprestimo_deve_ter_um_livro_titulo_valido_BeFail()
        {
            _emprestimo.Livro.Titulo = "";
            Action comparison = _emprestimo.Livro.ValidarTitulo;
            comparison.Should().Throw<TituloInvalidoException>();
        }

        [Test]
        public void Emprestimo_deve_ter_um_livro_disponivel_valido_BeOk()
        {
            _emprestimo.Livro.Disponibilidade.Should().Be(true);
        }

        [Test]
        public void Emprestimo_deve_ter_um_livro_disponivel_valido_BeFail()
        {
            _emprestimo.Livro.Disponibilidade = false;
            Action comparison = _emprestimo.ValidarDisponibilidade;
            comparison.Should().Throw<EmprestimoLivroInvalidoException>();
        }

        [Test]
        public void Emprestimo_deve_gerar_multa_atraso()
        {
            _emprestimo.DataDevolucao = DateTime.Now.AddDays(-2);

            _emprestimo.ValidarMulta();

            double obtido = _emprestimo.ValorMulta;
            obtido.Should().Be(5.00);
        }
    }
}
