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
        public WebContexto(string connection = "Name=WebContext") : base(connection)
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }

        protected WebContexto(DbConnection connection) : base(connection, true)
        {
        }
    }
}
