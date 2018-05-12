using DonaLaura.Domain.Features;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Testes.Domain.Test
{
    [TestFixture]
    public class TestVenda
    {
        Venda venda;
        Produto _produto;       
        [SetUp]
        public void setTime()
        {
            venda = ObjectMother.venda;
            _produto = ObjectMother.produto;
        }

        [Test]
        public void Test_Venda_Quantidade_BeOk()
        {
            venda.Quantidade.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_Venda_Quantidade_BeFail()
        {
            venda.Quantidade = 0;
            Action comparison = venda.Validar;
            comparison.Should().Throw<QuantidadeProdutoException>();
        }

        [Test]
        public void Test_Venda_deve_ter_um_produto_Ok()
        {
            venda.Produto = _produto;
            venda.Produto.Nome.Should().Be("perfume");
        }


        [Test]
        public void Test_Venda_deve_ter_um_produto_Fail()
        {
            venda.Produto = null;
            Action comparison = venda.Validar;
            comparison.Should().Throw<ProdutoVazioException>();
        }

    }
}
