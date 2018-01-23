using HerseyBurada.Entities.EntitiesTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HerseyBurada.Business.Abstract
{
    public interface IProductService
    {
        List<Product> getProduct();

        void AddProduct(Product product,int categoryId);

        void DeleteProduct(int id);

        void UpdateProduct(int id,Product product);

        Product FindProduct(int id);
    }
}
