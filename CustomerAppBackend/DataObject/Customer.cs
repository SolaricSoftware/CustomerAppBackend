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
            this.LoadFromShopifyObject(data);
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

        public Address DefaultAddress
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
            dynamic data = new {
                customer = new {
                    first_name = this.FirstName,
                    last_name = this.LastName,
                    email = this.Email,
                    verified_email = true,
                    addresses = this.Addressess,
//                    password = this.Password,
//                    password_confirmation = this.Password,
                    send_email_welcome = false
                }
            };

            if (this.Password != null)
            {
                data.customer.password = this.Password;
                data.customer.password_confirmation = this.Password;
            }
                   
            var retval = (new JavaScriptSerializer()).Serialize(data);
            return retval;
        }

        public void LoadFromShopifyObject(IDictionary data)
        {
            if (data == null || data.Keys.Count == 0)
                return;

            this.Id = (int)data["id"];
            this.FirstName = data["first_name"] as String;
            this.LastName = data["last_name"] as String;
            this.Email = data["email"] as String;
            this.Note = data["note"] as String;
            this.OrderCount = (int)data["orders_count"];
            this.DefaultAddress = new Address(data["default_address"] as IDictionary);
            this.Addressess = ShopInterfaceBase.Transform<Address>(data["addresses"]);
        }   
    }
}

