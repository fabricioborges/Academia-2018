using GerenciadorSalas.Domain.Usuarios;
using GerenciadorSalas.Infra.Dbs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Infra.Data.Features.Usuarios
{
    public class UsuarioSqlRepository : IUsuarioRepository
    {
        #region readonly

        private readonly string SaveSql = @"insert into TBUsuario
                                            (Nome, Setor) 
                                            values 
                                            (@Nome, @Setor)";

        private readonly string UpdateSql = @"UPDATE TBUsuario
                                              SET Nome = @Nome,
                                              Setor = @Setor
                                              WHERE Id_usuario = @Id_usuario";

        readonly string getAllSQL = @"SELECT Id_usuario,
                                        Nome,
                                        Setor
                                        FROM TBUsuario";

        readonly string getByIDSQL = @"SELECT Id_usuario,
                                        Nome,
                                        Setor
                                        FROM TBUsuario
                                        WHERE Id_usuario = @Id_usuario";

        readonly string DeleteSQLUsuarioSala = @"DELETE FROM TBSala
                                 WHERE Usuario_id = @Id_usuario";

        readonly string DeletesSQL = @"DELETE FROM TBUsuario
                                 WHERE Id_usuario = @Id_usuario";

        #endregion

        public Usuario Add(Usuario objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
            return objeto;
        }

        public void Delete(Usuario objeto)
        {
            Db.Delete(DeleteSQLUsuarioSala, TakeId(objeto.Id));
            Db.Delete(DeletesSQL, TakeId(objeto.Id));
        }

        public IEnumerable<Usuario> GetAll()
        {
            return Db.GetAll(getAllSQL, Make);
        }

        public Usuario GetById(long Id)
        {
            return Db.Get(getByIDSQL, Make, TakeId(Id));
        }

        public Usuario Update(Usuario objeto)
        {
            Db.Update(UpdateSql, Take(objeto));
            return objeto;
        }

        private object[] Take(Usuario usuario)
        {
            return new object[]
            {
               "@Id_usuario", usuario.Id,
               "@Nome", usuario.Nome,
               "@Setor", usuario.Setor
            };
        }

        private object[] TakeId(long Id)
        {

            return new object[]
            {
                "@Id_usuario", Id
            };
        }

        private static Func<IDataReader, Usuario> Make = reader => new Usuario
        {
            Id = Convert.ToInt64(reader["Id_usuario"]),
            Nome = reader["Nome"].ToString(),
            Setor = reader["Setor"].ToString()
            
        };
    }
}
