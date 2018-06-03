using FluentAssertions;
using GerenciadorSalas.Common.Tests.Base;
using GerenciadorSalas.Common.Tests.Features.Salas;
using GerenciadorSalas.Domain.Features.Salas;
using GerenciadorSalas.Infra.Data.Features.Salas;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Infra.Data.Tests.Features.Salas
{
    [TestFixture]
    public class SalaSqlRepositoryTest
    {
        Sala _sala;
        SalaSqlRepository _salaSqlRepository;

        [SetUp]
        public void SalaSqlRepositoryTest_Set()
        {
            _salaSqlRepository = new SalaSqlRepository();
            _sala = ObjectMother.Sala();
            BaseSqlTests.SeedDatabase();
        }

        [Test]
        public void Sala_teste_Deve_adicionar_Ok()
        {
            _salaSqlRepository.Add(_sala);
            _sala.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Sala_teste_deve_deletar_Ok()
        {
            _sala.Id = 1;
            _salaSqlRepository.Delete(_sala);
        }

        [Test]
        public void Sala_teste_update_Ok()
        {
            _sala.Nome = "Reuniao";
            _sala.Id = 1;
            _salaSqlRepository.Update(_sala);
        }

        [Test]
        public void Sala_teste_GetAll_Ok()
        {
            var get = _salaSqlRepository.GetAll();
            get.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Sala_teste_GetById_Ok()
        {
            _sala.Id = 1;
            var get = _salaSqlRepository.GetById(_sala.Id);
            get.Id.Should().Be(_sala.Id);
        }
    }
}
