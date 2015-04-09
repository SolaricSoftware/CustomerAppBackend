using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;
using SI = CustomerAppBackend.ShopInterface;

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

        public CancelReason CancelReason
        {
            get;
            set;
        }

        public DateTime? CancelledAt
        {
            get;
            set;
        }

        public string CartToken
        {
            get;
            set;
        }

        public DateTime? ClosedAt
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

        public OrderStatus Status
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

        public List<TaxInfo> Taxes
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
            this.CartToken = data["cart_token"] as String;
            this.CancelledAt = data["cancelled_at"] != null ?  DateTime.Parse(data["cancelled_at"] as String) : (DateTime?)null;
            this.ClosedAt = data["closed_at"] != null ? DateTime.Parse(data["closed_at"] as String) : (DateTime?)null;
            this.CreatedAt = DateTime.Parse(data["created_at"] as String);
            this.Currency = data["currency"] as String;
            this.Customer = new Customer(data["customer"] as IDictionary);
            this.Email = data["email"] as String;
            this.Name = data["name"] as String;
            this.Note = data["note"] as String;
            this.NumericalIdentifier = (int)data["number"];
            this.OrderNumber = (int)data["order_number"];
            this.PaymentDetails = new PaymentDetail(data["payment_details"] as IDictionary);
            this.Subtotal = Decimal.Parse(data["subtotal_price"] as String);
            this.TaxesIncluded = (bool)data["taxes_included"];
            this.Token = data["token"] as String;
            this.TotalDiscount = Decimal.Parse(data["total_discounts"] as String);
            this.TotalLineItemPrice = Decimal.Parse(data["total_line_items_price"] as String);
            this.TotalPrice = Decimal.Parse(data["total_price"] as String);
            this.TotalTax = Decimal.Parse(data["total_tax"] as String);
            this.TotalWeight = (int)data["total_weight"];
            this.UpdatedAt = DateTime.Parse(data["updated_at"] as String);

            if (data["shipping_address"] != null)
                this.ShippingAddress = new Address(data["shipping_address"] as IDictionary);
            else
                this.ShippingAddress = this.BillingAddress;

            SI.CancelReason reason;
            Enum<SI.CancelReason>.TryParse(data["cancel_reason"] as String, out reason);
            this.CancelReason = reason;

            SI.FinancialStatus fstatus;
            Enum<SI.FinancialStatus>.TryParse(data["financial_status"] as String, out fstatus);
            this.FinancialStatus = fstatus;

            SI.OrderStatus ostatus;
            Enum<SI.OrderStatus>.TryParse(data["fulfillment_status"] as String, out ostatus);
            this.Status = ostatus;

            this.DiscountCodes = ShopInterfaceBase.Transform<DiscountCode>(data["discount_codes"]);
            this.Shipments = ShopInterfaceBase.Transform<Shipment>(data["fulfillments"]);
            this.LineItems = ShopInterfaceBase.Transform<LineItem>(data["line_items"]);
            this.Refunds = ShopInterfaceBase.Transform<Refund>(data["refund"]);
            this.Taxes = ShopInterfaceBase.Transform<TaxInfo>(data["tax_lines"]);
            this.ShippingMethods = ShopInterfaceBase.Transform<ShippingMethod>(data["shipping_lines"]);
        }

        #endregion
    }
}

