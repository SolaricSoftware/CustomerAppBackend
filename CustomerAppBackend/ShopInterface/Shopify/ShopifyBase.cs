using System;

namespace CustomerAppBackend.ShopInterface.Shopify
{
    public class ShopifyBase
    {
        public ShopifyBase()
        {
        }

        protected T FromString<T>(string text)
        {
            return Enum<T>.Parse(text);  
        }

        protected string ToString(PaymentStatusType item)
        {
            return item.ToString().ToLower();
        }
    }
}

