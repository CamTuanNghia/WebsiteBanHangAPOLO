using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHangAPOLO.Models;
using WebsiteBanHangAPOLO.Models.EF;

namespace WebsiteBanHangAPOLO.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
            ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index(string SearchString)
        {
            var subCategories = db.subCategories.Include("Category").AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                string sr = Models.Common.Filter.ChuyenCoDauThanhKhongDau(SearchString).ToLower();

                subCategories = subCategories.Where(sc =>
                    Models.Common.Filter.ChuyenCoDauThanhKhongDau(sc.Title).ToLower().Contains(sr) ||
                    Models.Common.Filter.ChuyenCoDauThanhKhongDau(sc.Category.Title).ToLower().Contains(sr)
                );
            }
            return View(subCategories.ToList());
        }
        public ActionResult Add()
            {
            ViewBag.ParentID = new SelectList(db.Categories, "ID", "Title");
            return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Add(SubCategory model)
            {
            var categories = db.subCategories.Where(c => c.IsActive).Select(c => new{c.ID,c.Title}).ToList();
            if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;
                    model.ModifiedDate = DateTime.Now;
                    model.IsActive = true;
                    model.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                    db.subCategories.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            ViewBag.CategoryList = new SelectList(categories, "ID", "Title");
            return View(model);
            }
            public ActionResult Edit(int id)
            {
                var item = db.subCategories.Find(id);
            ViewBag.Categories = new SelectList(db.Categories, "ID", "Title", item.ParentID);
            return View(item);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(SubCategory model)
            {
                if (ModelState.IsValid)
                {
                    db.subCategories.Attach(model);
                    model.ModifiedDate = DateTime.Now;
                    db.Entry(model).Property(x => x.Title).IsModified = true;
                    db.Entry(model).Property(x => x.Alias).IsModified = true;
                    db.Entry(model).Property(x => x.Descripttion).IsModified = true;
                    db.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                    db.Entry(model).Property(x => x.SeoDecripttion).IsModified = true;
                    db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                    db.Entry(model).Property(x => x.Position).IsModified = true;
                    db.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                    db.Entry(model).Property(x => x.ModifiedBy
                    ).IsModified = true;
                    model.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            ViewBag.Categories = new SelectList(db.Categories, "ID", "Title", model.ParentID);
            return View(model);
            }
            [HttpPost]
            public JsonResult ToggleActive(int id, bool isActive)
            {
                var item = db.subCategories.Find(id);
                if (item != null)
                {
                    item.IsActive = isActive;
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
            public ActionResult Delete(int id)
            {
                var item = db.subCategories.Find(id);
                if (item != null)
                {
                    /*var DeteleItem = db.Categories.Attach(item);*/
                    db.subCategories.Remove(item);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
        }
    }