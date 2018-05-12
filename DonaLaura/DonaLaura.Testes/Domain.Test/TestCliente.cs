using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Testes.Domain.Test
{
    [TestFixture]
    public class TestCliente
    {
        Cliente _cliente;

        [SetUp]
        public void setTime()
        {
            _cliente = ObjectMother.cliente;
        }

        [Test]
        public void Test_Cliente_deve_ter_um__nome_validoOK()
        {
            _cliente.Nome.Should().Be("Fabricio");

        }

        [Test]
        public void Test_Cliente_deve_ter_um__nome_validoFailVazio()
        {
            _cliente.Nome = "";
            Action comparison = _cliente.Validar;
            comparison.Should().Throw<NomeClienteInvalidoException>();

        }

        [Test]
        public void Test_Cliente_deve_ter_um__nome_validoFail_4Caracteres()
        {
            _cliente.Nome = "asd";
            Action comparison = _cliente.Validar;
            comparison.Should().Throw<NomeClienteInvalidoException>();

        }
    }
}
