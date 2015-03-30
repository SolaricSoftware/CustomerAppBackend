using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using CustomerAppBackend.Data;
using CustomerAppBackend.DataObject;

namespace CustomerAppBackend.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			return Json ("");
		}

		public JsonResult GetCustomers() {
			var customers = new List<AppCustomerDao> ();
			var da = new DataAccess ();

			customers.AddRange (da.AppCustomer.Select (ac => new AppCustomerDao {
				Name = ac.Name,
				Address1 = ac.Address1
			}));

			return Json (customers, JsonRequestBehavior.AllowGet);
		}
	}
}
	