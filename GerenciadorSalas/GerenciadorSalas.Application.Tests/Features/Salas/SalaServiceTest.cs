using FluentAssertions;
using GerenciadorSalas.Application.Features;
using GerenciadorSalas.Domain.Features.Salas;
using GerenciadorSalas.Domain.Usuarios;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Application.Tests.Features.Salas
{
    [TestFixture]
    public class SalaServiceTest
    {
        private SalaService _Alvo;
        private Mock<ISalaRepository> _mock;
        Sala _sala;

        [SetUp]
        public void UsuarioService_Set()
        {
            _mock = new Mock<ISalaRepository>();
            _sala = new Sala()
            {
                Id = 1,
                Nome = "Treinamento",
                Quantidade = 5,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddHours(1),
                Usuario = new Usuario()
                {
                    Id = 1,
                    Nome = "Fabricio",
                    Setor = "Desenvolvimento"
                }
            };

            _Alvo = new SalaService(_mock.Object);
        }

        [Test]
        public void SalaService_teste_adicionar_Ok()
        {
            _mock.Setup(x => x.Add(_sala)).Returns(new Sala() { Id = 1 });

            var obtido = _Alvo.Add(_sala);

            _mock.Verify(x => x.Add(_sala));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void SalaService_deletar_adicionar_Ok()
        {
            _mock.Setup(x => x.Delete(_sala));

            _Alvo.Delete(_sala);

            _mock.Verify(x => x.Delete(_sala));
        }

        [Test]
        public void SalaService_teste_update_Ok()
        {
            _mock.Setup(x => x.Update(_sala)).Returns(new Sala() { Id = 1 });

            var obtido = _Alvo.Update(_sala);

            _mock.Verify(x => x.Update(_sala));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void SalaService_teste_GetAll_Ok()
        {
            _mock.Setup(x => x.GetAll()).Returns(new List<Sala>() { _sala });

            var obtido = _Alvo.GetAll();

            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_sala);
        }

        [Test]
        public void SalaService_teste_GetById_Ok()
        {
            _mock.Setup(x => x.GetById(_sala.Id)).Returns(_sala);

            var obtido = _Alvo.GetById(_sala.Id);

            _mock.Verify(x => x.GetById(_sala.Id));
            _sala.Should().Be(obtido);
        }
    }
}
