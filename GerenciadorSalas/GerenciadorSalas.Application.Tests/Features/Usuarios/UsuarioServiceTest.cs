using FluentAssertions;
using GerenciadorSalas.Application.Features.Usuarios;
using GerenciadorSalas.Domain.Usuarios;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Application.Tests.Features.Usuarios
{
    [TestFixture]
    public class UsuarioServiceTest
    {
        private UsuarioService _Alvo;
        private Mock<IUsuarioRepository> _mock;
        Usuario _usuario;

        [SetUp]
        public void UsuarioService_Set()
        {
            _mock = new Mock<IUsuarioRepository>();
            _usuario = new Usuario()
            {
                Id = 1,
                Nome = "Fabricio",
                Setor = "Desenvolvimento"
            };

            _Alvo = new UsuarioService(_mock.Object);
        }

        [Test]
        public void UsuarioService_teste_adicionar_Ok()
        {
            _mock.Setup(x => x.Add(_usuario)).Returns(new Usuario() { Id = 1 });

            var obtido = _Alvo.Add(_usuario);

            _mock.Verify(x => x.Add(_usuario));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void UsuarioService_deletar_adicionar_Ok()
        {
            _mock.Setup(x => x.Delete(_usuario));

            _Alvo.Delete(_usuario);

            _mock.Verify(x => x.Delete(_usuario));
        }

        [Test]
        public void UsuarioService_teste_update_Ok()
        {
            _mock.Setup(x => x.Update(_usuario)).Returns(new Usuario() { Id = 1 });

            var obtido = _Alvo.Update(_usuario);

            _mock.Verify(x => x.Update(_usuario));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void UsuarioService_teste_GetAll_Ok()
        {
            _mock.Setup(x => x.GetAll()).Returns(new List<Usuario>() { _usuario });

            var obtido = _Alvo.GetAll();

            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_usuario);
        }

        [Test]
        public void UsuarioService_teste_GetById_Ok()
        {
            _mock.Setup(x => x.GetById(_usuario.Id)).Returns(_usuario);

            var obtido = _Alvo.GetById(_usuario.Id);

            _mock.Verify(x => x.GetById(_usuario.Id));
            _usuario.Should().Be(obtido);
        }
    }
}
