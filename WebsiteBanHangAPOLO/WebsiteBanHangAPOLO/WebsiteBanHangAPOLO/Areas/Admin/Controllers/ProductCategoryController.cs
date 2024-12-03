using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHangAPOLO.Models;
using WebsiteBanHangAPOLO.Models.EF;

namespace WebsiteBanHangAPOLO.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: Admin/ProductCategory
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index(string SearchString)
        {
            List<ProductCategory> lstProductCategory;

            if (!string.IsNullOrEmpty(SearchString))
            {
                string sr = Models.Common.Filter.ChuyenCoDauThanhKhongDau(SearchString).ToLower();
                lstProductCategory = db.ProductCategories.AsEnumerable().Where(x => Models.Common.Filter.ChuyenCoDauThanhKhongDau(x.Title).ToLower().Contains(sr)).ToList();
            }
            else
            {
                lstProductCategory = db.ProductCategories.ToList();
            }

            return View(lstProductCategory);

        }
        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                db.ProductCategories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductCategories.Find(id);
            if (item != null)
            {
                /*var DeteleItem = db.Categories.Attach(item);*/
                db.ProductCategories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        public ActionResult Edit(int Id)
        {
            var item = db.ProductCategories.Find(Id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Attach(model);
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}