using System;
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
using CustomerAppBackend.ShopInterface.Shopify;

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

        public JsonResult CreateCustomer()
        {
            var data = Request["customer"];
            var api = new Shopify();
            var retval = api.CreateCustomer(data).FirstOrDefault();
            return Json(retval);
        }

        public JsonResult GetCustomer()
        {
            var email = Request["email"];
            var api = new Shopify();
            var retval = api.GetCustomer(email);
            return Json(retval);
        }

        public JsonResult GetOrders()
        {
            var customerId = Int32.Parse(Request["customerId"]);
            var api = new Shopify();
            var retval = api.GetOrders(customerId);
            return Json(retval);
        }
            
        public void StoreTest() {
//            var customer = new Customer
//            {
//                    FirstName = "Jane",
//                    LastName = "Doe15",
//                    Email = "jane.doe15@testemail.com",
//                    Addressess = new List<Address> {
//                        new Address {
//                            Address1 = "123 E Spring St",
//                            Address2 = "Apt 12",
//                            City = "New Albany",
//                            State = "IN",
//                            Zip = "47150",
//                            Country = "US",
//                            FirstName = "Jane",
//                            LastName = "Doe",
//                            Phone = "8125551212"
//                        }
//                    },
//                    Password = "password1"
//            };

            var api = new Shopify();
            var customer = api.GetCustomer("olan.hall@icloud.com");
            //var orders = api.GetOrders(customer.Id);
            //var customers = api.SearchCustomer("default_address.zip:12345");
            var products = api.GetProducts();



            var lineItem = new LineItem()
            {
                Id = products[0].Variants[3].Id,
                Quantity = 1
            };

            var transaction = new Transaction()
            {
                TransactionType = CustomerAppBackend.ShopInterface.TransactionType.Sale,
                Status = CustomerAppBackend.ShopInterface.TransactionStatus.Success,
                Amount = products[0].Variants[3].Price
            };

            var taxes = api.CalculateTaxes(customer.DefaultAddress.Country, customer.DefaultAddress.State, products[0].Variants[3].Price);
            var totalTaxes = taxes.Sum(x => x.Price);

            var order = new Order()
            {
                    Customer = customer,
                    BillingAddress = customer.DefaultAddress,
                    ShippingAddress = customer.DefaultAddress,
                    Taxes = taxes,
                    Transactions = new List<Transaction>() { transaction },
                    Email = customer.Email
            };

//            var a = 1 + 1;
        }
    }
}
