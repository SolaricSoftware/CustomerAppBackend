using System;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Collections;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Credentials : IShopify
    {
        public Credentials()
        {
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        #region IShopify implementation

        public string ToShopifyJson()
        {
            var data = new {
                login = this.UserName,
                password = this.Password
            };

            var retval = Helper.Serialize(data);
            return retval;
        }

        public void LoadFromShopifyObject(IDictionary data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

