using FluentAssertions;
using Livraria.Domain.Exceptions;
using Livraria.Domain.Features.Livros;
using NUnit.Framework;
using System;

namespace Livraria.Test.Domain.Features.Livros
{
    [TestFixture]
    public class LivroTest
    {
        Livro _livro;

        [SetUp]
        public void setTime()
        {
            _livro = ObjectMother.Livro();
        }

        [Test]
        public void Livro_deve_ter_um_titulo_valido_BeOk()
        {
            _livro.Titulo.Should().Be("Guia do Mochileiro das Galaxias");
        }

        [Test]
        public void Livro_deve_ter_um_titulo_valido_BeFail()
        {
            _livro.Titulo = "";
            Action comparison = _livro.ValidarTitulo;
            comparison.Should().Throw<TituloInvalidoException>();
        }
        
        [Test]
        public void Livro_deve_ter_um_tema_valido_BeOk()
        {
            _livro.Tema.Should().Be("Ficção");
        }

        [Test]
        public void Livro_deve_ter_um_tema_valido_BeFail()
        {
            _livro.Tema = "";
            Action comparison = _livro.ValidarTema;
            comparison.Should().Throw<TemaInvalidoException>();
        }

        [Test]
        public void Livro_deve_ter_um_autor_valido_BeOk()
        {
            _livro.Autor.Should().Be("Douglas Adams");
        }

        [Test]
        public void Livro_deve_ter_um_autor_valido_BeFail()
        {
            _livro.Autor = "";
            Action comparison = _livro.ValidarAutor;
            comparison.Should().Throw<AutorInvalidoException>();
        }

        [Test]
        public void Livro_deve_ter_um_volume_valido_BeOk()
        {
            _livro.Volume.Should().BeGreaterThan(0);
        }

        [Test]
        public void Livro_deve_ter_um_volume_valido_BeFail()
        {
            _livro.Volume = 0;
            Action comparison = _livro.ValidarVolume;
            comparison.Should().Throw<VolumeInvalidoException>();
        }

       

    }
}
