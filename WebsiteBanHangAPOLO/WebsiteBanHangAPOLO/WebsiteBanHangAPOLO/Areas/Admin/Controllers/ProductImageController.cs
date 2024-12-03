using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHangAPOLO.Models;
using WebsiteBanHangAPOLO.Models.EF;

namespace WebsiteBanHangAPOLO.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImage
        public ActionResult Index(int Id)
        {
            ViewBag.ProductId = Id;
            var items = db.ProductImages.Where(x => x.ProductId == Id).ToList();
            return View(items);
        }
        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            db.ProductImages.Add(new ProductImage
            {
                ProductId = productId,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductImages.Find(id);
            db.ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult SetDefault(int id)
        {
            var newDefaultImage = db.ProductImages.Find(id);
            if (newDefaultImage == null)
            {
                return Json(new { success = false, message = "Không tìm thấy ảnh." });
            }

            var productImages = db.ProductImages.Where(x => x.ProductId == newDefaultImage.ProductId).ToList();
            foreach (var img in productImages)
            {
                img.IsDefault = false;
            }
            newDefaultImage.IsDefault = true;
            db.SaveChanges();
            return Json(new { success = true });
        }

    }
}
