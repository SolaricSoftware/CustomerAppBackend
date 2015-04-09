﻿using System;
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
            this.LoadFromShopifyObject(data);
        }

        //Id is sometimes present, sometimes not. Do we really need to know it?
//        public int Id
//        {
//            get;
//            set;
//        }

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

        public void LoadFromShopifyObject(IDictionary data)
        {
            if (data == null || data.Keys.Count == 0)
                return;

            //this.Id = (int)data["id"];
            this.Address1 = data["address1"] as String;
            this.Address2 = data["address2"] as String;
            this.City = data["city"] as String;
            this.State = data["province"] as String;
            this.Zip = data["zip"] as String;
            this.Country = data["country"] as String;
            this.Phone = data["phone"] as String;
            this.FirstName = data["first_name"] as String;
            this.LastName = data["last_name"] as String;
            this.Company = data["company"] as String;
            this.Name = data["name"] as String;
            this.Default = (data["default"] as String ?? String.Empty) == "True";
        }
    }
}
