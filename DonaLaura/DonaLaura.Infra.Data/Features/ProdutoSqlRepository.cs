using DonaLaura.Domain.Features;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Features
{
    public class ProdutoSqlRepository : IProdutoRepository
    {

        #region readonly

        private readonly string SaveSql = @"INSERT INTO TBProduto
                        (Nome,
                         PrecoCusto,
                         PrecoVenda,
                         DataFabricacao,
                         DataValidade,
                         Disponibilidade 
                        )
                         VALUES
                        (@Nome,
                        @PrecoCusto,
                        @PrecoVenda,
                        @DataFabricacao,
                        @DataValidade,
                        @Disponibilidade
                        )";

        private readonly string UpdateSql = @"UPDATE TBProduto
                                SET Nome =  @Nome,
                                 PrecoCusto = @PrecoCusto,
                                 PrecoVenda = @PrecoVenda,
                                 DataFabricacao = @DataFabricacao,
                                 DataValidade = @DataValidade, 
                                 Disponibilidade = @Disponibilidade
                                 WHERE Id_produto = @Id_produto";

        readonly string getAllSQL = @"SELECT Id_produto,
                                             Nome,
                                             PrecoCusto,
                                             PrecoVenda,
                                             DataFabricacao,
                                             DataValidade,
                                             Disponibilidade
                                    FROM TBProduto";

        readonly string getByIDSQL = @"SELECT Id_produto,
                                             Nome,
                                             PrecoCusto,
                                             PrecoVenda,
                                             DataFabricacao,
                                             DataValidade,
                                             Disponibilidade
                                    FROM TBProduto
                                    WHERE Id_produto = @Id_produto";

        readonly string DeletesSQL = @"DELETE FROM TBProduto
                                  WHERE Id_produto = @Id_produto";


        #endregion

        public void Delete(Produto objeto)
        {
            Db.Delete(DeletesSQL, TakeProdutoId(objeto.Id));

        }

        public IEnumerable<Produto> GetAll()
        {
            return Db.GetAll(getAllSQL, Make);
        }

        public Produto GetById(long Id)
        {
            return Db.Get(getByIDSQL, Make, TakeProdutoId(Id));
        }

        public Produto Save(Produto objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
            return objeto;
        }

        public Produto Update(Produto objeto)
        {
            Db.Update(UpdateSql, Take(objeto));
            return objeto;
        }


        private static Func<IDataReader, Produto> Make = reader => new Produto
        {
            Id = Convert.ToInt64(reader["Id_produto"]),
            Nome = reader["Nome"].ToString(),
            PrecoCusto = Convert.ToDouble(reader["PrecoCusto"]),
            PrecoVenda = Convert.ToDouble(reader["PrecoVenda"]),
            DataFabricacao = Convert.ToDateTime(reader["DataFabricacao"]),
            Validade = Convert.ToDateTime(reader["DataValidade"]),
            Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"])
        };

        private object[] Take(Produto produto)
        {
            return new object[]
            {
                "@Id_produto", produto.Id,
                "@Nome", produto.Nome,
                "@PrecoCusto", produto.PrecoCusto,
                "@PrecoVenda", produto.PrecoVenda,
                "@DataFabricacao", produto.DataFabricacao,
                "@DataValidade", produto.Validade,
                "@Disponibilidade", produto.Disponibilidade
            };
        }

        private object[] TakeProdutoId(long Id)
        {

            return new object[]
            {
                "@Id_produto", Id
            };
        }
    }
}
