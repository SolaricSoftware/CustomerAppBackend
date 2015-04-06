using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomerAppBackend.ShopifyInterface
{
    public interface IShopify
    {
        string ToShopifyJson();
        void LoadFromObject(IDictionary data);
    }
}

