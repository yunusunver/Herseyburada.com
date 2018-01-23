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
    public class ProductManager : IProductService
    {

        private Repository<Category> repo_category;
        private Repository<Product> repo_product;

        public ProductManager()
        {
            repo_category = new Repository<Category>();
            repo_product = new Repository<Product>();
        }
        public void AddProduct(Product product,int categoryId)
        {
            product.CategoryId = categoryId;
            
            
            repo_product.Insert(product);
        }

        public void DeleteProduct(int id)
        {
            Product result = repo_product.Find(x=>x.Id==id);
            repo_product.Delete(result);
        }

        public Product FindProduct(int id)
        {
            return repo_product.Find(x=>x.Id==id);
        }

        public List<Product> getProduct()
        {
            return repo_product.List();
        }

        public List<Product> getByIdCategoryProduct(int id)
        {
            return repo_product.List(x=>x.CategoryId==id);
        }

        public void UpdateProduct(int id, Product product)
        {
            Product result = repo_product.Find(x=>x.Id==id);

            result.ProductName = product.ProductName;
            result.ProductDescripion = product.ProductDescripion;
            result.ModifiedDate = DateTime.Now;
            result.Image = product.Image;

            repo_product.Update(result);
        }
    }
}
