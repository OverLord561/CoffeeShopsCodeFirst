using CoffeeShopsCodeFirst.BLL;
using CoffeeShopsCodeFirst.BLL.RDL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShopsCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopsRepository repo = new CoffeeShopsRepository();
            repo.db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            var coments = repo.GetUserCommentsViaProcedure("fda78599-b7b5-48ee-838f-37527a209a01", 3);

           


            return View();
        }
        public ActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Cabinet(HttpPostedFileBase file)
        {
            Manager mng = new Manager();
            CoffeeShopsRepository repo = new CoffeeShopsRepository();
          
            string userID = User.Identity.GetUserId();
            ViewBag.Message = mng.UploadPhoto(userID, file);
            
            return View("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}