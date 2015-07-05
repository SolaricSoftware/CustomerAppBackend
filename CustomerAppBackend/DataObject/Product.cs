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
			this.Images = new List<ProductImage> ();
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

        public string Name
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

//        public string Category
//        {
//            get;
//            set;
//        }

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
            this.Description = data["body_html"] as String ?? String.Empty;
            this.Name = data["handle"] as String ?? String.Empty;
            this.Images = ShopInterfaceBase.Transform<ProductImage>(data["images"]);
            this.Options = data["options"] as Dictionary<string, string> ?? new Dictionary<string, string>();
            //this.Category = data["product_type"] as String ?? String.Empty;
            this.Tags = data["tags"] as String ?? String.Empty;
            this.Title = data["title"] as String ?? String.Empty;
            this.Variants = ShopInterfaceBase.Transform<ProductVariant>(data["variants"]);
            this.Vendor = data["vendor"] as String ?? String.Empty;
        }

        #endregion
    }
}

