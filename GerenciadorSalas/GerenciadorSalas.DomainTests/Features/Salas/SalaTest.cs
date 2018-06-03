using FluentAssertions;
using GerenciadorSalas.Common.Tests.Features.Salas;
using GerenciadorSalas.Domain.Features.Salas;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.DomainTests.Features.Salas
{
    [TestFixture]
    public class SalaTest
    {
        Sala _sala;

        [SetUp]
        public void SalaTest_Set()
        {
            _sala = ObjectMother.Sala();
        }

        [Test]
        public void Sala_deve_ter_um_nome_valido_Ok()
        {
            _sala.Nome.Should().Be("Treinamento");
            _sala.Validar();
        }

        [Test]
        public void Sala_deve_ter_um_nome_invalido()
        {
            _sala.Nome = "";
            Action comparison = _sala.Validar;
            comparison.Should().Throw<NomeSalaInvalidoException>();
        }

        [Test]
        public void Sala_deve_ter_uma_data_valida()
        {
            _sala.DataInicio = DateTime.Now;
            _sala.DataFim = DateTime.Now.AddDays(2);
            _sala.Validar();
            
        }

        [Test]
        public void Sala_deve_ter_uma_data_invalida()
        {
            _sala.DataFim = DateTime.Now.AddDays(-1);
            Action comparison = _sala.Validar;
            comparison.Should().Throw<DataInvalidaException>();
        }

        [Test]
        public void Sala_deve_ter_uma_quantidade_valida_Ok()
        {
            _sala.Quantidade.Should().BeGreaterThan(0);
            _sala.Validar();
        }

        [Test]
        public void Sala_deve_ter_uma_quantidade_invalida()
        {
            _sala.Quantidade = 0;
            Action comparison = _sala.Validar;
            comparison.Should().Throw<QuantidadeInvalidaException>();
        }
    }
}
