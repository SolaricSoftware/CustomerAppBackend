using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class DiscountCode : IShopify
    {
        public DiscountCode()
        {
        }

        public DiscountCode(IDictionary data)
        {
            this.LoadFromShopifyObject(data);
        }

        public decimal Amount
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public DiscountCodeType CodeType
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
            this.Amount = (decimal)data["amount"];
            this.Code = data["code"] as String;
            this.CodeType = Enum<CustomerAppBackend.ShopInterface.DiscountCodeType>.Parse(data["type"] as String);
        }

        #endregion
    }
}

