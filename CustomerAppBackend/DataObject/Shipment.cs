using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;
using CustomerAppBackend.ShopInterface.Shopify;

namespace CustomerAppBackend.DataObject
{
    public class Shipment : IShopify
    {
        public Shipment()
        {
            this.TrackingNumbers = new List<String>();
            this.TrackingUrls = new List<String>();
        }

        public Shipment(IDictionary data)
            : this()
        {
            this.LoadFromObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public DateTime CreatedAt
        {
            get;
            set;
        }

        public LineItem LineItem
        {
            get;
            set;
        }

        public int OrderId
        {
            get;
            set;
        }

        public Receipt Receipt
        {
            get;
            set;
        }

        public ShipmentStatus Status
        {
            get;
            set;
        }

        public string TrackingCompany
        {
            get;
            set;
        }

        public List<String> TrackingNumbers
        {
            get;
            set;
        }

        public List<String> TrackingUrls
        {
            get;
            set;
        }

        public DateTime UpdatedAt
        {
            get;
            set;
        }

        #region IShopify implementation

        public string ToShopifyJson()
        {
            throw new NotImplementedException();
        }

        public void LoadFromObject(IDictionary data)
        {
            this.CreatedAt = DateTime.Parse(data["created_at"] as String);
            this.Id = (int)data["id"];
            this.OrderId = (int)data["order_id"];
            this.Status = Enum<ShipmentStatus>.Parse(data["status"] as String);
            this.TrackingCompany = data["tracking_company"] as String;
            this.TrackingNumbers = data["tracking_number"] as List<String>;
            this.TrackingUrls = data["tracking_urls"] as List<String>;
            this.UpdatedAt = DateTime.Parse(data["updated_at"] as String);
            this.Receipt = new Receipt(data["receipt"] as IDictionary);
        }

        #endregion
    }
}

