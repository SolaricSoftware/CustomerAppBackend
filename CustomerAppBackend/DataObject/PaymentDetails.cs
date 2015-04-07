using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class PaymentDetails : IShopify
    {
        public PaymentDetails()
        {
        }

        public PaymentDetails(IDictionary data)
            : this()
        {
            this.LoadFromObject(data);
        }

        public string AvsResultCode
        {
            get;
            set;
        }

        public string CreditCardBin
        {
            get;
            set;
        }

        public string CvvResultCode
        {
            get;
            set;
        }

        public string CreditCardNumber
        {
            get;
            set;
        }

        public string CreditCardCompany
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
            this.AvsResultCode = data["avs_result_code"] as String;
            this.CreditCardBin = data["credit_card_bin"] as String;
            this.CvvResultCode = data["cvv_result_code"] as String;
            this.CreditCardNumber = data["credit_card_number"] as String;
            this.CreditCardCompany = data["credit_card_company"] as String;
        }

        #endregion
    }
}

