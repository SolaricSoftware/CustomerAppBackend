﻿using System;
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
			return Json ("Index");
		}
	}
}
	