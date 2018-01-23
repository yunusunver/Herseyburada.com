using HerseyBurada.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.DataAccess.Abstract
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DatabaseContext db;

        private DbSet<T> _objectSet;
        public Repository()
        {
            db = RepositoryBase.CreateContext();
            _objectSet = db.Set<T>();
        }


        public void Delete(T obj)
        {
            _objectSet.Remove(obj);
            db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }

        public void Insert(T obj)
        {
            _objectSet.Add(obj);
            db.SaveChanges();
        }

        public List<T> List()
        {
           return  _objectSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public void Update(T obj)
        {
            db.SaveChanges();
        }
    }
}
