using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;
using System.Dynamic;

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

        public int StoreId
        {
            get;
            set;
        }

        public int WebsiteId
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
            dynamic data = new ExpandoObject();

            if(this.Id > 0)
                data.id = this.Id;

            if(!String.IsNullOrWhiteSpace(this.FirstName))
                data.first_name = this.FirstName;

            if (!String.IsNullOrWhiteSpace(this.LastName))
                data.last_name = this.LastName;

            if (!String.IsNullOrWhiteSpace(this.Email))
                data.email = this.Email;

            if (this.Password != null)
            {
                data.password = this.Password;
                data.password_confirmation = this.Password;
            }
                   
            var retval = Helper.Serialize(data);
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
            this.DefaultAddress = new Address(data["default_address"] as IDictionary);
            this.Addressess = ShopInterfaceBase.Transform<Address>(data["addresses"]);
        }   
    }
}

