using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CustomerAppBackend.ShopInterface
{
    public enum HttpMethods
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum FinancialStatus
    {
        Unknown,
        Pending,
        Authorized,
        Partially_Paid,
        Paid,
        Partially_Refunded,
        Refunded,
        Voided
    }


    public enum Status
    {
        Unknown,
        Pending,
        Success,
        Cancelled,
        Error,
        Failure
    }

    public enum ShipmentStatus
    {
        Fulfilled,
        Null,
        Partial
    }

    public enum CancelReason
    {
        Unknown,
        Customer,
        Fraud,
        Inventory,
        Other
    }

    public enum TransactionType
    {
        Authorization,
        Capture,
        Sale,
        Void,
        Refund
    }

    public enum ErrorCode
    {
        Incorrect_Number,
        Invalid_Number,
        Invalid_Expiry_Date,
        Invalid_Cvc,
        Expired_Card,
        Incorrect_Cvc,
        Incorrect_Zip,
        Incorrect_Address,
        Card_Declined,
        Processing_Error,
        Call_Issuer,
        PIck_Up_Card
    }

    public enum DiscountCodeType
    {
        Percentage,
        Shipping,
        Fixed_Amount
    }

    public class ShopInterfaceBase
    {
        public ShopInterfaceBase()
        {
        }

        public static List<T> Transform<T>(object obj) where T: IShopify, new()
        {
            var retval = new List<T>();
            if (obj is IDictionary)
            {
                var dic = obj as IDictionary;
                foreach (var key in dic.Keys)
                {
                    if (dic[key] is IDictionary)
                    {
                        var c = new T();
                        c.LoadFromShopifyObject(dic[key] as IDictionary);
                        retval.Add(c);
                    }
                    else if(dic[key] is Array)
                    {
                        foreach (var item in (dic[key] as Array))
                        {
                            var c = new T();
                            c.LoadFromShopifyObject(item as IDictionary);
                            retval.Add(c);
                        }
                    }

                }
            }
            else if (obj is Array)
            {
                foreach (var item in (obj as Array))
                {
                    if (item is IDictionary)
                    {
                        var c = new T();
                        c.LoadFromShopifyObject(item as IDictionary);
                        ((IList)retval).Add(item);
                    }
                }
            }

            return retval;
        }

        protected T Deserialize<T>(string data)
        {
            return (new JavaScriptSerializer()).Deserialize<T>(data);
        }

        protected string Serialize(object data)
        {
            return (new JavaScriptSerializer()).Serialize(data);
        }
    }
}

