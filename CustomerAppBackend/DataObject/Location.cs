using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;


namespace CustomerAppBackend.DataObject
{
    public class Location : IShopify
    {
        public Location()
        {
        }

        public Location(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public int Id {
            get;
            set;
        }

        public string Name {
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

        public string Phone {
            get;
            set;
        }

        #region IShopify implementation

        public string ToShopifyJson()
        {
            throw new NotImplementedException();
        }

        public void LoadFromShopifyObject(IDictionary data)
        {
            this.Id = (int)data["id"];
            this.Name = data["name"] as String;
            this.Address1 = data["address1"] as String;
            this.Address2 = data["address2"] as String;
            this.City = data["city"] as String;
            this.State = data["province"] as String;
            this.Zip = data["zip"] as String;
            this.Country = data["country"] as String;
            this.Phone = data["phone"] as String;
        }

        #endregion
    }
}

