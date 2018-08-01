using Domain.Features.Clientes;
using Domain.Features.Lojas;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Features.Contexto
{
    public class WebContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public WebContexto(string connection = "Name=WebContext") : base("WebContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }

        protected WebContexto(DbConnection connection) : base(connection, true)
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Busca todos as configurações criadas nesse assembly, que são as classes que são derivadas de EntityTypeConfiguration
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            // Chama o OnModelCreating do EF para dar continuidade na criação do modelo
            base.OnModelCreating(modelBuilder);
        }
    }
}
