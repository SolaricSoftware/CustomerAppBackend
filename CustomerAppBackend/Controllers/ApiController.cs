using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        public JsonResult GetCustomer()
        {
            var retval = new DataWrapper<AppCustomerDao>()
                {
                    Error = String.Empty,
                    Data = null
                };

            Guid accessKey;
            if (Guid.TryParse(Request["accessKey"], out accessKey))
            {
                var db = new DataAccess();
                retval.Data = db.AppCustomers.FirstOrDefault(x => x.Active == true && x.AccessKey == accessKey).ToDao(true);
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

        public void StoreTest()
        {
            var apiKey = "8037a4e7d88990e51606487d2faee5e8";
            var password = "7460df937d2be2ce09c69b29ce3a19b9";
            var storeName = "customerappteststore";
            //var resource = "admin/products";
            var resource = "admin";
            var call = "customers";
            var parms = "query= email:bob@solaricsoftware.com";

            var url = String.Format("https://{0}.myshopify.com/{1}{2}{3}.json{4}", storeName, resource, !String.IsNullOrWhiteSpace(call) ? "/" : String.Empty, call, !String.IsNullOrWhiteSpace(parms) ? "?" + parms : String.Empty);
            var uri = new Uri(url);
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Credentials = new NetworkCredential(apiKey, password);

            try
            {
                var response = request.GetResponse() as HttpWebResponse;
                var reader = new StreamReader(response.GetResponseStream());
                var json = reader.ReadToEnd();
                dynamic obj = (new JavaScriptSerializer()).DeserializeObject(json);
                var b = 1 + 1;
            }
            catch(Exception ex)
            {
                var tmp = ex.Message;

            }

            var a = 1 + 1;
        }
    }
}
