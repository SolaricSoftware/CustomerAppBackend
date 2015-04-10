using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public class Receipt: IShopify
    {
        public Receipt()
        {
        }

        public Receipt(IDictionary data)
            : this()
        {
            this.LoadFromShopifyObject(data);
        }

        public bool TestCase {
            get;
            set;
        }

        public string Authorization {
            get;
            set;
        }

        #region IShopify implementation

        public string ToShopifyJson()
        {
            var data = new {
                receipt = new {
                    testcase = this.TestCase,
                    authorization = this.Authorization
                }
            };

            var retval = Helper.Serialize(data);
            return retval;
        }

        public void LoadFromShopifyObject(IDictionary data)
        {
            if (data == null || data.Keys.Count == 0)
                return;

            this.TestCase = (bool)data["testcase"];
            this.Authorization = data["authorization"].ToString();
        }

        #endregion
    }
}

