using HerseyBurada.Entities.EntitiesTable;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.DataAccess.Context
{
    public class DatabaseContext:DbContext
    {
       public DbSet<Category> Categories { get; set; }
       public DbSet<Product> Products { get; set; }
    }
}
