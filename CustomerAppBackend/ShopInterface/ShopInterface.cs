using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Text;
using System.Security.Cryptography;

namespace CustomerAppBackend.ShopInterface
{
    public enum HttpMethodsType
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum AddressType
    {
        NotSet,
        Shipping,
        Billing
    }

    public enum PaymentStatusType
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


    public enum ShipmentStatusType
    {
        Failure,
        Pending,
        Success,
        Cancelled,
        Error
    }

    public enum OrderStatusType
    {
        Null,
        Fulfilled,
        Partial,
        Pending_Payment,
        Complete,
        New,
        Processing,
        Closed,
        Canceled,
        Hold
    }

    public enum CancelReasonType
    {
        Unknown,
        Customer,
        Fraud,
        Inventory,
        Other
    }

    public enum TransactionStatusType
    {
        Failure,
        Pending,
        Success,
        Error
    }

    public enum TransactionType
    {
        Unknown,
        Authorization,
        Capture,
        Sale,
        Void,
        Refund
    }

    public enum ErrorCodeType
    {
        Unknown,
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
        Unknown,
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
                        ((IList)retval).Add(c);
                    }
                }
            }

            return retval;
        }

        protected bool ValidateHash(string password, string hash)
        {
            var hashArr = hash.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            var retval = false;
            switch (hashArr.Length)
            {
                case 1:
                    var hashedString = GenerateHash(password, "");
                    retval = hashedString == hash;
                    break;
                case 2:
                    var saltedHash = GenerateHash(password, hashArr[1]);
                    retval = saltedHash == hashArr[0];
                    break;
            }

            return retval;
        }

        protected string GenerateHash(string value, string salt)
        {
            byte[] data = ASCIIEncoding.Default.GetBytes(salt + value);
            data = MD5.Create().ComputeHash(data);
            var retval = BitConverter.ToString(data).Replace("-", "").ToLower();
            return retval;
        }

        protected T Deserialize<T>(string data)
        {
            return (new JavaScriptSerializer()).Deserialize<T>(data);
        }

        protected string Serialize(object data)
        {
            return (new JavaScriptSerializer()).Serialize(data).Replace("\"[", "[").Replace("\\\"", "\"").Replace("]\"", "]").Replace("\"{", "{").Replace("}\"", "}");
        }
    }
}

