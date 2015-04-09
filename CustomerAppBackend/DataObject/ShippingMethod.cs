using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class ShippingMethod : IShopify
    {
        public ShippingMethod()
        {
            this.Taxes = new List<TaxInfo>();
        }

        public ShippingMethod(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public string Code
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public string Source
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public List<TaxInfo> Taxes
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
            this.Code = data["code"] as String;
            this.Price = Decimal.Parse(data["price"] as String);
            this.Source = data["source"] as String;
            this.Title = data["title"] as String;
            this.Taxes = ShopInterfaceBase.Transform<TaxInfo>(data[""]);
        }

        #endregion
    }
}

