using System;
using System.Linq;
using System.Collections.Generic;
using CustomerAppBackend.DataObject;

namespace CustomerAppBackend.Data
{
    public static class Extentions
    {
        public static AppCustomerDao ToDao(this AppCustomer item, bool includeLocation = false)
        {
            var retval = new AppCustomerDao
            {
                    Id = item.ID,
                    Name = item.Name,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    City = item.City,
                    State = item.State,
                    PostalCode = item.PostalCode,
                    Country = item.Country,
                    AccessKey = item.AccessKey,
                    Active = item.Active
            };

            if (includeLocation)
            {
                if (item.AppCustomerLocations.Count == 0)
                    item.AppCustomerLocations.Load();

                if (item.AppCustomerLocations.Count > 0)
                {
                    retval.Locations.AddRange(item.AppCustomerLocations.ToDao());
                }
            }

            return retval;
        }

        public static List<AppCustomerDao> ToDao(this IEnumerable<AppCustomer> items, bool includeLocations = false)
        {
            var retval = new List<AppCustomerDao>();
            foreach (var item in items)
            {
                retval.Add(item.ToDao(includeLocations));
            }
            return retval;
        }

        public static AppCustomerLocationDao ToDao(this AppCustomerLocation item)
        {
            var retval = new AppCustomerLocationDao
                {
                    Id = item.ID,
                    Name = item.Name,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    City = item.City,
                    State = item.State,
                    PostalCode = item.PostalCode,
                    Country = item.Country,
                    AppCustomerId = item.AppCustomerID,
                    Active = item.Active
                };

            return retval;
        }

        public static List<AppCustomerLocationDao> ToDao(this IEnumerable<AppCustomerLocation> items)
        {
            var retval = new List<AppCustomerLocationDao>();
            foreach (var item in items)
            {
                retval.Add(item.ToDao());
            }
            return retval;
        }

        public static AppCustomerItemImageDao ToDao(this AppCustomerItemImage item)
        {
            var dao = new AppCustomerItemImageDao
            {
                    Id = item.ID,
                    ItemId = item.ItemID,
                    FileLocation = item.FileLocation,
                    Url = item.Url,
                    Primary = item.Primary,
                    DisplayOrder = item.DisplayOrder
            };

            return dao;
        }

        public static List<AppCustomerItemImageDao> ToDao(this IEnumerable<AppCustomerItemImage> items)
        {
            var daos = new List<AppCustomerItemImageDao>();
            foreach (var item in items)
            {
                daos.Add(item.ToDao());
            }
            return daos;
        }

        public static AppCustomerItemSaleDao ToDao(this AppCustomerItemSale item)
        {
            var dao = new AppCustomerItemSaleDao
            {
                    Id = item.ID,
                    ItemId = item.ItemID,
                    Price = item.Price,
                    EffectiveDate = item.EffectiveDate,
                    ExpireDate = item.ExpireDate
            };

            return dao;
        }

        public static List<AppCustomerItemSaleDao> ToDao(this IEnumerable<AppCustomerItemSale> items)
        {
            var daos = new List<AppCustomerItemSaleDao>();
            foreach (var item in items)
            {
                daos.Add(item.ToDao());
            }
            return daos;
        }

        public static AppCustomerItemFeaturedDao ToDao(this AppCustomerItemFeaturedDao item)
        {
            var dao = new AppCustomerItemFeaturedDao
                {
                    Id = item.Id,
                    ItemId = item.ItemId,
                    EffectiveDate = item.EffectiveDate,
                    ExpireDate = item.ExpireDate
                };

            return dao;
        }

        public static List<AppCustomerItemFeaturedDao> ToDao(this IEnumerable<AppCustomerItemFeaturedDao> items)
        {
            var daos = new List<AppCustomerItemFeaturedDao>();
            foreach (var item in items)
            {
                daos.Add(item.ToDao());
            }
            return daos;
        }
    }
}

