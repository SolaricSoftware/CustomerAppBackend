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
            this.DiscountCodes = new List<DiscountCode>();
            this.Shipments = new List<Shipment>();
            this.LineItems = new List<LineItem>();
            this.Refunds = new List<Refund>();
            this.ShippingMethods = new List<ShippingMethod>();
        }

        public Order(IDictionary data) 
            : this()
        {
            this.LoadFromShopifyObject(data);
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

        public List<DiscountCode> DiscountCodes
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

        public ShipmentStatus Status
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

        public PaymentDetail PaymentDetails
        {
            get;
            set;
        }

        public DateTime ProcessedAt
        {
            get;
            set;
        }

        public List<Refund> Refunds
        {
            get;
            set;
        }

        public Address ShippingAddress
        {
            get;
            set;
        }

        public List<ShippingMethod> ShippingMethods
        {
            get;
            set;
        }

        public decimal Subtotal
        {
            get;
            set;
        }

        public List<TaxInfo> TaxInfos
        {
            get;
            set;
        }

        public bool TaxesIncluded
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public decimal TotalDiscount
        {
            get;
            set;
        }

        public decimal TotalLineItemPrice
        {
            get;
            set;
        }

        public decimal TotalPrice {
            get;
            set;
        }

        public decimal TotalTax
        {
            get;
            set;
        }

        public int TotalWeight
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

        public void LoadFromShopifyObject(IDictionary data)
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
            this.Email = data["email"] as String;
            this.FinancialStatus = Enum<CustomerAppBackend.ShopInterface.FinancialStatus>.Parse(data["financial_status"] as String);
            this.Status = Enum<CustomerAppBackend.ShopInterface.ShipmentStatus>.Parse(data["fulfillment_status"] as String);
            this.Name = data["name"] as String;
            this.Note = data["note"] as String;
            this.NumericalIdentifier = (int)data["number"];
            this.OrderNumber = (int)data["order_number"];
            this.PaymentDetails = new PaymentDetail(data["payment_details"] as IDictionary);
            this.Subtotal = (decimal)data["subtotal_price"];
            this.TaxesIncluded = (bool)data["taxes_included"];
            this.Token = data["token"] as String;
            this.TotalDiscount = (decimal)data["total_discounts"];
            this.TotalLineItemPrice = (decimal)data["total_line_items_price"];
            this.TotalPrice = (decimal)data["total_price"];
            this.TotalTax = (decimal)data["total_tax"];
            this.TotalWeight = (int)data["total_weight"];
            this.UpdatedAt = DateTime.Parse(data["updated_at"] as String);

            this.TaxInfos = ShopInterfaceBase.Transform<TaxInfo>(data["tax_line"]);

            var arr = data["discount_codes"] as Array;
            if (arr != null)
            {
                foreach (var item in arr)
                {
                    var discountCode = new DiscountCode(item as IDictionary);
                    this.DiscountCodes.Add(discountCode);
                }
            }

            arr = data["fulfillments"] as Array;
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

            arr = data["refund"] as Array;
            if (arr != null)
            {
                foreach (var item in arr)
                {
                    var refund = new Refund(item as IDictionary);
                    this.Refunds.Add(refund);
                }
            }

//            arr = data["tax_lines"] as Array;
//            if (arr != null)
//            {
//                foreach (var item in arr)
//                {
//                    var taxInfo = new TaxInfo(item as IDictionary);
//                    this.TaxInfos.Add(taxInfo);
//                }
//            }
        }

        #endregion
    }
}

