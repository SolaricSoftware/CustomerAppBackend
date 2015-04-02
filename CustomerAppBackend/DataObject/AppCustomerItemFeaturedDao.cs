using System;

namespace CustomerAppBackend.DataObject
{
    public class AppCustomerItemFeaturedDao
    {
        public AppCustomerItemFeaturedDao()
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

        public AppCustomerItemDao Item
        {
            get;
            set;
        }
    }
}

