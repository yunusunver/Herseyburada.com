using HerseyBurada.DataAccess.Context;
using HerseyBurada.Entities.EntitiesTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.Business
{
    public class Test
    {
        DatabaseContext db = new DatabaseContext();
        public Test()
        {
            List<Category> listele = db.Categories.ToList();


        }

    }
}
