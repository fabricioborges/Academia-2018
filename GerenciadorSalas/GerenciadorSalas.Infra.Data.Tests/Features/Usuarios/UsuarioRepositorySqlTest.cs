using FluentAssertions;
using GerenciadorSalas.Common.Tests.Base;
using GerenciadorSalas.Common.Tests.Features.Usuarios;
using GerenciadorSalas.Domain.Usuarios;
using GerenciadorSalas.Infra.Data.Features.Usuarios;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Infra.Data.Tests.Features.Usuarios
{
    [TestFixture]
    public class UsuarioRepositorySqlTest
    {
        Usuario _usuario;
        UsuarioSqlRepository _usuarioSqlRepository;
        
        [SetUp]
        public void UsuarioRepositorySqlTest_Set()
        {
            _usuarioSqlRepository = new UsuarioSqlRepository();
            _usuario = ObjectMother.Usuario();
            BaseSqlTests.SeedDatabase();
        }

        [Test]
        public void Usuario_teste_Deve_adicionar_Ok()
        {
            _usuarioSqlRepository.Add(_usuario);
            _usuario.Id.Should().BeGreaterThan(0);
        }

        [Test]  
        public void Usuario_teste_deve_deletar_Ok()
        {
            _usuario.Id = 1;
            _usuarioSqlRepository.Delete(_usuario);
        }

        [Test]
        public void Usuario_teste_update_Ok()
        {
            _usuario.Nome = "Fabricio";
            _usuario.Id = 1;
            _usuarioSqlRepository.Update(_usuario);
        }

        [Test]
        public void Usuario_teste_GetAll_Ok()
        {
            var get = _usuarioSqlRepository.GetAll();
            get.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Usuario_teste_GetById_Ok()
        {
            _usuario.Id = 1;
            var get = _usuarioSqlRepository.GetById(_usuario.Id);
            get.Id.Should().Be(_usuario.Id);
        }
    }
}
