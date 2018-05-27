using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.BaseSql
{
    public static class BaseSqlTest
    {
        private const string RECREATE_LIVRO_TABLE = "DELETE FROM TB_Livros DBCC CHECKIDENT('TB_Livros', RESEED, 0)";
        private const string INSERT_LIVRO = "INSERT INTO TB_Livros(Titulo, Autor, Volume, DataPublicacao, Disponibilidade, Tema ) VALUES ('Teste', 'Teste', 1, 2018-01-01, 1, 'Teste')";
        private const string RECREATE_EMPRESTIMO_TABLE = "TRUNCATE TABLE TB_Emprestimos ";
        private const string INSERT_EMPRESTIMO = "INSERT INTO TB_Emprestimos(Cliente, DataDevolucao, Livro_id) VALUES ('Teste', 2018-01-01, 1)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_EMPRESTIMO_TABLE);
            Db.Update(RECREATE_LIVRO_TABLE);
            Db.Update(INSERT_LIVRO);
            Db.Update(INSERT_EMPRESTIMO);
        }


    }


}
