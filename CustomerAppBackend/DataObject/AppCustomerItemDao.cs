using System;

namespace CustomerAppBackend.DataObject
{
    public class AppCustomerItemDao
    {
        public AppCustomerItemDao()
        {
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

        public string StockNumber
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public int AppCustomerLocationId
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public AppCustomerLocationDao Location
        {
            get;
            set;
        }
    }
}

