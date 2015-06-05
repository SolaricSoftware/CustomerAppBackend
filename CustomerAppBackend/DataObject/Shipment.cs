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
            this.TrackingUrls = new List<String>();
        }

        public Shipment(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
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

//        public LineItem LineItem
//        {
//            get;
//            set;
//        }

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

        public ShipmentStatusType Status
        {
            get;
            set;
        }

        public string TrackingCompany
        {
            get;
            set;
        }

        public string TrackingNumber
        {
            get;
            set;
        }

        public List<String> TrackingUrls
        {
            get;
            set;
        }

        public DateTime? UpdatedAt
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
            this.CreatedAt = DateTime.Parse(data["created_at"] as String);
            this.Id = (int)data["id"];
            this.OrderId = (int)data["order_id"];
            this.TrackingCompany = data["tracking_company"] as String;
            this.TrackingNumber = data["tracking_number"] as String;
            this.TrackingUrls = data["tracking_urls"] as List<String> ?? new List<string>();
            this.UpdatedAt = data["updated_at"] != null ? DateTime.Parse(data["updated_at"] as String) : (DateTime?)null;
            this.Receipt = new Receipt(data["receipt"] as IDictionary);

            ShipmentStatusType sstatus;
            Enum<ShipmentStatusType>.TryParse(data["status"] as String, out sstatus);
            this.Status = sstatus;
        }

        #endregion
    }
}

