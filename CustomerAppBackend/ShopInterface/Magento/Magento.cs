using System;
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

