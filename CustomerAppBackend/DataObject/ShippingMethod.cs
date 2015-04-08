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

        public List<TaxInfo> TaxInfos
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
            this.Price = (decimal)data["price"];
            this.Source = data["source"] as String;
            this.Title = data["title"] as String;

            var arr = data["tax_lines"] as Array;
            if (arr != null)
            {
                foreach (var item in arr)
                {
                    var taxInfo = new TaxInfo(item as IDictionary);
                    this.TaxInfos.Add(taxInfo);
                }
            }
        }

        #endregion
    }
}

