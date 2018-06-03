using GerenciadorSalas.Infra.Dbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Common.Tests.Base
{
    public static class BaseSqlTests
    {
        private const string DELETE_DATABASE = "truncate table TBSala; DELETE FROM TBUsuario DBCC CHECKIDENT('TBUsuario', RESEED, 0)";
        private const string RECREATE_DATABASE = "insert into TBUsuario (Nome, Setor) values ('testenome', 'testesetor'); insert into TBSala (Nome_sala , Quantidade_lugar, Usuario_id, data_inicio, data_final) values ('nomesala', 5, 1, GETDATE(), GETDATE())";

        public static void SeedDatabase()
        {
            Db.Update(DELETE_DATABASE);
            Db.Update(RECREATE_DATABASE);
        }
    }
}
