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
        private const string DELETE_DATABASE = "truncate table TBSalaTreinamento; truncate table TBSalaReuniao; truncate table TBSalaConferencia; DELETE FROM TBUsuario DBCC CHECKIDENT('TBUsuario', RESEED, 0)";
        private const string RECREATE_DATABASE = "insert into TBUsuario (Nome, Setor) values ('testenome', 'testesetor'); insert into TBSalaConferencia (QuantidadeLugar, Usuario_id, Data_ocupada) values (5, 1, GETDATE());insert into TBSalaReuniao(QuantidadeLugar, Usuario_id, Data_ocupada) values (3, 1, GETDATE()); insert into TBSalaTreinamento(QuantidadeLugar, Usuario_id, Data_ocupada) values (30, 1, GETDATE())";

        public static void SeedDatabase()
        {
            Db.Update(DELETE_DATABASE);
            Db.Update(RECREATE_DATABASE);
        }
    }
}
