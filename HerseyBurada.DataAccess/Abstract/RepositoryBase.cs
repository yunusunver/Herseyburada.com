using HerseyBurada.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.DataAccess.Abstract
{

    //sadece bir nesne oluşmasını istediğimiz singleton pattern kullanıyoruz.
    public class RepositoryBase
    {
        //DatabaseContext nesnesi oluşturuyoruz
        public static DatabaseContext db;

        private static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }
        //sadece birtane nesne oluşturmak için kullandığımız metod
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
