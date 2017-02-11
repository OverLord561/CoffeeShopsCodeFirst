using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShopsCodeFirst.Models
{
    public class Novelty
    {
        public int NoveltyID { get; set; }
        public string Article { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public System.DateTime Date { get; set; }
        public int CoffeeShopID { get; set; }

        public virtual CoffeeShop CoffeeShop { get; set; }
    }
}