using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.DataAccess.Abstract
{
    //Veritabanı temel işlemlerini(CRUD) yaptığımız yerin interface'i
    interface IRepository<T> where T:class
    {
        List<T> List();
        List<T> List(Expression<Func<T,bool>> where);

        void Insert(T obj);

        void Update(T obj);

        void Delete(T obj);

        T Find(Expression<Func<T, bool>> where);
    }
}
