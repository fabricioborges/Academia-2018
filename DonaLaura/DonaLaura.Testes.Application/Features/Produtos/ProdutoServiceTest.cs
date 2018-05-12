using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using DonaLauraApplication.Features;
using Moq;
using DonaLaura.Domain.Features;

namespace DonaLaura.Testes.Application.Features.Produtos
{
    [TestFixture]
    public class ProdutoServiceTest
    {
        private ProdutoService Alvo;

        private Mock<IProdutoRepository> _mock;

        Produto _produto;

        [SetUp]
        public void PostService_Set()
        {
            _mock = new Mock<IProdutoRepository>();
            Alvo = new ProdutoService(_mock.Object);
            _produto = new Produto()
            {
                Id = 1,
                Nome = "shampoo",
                Validade = DateTime.Now.AddYears(1),
                DataFabricacao = DateTime.Now,
                PrecoCusto = 10.00,
                PrecoVenda = 15.00,
                Disponibilidade = true,
            };
        }

        [Test]
        public void TestProdutoService_AddTest_ShouldBeOK()
        {

            _mock.Setup(x => x.Save(_produto)).Returns(new Produto() { Id = 1 });

            var obtido = Alvo.Add(_produto);

            _mock.Verify(x => x.Save(_produto));
            obtido.Id.Should().BeGreaterThan(0);
        }


        [Test]
        public void TestProdutoService_DeleteTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Delete(_produto));

            Alvo.Delete(_produto);

            _mock.Verify(x => x.Delete(_produto));
        }

        [Test]
        public void TestProdutoService_GetAllTest_ShouldBeOK()
        {

            _mock.Setup(x => x.GetAll()).Returns(new List<Produto>() {
               _produto
            });

            var obtido = Alvo.GetAll();
            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_produto);
        }

        [Test]
        public void TestProdutoService_GetById_ShouldBeOK()
        {
            _mock.Setup(x => x.GetById(_produto.Id)).Returns(_produto);

            var obtido = Alvo.GetById(_produto.Id);

            _mock.Verify(x => x.GetById(_produto.Id));
            _produto.Should().Be(obtido);
        }

        [Test]
        public void TestProdutoService_UpdateTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Update(_produto)).Returns(new Produto() { Id = 1 });

            var obtido = Alvo.Update(_produto);

            _mock.Verify(x => x.Update(_produto));
            obtido.Id.Should().BeGreaterThan(0);
        }

    }
}
