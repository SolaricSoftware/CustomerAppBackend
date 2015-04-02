using System;

namespace CustomerAppBackend.DataObject
{
    public class AppCustomerItemFeatured
    {
        public AppCustomerItemFeatured()
        {
        }

        public int Id
        {
            get;
            set;
        }

        public int ItemId
        {
            get;
            set;
        }

        public DateTime EffectiveDate
        {
            get;
            set;
        }

        public DateTime ExpireDate
        {
            get;
            set;
        }
    }
}

