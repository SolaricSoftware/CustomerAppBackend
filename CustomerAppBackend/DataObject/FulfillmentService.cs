using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend
{
    public class FulfillmentService : IShopify
    {
        public FulfillmentService()
        {

        }

        public FulfillmentService(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ServiceName
        {
            get;
            set;
        }

        public bool TrackingSupport
        {
            get;
            set;
        }

        public int ProviderId
        {
            get;
            set;
        }

        public string ToShopifyJson()
        {
            return String.Empty;
        }

        public void LoadFromShopifyObject(IDictionary data)
        {
            this.Id = (int)data["id"];
            this.Name = data["name"] as String;
            this.ServiceName = data["service_name"] as String;
            this.TrackingSupport = (bool)data["tracking_support"];
            this.ProviderId = (int)data["provider_id"];
        }
    }
}

