using FluentAssertions;
using Livraria.Application.Features.Emprestimos;
using Livraria.Domain.Features.Emprestimos;
using Livraria.Domain.Features.Livros;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Tests.Application.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoServiceTest
    {
        private EmprestimoService Alvo;
        private Mock<IEmprestimoRepository> _mock;
        private Emprestimo _emprestimo;

        [SetUp]
        public void EmprestimoServiceSet()
        {
            _mock = new Mock<IEmprestimoRepository>();
            _emprestimo = new Emprestimo()
            {
                Id = 1,
                Cliente = "Fabricio",
                DataDevolucao = DateTime.Now,
                Multa = 10.50,

                Livro = new Livro()
                {
                    Id = 1,
                    Titulo = "Guia do Mochileiro das Galaxias",
                    Disponibilidade = true
                }
            };
            Alvo = new EmprestimoService(_mock.Object);
        }

        [Test]
        public void Test_EmprestimoService_Add_Test_Should_BeOk()
        {
            _mock.Setup(x => x.Add(_emprestimo)).Returns(new Emprestimo() { Id = 1 });

            var obtido = Alvo.Add(_emprestimo);

            _mock.Verify(x => x.Add(_emprestimo));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_EmprestimoService_Delete_Test_Should_BeOk()
        {
            _mock.Setup(x => x.Delete(_emprestimo));

            Alvo.Delete(_emprestimo);

            _mock.Verify(x => x.Delete(_emprestimo));
        }

        [Test]
        public void Test_EmprestimoService_Update_Test_Should_BeOk()
        {
            _mock.Setup(x => x.Update(_emprestimo)).Returns(new Emprestimo() { Id = 1 });

            var obtido = Alvo.Update(_emprestimo);
            
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_EmprestimoService_GetAll_Test_Should_BeOk()
        {
            _mock.Setup(x => x.GetAll()).Returns(new List<Emprestimo>() { _emprestimo});

            var obtido = Alvo.GetAll();

            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_emprestimo);
        }

        [Test]
        public void Test_EmprestimoService_GetById_Test_Should_BeOk()
        {
            _mock.Setup(x => x.GetById(_emprestimo.Id)).Returns(_emprestimo);

            var obtido = Alvo.GetById(_emprestimo.Id);

            _mock.Verify(x => x.GetById(_emprestimo.Id));
            obtido.Should().Be(_emprestimo);
        }
    }
}
