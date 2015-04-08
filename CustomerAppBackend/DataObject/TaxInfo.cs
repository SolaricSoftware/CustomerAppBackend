using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class TaxInfo : IShopify
    {
        public TaxInfo()
        {
        }

        public TaxInfo(IDictionary data)
        {
            this.LoadFromShopifyObject(data);
        }

        public decimal Price
        {
            get;
            set;
        }

        public decimal Rate
        {
            get;
            set;
        }

        public string Title
        {
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
            this.Price = (decimal)data["price"];
            this.Rate = (decimal)data["rate"];
            this.Title = data["title"] as String;
        }

        #endregion
    }
}

