using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;
using System.Dynamic;

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

        public CancelReasonType CancelReason
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

        public PaymentStatusType PaymentStatus
        {
            get;
            set;
        }

        public List<Shipment> Shipments
        {
            get;
            set;
        }

        public OrderStatusType Status
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

//        public PaymentDetail PaymentDetails
//        {
//            get;
//            set;
//        }

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

        public decimal TotalPrice {
            get;
            set;
        }

        public decimal TotalTax
        {
            get;
            set;
        }

        public decimal TotalWeight
        {
            get;
            set;
        }

        public DateTime UpdatedAt
        {
            get;
            set;
        }

        public List<Transaction> Transactions
        {
            get;
            set;
        }

        #region IShopify implementation

        public string ToShopifyJson()
        {
            dynamic data = new ExpandoObject();
            data.order = new ExpandoObject();

            if (!String.IsNullOrWhiteSpace(this.Email))
            {
                data.order.email = this.Email;
                data.order.send_receipt = true;
            }

            if (this.TotalTax > 0)
                data.order.total_tax = this.TotalTax;

            if (!String.IsNullOrWhiteSpace(this.Currency))
                data.order.currency = this.Currency;

            if (this.PaymentStatus != PaymentStatusType.Unknown)
                data.order.financial_status = this.PaymentStatus.ToString().ToLower();

            if (this.Customer != null)
                data.order.customer = this.Customer.ToShopifyJson();

            if (this.LineItems != null)
                data.order.line_items = this.LineItems.ToShopifyJson();

            if (this.Transactions != null)
                data.order.transactions = this.Transactions.ToShopifyJson();

            if (this.BillingAddress != null)
                data.order.billing_address = this.BillingAddress.ToShopifyJson();

            if (this.ShippingAddress != null)
                data.order.shipping_address = this.ShippingAddress.ToShopifyJson();

            if (this.Taxes != null)
                data.order.tax_lines = this.Taxes.ToShopifyJson();

            var retval = Helper.Serialize(data);
            return retval;
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
            this.Subtotal = Decimal.Parse(data["subtotal_price"] as String);
            this.TaxesIncluded = (bool)data["taxes_included"];
            this.Token = data["token"] as String;
            this.TotalDiscount = Decimal.Parse(data["total_discounts"] as String);
            this.TotalPrice = Decimal.Parse(data["total_price"] as String);
            this.TotalTax = Decimal.Parse(data["total_tax"] as String);
            this.TotalWeight = Decimal.Parse(data["total_weight"] as String);
            this.UpdatedAt = DateTime.Parse(data["updated_at"] as String);

            if (data["shipping_address"] != null)
                this.ShippingAddress = new Address(data["shipping_address"] as IDictionary);
            else
                this.ShippingAddress = this.BillingAddress;

            SI.CancelReasonType reason;
            Enum<SI.CancelReasonType>.TryParse(data["cancel_reason"] as String, out reason);
            this.CancelReason = reason;

            SI.PaymentStatusType fstatus;
            Enum<SI.PaymentStatusType>.TryParse(data["financial_status"] as String, out fstatus);
            this.PaymentStatus = fstatus;

            SI.OrderStatusType ostatus;
            Enum<SI.OrderStatusType>.TryParse(data["fulfillment_status"] as String, out ostatus);
            this.Status = ostatus;

            this.DiscountCodes = ShopInterfaceBase.Transform<DiscountCode>(data["discount_codes"]);
            this.Shipments = ShopInterfaceBase.Transform<Shipment>(data["fulfillments"]);
            this.LineItems = ShopInterfaceBase.Transform<LineItem>(data["line_items"]);
            this.Refunds = ShopInterfaceBase.Transform<Refund>(data["refund"]);
            this.Taxes = ShopInterfaceBase.Transform<TaxInfo>(data["tax_lines"]);
            this.ShippingMethods = ShopInterfaceBase.Transform<ShippingMethod>(data["shipping_lines"]);
            this.Transactions = ShopInterfaceBase.Transform<Transaction>(data["transactions"]);
        }

        #endregion
    }
}

