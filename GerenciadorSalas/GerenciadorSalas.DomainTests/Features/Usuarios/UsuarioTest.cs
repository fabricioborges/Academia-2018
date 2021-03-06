﻿using FluentAssertions;
using GerenciadorSalas.Common.Tests.Features.Usuarios;
using GerenciadorSalas.Domain.Usuarios;
using NUnit.Framework;
using System;

namespace GerenciadorSalas.DomainTests.Features.Usuarios
{
    [TestFixture]
    public class UsuarioTest
    {
        Usuario _usuario;
        [SetUp]
        public void Usuario_set()
        {
            _usuario = ObjectMother.Usuario();
        }

        [Test]
        public void Usuario_deve_ter_um_nome_valido_Ok()
        {
            _usuario.Nome.Should().Be("Usuario");
            _usuario.Validar();
        }

        [Test]
        public void Usuario_deve_ter_um_setor_valido_Ok()
        {
            _usuario.Setor.Should().Be("Desenvolvimento");
            _usuario.Validar();
        }

        [Test]
        public void Usuario_deve_ter_um_nome_invalido()
        {
            _usuario.Nome = "";
            Action comparison = _usuario.Validar;
            comparison.Should().Throw<NomeInvalidoException>();
        }

        [Test]
        public void Usuario_deve_ter_um_setor_invalido()
        {
            _usuario.Setor = "";
            Action comparison = _usuario.Validar;
            comparison.Should().Throw<SetorInvalidoException>();
        }
    }
}
