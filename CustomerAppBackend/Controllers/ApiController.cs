﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using CustomerAppBackend.Data;
using CustomerAppBackend.DataObject;
using CustomerAppBackend.ShopifyInterface;

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

//        public JsonResult GetCustomer()
//        {
//            var retval = new DataWrapper<AppCustomerDao>()
//                {
//                    Error = String.Empty,
//                    Data = null
//                };
//
//            Guid accessKey;
//            if (Guid.TryParse(Request["accessKey"], out accessKey))
//            {
//                var db = new DataAccess();
//                retval.Data = db.AppCustomers.FirstOrDefault(x => x.Active == true && x.AccessKey == accessKey).ToDao(true);
//            }
//            else
//            {
//                retval.Error = "Access Key is missing or invalid.";
//            }
//
//            return Json(retval, JsonRequestBehavior.AllowGet);
//        }
//
//        public JsonResult GetLocations()
//        {
//            var retval = new DataWrapper<List<AppCustomerLocationDao>>()
//                {
//                    Error = String.Empty,
//                    Data = new List<AppCustomerLocationDao>()
//                };
//            
//            Guid accessKey;
//            if (Guid.TryParse(Request["accessKey"], out accessKey))
//            {
//                var db = new DataAccess();
//                retval.Data = db.AppCustomerLocations.Where(x => 
//                                x.AppCustomer.AccessKey == accessKey &&
//                                x.AppCustomer.Active == true &&
//                                x.Active == true).ToDao();
//            }
//            else
//            {
//                retval.Error = "Access Key is missing or invalid.";
//            }
//
//            return Json(retval, JsonRequestBehavior.AllowGet);
//        }  
//
//        public JsonResult GetItems()
//        {
//            var retval = new DataWrapper<List<AppCustomerItemDao>>()
//                {
//                    Error = String.Empty,
//                    Data = new List<AppCustomerItemDao>()
//                };
//
//            Guid accessKey;
//            if (Guid.TryParse(Request["accessKey"], out accessKey))
//            {
//                int locationId;
//                Int32.TryParse(Request["locationId"], out locationId);
//
//                var db = new DataAccess();
//                retval.Data = db.AppCustomerItems.Where(x => 
//                    x.Active == true &&
//                    x.AppCustomerLocation.Active == true &&
//                    x.AppCustomerLocation.AppCustomer.Active == true &&
//                    x.AppCustomerLocation.AppCustomer.AccessKey == accessKey &&
//                    (locationId == 0 || x.AppCustomerLocationID == locationId)).ToDao();
//            }
//            else
//            {
//                retval.Error = "Access Key is missing or invalid.";
//            }
//
//            return Json(retval, JsonRequestBehavior.AllowGet);
//        }
//
//        public JsonResult GetSaleItems()
//        {
//            var retval = new DataWrapper<List<AppCustomerItemSaleDao>>()
//                {
//                    Error = String.Empty,
//                    Data = new List<AppCustomerItemSaleDao>()
//                };
//
//            Guid accessKey;
//            if (Guid.TryParse(Request["accessKey"], out accessKey))
//            {
//                int locationId;
//                Int32.TryParse(Request["locationId"], out locationId);
//
//                var db = new DataAccess();
//                retval.Data = db.AppCustomerItemSales.Where(x => 
//                    x.AppCustomerItem.Active == true &&
//                    x.AppCustomerItem.AppCustomerLocation.Active == true &&
//                    x.AppCustomerItem.AppCustomerLocation.AppCustomer.Active == true &&
//                    x.AppCustomerItem.AppCustomerLocation.AppCustomer.AccessKey == accessKey &&
//                    (locationId == 0 || x.AppCustomerItem.AppCustomerLocationID == locationId)).ToDao(true);
//            }
//            else
//            {
//                retval.Error = "Access Key is missing or invalid.";
//            }
//
//            return Json(retval, JsonRequestBehavior.AllowGet);
//        }
//
//        public JsonResult GetFeaturedItems()
//        {
//            var retval = new DataWrapper<List<AppCustomerItemFeaturedDao>>()
//                {
//                    Error = String.Empty,
//                    Data = new List<AppCustomerItemFeaturedDao>()
//                };
//
//            Guid accessKey;
//            if (Guid.TryParse(Request["accessKey"], out accessKey))
//            {
//                int locationId;
//                Int32.TryParse(Request["locationId"], out locationId);
//
//                var db = new DataAccess();
//                retval.Data = db.AppCustomerItemFeatured.Where(x => 
//                    x.AppCustomerItem.Active == true &&
//                    x.AppCustomerItem.AppCustomerLocation.Active == true &&
//                    x.AppCustomerItem.AppCustomerLocation.AppCustomer.Active == true &&
//                    x.AppCustomerItem.AppCustomerLocation.AppCustomer.AccessKey == accessKey &&
//                    (locationId == 0 || x.AppCustomerItem.AppCustomerLocationID == locationId)).ToDao(true);
//            }
//            else
//            {
//                retval.Error = "Access Key is missing or invalid.";
//            }
//
//            return Json(retval, JsonRequestBehavior.AllowGet);
//        }

        public JsonResult CreateCustomer(string data)
        {
            var customer = Deserialize<Customer>(data);
            var api = new Shopify();
            var path = "/admin/customers.json";
            var retval = api.Post<Customer>(path, customer);
            return Json(retval);
        }

        public JsonResult GetCustomer(string email)
        {
            var path = "/admin/customers/search.json";
            var api = new Shopify();
            var retval = api.Get<Customer>(path, String.Format("query= email:{0}", email));
            return Json(retval);
        }

        public JsonResult GetOrders(int customerId)
        {
            return Json("");
        }
            
        public void StoreTest() {
            var customer = new Customer
            {
                    FirstName = "Jane",
                    LastName = "Doe15",
                    Email = "jane.doe15@testemail.com",
                    Addressess = new List<Address> {
                        new Address {
                            Address1 = "123 E Spring St",
                            Address2 = "Apt 12",
                            City = "New Albany",
                            State = "IN",
                            Zip = "47150",
                            Country = "US",
                            FirstName = "Jane",
                            LastName = "Doe",
                            Phone = "8125551212"
                        }
                    },
                    Password = "password1"
            };


            this.CreateCustomer(this.Serialize(customer));
            //this.GetCustomer("olan.hall@icloud.com");

            var a = 1 + 1;
        }

        private T Deserialize<T>(string data)
        {
            return (new JavaScriptSerializer()).Deserialize<T>(data);
        }

        private string Serialize(object data)
        {
            return (new JavaScriptSerializer()).Serialize(data);
        }
    }
}
