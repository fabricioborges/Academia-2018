using DonaLaura.Domain.Features;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Features
{
    public class ClienteSqlRepository : IClienteRepository
    {
        #region readOnly

        private readonly string SaveSql = @"INSERT INTO TBCliente
                        (NomeCliente
                                                       
                        )
                         VALUES
                        (@NomeCliente
                        
                        )";

        private readonly string UpdateSql = @"UPDATE TBCliente
                                SET NomeCliente =  @NomeCliente
                                WHERE Id_cliente = @Id_cliente";

        readonly string getAllSQL = @"SELECT Id_cliente,
                                             NomeCliente
                                                                                          
                                    FROM TBCliente";

        readonly string getByIDSQL = @"SELECT Id_cliente,
                                              NomeCliente
                                              
                                FROM TBCliente
                                WHERE Id_cliente = @Id_cliente";

        readonly string DeletesSQL = @"DELETE FROM TBCliente
                                  WHERE Id_cliente = @Id_cliente";

        #endregion

        public void Delete(Cliente objeto)
        {
            Db.Delete(DeletesSQL, TakeId(objeto.Id));
        }

        public IEnumerable<Cliente> GetAll()
        {
            return Db.GetAll(getAllSQL, Make);
        }

        public Cliente GetById(long Id)
        {
            return Db.Get(getByIDSQL, Make, TakeId(Id));
        }

        public Cliente Save(Cliente objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
            return objeto;
        }

        public Cliente Update(Cliente objeto)
        {
            Db.Update(UpdateSql, Take(objeto));
            return objeto;
        }

        private static Func<IDataReader, Cliente> Make = reader => new Cliente
        {
            Id = Convert.ToInt32(reader["Id_cliente"]),
            Nome = reader["NomeCliente"].ToString()
        };

        private object[] Take(Cliente cliente)
        {
            return new object[]
            {
                "@Id_cliente", cliente.Id,
                "@NomeCliente", cliente.Nome,
                
            };
        }

        private object[] TakeId(long Id)
        {

            return new object[]
            {
                "@Id_cliente", Id
            };
        }

    }
}
