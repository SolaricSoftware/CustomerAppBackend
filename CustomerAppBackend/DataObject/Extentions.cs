using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CustomerAppBackend.DataObject;

using CustomerAppBackend.ShopInterface;

namespace CustomerAppBackend.DataObject
{
    public static class Extentions
    {
//        public static AppCustomerDao ToDao(this AppCustomer item, bool includeLocation = false)
//        {
//            var retval = new AppCustomerDao
//            {
//                    Id = item.ID,
//                    Name = item.Name,
//                    Address1 = item.Address1,
//                    Address2 = item.Address2,
//                    City = item.City,
//                    State = item.State,
//                    PostalCode = item.PostalCode,
//                    Country = item.Country,
//                    AccessKey = item.AccessKey,
//                    Active = item.Active
//            };
//
//            if (includeLocation)
//            {
//                if (item.AppCustomerLocations.Count == 0)
//                    item.AppCustomerLocations.Load();
//
//                if (item.AppCustomerLocations.Count > 0)
//                {
//                    retval.Locations.AddRange(item.AppCustomerLocations.ToDao());
//                }
//            }
//
//            return retval;
//        }
//
//        public static List<AppCustomerDao> ToDao(this IEnumerable<AppCustomer> items, bool includeLocations = false)
//        {
//            var retval = new List<AppCustomerDao>();
//            foreach (var item in items)
//            {
//                retval.Add(item.ToDao(includeLocations));
//            }
//            return retval;
//        }
//
//        public static AppCustomerLocationDao ToDao(this AppCustomerLocation item)
//        {
//            var retval = new AppCustomerLocationDao
//                {
//                    Id = item.ID,
//                    Name = item.Name,
//                    Address1 = item.Address1,
//                    Address2 = item.Address2,
//                    City = item.City,
//                    State = item.State,
//                    PostalCode = item.PostalCode,
//                    Country = item.Country,
//                    AppCustomerId = item.AppCustomerID,
//                    Active = item.Active
//                };
//
//            return retval;
//        }
//
//        public static List<AppCustomerLocationDao> ToDao(this IEnumerable<AppCustomerLocation> items)
//        {
//            var retval = new List<AppCustomerLocationDao>();
//            foreach (var item in items)
//            {
//                retval.Add(item.ToDao());
//            }
//            return retval;
//        }
//
//        public static AppCustomerItemDao ToDao(this AppCustomerItem item)
//        {
//            var dao = new AppCustomerItemDao
//                {
//                    Id = item.ID,
//                    Name = item.Name,
//                    StockNumber = item.StockNumber,
//                    Description = item.Description,
//                    Quantity = item.Quantity,
//                    Price = item.Price,
//                    AppCustomerLocationId = item.AppCustomerLocationID,
//                    Active = item.Active
//                };
//
//            if (item.AppCustomerLocation != null)
//            {
//                dao.Location = item.AppCustomerLocation.ToDao();
//            }
//
//            if (item.AppCustomerItemImages == null)
//                item.AppCustomerItemImages.Load();
//
//            if (item.AppCustomerItemImages.Count > 0)
//                dao.Images = item.AppCustomerItemImages.ToDao();
//
//            if (item.AppCustomerItemSales == null)
//                item.AppCustomerItemSales.Load();
//
//            if (item.AppCustomerItemSales.Count > 0)
//                dao.SaleItems = item.AppCustomerItemSales.ToDao();
//
//            if (item.AppCustomerItemFeatured == null)
//                item.AppCustomerItemFeatured.Load();
//
//            if (item.AppCustomerItemFeatured.Count > 0)
//                dao.FeaturedItems = item.AppCustomerItemFeatured.ToDao();
//
//            return dao;
//        }
//
//        public static List<AppCustomerItemDao> ToDao(this IEnumerable<AppCustomerItem> items)
//        {
//            var daos = new List<AppCustomerItemDao>();
//            foreach (var item in items)
//            {
//                daos.Add(item.ToDao());
//            }
//            return daos;
//        }
//
//        public static AppCustomerItemCategoryDao ToDao(this AppCustomerItemCategory item, bool loadItems = false)
//        {
//            var dao = new AppCustomerItemCategoryDao
//            {
//                Id = item.ID,
//                Name = item.Name,
//                Description = item.Description,
//                Active = item.Active
//            };
//
//            if (loadItems)
//            {
//                if (item.AppCustomerItems == null)
//                    item.AppCustomerItems.Load();
//
//                if (item.AppCustomerItems.Count > 0)
//                {
//                    dao.Items = item.AppCustomerItems.ToDao();
//                }
//            }
//
//            return dao;
//        }
//
//        public static List<AppCustomerItemCategoryDao> ToDao(this IEnumerable<AppCustomerItemCategory> items, bool loadItems = false)
//        {
//            var daos = new List<AppCustomerItemCategoryDao>();
//            foreach (var item in items)
//            {
//                daos.Add(item.ToDao(loadItems));
//            }
//            return daos;
//        }
//
//        public static AppCustomerItemImageDao ToDao(this AppCustomerItemImage item)
//        {
//            var dao = new AppCustomerItemImageDao
//            {
//                    Id = item.ID,
//                    ItemId = item.ItemID,
//                    FileLocation = item.FileLocation,
//                    Url = item.Url,
//                    ThumbnailUrl = item.ThumbnailUrl,
//                    Primary = item.Primary,
//                    DisplayOrder = item.DisplayOrder
//            };
//                        
//            return dao;
//        }
//
//        public static List<AppCustomerItemImageDao> ToDao(this IEnumerable<AppCustomerItemImage> items)
//        {
//            var daos = new List<AppCustomerItemImageDao>();
//            foreach (var item in items)
//            {
//                daos.Add(item.ToDao());
//            }
//            return daos;
//        }
//
//        public static AppCustomerItemSaleDao ToDao(this AppCustomerItemSale item, bool loadItem = false)
//        {
//            var dao = new AppCustomerItemSaleDao
//            {
//                    Id = item.ID,
//                    ItemId = item.ItemID,
//                    Price = item.Price,
//                    EffectiveDate = item.EffectiveDate,
//                    ExpireDate = item.ExpireDate
//            };
//
//            if (loadItem)
//            {
//                dao.Item = item.AppCustomerItem.ToDao();
//            }
//
//            return dao;
//        }
//
//        public static List<AppCustomerItemSaleDao> ToDao(this IEnumerable<AppCustomerItemSale> items, bool loadItems = false)
//        {
//            var daos = new List<AppCustomerItemSaleDao>();
//            foreach (var item in items)
//            {
//                daos.Add(item.ToDao(loadItems));
//            }
//            return daos;
//        }
//
//        public static AppCustomerItemFeaturedDao ToDao(this AppCustomerItemFeatured item, bool loadItem = false)
//        {
//            var dao = new AppCustomerItemFeaturedDao
//                {
//                    Id = item.ID,
//                    ItemId = item.ItemID,
//                    EffectiveDate = item.EffectiveDate,
//                    ExpireDate = item.ExpireDate
//                };
//
//            if (loadItem)
//            {
//                dao.Item = item.AppCustomerItem.ToDao();
//            }
//
//            return dao;
//        }
//
//        public static List<AppCustomerItemFeaturedDao> ToDao(this IEnumerable<AppCustomerItemFeatured> items, bool loadItems = false)
//        {
//            var daos = new List<AppCustomerItemFeaturedDao>();
//            foreach (var item in items)
//            {
//                daos.Add(item.ToDao(loadItems));
//            }
//            return daos;
//        }

        public static string ToShopifyJson<T>(this IEnumerable<T> items) where T : IShopify
        {
            var itemCount = items.Count();
            var sb = new StringBuilder();
            sb.Append("[");
            foreach(var item in items)
            {
                sb.Append(item.ToShopifyJson());

                if (itemCount < items.Count() - 1)
                    sb.Append(",");

                itemCount++;
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}

