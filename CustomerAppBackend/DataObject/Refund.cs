using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Refund : IShopify
    {
        public Refund()
        {
            this.Transactions = new List<Transaction>();
        }

        public Refund(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public int Id {
            get;
            set;
        }

        public DateTime CreatedAt {
            get;
            set;
        }

        public string Note {
            get;
            set;
        }

        public RefundLineItem LineItem
        {
            get;
            set;
        }

        public List<Transaction> Transactions
        {
            get;
            set;
        }

        public int UserId
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
            this.CreatedAt = DateTime.Parse(data["created_at"] as String);
            this.Note = data["note"] as String;
            this.LineItem = new RefundLineItem(data["refund_line_items"] as IDictionary);
            this.UserId = (int)data["user_id"];


            var arr = data["transactions"] as Array;
            if (arr != null)
            {
                foreach (var item in arr)
                {
                    var transaction = new Transaction(item as IDictionary);
                    this.Transactions.Add(transaction);
                }
            }
        }

        #endregion
    }
}

