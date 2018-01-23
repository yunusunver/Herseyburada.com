using HerseyBurada.Business.Abstract;
using HerseyBurada.DataAccess.Abstract;
using HerseyBurada.Entities.EntitiesTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerseyBurada.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private Repository<Category> repo_category;
        private Repository<Product> repo_product;


        public CategoryManager()
        {
            repo_category = new Repository<Category>();
            repo_product = new Repository<Product>();
        }
        public void AddCategory(Category category)
        {
            repo_category.Insert(category);
        }

        public void DeleteCategory(int id)
        {
            
            Category result = repo_category.Find(x => x.Id == id);
            foreach (var item in result.Products)
            {
                repo_product.Delete(item);
            }
            
            repo_category.Delete(result);
        }

        public Category FindCategory(int id)
        {
            return repo_category.Find(x=>x.Id==id);
        }

        public List<Category> getCategory()
        {
            return repo_category.List();
        }

        public void UpdateCategory(int id, Category category)
        {
            Category result = repo_category.Find(x=>x.Id==id);
            result.CategoryName = category.CategoryName;
            repo_category.Update(result);
        }
    }
}
