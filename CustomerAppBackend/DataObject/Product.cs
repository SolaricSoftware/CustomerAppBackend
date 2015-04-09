using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Product : IShopify
    {
        public Product()
        {
        }

        public Product(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
            
        public List<ProductImage> Images
        {
            get;
            set;
        }

        public Dictionary<string,string> Options
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public string Tags
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public List<ProductVariant> Variants 
        {
            get;
            set;
        }

        public string Vendor
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
            this.Description = data["body_html"] as String;
            this.Images = ShopInterfaceBase.Transform<ProductImage>(data["images"]);
            this.Options = data["options"] as Dictionary<string, string>;
            this.Category = data["product_type"] as String;
            this.Tags = data["tags"] as String;
            this.Title = data["title"] as String;
            this.Variants = ShopInterfaceBase.Transform<ProductVariant>(data["variants"]);
            this.Vendor = data["vendor"] as String;
        }

        #endregion
    }
}

