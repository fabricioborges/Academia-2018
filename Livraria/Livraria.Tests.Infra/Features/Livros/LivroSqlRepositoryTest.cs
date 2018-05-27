using FluentAssertions;
using Livraria.Domain.Features.Livros;
using Livraria.Infra.BaseSql;
using Livraria.Infra.Data.Features.Livros;
using Livraria.Test.Domain.Features.Livros;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Tests.Infra.Features.Livros
{
    [TestFixture]
    public class LivroSqlRepositoryTest
    {
        LivroSqlRepository _livroSqlRepository;
        Livro _livro;

        [SetUp]
        public void LivroRepository_set()
        {
            _livroSqlRepository = new LivroSqlRepository();
            _livro = ObjectMother.Livro();
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Livro_deve_adicionar_Should_Be_Ok()
        {
            _livroSqlRepository.Add(_livro);
            _livro.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Livro_deve_deletar_Should_Be_Ok()
        {
            _livro.Id = 1;
            _livroSqlRepository.Delete(_livro);            
        }

        [Test]
        public void Livro_deve_atualizar_Should_Be_Ok()
        {
            _livro.Titulo = "Sherlock";
            _livro.Id = 1;
            _livroSqlRepository.Update(_livro);
            
        }

        [Test]
        public void Livro_getAll_Should_Be_Ok()
        {
            var get = _livroSqlRepository.GetAll();
            get.Count().Should().BeGreaterThan(0);

        }

        [Test]
        public void Livro_getById_Should_Be_Ok()
        {
            _livro.Id = 1;
            var get = _livroSqlRepository.GetById(_livro.Id);
            get.Id.Should().Be(_livro.Id);

        }
    }
}
