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


    public enum ShipmentStatus
    {
        Unknown,
        Pending,
        Success,
        Cancelled,
        Error,
        Failure
    }

    public enum CancelReason
    {
        Unknown,
        Customer,
        Fraud,
        Inventory,
        Other
    }

    public class ShopInterfaceBase
    {
        public ShopInterfaceBase()
        {
        }

        protected List<T> Transform<T>(object obj) where T: IShopify, new()
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
                        c.LoadFromObject(dic[key] as IDictionary);
                        retval.Add(c);
                    }
                    else if(dic[key] is Array)
                    {
                        foreach (var item in (dic[key] as Array))
                        {
                            var c = new T();
                            c.LoadFromObject(item as IDictionary);
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
                        c.LoadFromObject(item as IDictionary);
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

