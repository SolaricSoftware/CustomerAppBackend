using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Policy : IShopify
    {
        public Policy()
        {
            
        }

        public string Title
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public Policy(IDictionary data) 
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        #region IShopify implementation

        public string ToShopifyJson()
        {
            throw new NotImplementedException();
        }

        public void LoadFromShopifyObject(IDictionary data)
        {
            this.Title = data["title"] as String;
            this.Text = data["body"] as String;
            this.Url = data["url"] as String;
        }

        #endregion
    }
}

