using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;


using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Cart
    {
        public Cart()
        {
        }

        public int Id
        {
            get;
            set;
        }

        public int StoreId
        {
            get;
            set;
        }

        public DateTime CreatedAt
        {
            get;
            set;
        }

        public int ItemsCount
        {
            get;
            set;
        }

        public int ItemsQty
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        public decimal Subtotal
        {
            get;
            set;
        }
            
        public int CustomerId
        {
            get;
            set;
        }

        public string CustomerEmail
        {
            get;
            set;
        }

        public string CustomerFirstName
        {
            get;
            set;
        }

        public string CustomerLastName
        {
            get;
            set;
        }

        public Address ShippingAddress
        {
            get;
            set;
        }

        public Address BillingAddress
        {
            get;
            set;
        }

        public List<Product> Items
        {
            get;
            set;
        }
    }
}

