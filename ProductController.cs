using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pagination_MVC.Models;

namespace Pagination_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly Entities db = new Entities();
        // GET: Product
        public ActionResult Index(int? page)
        {
            var data = (from s in db.Product1 select s);
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int limit = 5;
            int start = (int) (page - 1) * limit;
            int totalProduct = data.Count();
            ViewBag.totalProduct = totalProduct;
            ViewBag.pagecurrent = page;
            float numberpage = (float) totalProduct / limit;
            ViewBag.numberpage = (int)Math.Ceiling(numberpage);
            var dataProduct = data.OrderByDescending(s => s.ProductID).Skip(start).Take(limit);

            return View(data.ToList());
           
        }
    }
}