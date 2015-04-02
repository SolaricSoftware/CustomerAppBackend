using System;
using System.Collections.Generic;

namespace CustomerAppBackend.DataObject
{
    public class AppCustomerDao
	{
		public AppCustomerDao ()
		{
            this.Locations = new List<AppCustomerLocationDao>();
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

        public Guid AccessKey
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public List<AppCustomerLocationDao> Locations
        {
            get;
            set;
        }
	}
}

