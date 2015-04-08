using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class RefundLineItem : IShopify
    {
        public RefundLineItem()
        {
        }

        public RefundLineItem(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public LineItem LineItem
        {
            get;
            set;
        }

        public int LineItemId
        {
            get;
            set;
        }

        public int Quantity
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
            this.LineItem = new LineItem(data["line_item"] as IDictionary);
            this.LineItemId = (int)data["line_item_id"];
            this.Quantity = (int)data["quantity"];
        }

        #endregion
    }
}

