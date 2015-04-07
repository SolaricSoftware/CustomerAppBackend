using System;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Collections;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Address : IShopify
    {
        public Address()
        {
            this.Country = "US";
        }

        public Address(IDictionary data)
            : this()
        {
            this.LoadFromObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public string Address1
        {
            get;
            set;
        }

        public string Address2
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string Zip
        {
            get;
            set;
        }
            
        public string Country
        {
            get;
            set;
        }

        public string Phone
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

        public string Company
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public bool Default
        {
            get;
            set;
        }

        public string ToShopifyJson()
        {
            var data = new {
                address1 = this.Address1,
                address2 = this.Address2,
                city = this.City,
                province = this.State,
                zip = this.Zip,
                country = this.Country,
                first_name = this.FirstName,
                last_name = this.LastName,
                phone = this.Phone
            };

            var retval = (new JavaScriptSerializer()).Serialize(data);
            return retval;
        }

        public void LoadFromObject(IDictionary data)
        {
            if (data == null || data.Keys.Count == 0)
                return;

            this.Id = (int)data["id"];
            this.Address1 = data["address1"].ToString();
            this.Address2 = data["address2"].ToString();
            this.City = data["city"].ToString();
            this.State = data["province"].ToString();
            this.Zip = data["zip"].ToString();
            this.Country = data["country"].ToString();
            this.Phone = data["phone"].ToString();
            this.FirstName = data["first_name"].ToString();
            this.LastName = data["last_name"].ToString();
            this.Company = data["company"].ToString();
            this.Name = data["name"].ToString();
            this.Default = (bool)data["default"];
        }
    }
}

