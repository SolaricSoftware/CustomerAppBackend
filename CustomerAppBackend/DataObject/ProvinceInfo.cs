using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class ProvinceInfo : IShopify
    {
        public ProvinceInfo()
        {
        }

        public ProvinceInfo(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public string Code
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string TaxName
        {
            get;
            set;
        }

        public decimal Tax
        {
            get;
            set;
        }

        public decimal TaxPercentage
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
            this.Name = data["name"] as String;
            this.TaxName = data["tax_name"] as String;
            this.Tax = (decimal)data["tax"];
            this.TaxPercentage = (decimal)data["tax_percentage"];
        }

        #endregion
    }
}

