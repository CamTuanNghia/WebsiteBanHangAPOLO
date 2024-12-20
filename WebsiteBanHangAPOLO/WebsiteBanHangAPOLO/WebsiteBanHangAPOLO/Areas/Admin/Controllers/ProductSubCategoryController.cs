using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHangAPOLO.Models;
using WebsiteBanHangAPOLO.Models.EF;

namespace WebsiteBanHangAPOLO.Areas.Admin.Controllers
{
    public class ProductSubCategoryController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductSubCategory
        public ActionResult Index(string SearchString)
        {
            List<ProductSubCategory> lstProductSubCategory;

            if (!string.IsNullOrEmpty(SearchString))
            {
                string searchFilter = Models.Common.Filter.ChuyenCoDauThanhKhongDau(SearchString).ToLower();
                lstProductSubCategory = db.productSubCategories
                    .AsEnumerable()
                    .Where(x => Models.Common.Filter.ChuyenCoDauThanhKhongDau(x.Title).ToLower().Contains(searchFilter))
                    .ToList();
            }
            else
            {
                lstProductSubCategory = db.productSubCategories.ToList();
            }

            return View(lstProductSubCategory);
        }

        // GET: Admin/ProductSubCategory/Add
        public ActionResult Add()
        {
            ViewBag.ProductCategories = new SelectList(db.ProductCategories, "ID", "Title");
            return View();
        }

        // POST: Admin/ProductSubCategory/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductSubCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                db.productSubCategories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategories = new SelectList(db.ProductCategories, "ID", "Title", model.ParentCategoryID);
            return View(model);
        }

        // POST: Admin/ProductSubCategory/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.productSubCategories.Find(id);
            if (item != null)
            {
                db.productSubCategories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        // GET: Admin/ProductSubCategory/Edit
        public ActionResult Edit(int id)
        {
            var item = db.productSubCategories.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProductCategories = new SelectList(db.ProductCategories, "ID", "Title", item.ParentCategoryID);
            return View(item);
        }

        // POST: Admin/ProductSubCategory/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSubCategory model)
        {
            if (ModelState.IsValid)
            {
                var item = db.productSubCategories.Find(model.ID);
                if (item != null)
                {
                    item.Title = model.Title;
                    item.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                    item.ParentCategoryID = model.ParentCategoryID;
                    item.Descripttion = model.Descripttion;
                    item.Icon = model.Icon;
                    item.SeoTitle = model.SeoTitle;
                    item.SeoDescription = model.SeoDescription;
                    item.SeoKeywords = model.SeoKeywords;
                    item.ModifiedDate = DateTime.Now;

                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ProductCategories = new SelectList(db.ProductCategories, "ID", "Title", model.ParentCategoryID);
            return View(model);
        }
    }
}
