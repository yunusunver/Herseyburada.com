using HerseyBurada.Entities.EntitiesTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> getCategory();

        void AddCategory(Category category);

        void DeleteCategory(int id);

        void UpdateCategory(int id, Category category);

        Category FindCategory(int id);
        
    }
}
