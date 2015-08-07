using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public enum CreditCardType
    {
        AmericanExpress,
        Visa,
        MasterCard,
        Discover
    }

    public class PaymentInfo
    {
        public PaymentInfo()
        {
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

        public string Method
        {
            get;
            set;
        }
       
        public CreditCardType CardType
        {
            get;
            set;
        }

        public string CreditCardLastFour
        {
            get;
            set;
        }

        public string CreditCardExpMonth
        {
            get;
            set;
        }

        public string CreditCardYear
        {
            get;
            set;
        }

        public string PurcahseOrderNumber
        {
            get;
            set;
        }
    }
}

