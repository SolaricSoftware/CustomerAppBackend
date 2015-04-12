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
            
        public string PostalCode
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
            this.Name = data["name"] as String ?? String.Empty;
            this.Address1 = data["address1"] as String ?? String.Empty;
            this.Address2 = data["address2"] as String ?? String.Empty;
            this.City = data["city"] as String ?? String.Empty;
            this.State = data["province"] as String ?? String.Empty;
            this.PostalCode = data["zip"] as String ?? String.Empty;
            this.Country = data["country"] as String ?? String.Empty;
            this.Phone = data["phone"] as String ?? String.Empty;
        }

        #endregion
    }
}

