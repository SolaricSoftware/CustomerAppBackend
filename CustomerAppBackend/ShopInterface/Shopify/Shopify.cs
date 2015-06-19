using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Linq;
using System.Web.Script.Serialization;
using System.Collections;
using System.Collections.Generic;

using CustomerAppBackend.DataObject;
using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.ShopInterface.Shopify
{
    public class Shopify : ShopInterfaceBase
    {
        private string _apiKey = "8037a4e7d88990e51606487d2faee5e8";
        private string _password = "7460df937d2be2ce09c69b29ce3a19b9";
        private string _shopName = "customerappteststore";

        public Shopify()
        {
        }

        public List<Customer> SearchCustomers(string query)
        {
            var path = "/admin/customers/search.json";
            var retval = this.Get<Customer>(path, String.Format("query= {0}", query));
            return retval;
        }

        public List<TaxInfo> CalculateTaxes(string countryCode, string provinceCode, decimal subtotal)
        {
            var path = "/admin/countries.json";
            var country = this.Get<CountryInfo>(path).FirstOrDefault(x => x.Code == countryCode);
            var provice = country.Provinces.FirstOrDefault(x => x.Code == provinceCode);

            var retval = new List<TaxInfo>();
            if (country.Tax > 0)
            {
                retval.Add(new TaxInfo
                    {
                        Rate = country.Tax,
                        Title = country.TaxName,
                        Amount = Math.Round(subtotal * country.Tax, 2)
                    });
            }

            retval.Add(new TaxInfo
                {
                    Rate = provice.Tax,
                    Title = provice.TaxName,
                    Amount = Math.Round(subtotal * provice.Tax, 2)
                });

            return retval;
        }

        public List<ShippingRate> GetShippingRates(string countryCode)
        {
            var path = "/admin/countries.json";
            var country = this.Get<CountryInfo>(path).FirstOrDefault(x => x.Code == countryCode);
            return country.ShippingRates;
        }

        public Customer GetCustomer(string email)
        {
            var path = "/admin/customers/search.json";
            var retval = this.Get<Customer>(path, String.Format("query= email:{0}", email)).FirstOrDefault();
            return retval;
        }

        public Customer GetCustomer(int id)
        {
            var path= String.Format("/admin/customers/#{0}.json", id);
            var retval = this.Get<Customer>(path).FirstOrDefault();
            return retval;
        }

        public List<Customer> CreateCustomer(string data)
        {
            var customer = Deserialize<Customer>(data);
            var path = "/admin/customers.json";
            var retval = this.Post<Customer>(path, customer);
            return retval;
        }

        public List<Address> GetAddresses(int customerId)
        {
            var path = String.Format("/admin/customers/{0}/addresses.json", customerId);
            var retval = this.Get<Address>(path);
            return retval;
        }

        public Address GetAddress(int customerId, int addressId)
        {
            var path = String.Format("/admin/customers/{0}/addresses/{1}.json", customerId, addressId);
            var retval = this.Get<Address>(path).FirstOrDefault();
            return retval;
        }

        public Address AddAddress(int customerId, Address address)
        {
            var path = String.Format("/admin/customers/{0}/addresses.json", customerId);
            var retval = this.Post<Address>(path, address).FirstOrDefault();
            return retval;
        }

        public Address UpdateAddress(int customerId, Address address)
        {
            var path = String.Format("/admin/customers/{0}/addresses/{1}.json", customerId, address.Id);
            var retval = this.Put<Address>(path, address).FirstOrDefault();
            return retval;
        }

        public void DeleteAddress(int customerId, int addressId)
        {
            var path = String.Format("/admin/customers/{0}/addresses/{1}.json", customerId, addressId);
            this.Delete(path);
        }

        public Address SetDefaultAddress(int customerId, int addressId)
        {
            var path = String.Format("/admin/customers/{0}/addresses/{1}/default.json", customerId, addressId);
            var retval = this.Put<Address>(path).FirstOrDefault();
            return retval;
        }

        public List<FulfillmentService> GetFulfillmentServices() 
        {
            var path = String.Format("/admin/fulfillment_services.json");
            var retval = this.Get<FulfillmentService>(path, "scope=all");
            return retval;
        }

        public List<Order> GetOrders(int customerId, string status = "any")
        {
            var path = String.Format("/admin/orders.json");
            var retval = this.Get<Order>(path, String.Format("customer_id={0}&status={1}", customerId, status));
            return retval;
        }

        public Order GetOrder(int id)
        {
            var path = String.Format("/admin/orders/{0}.json", id);
            var retval = this.Get<Order>(path).FirstOrDefault();
            return retval;
        }

        public Order CreateOrder(Order order)
        {
            var path = "/admin/orders.json";
            var retval = this.Post<Order>(path, order);
            return retval.FirstOrDefault();
        }

        public void DeleteOrder(int id)
        {
            var path = String.Format("/admin/orders/#{0}.json", id);
            this.Delete(path);
        }

        public List<Product> GetProducts()
        {
            var path = "/admin/products.json";
            var retval = this.Get<Product>(path);
            return retval;
        }

        public List<Product> GetProducts(string ids)
        {
            var path = "/admin/products.json";
            var retval = this.Get<Product>(path, String.Format("ids={0}", ids));
            return retval;
        }

        public List<Product> GetProductsByCategoryId(string id)
        {
            var path = "/admin/products.json";
            var retval = this.Get<Product>(path, String.Format("collection_id={0}", id));
            return retval;
        }

        public Product GetProduct(int id)
        {
            var path = String.Format("/admin/products/{0}.json", id);
            var retval = this.Get<Product>(path).FirstOrDefault();
            return retval;
        }

        public List<ProductImage> GetProductImages(int productId)
        {
            var path = String.Format("/admin/products/{0}/images.json", productId);
            var retval = this.Get<ProductImage>(path).OrderBy(x => x.Source).ToList();
            return retval;
        }

        public Policy GetPolicy()
        {
            var path = "/admin/policies.json";
            var retval = this.Get<Policy>(path).FirstOrDefault();
            return retval;
        }

        public List<Category> GetCategories(string featuredCollectionName = "frontpage")
        {
            var path = "/admin/custom_collections.json";
            var retval = this.Get<Category>(path).Where(x => x.Visible && x.Name != featuredCollectionName).ToList();
            return retval;
        }
            
        public List<Product> GetFeaturedProducts(string featuredCollectionName = "frontpage")
        {
            var retval = new List<Product>();

            if (String.IsNullOrWhiteSpace(featuredCollectionName))
                featuredCollectionName = "frontpage";

            var path = "/admin/custom_collections.json";
            var featuredCategory = this.Get<Category>(path).FirstOrDefault(x => x.Visible && x.Name == featuredCollectionName);
                
            if (featuredCategory != null)
            {
                path = "/admin/products.json";
                retval = this.Get<Product>(path, String.Format("collection_id={0}", featuredCategory.Id));
            }
            else
            {
                throw new Exception("No freatured category was found.");
            }

            return retval;
        }

        public List<Location> GetLocations()
        {
            var path = "/admin/locations.json";
            var retval = this.Get<Location>(path);
            return retval;
        }

        public Location GetLocation(int id)
        {
            var path = String.Format("/admin/locations/#{id}.json", id);
            var retval = this.Get<Location>(path).FirstOrDefault();
            return retval;
        }

        public List<T> Get<T>(string path) where T: IShopify, new()
        {
            return this.Get<T>(path, null);
        }

        public List<T> Get<T>(string path, string data) where T: IShopify, new()
        {
            var obj = this.Get(path, data);
            var retval = Transform<T>(obj);
            return retval;
        }

        public object Get(string path, string data)
        {
            var url = String.Format("https://{0}.myshopify.com/{1}{2}", this._shopName, path, data != null ? String.Format("?{0}", data) : String.Empty);
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Credentials = new NetworkCredential(this._apiKey, this._password);

            var response = (HttpWebResponse)request.GetResponse();
            string result = null;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                result = sr.ReadToEnd();
                sr.Close();
            }
                
            if (String.IsNullOrWhiteSpace(result))
                return null;

            var obj = (new JavaScriptSerializer()).DeserializeObject(result);
            return obj;
        }

        public List<T> Post<T>(string path, IShopify data) where T: IShopify, new()
        {
            var obj = this.Post(path, data);
            var retval = Transform<T>(obj);
            return retval;
        }

        public object Post(string path, IShopify data) 
        {
            return this.ExecuteInstruction("POST", path, data);
        }

        public List<T> Put<T>(string path) where T: IShopify, new()
        {
            var obj = this.Put(path, null);
            var retval = Transform<T>(obj);
            return retval;
        }

        public List<T> Put<T>(string path, IShopify data) where T: IShopify, new()
        {
            var obj = this.Put(path, data);
            var retval = Transform<T>(obj);
            return retval;
        }

        public object Put(string path, IShopify data) 
        {
            return this.ExecuteInstruction("PUT", path, data);
        }

        public void Delete(string path)
        {
            var url = String.Format("https://{0}.myshopify.com/{1}", this._shopName, path);
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "DELETE";
            request.Credentials = new NetworkCredential(this._apiKey, this._password);

            request.GetResponse();
        }

        private object ExecuteInstruction(string method, string path, IShopify data)
        {
            string result = null;

            var url = String.Format("https://{0}.myshopify.com/{1}", this._shopName, path);
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Method = method;
            request.Credentials = new NetworkCredential(this._apiKey, this._password);

            if (data != null)
            {
                string json;

                if (data.GetType() != typeof(Address))
                {
                    json = data.ToShopifyJson();
                }
                else
                {
                    json ="{\"address\": " +  data.ToShopifyJson() + "}";
                }

                var postData = json;
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(postData);
                    writer.Close();
                }
            }

            var response = request.GetResponse() as HttpWebResponse;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                result = sr.ReadToEnd();
                sr.Close();
            }

            if (String.IsNullOrWhiteSpace(result))
                return null;

            var obj = (new JavaScriptSerializer()).DeserializeObject(result);
            return obj;
        }
    }
}

