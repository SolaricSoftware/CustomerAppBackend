using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class ProductVariant : IShopify
    {
        public ProductVariant()
        {
            this.Options = new List<string>();
        }

        public ProductVariant(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public string Barcode
        {
            get;
            set;
        }

        public string CompareAtPrice
        {
            get;
            set;
        }

        public decimal Weight
        {
            get;
            set;
        }

        public string WeightUnit
        {
            get;
            set;
        }

        public int InventoryQuantity
        {
            get;
            set;
        }

        public List<string> Options
        {
            get;
            set;
        }

        public int Position
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public int ProductId
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

        #region IShopify implementation

        public string ToShopifyJson()
        {
            throw new NotImplementedException();
        }

        public void LoadFromShopifyObject(IDictionary data)
        {
            this.Id = (int)data["id"];
            this.Barcode = data["barcode"] as String;
            this.CompareAtPrice = data["compare_at_price"] as String;
            this.Weight = (decimal)data["weight"];
            this.WeightUnit = data["weight_unit"] as String;
            this.InventoryQuantity = (int)data["inventory_quantity"];
            this.Position = (int)data["position"];
            this.Price = Decimal.Parse(data["price"] as String);
            this.ProductId = (int)data["product_id"];
            this.RequiresShipping = (bool)data["requires_shipping"];
            this.Sku = data["sku"] as String;
            this.Title = data["title"] as String;

            for(var i = 1; i <= 10; i++)
            {
                var o = data[String.Format("option{0}", i)] as String;
                if(o != null)
                    this.Options.Add(o);
            }
        }

        #endregion
    }
}

