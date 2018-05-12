using System;
using DonaLaura.Domain.Features;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FluentAssertions;
using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Testes.Domain.Test
{
    [TestFixture]
    public class TestProduto
    {
        Produto produto;
        [SetUp]
        public void setTime()
        {
            produto = ObjectMother.produto;
        }

        [Test]
        public void Test_Produto_deve_ter_um__nome_validoOK()
        {
            produto.Nome.Should().Be("perfume");

        }

        [Test]
        public void Test_Produto_deve_ter_um__nome_validoFailVazio()
        {
            produto.Nome = "";
            Action comparison = produto.Validar;
            comparison.Should().Throw<NomeInvalidoException>();

        }

        [Test]
        public void Test_Produto_deve_ter_um__nome_validoFail_4Caracteres()
        {
            produto.Nome = "asd";
            Action comparison = produto.Validar;
            comparison.Should().Throw<NomeInvalidoException>();

        }

        [Test]
        public void Test_Produto_deve_ter_validade_maior_dataFabricacao_Ok()
        {
            produto.Validade.Should().BeAfter(produto.DataFabricacao);
        }

        [Test]
        public void Test_Produto_deve_ter_validade_maior_dataFabricacao_Fail()
        {
            produto.Validade = DateTime.Now.AddYears(-2);
            Action comparison = produto.Validar;
            comparison.Should().Throw<DataValidadeException>();
        }

        [Test]
        public void Test_Produto_deve_ser_disponivel_Ok()
        {
            produto.Disponibilidade.Should().BeTrue();
        }

        [Test]
        public void Test_Produto_deve_ser_disponivel_Fail()
        {
            produto.Disponibilidade = false;
            Action comparison = produto.Validar;
            comparison.Should().Throw<DisponibilidadeException>();
        }

        [Test]
        public void Test_Produto_precovenda_deve_ser_Maior_precocusto_Ok()
        {
            produto.PrecoVenda.Should().BeGreaterThan(produto.PrecoCusto);
        }

        [Test]
        public void Test_Produto_quantidade_deve_ser_Maior_Zero_Fail()
        {
            produto.PrecoVenda = 5.00;
            Action comparison = produto.Validar;
            comparison.Should().Throw<PrecoInvalidoException>();
        }
    }
}
