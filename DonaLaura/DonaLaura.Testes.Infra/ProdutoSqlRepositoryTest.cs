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
    class ProdutoSqlRepositoryTest
    {
        ProdutoSqlRepository _produtoSqlRepository;
        Produto _produto;


        [SetUp]
        public void ProdutoRepository_Set()
        {
            _produtoSqlRepository = new ProdutoSqlRepository();
            _produto = new Produto()
            {
                Nome = "Shampoo",
                Validade = DateTime.Now.AddYears(1),
                DataFabricacao = DateTime.Now.AddYears(-1),
                Disponibilidade = true,
                PrecoCusto = 10.00,
                PrecoVenda = 15.00
            };
            BaseSqlTest.SeedDatabaseProduto();
        }

        [Test]
        public void TestProdutoRepository_Save_Should_BeOk()
        {
            _produtoSqlRepository.Save(_produto);
            _produto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void TestProdutoRepository_GetById_ShouldBeOk()
        {
            _produto.Id = 1;
            var teste = _produtoSqlRepository.GetById(_produto.Id);
            teste.Id.Should().Be(_produto.Id);
        }

        [Test]
        public void TestProdutoRepository_Update_Should_BeOk()
        {
            _produto.Nome = "Sabonete";
            _produto.Id = 1;
            _produtoSqlRepository.Update(_produto);


        }

        [Test]
        public void TestProdutoRepository_GetAll_ShouldBeOk()
        {
            var teste = _produtoSqlRepository.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }



        [Test]
        public void TestProdutoRepository_Delete_ShouldBeOk()
        {
            _produto.Id = 1;
            _produtoSqlRepository.Delete(_produto);
        }

    }
}
