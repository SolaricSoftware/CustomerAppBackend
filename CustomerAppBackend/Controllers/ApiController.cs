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

        private JsonRequestBehavior _requestBehavior = JsonRequestBehavior.AllowGet;

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

        [HttpPost]
        public JsonResult CreateCustomer()
        {
            var retval = new DataWrapper<Customer>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                var data = Request["customer"];
                var api = new Shopify();
                retval.Data = api.CreateCustomer(data).FirstOrDefault();
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetCustomer()
        {
            var retval = new DataWrapper<Customer>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                var email = Request["email"];
                var api = new Shopify();
                retval.Data = api.GetCustomer(email);
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetOrders()
        {
            var retval = new DataWrapper<List<Order>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                var customerId = Int32.Parse(Request["customerId"]);
                var api = new Shopify();
                retval.Data = api.GetOrders(customerId);
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetOrder()
        {
            var retval = new DataWrapper<Order>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                var orderId = Int32.Parse(Request["orderId"]);
                var api = new Shopify();
                retval.Data = api.GetOrder(orderId);
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        [HttpPost]
        public JsonResult CreateOrder()
        {
            var data = Request["order"]; 
            var wrapper = new DataWrapper<Order>();

            return Json(wrapper);
        }

        public JsonResult GetPolicy()
        {
            var retval = new DataWrapper<Policy>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                var api = new Shopify();
                retval.Data = api.GetPolicy();
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetLocations()
        {
            var retval = new DataWrapper<List<Location>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                var api = new Shopify();
                retval.Data = api.GetLocations();
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetLocation()
        {
            var retval = new DataWrapper<Location>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                var locationId = Int32.Parse(Request["locationId"]);
                var api = new Shopify();
                retval.Data = api.GetLocation(locationId);
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
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
//            var customer = api.GetCustomer("olan.hall@icloud.com");
//            //var orders = api.GetOrders(customer.Id);
//            //var customers = api.SearchCustomer("default_address.zip:12345");
//            var products = api.GetProducts();
//
//            var prod = products[0].Variants[3];
//            var lineItem = new LineItem()
//            {
//                VariantId = prod.Id,
//                Quantity = 1,
//                Title = prod.Title,
//                Price = prod.Price
//            };
//
//            var taxes = api.CalculateTaxes(customer.DefaultAddress.CountryCode, customer.DefaultAddress.StateCode, products[0].Variants[3].Price);
//            var totalTax = taxes.Sum(x => x.Price);
//            var cus = new Customer
//            {
//                Id = customer.Id
//            };
//            
//            var transaction = new Transaction()
//            {
//                TransactionType = CustomerAppBackend.ShopInterface.TransactionType.Sale,
//                Status = CustomerAppBackend.ShopInterface.TransactionStatus.Success,
//                Amount = prod.Price + totalTax
//            };
//                        
//            var order = new Order()
//            {
//                    LineItems = new List<LineItem> { lineItem },
//                    Customer = cus,
//                    BillingAddress = customer.DefaultAddress,
//                    ShippingAddress = customer.DefaultAddress,
//                    Taxes = taxes,
//                    Transactions = new List<Transaction> { transaction },
//                    Email = customer.Email,
//                    TotalTax = totalTax,
//                    FinancialStatus = CustomerAppBackend.ShopInterface.FinancialStatus.Paid,
//                    Currency = "USD"
//            };
//
//            var wrapper = new DataWrapper<Order>();
//
//            try
//            {
//                wrapper.Data = api.CreateOrder(order);
//            }
//            catch (WebException ex)
//            {
//                wrapper.Error = ex.Message;
//                
//                var aaa = 1 + 1;
//            }
//            catch(Exception ex)
//            {
//                wrapper.Error = ex.Message;
//                var bbb = 1 + 1;
//            }


            var a = 1 + 1;
        }
    }
}
