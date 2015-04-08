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

        public List<Customer> GetCustomer(string email)
        {
            var path = "/admin/customers/search.json";
            var retval = this.Get<Customer>(path, String.Format("query= email:{0}", email));
            return retval;
        }

        public List<Customer> GetCustomer(int id)
        {
            var path= String.Format("/admin/customers/#{0}.json", id);
            var retval = this.Get<Customer>(path, null);
            return retval;
        }

        public List<Customer> CreateCustomer(string data)
        {
            var customer = Deserialize<Customer>(data);
            var path = "/admin/customers.json";
            var retval = this.Post<Customer>(path, customer);
            return retval;
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

        public object Post(string path, IShopify data) {
            var url = String.Format("https://{0}.myshopify.com/{1}", this._shopName, path);
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Credentials = new NetworkCredential(this._apiKey, this._password);

            var postData = data.ToShopifyJson();
//            try
//            {
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(postData);
                    writer.Close();
                }
//            }
//            catch(Exception ex)
//            {
//                var aaa = 1 + 1;
//            }

            string result = null;
//            try
//            {
                var response = request.GetResponse() as HttpWebResponse;

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    result = sr.ReadToEnd();
                    sr.Close();
                }
//            }   
//            catch(Exception ex)
//            {
//                var bbb = 1 + 1;
//            }

            if (String.IsNullOrWhiteSpace(result))
                return null;
        
            var obj = (new JavaScriptSerializer()).DeserializeObject(result);
            return obj;
        }
    }
}

