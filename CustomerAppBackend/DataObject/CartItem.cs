using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class CartItem : Product
    {
        public CartItem()
        {
        }
          
        public int Quantity
        {
            get;
            set;
        }

        public decimal TaxAmount
        {
            get;
            set;
        }

        public decimal TaxPercent
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }

        public decimal TotalPrice
        {
            get;
            set;
        }
    }
}

