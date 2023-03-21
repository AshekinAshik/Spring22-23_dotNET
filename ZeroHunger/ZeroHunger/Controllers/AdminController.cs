using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.EF.Models;

namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AddAccept(int id)
        {
            ZeroHungerContext db = new ZeroHungerContext();
            var pr = db.ProdReqs.Find(id);

            List<ProdReq> preq = null;
            if (Session["preq"] == null)
            {
                preq = new List<ProdReq>();
            }
            else
            {
                preq = (List<ProdReq>)Session["preq"];
            }

            preq.Add(new ProdReq()
            {
                Id = pr.Id,
                Prod_Id = pr.Prod_Id,
                Req_Id = pr.Req_Id
            });
            db.SaveChanges();
            Session["preq"] = preq;
            TempData["msg"] = "Request Accepted!";
            TempData["color"] = "alert-success";

            return RedirectToAction("Index");
        }

        public ActionResult AcceptDetails()
        {
            if (Session["preq"] != null)
            {
                return View((List<ProdReq>)Session["preq"]);
            }

            TempData["msg"] = "No Request Accepted";
            TempData["color"] = "alert-info";
            return RedirectToAction("Index");
        }

        public ActionResult AcceptRequest()
        {
            ZeroHungerContext db = new ZeroHungerContext();
            Employee employee = new Employee();

            var prodreq = (List<ProdReq>)Session["preq"];

            foreach (var v in prodreq)
            {
                EmpProdReq epr = new EmpProdReq();
                epr.Status = "Request Accepted";
                epr.Emp_Id = employee.Id;
                epr.ProdReq_Id = v.Prod_Id;

                db.EmpProdReqs.Add(epr);
            }
            db.SaveChanges();
            Session["preq"] = null;
            TempData["msg"] = "Request Successfully Accepted";
            TempData["color"] = "alert-success";
            return RedirectToAction("Index");
        }
    }
}