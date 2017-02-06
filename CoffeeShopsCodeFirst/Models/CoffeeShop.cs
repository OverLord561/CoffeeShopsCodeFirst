using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationInternet.Models
{
    public class CoffeeShop
    {
        public int CoffeeShopID { get; set; }
        public string CoffeeShopName { get; set; }
        public string CoffeeShopAdress { get; set; }
        public double CoffeeShopRating { get; set; }
        public string CoffeeShopImage { get; set; }
        public string CoffeeShopWebsite { get; set; }
        public string CoffeeShopNumber { get; set; }
        public string CoffeeShopTime { get; set; }
        public string CoffeeShopWiFi { get; set; }
        public string CoffeeShopLoyaltyCard { get; set; }
        public string CoffeeShopOutdoorSeating { get; set; }
        public string CoffeeShopAlcoholLicence { get; set; }
        public string CoffeeShopDescription { get; set; }
        public Nullable<double> CoffeeShopLongitude { get; set; }
        public Nullable<double> CoffeeShopCoffeeLatitude { get; set; }

        public virtual ICollection<Novelty> Novelty { get; set; }

        public virtual ICollection<UserComment> UserComment { get; set; }

    }
}