using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEcartDemo.Models;
using WebAppEcartDemo.viewModel;
using System.IO;


namespace WebAppEcartDemo.Controllers
{



    public class shoppingController : Controller
    {
        private EcartDBEntities objEcartDBEntities;
        public shoppingController()
        {


           objEcartDBEntities = new EcartDBEntities();

    }

    // GET: shopping
    public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> ListOfShoppingViewModels = (from objItem in objEcartDBEntities.items
                                                                       join
                                                                       objcate in objEcartDBEntities.categories
                                                                       on objItem.categoryId equals objcate.categoryId
                                                                       select new ShoppingViewModel()
                                                                       {
                                                                           imagePath = objItem.imagePath,
                                                                           itemName = objItem.itemName,
                                                                           description = objItem.description,
                                                                           itemPrice = objItem.itemPrice,
                                                                           itemId = objItem.itemId,
                                                                           category = objcate.categoryName,
                                                                           itemCode = objItem.itemCode,
                                                                       }).ToList();
            return View(ListOfShoppingViewModels);
        }

    }
}