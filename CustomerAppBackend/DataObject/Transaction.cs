using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;
using SI = CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Transaction : IShopify
    {
        public Transaction()
        {
        }

        public Transaction(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public string Authorization
        {
            get;
            set;
        }

        public DateTime CreatedAt
        {
            get;
            set;
        }

        public PaymentDetail PaymentDetail
        {
            get;
            set;
        }

        public TransactionType TransactionType
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

        public ErrorCode Error
        {
            get;
            set;
        }

        public TransactionStatus Status
        {
            get;
            set;
        }

        public bool Test
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        public string Currency
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
            this.Amount = (decimal)data["amount"];
            this.Authorization = data["authorization"] as String;
            this.CreatedAt = DateTime.Parse(data["created_at"] as String);
            this.PaymentDetail = new PaymentDetail(data["payment_details"] as IDictionary);
            this.Id = (int)data["id"];
            this.OrderId = (int)data["order_id"];
            this.Receipt = new Receipt(data["receipt"] as IDictionary);
            this.Test = (bool)data["test"];
            this.UserId = (int)data["user_id"];
            this.Currency = data["currenty"] as String;

            SI.TransactionType ttype;
            Enum<TransactionType>.TryParse(data["kind"] as String, out ttype);
            this.TransactionType = ttype;

            SI.ErrorCode ecode;
            Enum<ErrorCode>.TryParse(data["status"] as String, out ecode);
            this.Error = ecode;

            TransactionStatus tstatus;
            Enum<TransactionStatus>.TryParse(data["status"] as String, out tstatus);
            this.Status = tstatus;
        }

        #endregion
    }
}

