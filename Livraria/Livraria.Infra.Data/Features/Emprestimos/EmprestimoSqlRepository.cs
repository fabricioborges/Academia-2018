using Livraria.Domain.Features.Emprestimos;
using Livraria.Domain.Features.Livros;
using Livraria.Infra.BaseSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.Data.Features.Emprestimos
{
    public class EmprestimoSqlRepository : IEmprestimoRepository
    {
        #region readonly

        private readonly string SaveSql = @"INSERT INTO TB_Emprestimos
                        (Cliente,
                        DataDevolucao,
                        Livro_id
                        )
                         VALUES
                         (@Cliente,
                        @DataDevolucao,
                        @Livro_id
                       
                        )";

        private readonly string UpdateSql = @"UPDATE TB_Emprestimos
                                SET Cliente =  @Cliente,
                                 DataDevolucao = @DataDevolucao,
                                 Livro_id = @Livro_id
                                                              
                                 WHERE Id_emprestimo = @Id_emprestimo";

        readonly string getAllSQL = @"SELECT Id_emprestimo,
                                             Cliente,
                                             DataDevolucao,
                                             Livro_id
                                            
                                    FROM TB_Emprestimos";

        readonly string getAllSQLLivrosEmEmprestimo = @"SELECT Titulo,
                                                        Disponibilidade 
                                                        from TB_Emprestimos 
                                                        inner join 
                                                        TB_Livros on TB_Emprestimos.Livro_id = TB_Livros.Id_livro";

        readonly string getByIDSQL = @"SELECT Id_emprestimo,
                                             Cliente,
                                             DataDevolucao,
                                             Livro_id
                                            
                                    FROM TB_Emprestimos
                                    WHERE Id_emprestimo = @Id_emprestimo";

        readonly string DeleteSQL = @"DELETE FROM TB_Emprestimos
                                  WHERE Id_emprestimo = @Id_emprestimo";


        #endregion

        public Emprestimo Add(Emprestimo objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
            return objeto;
        }

        public void Delete(Emprestimo objeto)
        {
            Db.Delete(DeleteSQL, Take(objeto));
        }

        public IEnumerable<Emprestimo> GetAll()
        {
            return Db.GetAll(getAllSQL, Make);
        }

        public Emprestimo GetById(long Id)
        {
            return Db.Get(getByIDSQL, Make, TakeId(Id));
        }

        public Emprestimo Update(Emprestimo objeto)
        {
            Db.Update(UpdateSql, Take(objeto));
            return objeto;
        }

        private object[] Take(Emprestimo emprestimo)
        {
            return new object[]
            {
               "@Id_emprestimo", emprestimo.Id,
               "@Cliente", emprestimo.Cliente,
               "@DataDevolucao", emprestimo.DataDevolucao,
               "@Livro_id", emprestimo.Livro.Id,
              
            };
        }

        private object[] TakeId(long Id)
        {

            return new object[]
            {
                "@Id_emprestimo", Id
            };
        }

     
        private static Func<IDataReader, Emprestimo> Make = reader => new Emprestimo
        {
            Id = Convert.ToInt64(reader["Id_emprestimo"]),
            Cliente = reader["Cliente"].ToString(),
            DataDevolucao = Convert.ToDateTime(reader["DataDevolucao"]),
           
        };

        private static Func<IDataReader, Livro> MakeLivro = reader => new Livro
        {
            Id = Convert.ToInt64(reader["Id_emprestimo"]),
            Titulo = reader["Titulo"].ToString(),
            Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]),

        };
    }
}
