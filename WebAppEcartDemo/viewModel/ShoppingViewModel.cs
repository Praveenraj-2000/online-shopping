using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEcartDemo.viewModel
{
	public class ShoppingViewModel
	{
	public Guid itemId { get; set;}

	public string itemName { get; set; }

	public decimal itemPrice { get; set; }

	public string imagePath { get; set; }

	public string description { get; set; }

	public string category{ get; set; }

	public string itemCode { get; set; }


	}
}