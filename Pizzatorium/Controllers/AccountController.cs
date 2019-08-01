using Pizzatorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzatorium.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private StoreDBContext db = new StoreDBContext();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "dUserName,dPassword")] LUser user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var obj = db.Users.Where(a => a.dUserName.Equals(user.dUserName) && a.dPassword.Equals(user.dPassword)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Username"] = obj.dUserName;
                        return RedirectToAction("Design", "Order");
                    }
                }
                catch (Exception)
                {
                    RedirectToAction("Error", "Index");
                }
            }
            ViewBag.Success = "Invalid";
            return View(user);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,dName,dUserName,dPassword,dAddress,dPhone,dFavPizza")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                RedirectToAction("Error", "Index");
            }

            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}