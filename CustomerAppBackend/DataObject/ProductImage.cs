using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class ProductImage : IShopify
    {
        public ProductImage()
        {
        }

        public ProductImage(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public int Position
        {
            get;
            set;
        }

        public int ProductId
        {
            get;
            set;
        }

        public string Source
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
            this.Id = (int)data["id"];
            this.Position = (int)data["position"];
            this.ProductId = (int)data["product_id"];
            this.Source = data["src"] as String;
        }

        #endregion
    }
}

