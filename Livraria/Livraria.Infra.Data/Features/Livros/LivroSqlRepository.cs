using Livraria.Domain.Features.Livros;
using Livraria.Infra.BaseSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.Data.Features.Livros
{
    public class LivroSqlRepository : ILivroRepository
    {
        #region readonly

        private readonly string SaveSql = @"INSERT INTO TB_Livros
                                            (Titulo, 
                                            Autor, 
                                            Volume, 
                                            DataPublicacao, 
                                            Disponibilidade,
                                            Tema
                                            )
                                            VALUES
                                            (@Titulo, 
                                            @Autor, 
                                            @Volume, 
                                            @DataPublicacao, 
                                            @Disponibilidade,
                                            @Tema
                                            )";

        private readonly string UpdateSql = @"UPDATE TB_Livros
                                SET Titulo =  @Titulo,
                                 Autor = @Autor,
                                 Volume = @Volume,
                                 DataPublicacao = @DataPublicacao,
                                 Disponibilidade = @Disponibilidade,
                                 Tema = @Tema
                                 WHERE Id_livro = @Id_livro";

        readonly string getAllSQL = @"SELECT Id_livro,
                                             Titulo,
                                             Autor,
                                             Volume,
                                             DataPublicacao,
                                             Disponibilidade,
                                             Tema
                                    FROM TB_Livros";

        readonly string getByIDSQL = @"SELECT Id_livro,
                                             Titulo,
                                             Autor,
                                             Volume,
                                             DataPublicacao,
                                             Disponibilidade,
                                             Tema
                                    FROM TB_Livros
                                    WHERE Id_livro = @Id_livro";

        readonly string DeletesSQL = @"DELETE FROM TB_Livros
                                 WHERE Id_livro = @Id_livro";

        readonly string DeleteSQLLivroEmprestimo = @"DELETE FROM TB_Emprestimos
                                 WHERE Livro_id = @Id_livro";



        #endregion

        public Livro Add(Livro objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
            return objeto;
        }
        
        public void Delete(Livro objeto)
        {
            Db.Delete(DeleteSQLLivroEmprestimo, TakeId(objeto.Id));
            Db.Delete(DeletesSQL, TakeId(objeto.Id));
        }

        public IEnumerable<Livro> GetAll()
        {
            return Db.GetAll(getAllSQL, Make);
        }
        
        public Livro GetById(long Id)
        {
            return Db.Get(getByIDSQL, Make, TakeId(Id));
        }

        public Livro Update(Livro objeto)
        {
            Db.Update(UpdateSql, Take(objeto));
            return objeto;
        }

        private object[] Take(Livro livro)
        {
            return new object[]
            {
               "@Id_livro", livro.Id,
               "@Titulo", livro.Titulo,
               "@Autor", livro.Autor,
               "@Volume", livro.Volume,
               "@DataPublicacao", livro.DataPublicacao,
               "@Disponibilidade", livro.Disponibilidade,
               "@Tema", livro.Tema
            };
        }

        private object[] TakeId(long Id)
        {

            return new object[]
            {
                "@Id_livro", Id
            };
        }


        private static Func<IDataReader, Livro> Make = reader => new Livro
        {
            Id = Convert.ToInt64(reader["Id_livro"]),
            Titulo = reader["Titulo"].ToString(),
            Tema = reader["Tema"].ToString(),
            Volume = Convert.ToInt32(reader["Volume"]),
            Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]),
            DataPublicacao = Convert.ToDateTime(reader["DataPublicacao"]),
            Autor = reader["Autor"].ToString()
            
        };
    }
}
