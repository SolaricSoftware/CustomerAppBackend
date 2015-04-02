using System;

namespace CustomerAppBackend.DataObject
{
    public class AppCustomerItemImageDao
    {
        public AppCustomerItemImageDao()
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

        public string FileLocation
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public string ThumbnailUrl
        {
            get;
            set;
        }

        public bool Primary
        {
            get;
            set;
        }

        public sbyte DisplayOrder
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

