using System;
using System.Collections.Generic;

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

        public string Manufacturer
        {
            get;
            set;
        }

        public string Model
        {
            get;
            set;
        }

        public AppCustomerLocationDao Location
        {
            get;
            set;
        }

        public List<AppCustomerItemImageDao> Images
        {
            get;
            set;
        }

        public List<AppCustomerItemSaleDao> SaleItems
        {
            get;
            set;
        }

        public List<AppCustomerItemFeaturedDao> FeaturedItems
        {
            get; 
            set;
        }

        public int AppCustomerItemCategoryId
        {
            get;
            set;
        }

        public AppCustomerItemCategoryDao Category
        {
            get;
            set;
        }
    }
}

