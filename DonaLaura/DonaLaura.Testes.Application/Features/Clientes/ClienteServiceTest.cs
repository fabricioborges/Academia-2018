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

namespace DonaLaura.Testes.Application.Features.Clientes
{
    [TestFixture]
    public class ClienteServiceTest
    {
        private ClienteService Alvo;

        private Mock<IClienteRepository> _mock;

        Cliente _cliente;

        [SetUp]
        public void PostService_Set()
        {
            _mock = new Mock<IClienteRepository>();
            Alvo = new ClienteService(_mock.Object);
            _cliente = new Cliente()
            {
                Id = 1,
                Nome = "Fabricio"
                
            };
        }

        [Test]
        public void TestClienteService_AddTest_ShouldBeOK()
        {

            _mock.Setup(x => x.Save(_cliente)).Returns(new Cliente() { Id = 1 });

            var obtido = Alvo.Add(_cliente);

            _mock.Verify(x => x.Save(_cliente));
            obtido.Id.Should().BeGreaterThan(0);
        }


        [Test]
        public void TestClienteService_DeleteTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Delete(_cliente));

            Alvo.Delete(_cliente);

            _mock.Verify(x => x.Delete(_cliente));
        }

        [Test]
        public void TestClienteService_GetAllTest_ShouldBeOK()
        {

            _mock.Setup(x => x.GetAll()).Returns(new List<Cliente>() {
               _cliente
            });

            var obtido = Alvo.GetAll();
            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_cliente);
        }

        [Test]
        public void TestClienteService_GetById_ShouldBeOK()
        {
            _mock.Setup(x => x.GetById(_cliente.Id)).Returns(_cliente);

            var obtido = Alvo.GetById(_cliente.Id);

            _mock.Verify(x => x.GetById(_cliente.Id));
            _cliente.Should().Be(obtido);
        }

        [Test]
        public void TestClienteService_UpdateTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Update(_cliente)).Returns(new Cliente { Id = 1 });

            var obtido = Alvo.Update(_cliente);

            _mock.Verify(x => x.Update(_cliente));
            obtido.Id.Should().BeGreaterThan(0);
        }

    }
}
