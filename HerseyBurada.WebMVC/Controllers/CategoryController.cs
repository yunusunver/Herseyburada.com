using HerseyBurada.Business.Concrete;
using HerseyBurada.Entities.EntitiesTable;
using HerseyBurada.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerseyBurada.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager category_manager=new CategoryManager();
       

        public ActionResult Index()
        {
            CategoryListViewModel model = new CategoryListViewModel
            {
                ListCategory = category_manager.getCategory()
            };
            return View(model);
            
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                category_manager.AddCategory(category);
            }
            else
            {
                ModelState.AddModelError("","Lütfen bilgileri doğru girin.");
            }

            return RedirectToAction("Index","Category");
        }

        public ActionResult Update(int id)
        {
            GetCategoryViewModel model = new GetCategoryViewModel
            {
                GetCategory=category_manager.FindCategory(id)
            };
            return View(model.GetCategory);
        }

        [HttpPost]
        public ActionResult Update(int id,Category category)
        {
            
            category_manager.UpdateCategory(id,category);
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Delete(int id) {

            category_manager.DeleteCategory(id);
            return RedirectToAction("Index", "Category");
        }

    }
}