﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Linq;
using System.Web.Script.Serialization;
using System.Collections;
using System.Collections.Generic;

using CustomerAppBackend.DataObject;
using CustomerAppBackend.ShopInterface;
using CustomerAppBackend.Magento;


namespace CustomerAppBackend.ShopInterface.Magento
{
    public class MagentoClient : ShopInterfaceBase
    {
        private MagentoService _client;  
        private string _sessionId = "";
      
        public MagentoClient()
        {
            this._client = new MagentoService();
            this._sessionId = this._client.login("RSM", "meandme1");
        }

        public List<Category> GetCategories() 
        {
            var tree = this._client.catalogCategoryTree(this._sessionId, null, null);

            var retval = new List<Category>();
            foreach (var child in tree.children)
            {
                var categories = this.ConvertToCategories(child);
                retval.AddRange(categories);
            }
            return retval;
        }

		public List<Product> GetProducts()
		{
			var products = this._client.catalogProductList(this._sessionId, null, null);

			var retval = new List<Product>();
			foreach (var product in products) 
			{
				var p = new Product {
					Id = Int32.Parse(product.product_id),
					Name = product.name,
					Title = product.name
				};

				var images = this._client.catalogProductAttributeMediaList(this._sessionId, p.Id.ToString (), null, null);
				foreach (var img in images) {
					var pi = new ProductImage {
						Position = Int32.Parse(img.position),
						ProductId = p.Id,
						Source = img.url
					};

					p.Images.Add(pi);
				}

				retval.Add (p);
			}
			return retval;
		}

		public List<Product> GetProducts(string ids)
		{
			var idList = ids.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

			var retval = new List<Product>();

			foreach (var id in idList) {
				var product = this.GetProduct (id);
				retval.Add(product);
			}

			return retval;
		}

		public Product GetProduct(string id)
		{
			var product = this._client.catalogProductInfo(this._sessionId, id, null, null, null);

			var retval = new Product {
				Id = Int32.Parse(product.product_id),
				Name = product.name,
				Description = product.short_description,
				Tags = product.meta_keyword,
				Title = product.meta_title
			};

			var images = this._client.catalogProductAttributeMediaList(this._sessionId, retval.Id.ToString(), null, null);
			foreach (var img in images) {
				var pi = new ProductImage {
					Position = Int32.Parse(img.position),
					ProductId = retval.Id,
					Source = img.url
				};

				retval.Images.Add(pi);
			}

			return retval;
		}

		public List<Product> GetProductsByCategoryId(string id)
		{
			var retval = new List<Product> ();

			var products = this._client.catalogProductList(this._sessionId, null, null);

			foreach (var product in products.Where(x => x.category_ids.Contains(id))) 
			{
				var p = new Product {
					Id = Int32.Parse(product.product_id),
					Name = product.name,
					Title = product.name
				};

				var images = this._client.catalogProductAttributeMediaList(this._sessionId, p.Id.ToString (), null, null);
				foreach (var img in images) {
					var pi = new ProductImage {
						Position = Int32.Parse(img.position),
						ProductId = p.Id,
						Source = img.url
					};

					p.Images.Add(pi);
				}

				retval.Add (p);
			}

			return retval;
		}

        private List<Category> ConvertToCategories(catalogCategoryEntity entity)
        {
            var retval = new List<Category>();

            var category = new Category
            {
                    Id = entity.category_id,
                    Name = entity.name,
                    ParentId = entity.parent_id,
                    SortOrder = entity.position.ToString(),
                    Title = entity.name,
                    Visible = entity.is_active > 0
            };

            foreach (var child in entity.children.OrderBy(x => x.position))
            {
                category.Children.AddRange(this.ConvertToCategories(child));
            }

            retval.Add(category);


            return retval;
        }
    }
}
