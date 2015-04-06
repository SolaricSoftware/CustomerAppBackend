using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CustomerAppBackend.ShopifyInterface
{
    public enum HttpMethods
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class ShopInterfaceBase
    {
        public ShopInterfaceBase()
        {
        }

        public List<T> Transform<T>(object obj) where T: IShopify, new()
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
    }
}

