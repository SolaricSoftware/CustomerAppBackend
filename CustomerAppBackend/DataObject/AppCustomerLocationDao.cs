using System;

namespace CustomerAppBackend.DataObject
{
    public class AppCustomerLocationDao
    {
        public AppCustomerLocationDao()
        {
        }

        public int Id
        {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string Address1 {
            get;
            set;
        }

        public string Address2
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string PostalCode
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        public int AppCustomerId
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }
    }
}

