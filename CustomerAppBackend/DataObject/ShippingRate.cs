using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class ShippingRate : IShopify
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public decimal MaxWeight
        {
            get;
            set;
        }

        public decimal MinWeight
        {
            get;
            set;
        }

        public ShippingRate()
        {
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
            this.Price = Decimal.Parse(data["price"] as String);
            this.MaxWeight = (decimal)data["weight_high"];
            this.MinWeight = (decimal)data["weight_low"];
        }

        #endregion
    }
}

