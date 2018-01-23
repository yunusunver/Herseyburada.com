using HerseyBurada.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.DataAccess.Abstract
{
    public class RepositoryBase
    {
        public static DatabaseContext db;
        private static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        public static DatabaseContext CreateContext()
        {
            if (db==null)
            {
                lock (_lockSync)
                {
                    if (db==null)
                    {
                        db = new DatabaseContext();
                    }
                }
            }
            return db;

        }
    }
}
