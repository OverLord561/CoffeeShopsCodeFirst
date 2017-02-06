using CoffeeShopsCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplicationInternet.Models
{
    public class UserComment
    {

        public int UserCommentID { get; set; }
        public string LabelText { get; set; }
        public System.DateTime Date { get; set; }
        public int CoffeeShopID { get; set; }


        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        public virtual CoffeeShop CoffeeShop { get; set; }
    }
}