using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Customer : IShopify
    {
        public Customer()
        {
            this.Addressess = new List<Address>();
        }

        public Customer(IDictionary data)
            : this()
        {
            this.LoadFromObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public int OrderCount
        {
            get;
            set;
        }

        public List<Address> Addressess
        {
            get;
            set;
        }


        public string ToShopifyJson()
        {
            var data = new {
                customer = new {
                    first_name = this.FirstName,
                    last_name = this.LastName,
                    email = this.Email,
                    verified_email = true,
                    addresses = this.Addressess,
                    password = this.Password,
                    password_confirmation = this.Password,
                    send_emnail_welcome = false
                }
            };
                   
            var retval = (new JavaScriptSerializer()).Serialize(data);
            return retval;
        }

        public void LoadFromObject(IDictionary data)
        {
            if (data == null || data.Keys.Count == 0)
                return;

            this.Id = (int)data["id"];
            this.FirstName = data["first_name"].ToString();
            this.LastName = data["last_name"].ToString();
            this.Email = data["email"].ToString();
            this.Note = data["note"].ToString();
            this.OrderCount = (int)data["orders_count"];

//            var dic = data["addresses"] as IDictionary;
//            if (dic != null)
//            {
//                foreach (var key in dic.Keys)
//                {
//                    var address = new Address();
//                    address.LoadFromObject(dic[key] as IDictionary);
//                    this.Addressess.Add(address);
//                }
//            }

            var arr = data["addresses"] as Array;
            if (arr != null)
            {
                foreach (var addr in arr)
                {
                    var address = new Address(addr as IDictionary);
                    this.Addressess.Add(address);
                }
            }
        }
    }
}

