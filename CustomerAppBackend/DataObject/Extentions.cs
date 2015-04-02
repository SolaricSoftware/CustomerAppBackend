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
    }
}

