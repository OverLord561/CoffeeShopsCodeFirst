using CoffeeShopsCodeFirst.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShopsCodeFirst.Controllers
{
    public class CoffeeShopsController : Controller
    {
        CoffeeShopsRepository repo = new CoffeeShopsRepository();
        // GET: CoffeeShops
        public ActionResult Review(int id)
        {
            TempData["coffeeID"] = id;
            var _shop =  repo.GetCoffeeShopById(id);
            return View(_shop);
        }

        public JsonResult MapData()
        {
            int ID =Convert.ToInt32( TempData.Peek("coffeeID"));
            Models.CoffeeShop _shop = repo.GetCoffeeShopById(ID);

            return Json(_shop, JsonRequestBehavior.AllowGet);
        }
    }

    
}