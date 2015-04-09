using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class CountryInfo : IShopify
    {
        public CountryInfo()
        {
        }

        public CountryInfo(IDictionary data)
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

        public List<ProvinceInfo> Provinces
        {
            get;
            set;
        }

        public decimal Tax
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
            this.Provinces = ShopInterfaceBase.Transform<ProvinceInfo>(data["provinces"]);
            this.Tax = (decimal)data["tax"];
        }

        #endregion
    }
}

