using System;

namespace CustomerAppBackend.DataObject
{
    public class AppCustomerItemSaleDao
    {
        public AppCustomerItemSaleDao()
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

        public decimal Price
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

