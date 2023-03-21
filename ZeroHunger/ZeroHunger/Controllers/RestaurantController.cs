using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.EF.Models;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        //[HttpGet]
        public ActionResult Index(int id = 1) //id means page number
        {

            ZeroHungerContext db = new ZeroHungerContext();
            int itemperpage = 10;
            int total = db.Products.Count();
            int pages = (int)Math.Ceiling(total / (double)itemperpage);
            ViewBag.pages = pages;

            var products = db.Products.OrderBy(p => p.Id).Skip((id - 1) * itemperpage).Take(itemperpage).ToList();

            return View(products);
        }
        //[HttpPost]
        //public ActionResult Index(Request model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("RequestDetails");
        //    }
        //    return View(model);
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult AddReq (int id)
        {
            ZeroHungerContext db = new ZeroHungerContext();
            var product = db.Products.Find(id);

            List<Product> req = null;
            if (Session["req"] == null)
            {
                req = new List<Product>();
            }
            else
            {
                req = (List<Product>)Session["req"];
            }

            req.Add(new Product() {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
            });
            db.SaveChanges();
            Session["req"] = req;
            TempData["msg"] = "Product Added to Request!";
            TempData["color"] = "alert-success";

            return RedirectToAction("Index");
        }

        //public ActionResult SubmitExpDate()
        //{
        //    ZeroHungerContext db = new ZeroHungerContext();
        //    Request request = new Request();

        //    request.ExpDate = DateTime.Now.AddHours(5);
        //    db.Requests.Add(request);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        public ActionResult RequestDetails () 
        {
            if (Session["req"] != null)
            {
                return View((List<Product>)Session["req"]);
            }
                
            TempData["msg"] = "Request Empty";
            TempData["color"] = "alert-info";
            return RedirectToAction("Index");
        }

        public ActionResult PlaceRequest()
        {
            ZeroHungerContext db = new ZeroHungerContext();
            Request request = new Request();

            request.ReqDate = DateTime.Now;
            request.ExpDate= DateTime.Now.AddHours(5);
            request.Status = "Request Placed";

            db.Requests.Add(request);
            db.SaveChanges();
            var products = (List<Product>)Session["req"];

            foreach (var prod in products)
            {
                ProdReq pr = new ProdReq();
                pr.Req_Id = request.Id;
                pr.Prod_Id = prod.Id;

                db.ProdReqs.Add(pr);
            }
            db.SaveChanges();
            Session["req"] = null;
            TempData["msg"] = "Request Successfully Placed";
            TempData["color"] = "alert-success";
            return RedirectToAction("Index");
        }
    }
}