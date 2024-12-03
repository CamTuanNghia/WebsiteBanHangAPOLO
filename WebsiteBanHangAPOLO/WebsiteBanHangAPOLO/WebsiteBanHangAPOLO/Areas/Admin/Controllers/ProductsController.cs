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
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Products
        public ActionResult Index(string SearchString, int? page)
        {
            IPagedList<Product> lstProduct; ;
            var PageSize = 10;
            var pageIndex = page ?? 1;

            if (!string.IsNullOrEmpty(SearchString))
            {
                string sr = Models.Common.Filter.ChuyenCoDauThanhKhongDau(SearchString).ToLower();
                lstProduct = db.Products.AsEnumerable().Where(x => Models.Common.Filter.ChuyenCoDauThanhKhongDau(x.Title).ToLower().Contains(sr)).ToList().ToPagedList(pageIndex, PageSize); ;
            }
            else
            {
                lstProduct = db.Products.OrderByDescending(x => x.ID).ToPagedList(pageIndex, PageSize);
            }
            ViewBag.Page = Convert.ToInt32(page ?? 1);
            ViewBag.PageSize = Convert.ToInt32(PageSize);
            return View(lstProduct);
        }
        public ActionResult Add()
        {
            
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "ID", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.ProductImages.Add(new ProductImage
                            {

                                ProductId = model.ID,
                                Image = Images[i],
                                IsDefault = true
                            });
                        }
                        else
                        {
                            model.ProductImages.Add(new ProductImage
                            {
                                ProductId = model.ID,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.IsActive = true;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "ID", "Title");
            var item = db.Products.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid) {      
                db.Products.Attach(model);
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebsiteBanHangAPOLO.Models.Common.Filter.FilterChar(model.Title);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "ID", "Title",model.ProductCategoryId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                /*var DeteleItem = db.Categories.Attach(item);*/
                db.Products.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public JsonResult ToggleActive(int id, bool isActive)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsActive = isActive;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult ToggleHome(int id, bool isHome)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsHome = isHome;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public JsonResult ToggleSale(int id, bool isSale)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsSale = isSale;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}