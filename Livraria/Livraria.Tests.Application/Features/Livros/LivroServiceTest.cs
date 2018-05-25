using FluentAssertions;
using Livraria.Application.Features.Livros;
using Livraria.Domain.Features.Livros;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Tests.Application.Features.Livros
{
    [TestFixture]
    public class LivroServiceTest
    {
        private LivroService Alvo;

        private Mock<ILivroRepository> _mock;

        Livro _livro;

        [SetUp]
        public void LivroServiceSet()
        {
            _mock = new Mock<ILivroRepository>();
            _livro = new Livro()
            {
                Id = 1,
                Titulo = "Guia do Mochileiro das Galaxias",
                Tema = "Ficção",
                Autor = "Douglas Adams",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddYears(-39),
                Disponibilidade = true
            };
            Alvo = new LivroService(_mock.Object);
        }

        [Test]
        public void Test_LivroService_Add_Test_Should_BeOk()
        {
            _mock.Setup(x => x.Add(_livro)).Returns(new Livro() { Id = 1 });

            var obtido = Alvo.Add(_livro);

            _mock.Verify(x => x.Add(_livro));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_LivroService_Delete_Test_Should_BeOk()
        {
            _mock.Setup(x => x.Delete(_livro));

            Alvo.Delete(_livro);

            _mock.Verify(x => x.Delete(_livro));
        }

        [Test]
        public void Test_LivroService_Update_Test_Should_BeOk()
        {
            _mock.Setup(x => x.Update(_livro)).Returns(new Livro() { Id = 1 });

            var obtido = Alvo.Update(_livro);

            _mock.Verify(x => x.Update(_livro));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_LivroService_GetAll_Test_Should_BeOk()
        {
            _mock.Setup(x => x.GetAll()).Returns(new List<Livro>() { _livro});

            var obtido = Alvo.GetAll();

            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_livro);
        }

        [Test]
        public void Test_LivroService_GetById_Test_Should_BeOk()
        {
            _mock.Setup(x => x.GetById(_livro.Id)).Returns(_livro);

            var obtido = Alvo.GetById(_livro.Id);

            _mock.Verify(x => x.GetById(_livro.Id));
            _livro.Should().Be(obtido);
        }
    }
}
