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
using CustomerAppBackend.ShopInterface;
using CustomerAppBackend.ShopInterface.Shopify;
using CustomerAppBackend.ShopInterface.Magento;

namespace CustomerAppBackend.Controllers
{
    public class ApiController : Controller
    {

        private JsonRequestBehavior _requestBehavior = JsonRequestBehavior.AllowGet;

        public ActionResult Index()
        {
            return View ();
        }

        public JsonResult CanAccess(string accessKey)
        {
            var retval = new DataWrapper<bool>()
                {
                    Error = String.Empty,
                    Data = true
                };
                      
            string error;
            var db = new DataAccess();
            retval.Data = db.CanAccess(accessKey, out error);
            retval.Error = error;

            return Json(retval, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Login(string accessKey, string username, string password) 
        {
            var retval = new DataWrapper<Customer>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    //var api = new ShopifyClient();
                    var api = new MagentoClient();
                    var customer = api.GetCustomer(username, password);

                    if (customer != null)
                    {
                        retval.Data = customer;
                    }
                    else
                    {
                        retval.Error = "Invalid username or password.";
                    }
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
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
        public JsonResult CreateCustomer(string accessKey, string customer)
        {
            var retval = new DataWrapper<Customer>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (String.IsNullOrWhiteSpace(customer))
            {
                retval.Error = "Customer object is required.";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.CreateCustomer(customer).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetCustomer(string email)
        {
            var retval = new DataWrapper<Customer>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (Request["email"] == null)
            {
                retval.Error = "Email is required to retrieve a customer.";
            }
            else
            {
                try
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetCustomer(email, null);
                }
                catch (Exception ex)
                {
                    retval.Error = ex.Message;
                }
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetAddresses(string accessKey, int customerId)
        {
            var retval = new DataWrapper<List<Address>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (customerId <= 0)
            {
                retval.Error = "Invalid Customer Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetAddresses(customerId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetAddress(string accessKey, int customerId, int addressId)
        {
            var retval = new DataWrapper<Address>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (customerId <= 0)
            {
                retval.Error = "Invalid Customer Id";
                return Json(retval, _requestBehavior);
            }

            if (addressId <= 0)
            {
                retval.Error = "Invalid Address Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetAddress(customerId, addressId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        [HttpPost]
        public JsonResult AddAddress(string accessKey, int customerId, string address)
        {
            var retval = new DataWrapper<Address>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (customerId <= 0)
            {
                retval.Error = "Invalid Customer Id";
                return Json(retval, _requestBehavior);
            }

            if (String.IsNullOrWhiteSpace(address))
            {
                retval.Error = "Address object is required.";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var obj = (new JavaScriptSerializer()).Deserialize<Address>(address);
                    var api = new ShopifyClient();
                    retval.Data = api.AddAddress(customerId, obj);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        [HttpPost]
        public JsonResult UpdateAddress(string accessKey, int customerId, string address)
        {
            var retval = new DataWrapper<Address>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (customerId <= 0)
            {
                retval.Error = "Invalid Customer Id";
                return Json(retval, _requestBehavior);
            }

            if (String.IsNullOrWhiteSpace(address))
            {
                retval.Error = "Address object is required.";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var obj = (new JavaScriptSerializer()).Deserialize<Address>(address);
                    var api = new ShopifyClient();
                    retval.Data = api.UpdateAddress(customerId, obj);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }
            
        public JsonResult DeleteAddress(string accessKey, int customerId, int addressId)
        {
            var retval = new DataWrapper<bool>()
                {
                    Error = String.Empty,
                    Data = false
                };

            if (customerId <= 0)
            {
                retval.Error = "Invalid Customer Id";
                return Json(retval, _requestBehavior);
            }

            if (addressId <= 0)
            {
                retval.Error = "Invalid Address Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    api.DeleteAddress(customerId, addressId);
                    retval.Data = true;
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult SetDefaultAddress(string accessKey, int customerId, int addressId)
        {
            var retval = new DataWrapper<Address>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (customerId <= 0)
            {
                retval.Error = "Invalid Customer Id";
                return Json(retval, _requestBehavior);
            }

            if (addressId <= 0)
            {
                retval.Error = "Invalid Address Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.SetDefaultAddress(customerId, addressId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetFulfillmentServices(string accessKey)
        {
            var retval = new DataWrapper<List<FulfillmentService>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetFulfillmentServices();
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetOrders(string accessKey, int customerId)
        {
            var retval = new DataWrapper<List<Order>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (customerId <= 0)
            {
                retval.Error = "Invalid Customer Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetOrders(customerId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetOrder(string accessKey, int orderId)
        {
            var retval = new DataWrapper<Order>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (orderId <= 0)
            {
                retval.Error = "Invalid Order Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
//                    var api = new ShopifyClient();
                    var api = new MagentoClient();
                    retval.Data = api.GetOrder(orderId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }
                
            return Json(retval, _requestBehavior);
        }

        [HttpPost]
        public JsonResult CreateOrder(string accessKey, string order)
        {
            var retval = new DataWrapper<Order>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (String.IsNullOrWhiteSpace(order))
            {
                retval.Error = "Order object is required.";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var orderObj = (new JavaScriptSerializer()).Deserialize<Order>(order);
                    var api = new ShopifyClient();
                    retval.Data = api.CreateOrder(orderObj);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;

                if (ex.InnerException != null)
                {
                    retval.Error += " - " + ex.InnerException;
                }
            }

            return Json(retval, _requestBehavior);
        }

//        [HttpPost]
//        public JsonResult CalculateCart(string accessKey, string order)
//        {
//            var retval = new DataWrapper<Order>()
//                {
//                    Error = String.Empty,
//                    Data = null
//                };
//
//            if (String.IsNullOrWhiteSpace(order))
//            {
//                retval.Error = "Order object is required.";
//                return Json(retval, _requestBehavior);
//            }
//
//            try
//            {
//                string error = String.Empty;
//                var db = new DataAccess();
//                var canAccess = db.CanAccess(accessKey, out error);
//                retval.Error = error;
//
//                if(canAccess)
//                {
//                    var orderObj = (new JavaScriptSerializer()).Deserialize<Order>(order);
//                    var api = new Shopify();
//                    retval.Data = api.CreateOrder(orderObj);
//
//                    api.DeleteOrder(retval.Data.Id);
//                }
//            }
//            catch(Exception ex)
//            {
//                retval.Error = ex.Message;
//            }
//
//            return Json(retval, _requestBehavior);
//        }

        public JsonResult GetPolicies(string accessKey)
        {
            var retval = new DataWrapper<List<Policy>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetPolicies();
                }
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
                var api = new ShopifyClient();
                retval.Data = api.GetLocations();
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetLocation(string accessKey, int locationId)
        {
            var retval = new DataWrapper<Location>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetLocation(locationId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetCategories()
        {
            var retval = new DataWrapper<List<Category>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                //var api = new ShopifyClient();
                var api = new MagentoClient();
                retval.Data = api.GetCategories();
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

		public JsonResult GetProducts(string accessKey, string ids = null)
        {
            var retval = new DataWrapper<List<Product>>()
                {
                    Error = String.Empty,
                    Data = null
                };
                    
			try
			{
				string error = String.Empty;
				var db = new DataAccess();
				var canAccess = db.CanAccess(accessKey, out error);
				retval.Error = error;

				if(canAccess)
				{
					//var api = new ShopifyClient();
					var api = new MagentoClient();

					if(ids == null)
						retval.Data = api.GetProducts();
					else
						retval.Data = api.GetProducts(ids);

					retval.Data = api.GetProducts();
				}
			}
			catch(Exception ex)
			{
				retval.Error = ex.Message;
			}

            return Json(retval, _requestBehavior);
        }

		public JsonResult GetProduct(string accessKey, int productId)
        {
            var retval = new DataWrapper<Product>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    //var api = new ShopifyClient();
                    var api = new MagentoClient();
                    retval.Data = api.GetProduct(productId.ToString());
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetProductsByCategoryId(string accessKey, int categoryId)
        {
            var retval = new DataWrapper<List<Product>>()
                {
                    Error = String.Empty,
                    Data = null
                };
                        
            if (categoryId == 0)
            {
                retval.Error = "Category Id is missing or invalid.";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    //var api = new ShopifyClient();
                    var api = new MagentoClient();
                    retval.Data = api.GetProductsByCategoryId(categoryId.ToString());
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetProductImages(string accessKey, int productId)
        {
            var retval = new DataWrapper<List<ProductImage>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (productId <= 0)
            {
                retval.Error = "Invalid Product Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetProductImages(productId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetFirstProductImage(string accessKey, int productId)
        {
            var retval = new DataWrapper<ProductImage>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (productId <= 0)
            {
                retval.Error = "Invalid Product Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetProductImages(productId).OrderBy(x => x.Position).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetFeaturedProducts()
        {
            var retval = new DataWrapper<List<Product>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            try
            {
                //TODO: Get freatured categoy name from database if one is availabe.

                var api = new ShopifyClient();
                retval.Data = api.GetFeaturedProducts();
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult SearchProducts(string accessKey, string text) 
        {
            var retval = new DataWrapper<List<Product>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (String.IsNullOrWhiteSpace(text))
            {
                retval.Error = "Invalid Product Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.SearchProducts(text);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult CalculateTaxes(string accessKey, string countryCode, string provinceCode, decimal subtotal) 
        {
            var retval = new DataWrapper<List<TaxInfo>>()
                {
                    Error = String.Empty,
                    Data = null
                };


            if (String.IsNullOrWhiteSpace(countryCode))
            {
                retval.Error = "A country code is required to calculate taxes.";
                return Json(retval, _requestBehavior);
            }

            if (String.IsNullOrWhiteSpace(provinceCode))
            {
                retval.Error = "A province code is required to calculate taxes.";
                return Json(retval, _requestBehavior);
            }

            if (subtotal <= 0)
            {
                retval.Error = "A subtotal is required to calculate taxes.";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.CalculateTaxes(countryCode, provinceCode, subtotal);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetShippingRates(string accessKey, string countryCode) 
        {
            var retval = new DataWrapper<List<ShippingRate>>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (String.IsNullOrWhiteSpace(countryCode))
            {
                retval.Error = "A country code is required to calculate taxes.";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new ShopifyClient();
                    retval.Data = api.GetShippingRates(countryCode);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult CreateCart(string accessKey, int customerId)
        {
            var retval = new DataWrapper<int>()
                {
                    Error = String.Empty,
                    Data = 0
                };

            if (customerId <= 0)
            {
                retval.Error = "Invalid Customer Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new MagentoClient();
                    retval.Data = api.CreateCart(customerId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult GetCart(string accessKey, int cartId)
        {
            var retval = new DataWrapper<Cart>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (cartId <= 0)
            {
                retval.Error = "Invalid Cart Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new MagentoClient();
                    retval.Data = api.GetCart(cartId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult AddToCart(string accessKey, int cartId, string cartItems)
        {
            var retval = new DataWrapper<bool>()
                {
                    Error = String.Empty,
                    Data = false
                };

            if (String.IsNullOrWhiteSpace(cartItems))
            {
                retval.Error = "CartItems object is required.";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var cartItemsObj = (new JavaScriptSerializer()).Deserialize<List<CartItem>>(cartItems);
                    var api = new MagentoClient();
                    retval.Data = api.AddToCart(cartId, cartItemsObj);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult AddPaymentMethodToCart(string accessKey, int cartId, string payment)
        {
            var retval = new DataWrapper<bool>()
                {
                    Error = String.Empty,
                    Data = false
                };

            if (String.IsNullOrWhiteSpace(payment))
            {
                retval.Error = "Payment object is required.";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var paymentObj = (new JavaScriptSerializer()).Deserialize<Payment>(payment);
                    var api = new MagentoClient();
                    retval.Data = api.AddPaymentMethodToCart(cartId, paymentObj);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult AddAddressToCart(string accessKey, int cartId, int addressId, int addressType)
        {
            var retval = new DataWrapper<bool>()
                {
                    Error = String.Empty,
                    Data = false
                };

            if (cartId <= 0)
            {
                retval.Error = "Invalid Cart Id";
                return Json(retval, _requestBehavior);
            }

            if (addressId <= 0)
            {
                retval.Error = "Invalid Address Id";
                return Json(retval, _requestBehavior);
            }

            if (addressType <= 0 && addressType >= 3)
            {
                retval.Error = "Invalid Address Type Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new MagentoClient();
                    retval.Data = api.AddAddressToCart(cartId, addressId, (AddressType)addressType);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }

        public JsonResult PlaceOrder(string accessKey, int cartId)
        {
            var retval = new DataWrapper<string>()
                {
                    Error = String.Empty,
                    Data = null
                };

            if (cartId <= 0)
            {
                retval.Error = "Invalid Cart Id";
                return Json(retval, _requestBehavior);
            }

            try
            {
                string error = String.Empty;
                var db = new DataAccess();
                var canAccess = db.CanAccess(accessKey, out error);
                retval.Error = error;

                if(canAccess)
                {
                    var api = new MagentoClient();
                    retval.Data = api.PlaceOrder(cartId);
                }
            }
            catch(Exception ex)
            {
                retval.Error = ex.Message;
            }

            return Json(retval, _requestBehavior);
        }
    }
}
