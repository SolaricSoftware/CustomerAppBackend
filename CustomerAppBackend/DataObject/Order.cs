using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;


namespace CustomerAppBackend.DataObject
{
    public class Order : IShopify
    {
        public Order()
        {
        }

        public Order(IDictionary data) 
            : this()
        {
            this.LoadFromObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public Address BillingAddress
        {
            get;
            set;
        }

        public CustomerAppBackend.ShopInterface.CancelReason CancelReason
        {
            get;
            set;
        }

        public DateTime CancelledAt
        {
            get;
            set;
        }

        public string CartToken
        {
            get;
            set;
        }

        public DateTime ClosedAt
        {
            get;
            set;
        }

        public DateTime CreatedAt
        {
            get;
            set;
        }

        public string Currency
        {
            get;
            set;
        }

        public Customer Customer
        {
            get;
            set;
        }

        public List<String> DiscountCodes
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public FinancialStatus FinancialStatus
        {
            get;
            set;
        }

        public List<Shipment> Shipments
        {
            get;
            set;
        }

        public ShipmentStatus ShipmentStatus
        {
            get;
            set;
        }

        public List<LineItem> LineItems
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public int NumericalIdentifier
        {
            get;
            set;
        }

        public int OrderNumber
        {
            get;
            set;
        }

        public PaymentDetails PaymentDetails
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
            this.Id = (int)data["id"];
            this.BillingAddress = new Address(data["billing_address"] as IDictionary);
            this.CancelReason = Enum<CustomerAppBackend.ShopInterface.CancelReason>.Parse(data["cancel_reason"] as String);
            this.CancelledAt = DateTime.Parse(data["cancelled_at"] as String);
            this.CartToken = data["cart_token"] as String;
            this.ClosedAt = DateTime.Parse(data["closed_at"] as String);
            this.CreatedAt = DateTime.Parse(data["created_at"] as String);
            this.Currency = data["currency"] as String;
            this.Customer = new Customer(data["cusomter"] as IDictionary);
            this.DiscountCodes = data["discount_codes"] as List<String>;
            this.Email = data["email"] as String;
            this.FinancialStatus = Enum<CustomerAppBackend.ShopInterface.FinancialStatus>.Parse(data["financial_status"] as String);
            this.ShipmentStatus = Enum<CustomerAppBackend.ShopInterface.ShipmentStatus>.Parse(data["fulfillment_status"] as String);
            this.Name = data["name"] as String;
            this.Note = data["note"] as String;
            this.NumericalIdentifier = (int)data["number"];
            this.OrderNumber = (int)data["order_number"];
            this.PaymentDetails = new PaymentDetails(data["payment_details"] as IDictionary);

            var arr = data["fulfillments"] as Array;
            if (arr != null)
            {
                foreach (var item in arr)
                {
                    var shipment = new Shipment(item as IDictionary);
                    this.Shipments.Add(shipment);
                }
            }

            arr = data["line_items"] as Array;
            if (arr != null)
            {
                foreach (var item in arr)
                {
                    var lineItem = new LineItem(item as IDictionary);
                    this.LineItems.Add(lineItem);
                }
            }
        }

        #endregion
    }
}

