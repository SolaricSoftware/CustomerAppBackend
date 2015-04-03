using System;
using System.Collections.Generic;

namespace CustomerAppBackend.DataObject
{
    public class AppCustomerItemCategoryDao
    {
        public AppCustomerItemCategoryDao()
        {

        }

        public int Id {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public List<AppCustomerItemDao> Items
        {
            get;
            set;
        }
    }
}

