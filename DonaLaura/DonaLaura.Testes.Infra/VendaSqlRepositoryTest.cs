using DonaLaura.Domain.Features;
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
    class VendaSqlRepositoryTest
    {
        VendaSqlRepository _vendaSqlRepository;
        Venda _venda;
    

        [SetUp]
        public void ProdutoRepository_Set()
        {
            _vendaSqlRepository = new VendaSqlRepository();
            _venda = new Venda()
            {
                Lucro = 5.00,
                Quantidade = 5
            };
            
        }


        [Test]
        public void TestVendaRepository_Save_Should_BeOk()
        {
            _vendaSqlRepository.Save(_venda);
            _venda.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void TestVendaRepository_GetById_ShouldBeOk()
        {
            _venda.Id = 1;
            var teste = _vendaSqlRepository.GetById(_venda.Id);
            teste.Id.Should().Be(_venda.Id);
        }

        [Test]
        public void TestVendaRepository_GetAll_ShouldBeOk()
        {
            var teste = _vendaSqlRepository.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void TestVendaRepository_Update_Should_BeOk()
        {
            _venda.Lucro = 10.50;
            _venda.Id = 1;
            _vendaSqlRepository.Update(_venda);

        }

        [Test]
        public void TestVendaRepository_Delete_ShouldBeOk()
        {
            _venda.Id = 1;
            _vendaSqlRepository.Delete(_venda);
        }

    }
}
