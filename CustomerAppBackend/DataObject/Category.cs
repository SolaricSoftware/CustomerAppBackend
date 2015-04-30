using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend
{
    public class Category : IShopify
    {
        public Category()
        {
        }

        public Category(IDictionary data)
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

        public string SortOrder
        {
            get;
            set;
        }
            
        public string Title
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public bool Visible
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
            this.SortOrder = data["sort_order"] as String ?? String.Empty;
            this.Title = data["title"] as String ?? String.Empty;
            this.Visible = (bool)(data["published"] ?? true);

            if (data["image"] != null)
                this.ImageUrl = (data["image"] as IDictionary)["src"] as String ?? String.Empty;
            else
                this.ImageUrl = String.Empty;
        }

        #endregion
    }
}

