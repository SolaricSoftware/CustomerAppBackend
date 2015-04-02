using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using CustomerAppBackend.Data;
using CustomerAppBackend.DataObject;

namespace CustomerAppBackend.Controllers
{
    public class ApiController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public JsonResult CanAccess()
        {
            var retval = new DataWrapper<bool>()
                {
                    Error = String.Empty,
                    Data = false
                };
                      
            Guid accessKey;
            if (Guid.TryParse(Request["accessKey"], out accessKey))
            {
                var db = new DataAccess();
                retval.Data = db.AppCustomers.Any(x => x.AccessKey == accessKey && x.Active == true);
            }
            else
            {
                retval.Error = "Access Key is missing or invalid.";
            }

            return Json(retval, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLocations()
        {
            var retval = new DataWrapper<List<AppCustomerLocationDao>>()
                {
                    Error = String.Empty,
                    Data = new List<AppCustomerLocationDao>()
                };
            
            Guid accessKey;
            if (Guid.TryParse(Request["accessKey"], out accessKey))
            {
                var db = new DataAccess();

                retval.Data = db.AppCustomerLocations.Where(x => 
                                x.AppCustomer.AccessKey == accessKey &&
                                x.AppCustomer.Active == true &&
                                x.Active == true).ToDao();
            }
            else
            {
                retval.Error = "Access Key is missing or invalid.";
            }

            return Json(retval, JsonRequestBehavior.AllowGet);
        }  

        public JsonResult GetItems()
        {
            var retval = new DataWrapper<List<AppCustomerItemDao>>()
                {
                    Error = String.Empty,
                    Data = new List<AppCustomerItemDao>()
                };

            Guid accessKey;
            if (Guid.TryParse(Request["accessKey"], out accessKey))
            {
                int locationId;
                Int32.TryParse(Request["locationId"], out locationId);

                var db = new DataAccess();

                retval.Data = db.AppCustomerItems.Where(x => 
                    x.Active == true &&
                    x.AppCustomerLocation.Active == true &&
                    x.AppCustomerLocation.AppCustomer.Active == true &&
                    x.AppCustomerLocation.AppCustomer.AccessKey == accessKey &&
                    (locationId == 0 || x.AppCustomerLocationID == locationId)).ToDao();
            }
            else
            {
                retval.Error = "Access Key is missing or invalid.";
            }

            return Json(retval, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSaleItems()
        {
            var retval = new DataWrapper<List<AppCustomerItemSaleDao>>()
                {
                    Error = String.Empty,
                    Data = new List<AppCustomerItemSaleDao>()
                };

            Guid accessKey;
            if (Guid.TryParse(Request["accessKey"], out accessKey))
            {
                int locationId;
                Int32.TryParse(Request["locationId"], out locationId);

                var db = new DataAccess();

                retval.Data = db.AppCustomerItemSales.Where(x => 
                    x.AppCustomerItem.Active == true &&
                    x.AppCustomerItem.AppCustomerLocation.Active == true &&
                    x.AppCustomerItem.AppCustomerLocation.AppCustomer.Active == true &&
                    x.AppCustomerItem.AppCustomerLocation.AppCustomer.AccessKey == accessKey &&
                    (locationId == 0 || x.AppCustomerItem.AppCustomerLocationID == locationId)).ToDao(true);
            }
            else
            {
                retval.Error = "Access Key is missing or invalid.";
            }

            return Json(retval, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFeaturedItems()
        {
            var retval = new DataWrapper<List<AppCustomerItemFeaturedDao>>()
                {
                    Error = String.Empty,
                    Data = new List<AppCustomerItemFeaturedDao>()
                };

            Guid accessKey;
            if (Guid.TryParse(Request["accessKey"], out accessKey))
            {
                int locationId;
                Int32.TryParse(Request["locationId"], out locationId);

                var db = new DataAccess();

                retval.Data = db.AppCustomerItemFeatured.Where(x => 
                    x.AppCustomerItem.Active == true &&
                    x.AppCustomerItem.AppCustomerLocation.Active == true &&
                    x.AppCustomerItem.AppCustomerLocation.AppCustomer.Active == true &&
                    x.AppCustomerItem.AppCustomerLocation.AppCustomer.AccessKey == accessKey &&
                    (locationId == 0 || x.AppCustomerItem.AppCustomerLocationID == locationId)).ToDao(true);
            }
            else
            {
                retval.Error = "Access Key is missing or invalid.";
            }

            return Json(retval, JsonRequestBehavior.AllowGet);
        }
    }
}
