using GerenciadorSalas.Domain.Features.Salas;
using GerenciadorSalas.Domain.Usuarios;
using GerenciadorSalas.Infra.Dbs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorSalas.Infra.Data.Features.Salas
{
    public class SalaSqlRepository : ISalaRepository
    {
        #region readonly

        private readonly string SaveSql = @"INSERT INTO TBSala
                                        (Nome_sala,
                                        Quantidade_lugar,
                                        Data_inicio,
                                        Data_final,
                                        Usuario_id)

                                        VALUES
                                        (@Nome_sala,
                                        @Quantidade_lugar,
                                        @Data_inicio,
                                        @Data_final,
                                        @Usuario_id)
                                        ";

        private readonly string UpdateSql = @"UPDATE TBSala
                                        SET Nome_sala = @Nome_sala,
                                        Quantidade_lugar = @Quantidade_lugar,
                                        Data_inicio = @Data_inicio,
                                        Data_final = @Data_final,
                                        Usuario_id = @Usuario_id
                                        
                                        WHERE Id_sala = @Id_sala";

        readonly string getAllSQL = @"SELECT Id_sala,
                                        Nome_sala,
                                        Quantidade_lugar,
                                        Data_inicio,
                                        Data_final,
                                        Usuario_id
                                        FROM TBSala";

        readonly string getAllSQLUsuarios = @"SELECT Nome,
                                                     Setor
                                                     FROM TBSala
                                                     inner join 
                                                     TBUsuario on TBSala.Usuario_id = TBUsuario.Id_usuario";

        readonly string getByIDSQL = @"SELECT Id_sala,
                                        Nome_sala,
                                        Quantidade_lugar,
                                        Data_inicio,
                                        Data_final,
                                        Usuario_id
                                        FROM TBSala
                                        WHERE Id_sala = @Id_sala";

        readonly string DeletesSQL = @"DELETE FROM TBSala
                                 WHERE Id_sala = @Id_sala";

        #endregion

        public Sala Add(Sala objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
            return objeto;
        }

        public void Delete(Sala objeto)
        {
            Db.Delete(DeletesSQL, TakeId(objeto.Id));
        }

        public IEnumerable<Sala> GetAll()
        {
            return Db.GetAll(getAllSQL, Make);
        }

        public Sala GetById(long Id)
        {
            return Db.Get(getByIDSQL, Make, TakeId(Id));
        }

        public Sala Update(Sala objeto)
        {
            Db.Update(UpdateSql, Take(objeto));
            return objeto;
        }

        private object[] Take(Sala sala)
        {
            return new object[]
            {
               "@Id_sala", sala.Id,
               "@Nome_sala", sala.Nome,
               "@Data_inicio", sala.DataInicio,
               "@Data_final", sala.DataFim,
               "@Quantidade_lugar", sala.Quantidade,
               "@Usuario_id", sala.Usuario.Id
            };
        }

        private object[] TakeId(long Id)
        {

            return new object[]
            {
                "@Id_sala", Id
            };
        }
        
        private static Func<IDataReader, Sala> Make = reader => new Sala
        {
            Id = Convert.ToInt64(reader["Id_sala"]),
            Nome = reader["Nome_sala"].ToString(),
            DataInicio = Convert.ToDateTime(reader["Data_inicio"]),
            DataFim = Convert.ToDateTime(reader["Data_final"]),
            Quantidade = Convert.ToInt32(reader["Quantidade_lugar"]),
            
        };

       
    }
}
