using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Payment
    {
        public Payment()
        {
        }

        public string PONumber
        {
            get;
            set;
        }

        public string Method
        {
            get;
            set;
        }

        public string CCV
        {
            get;
            set;
        }

        public string NameOnCard
        {
            get;
            set;
        }

        public string CardNumber
        {
            get;
            set;
        }

//        public CreditCardType CardType
//        {
//            get;
//            set;
//        }

        public string ExpYear
        {
            get;
            set;
        }

        public string ExpMonth
        {
            get;
            set;
        }
    }
}

