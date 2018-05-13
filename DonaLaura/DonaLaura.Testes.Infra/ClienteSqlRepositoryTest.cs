using DonaLaura.Domain.Features;
using DonaLaura.Infra;
using DonaLaura.Infra.Data.Features;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Testes.Infra
{
    [TestFixture]
    class ClienteSqlRepositoryTest
    {

        ClienteSqlRepository _clienteRepository;
        Cliente _cliente;


        [SetUp]
        public void ClienteRepository_Set()
        {
            _clienteRepository = new ClienteSqlRepository();
            _cliente = new Cliente()
            {
                Nome = "Fabricio"
            };
            BaseSqlTest.SeedDatabaseCliente();
        }

        [Test]
        public void TestClienteRepository_Save_Should_BeOk()
        {
            _clienteRepository.Save(_cliente);
            _cliente.Id.Should().BeGreaterThan(0);
        }

      
        [Test]
        public void TestClienteRepository_Update_Should_BeOk()
        {
            _cliente.Nome = "João";
            _cliente.Id = 1;
            _clienteRepository.Update(_cliente);

        }
        [Test]
        public void TestClienteRepository_GetById_ShouldBeOk()
        {
            _cliente.Id = 1;
            var teste = _clienteRepository.GetById(_cliente.Id);
            teste.Id.Should().Be(_cliente.Id);
        }
        [Test]
        public void TestClienteRepository_GetAll_ShouldBeOk()
        {
            var teste = _clienteRepository.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }



        [Test]
        public void TestClienteRepository_Delete_ShouldBeOk()
        {
            _cliente.Id = 1;
            _clienteRepository.Delete(_cliente);
        }

    }
}
