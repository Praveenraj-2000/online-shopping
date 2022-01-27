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
    public class itemController : Controller
    {
        private EcartDBEntities objEcartDBEntities;

        public itemController ()
        {
            objEcartDBEntities = new EcartDBEntities();
        }
        
        public ActionResult Index()
        {
            itemViewModel objitemViewModel = new itemViewModel();
            objitemViewModel.categoryselectListItem = (from objcat in objEcartDBEntities.categories
                                                       select new SelectListItem()
                                                       {
                                                           Text = objcat.categoryName ,
                                                           Value = objcat.categoryId.ToString(),
                                                           Selected = true
                                                       }
                                                       );

            return View(objitemViewModel);
        }
        [HttpPost]
        public JsonResult Index(itemViewModel objitemViewModel)
        {
            string NewImage = Guid.NewGuid() + Path.GetExtension(objitemViewModel.imagePath.FileName);
            objitemViewModel.imagePath.SaveAs(filename: Server.MapPath("~/images/" + NewImage));
            item objitem = new item();
            objitem.imagePath = "~/images/" + NewImage;
            objitem.categoryId = objitemViewModel.categoryId;
            objitem.itemCode = objitemViewModel.itemCode;
            objitem.itemId = Guid.NewGuid();
            objitem.itemName = objitemViewModel.itemName;
            objitem.itemPrice = objitemViewModel.itemPrice;
            objEcartDBEntities.items.Add(objitem);
            objEcartDBEntities.SaveChanges();
            return Json( new {Success = true, Message = " the item is added successfully"}, JsonRequestBehavior.AllowGet);
        }
    }
}