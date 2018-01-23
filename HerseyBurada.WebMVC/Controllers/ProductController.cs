using HerseyBurada.Business.Concrete;
using HerseyBurada.Entities.EntitiesTable;
using HerseyBurada.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HerseyBurada.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager product_manager = new ProductManager();
        private CategoryManager category_manager = new CategoryManager();
        // GET: Product
        public ActionResult Index(int id = 0)
        {
            ProductListViewModel model = new ProductListViewModel();
            if (id == 0)
            {
                model = new ProductListViewModel
                {
                    Products = product_manager.getProduct()
                };
            }
            else
            {
                model = new ProductListViewModel
                {
                    Products = product_manager.getByIdCategoryProduct(id)
                };
            }


            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.Kategoriler = new SelectList(category_manager.getCategory(), "Id", "CategoryName").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product,HttpPostedFileBase image) {

            if (ModelState.IsValid)
            {
                if (image!=null)
                {
                    WebImage productImage = new WebImage(image.InputStream);
                    FileInfo info = new FileInfo(image.FileName);

                    string newphoto = Guid.NewGuid().ToString() + info.Extension;

                    productImage.Resize(250,250);
                    productImage.Save("~/img/products/" + newphoto);
                    product.Image = "/img/products/" + newphoto;
                }
                product.CreatedDate = DateTime.Now;
                product.ModifiedDate = DateTime.Now;
                product_manager.AddProduct(product,product.CategoryId);
            }
            return RedirectToAction("Index","Product");
        }

        public ActionResult Update(int id)
        {
            GetProductViewModel getproduct = new GetProductViewModel
            {
                GetProduct=product_manager.FindProduct(id)
            };
            ViewBag.Kategoriler = new SelectList(category_manager.getCategory(), "Id", "CategoryName").ToList();
            return View(getproduct.GetProduct);
        }

        [HttpPost]
        public ActionResult Update(int id ,Product product,HttpPostedFileBase image) {

            Product productid = product_manager.FindProduct(id);

            if (System.IO.File.Exists(Server.MapPath(productid.Image)))
            {
                System.IO.File.Delete(Server.MapPath(productid.Image));
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                   
                    WebImage productImage = new WebImage(image.InputStream);
                    FileInfo info = new FileInfo(image.FileName);

                    string newphoto = Guid.NewGuid().ToString() + info.Extension;

                    productImage.Resize(250, 250);
                    productImage.Save("~/img/products/" + newphoto);
                    productid.Image = "/img/products/" + newphoto;

                }
                productid.ProductName = product.ProductName;
                productid.ProductDescripion = product.ProductDescripion;
                productid.ModifiedDate = DateTime.Now;
                productid.CategoryId = product.CategoryId;

                product_manager.UpdateProduct(id, productid);
                return RedirectToAction("Index", "Product");
            }
            

            return RedirectToAction("Index","Product");
        }
        
        public ActionResult Delete(int id)
        {
            Product product = product_manager.FindProduct(id);
            if (System.IO.File.Exists(Server.MapPath(product.Image)))
            {
                System.IO.File.Delete(Server.MapPath(product.Image));
            }

            product_manager.DeleteProduct(id);

            return RedirectToAction("Index","Product");
        }

        public ActionResult Detail(int id)
        {

            Product product = product_manager.FindProduct(id);
            return View(product);
        }
    }
}