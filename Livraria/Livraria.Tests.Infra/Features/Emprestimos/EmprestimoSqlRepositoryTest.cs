using FluentAssertions;
using Livraria.Domain.Features.Emprestimos;
using Livraria.Infra.BaseSql;
using Livraria.Infra.Data.Features.Emprestimos;
using Livraria.Test.Domain.Features.Emprestimos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Tests.Infra.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoSqlRepositoryTest
    {
        EmprestimoSqlRepository _emprestimoSqlRepository;
        Emprestimo _emprestimo;

        [SetUp]
        public void EmprestimoRepository_set()
        {
            _emprestimoSqlRepository = new EmprestimoSqlRepository();
            _emprestimo = ObjectMother.Emprestimo();
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Emprestimo_deve_adicionar_Should_Be_Ok()
        {
            _emprestimoSqlRepository.Add(_emprestimo);
            _emprestimo.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Emprestimo_deve_deletar_Should_Be_Ok()
        {
            _emprestimo.Id = 1;
            _emprestimoSqlRepository.Delete(_emprestimo);
        }

        [Test]
        public void Emprestimo_deve_atualizar_Should_Be_Ok()
        {
            _emprestimo.Cliente = "João das coves";
            _emprestimo.Id = 1;
            _emprestimoSqlRepository.Update(_emprestimo);
        }

        [Test]
        public void Emprestimo_getAll_Should_Be_Ok()
        {
            var get = _emprestimoSqlRepository.GetAll();
            get.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void Emprestimo_getById_Should_Be_Ok()
        {
            _emprestimo.Id = 1;
            var get = _emprestimoSqlRepository.GetById(_emprestimo.Id);
            get.Id.Should().Be(_emprestimo.Id);
        }
    }
}
