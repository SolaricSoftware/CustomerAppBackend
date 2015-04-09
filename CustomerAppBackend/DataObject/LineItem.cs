using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class LineItem : IShopify
    {
        public LineItem()
        {
        }

        public LineItem(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public int FulfillableQuantity
        {
            get;
            set;
        }

        public string FulfillmentService
        {
            get;
            set;
        }

        public string FulfillmentStatus
        {
            get;
            set;
        }

        public int Grams
        {
            get;
            set;
        }

        public int ProductId
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public bool RequiresShipping
        {
            get;
            set;
        }

        public string Sku
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public int VariantId
        {
            get;
            set;
        }

        public string VariantTitle
        {
            get;
            set;
        }

        public string Vendor
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public List<String> Properites
        {
            get;
            set;
        }

        public bool ProductExists
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
            if (data == null || data.Keys.Count == 0)
                return;

            this.Id = (int)data["id"];
            this.FulfillableQuantity = (int)data["fulfillable_quantity"];
            this.FulfillmentService = data["fulfillment_service"] as String;
            this.FulfillmentStatus = data["fulfillment_status"] as String;
            this.Grams = (int)data["grams"];
            this.Price = Decimal.Parse(data["price"] as String);
            this.ProductId = (int)data["product_id"];
            this.Quantity = (int)data["quantity"];
            this.RequiresShipping = (bool)data["requires_shipping"];
            this.Sku = data["sku"] as String;
            this.Title = data["title"] as String;
            this.VariantId = (int)data["variant_id"];
            this.VariantTitle = data["variant_title"] as String;
            this.Vendor = data["vendor"] as String;
            this.Name = data["name"] as String;
            this.ProductExists = (bool)data["product_exists"];
            this.Properites = data["properties"] as List<String>;
        }

        #endregion
    }
}

