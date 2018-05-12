using DonaLaura.Domain.Features;
using DonaLauraApplication.Features;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Testes.Application.Features.Vendas
{
    [TestFixture]
    public class VendaServiceTest
    {
        private VendaService Alvo;

        private Mock<IVendaRepository> _mock;

        Venda _venda;
        Produto _produto;
        Cliente _cliente;

        [SetUp]
        public void VendaService_Set()
        {
            _mock = new Mock<IVendaRepository>();
            Alvo = new VendaService(_mock.Object);
            _produto = new Produto();
            _cliente = new Cliente();

            _venda = new Venda()
            {

                Produto = _produto,
                Id = 1,
                Lucro = _produto.PrecoVenda - _produto.PrecoCusto,
                Quantidade = 5,
                Cliente = new Cliente
                {
                    Nome = "Fabricio"
                }
            };
        }

        [Test]
        public void TestVendaService_AddTest_ShouldBeOK()
        {

            _mock.Setup(x => x.Save(_venda)).Returns(new Venda { Id = 1 });

            var obtido = Alvo.Add(_venda);

            _mock.Verify(x => x.Save(_venda));
            obtido.Id.Should().BeGreaterThan(0);
        }

       

        [Test]
        public void TestVendaService_GetAllTest_ShouldBeOK()
        {

            _mock.Setup(x => x.GetAll()).Returns(new List<Venda>() {
               _venda
            });

            var obtido = Alvo.GetAll();
            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_venda);
        }

        [Test]
        public void TestVendaService_GetById_ShouldBeOK()
        {
            _mock.Setup(x => x.GetById(_venda.Id)).Returns(_venda);

            var obtido = Alvo.GetById(_venda.Id);

            _mock.Verify(x => x.GetById(_venda.Id));
            _venda.Should().Be(obtido);
        }

        [Test]
        public void TestVendaService_DeleteTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Delete(_venda));

            Alvo.Delete(_venda);

            _mock.Verify(x => x.Delete(_venda));
        }

        [Test]
        public void TestVendaService_UpdateTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Update(_venda)).Returns(new Venda() { Id = 1 });

            var obtido = Alvo.Update(_venda);

            _mock.Verify(x => x.Update(_venda));
            obtido.Id.Should().BeGreaterThan(0);
        }

    }
}
