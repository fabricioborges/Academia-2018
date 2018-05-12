using DonaLaura.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Testes
{
    public class ObjectMother
    {
        public static Produto produto
        {
            get
            {
                return new Produto()
                {
                    Nome = "perfume",
                    PrecoCusto = 10.00,
                    PrecoVenda = 15.50,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    Validade = DateTime.Now.AddYears(1),
                    Disponibilidade = true
                };
            }


        }

        public static Cliente cliente
        {
            get
            {
                return new Cliente()
                {
                   Nome = "Fabricio"
                };
            }

        }

        public static Venda venda
        {
            get
            {
                return new Venda()
                {
                    Produto = new Produto()
                    {
                        Nome = "perfume",
                        PrecoCusto = 10.00,
                        PrecoVenda = 15.50,
                        DataFabricacao = DateTime.Now.AddYears(-1),
                        Validade = DateTime.Now.AddYears(1),
                        Disponibilidade = true
                    },
                    Lucro = produto.PrecoVenda - produto.PrecoCusto,
                    Quantidade = 5,
                    Cliente = new Cliente()
                    {
                        Nome = "Fabricio"
                    }
                };
            }
            
        }
    }


}

