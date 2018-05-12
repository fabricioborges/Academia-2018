using DonaLaura.Domain.Features;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Features
{
    public class VendaSqlRepository : IVendaRepository
    {
        #region readonly

        private readonly string SaveSql = @"INSERT INTO TBVenda
                        (Quantidade,
                        Lucro 
                        )
                         VALUES
                        (@Quantidade,
                        @Lucro
                       
                        )";

        private readonly string UpdateSql = @"UPDATE TBVenda
                                SET Lucro =  @Lucro,
                                 Quantidade = @Quantidade
                                                              
                                 WHERE Id_venda = @Id_venda";

        readonly string getAllSQL = @"SELECT Id_venda,
                                             Lucro,
                                             Quantidade
                                            
                                    FROM TBVenda";

        readonly string getByIDSQL = @"SELECT Id_venda,                                            
                                             Quantidade,                                            
                                             Lucro
                                    FROM TBVenda
                                    WHERE Id_venda = @Id_venda";

        readonly string DeletesSQL = @"DELETE FROM TBVenda
                                  WHERE Id_venda = @Id_venda";


        #endregion

        Venda _venda = new Venda();

        public void Delete(Venda objeto)
        {
            Db.Delete(DeletesSQL, TakeId(objeto.Id));
        }

        public IEnumerable<Venda> GetAll()
        {
            return Db.GetAll(getAllSQL, Make);
        }

        public Venda GetById(long Id)
        {
            return Db.Get(getByIDSQL, Make, TakeId(Id));
        }

        public Venda Save(Venda objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
            return objeto;
        }

        public Venda Update(Venda objeto)
        {
            Db.Update(UpdateSql, Take(objeto));
            return objeto;
        }

        private static Func<IDataReader, Venda> Make = reader => new Venda
        {

            Id = Convert.ToInt64(reader["Id_venda"]),
            Lucro = Convert.ToDouble(reader["Lucro"]),
            Quantidade = Convert.ToInt32(reader["Quantidade"])
        };

        private object[] Take(Venda venda)
        {
            return new object[]
            {
                "@Id_venda", venda.Id,
                "@Lucro", venda.Lucro,
                "@Quantidade", venda.Quantidade,
             

            };
        }

        private object[] TakeId(long Id)
        {

            return new object[]
            {
                "@Id_venda", Id
            };
        }
    }
}
