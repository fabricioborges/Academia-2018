using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DonaLaura.Infra
{
    public static class BaseSqlTest
    {

        private const string RECREATE_PRODUTO_TABLE = "TRUNCATE TABLE TBProduto ";
        private const string INSERT_PRODUTO = "INSERT INTO TBProduto(Nome,PrecoCusto,PrecoVenda,DataFabricacao,DataValidade,Disponibilidade ) VALUES ('Teste', 10.00, 15.50, 2018-01-01, 2018-01-02, 1)";
        private const string RECREATE_VENDA_TABLE = "TRUNCATE TABLE TBVenda ";
        private const string INSERT_VENDA = "INSERT INTO TBVenda(Quantidade,Lucro) VALUES (5, 15.50)";
        private const string RECREATE_CLIENTE_TABLE = "TRUNCATE TABLE TBCliente ";
        private const string INSERT_CLIENTE = "INSERT INTO TBCliente(NomeCliente ) VALUES ('Teste')";

        public static void SeedDatabaseProduto()
        {
            Db.Update(RECREATE_PRODUTO_TABLE);
            Db.Update(INSERT_PRODUTO);
        }

        public static void SeedDatabaseVenda()
        {

            Db.Update(RECREATE_VENDA_TABLE);
            Db.Update(INSERT_VENDA);
        }

        public static void SeedDatabaseCliente()
        {
            Db.Update(RECREATE_CLIENTE_TABLE);
            Db.Update(INSERT_CLIENTE);
        }
    }
}
