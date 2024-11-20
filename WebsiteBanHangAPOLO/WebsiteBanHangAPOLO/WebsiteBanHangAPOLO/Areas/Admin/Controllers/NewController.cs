using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHangAPOLO.Models;
using WebsiteBanHangAPOLO.Models.EF;

namespace WebsiteBanHangAPOLO.Areas.Admin.Controllers
{
    public class NewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/New
        public ActionResult Index(string SearchString, int? page)
        {
            IPagedList<New> lstNew;
            var PageSize = 10;
            var pageIndex = page ?? 1;

            if (!string.IsNullOrEmpty(SearchString))
            {
                string sr = Models.Common.Filter.ChuyenCoDauThanhKhongDau(SearchString).ToLower();
                lstNew = db.News.AsEnumerable().Where(x => Models.Common.Filter.ChuyenCoDauThanhKhongDau(x.Title).ToLower().Contains(sr)).ToList().ToPagedList(pageIndex,PageSize);
            }
            else
            {
                lstNew = db.News.OrderByDescending(x => x.ID).ToPagedList(pageIndex,PageSize);
            }
            ViewBag.PageSize = PageSize;
            ViewBag.Page = pageIndex;
            return View(lstNew);

        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(New model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                // model.CategoryId = 3;
                model.IsActive = true;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                db.News.Add(model);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }
        public ActionResult Edit(int Id)
        {
            var item = db.News.Find(Id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(New model)
        {
            if (ModelState.IsValid)
            {
                db.News.Attach(model);
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult ToggleActive(int id, bool isActive)
        {
            var item = db.News.Find(id);
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
            var item = db.News.Find(id);
            if (item != null)
            {
                /*var DeteleItem = db.Categories.Attach(item);*/
                db.News.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}