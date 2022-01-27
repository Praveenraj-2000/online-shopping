using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEcartDemo.Models;
using WebAppEcartDemo.viewModel;
using System.IO;

namespace WebAppEcartDemo.viewModel
{
    public class itemViewModel
    {
        public Guid itemId { get; set; }

        public int categoryId { get; set; } 

        public string itemCode { get; set;  }

        public string itemName { get; set; }

        public decimal itemPrice { get; set; }

        public decimal description { get; set; }

        public HttpPostedFileBase imagePath { get; set; }

        public IEnumerable<SelectListItem> categoryselectListItem { get; set; }
    }
}