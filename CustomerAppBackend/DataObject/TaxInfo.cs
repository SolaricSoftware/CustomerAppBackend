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

        public decimal Amount
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
            var data = new {
                price = this.Amount,
                rate = this.Rate,
                title = this.Title
            };

            var retval = Helper.Serialize(data);
            return retval;
        }

        public void LoadFromShopifyObject(IDictionary data)
        {
            this.Amount = Decimal.Parse(data["price"] as String);
            this.Rate = (decimal)data["rate"];
            this.Title = data["title"] as String;
        }

        #endregion
    }
}

