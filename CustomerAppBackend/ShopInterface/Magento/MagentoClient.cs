using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Linq;
using System.Web.Script.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

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
            var targetUrl = "http://www.solaricsoftware.com/magento/index.php/api/v2_soap";
            this._client = new MagentoService(targetUrl);
            this._sessionId = this._client.login("RSM", "meandme1");
        }

        public Customer GetCustomer(string email, string password)
        {
            var filter = this.ConfigureFilter("email", "=", email);
            var list = this._client.customerCustomerList(_sessionId, filter);

            ValidateHash(password, list[0].password_hash);

            customerCustomerEntity customerEntity = null;
            foreach (var item in list)
            {
                if (base.ValidateHash(password, item.password_hash))
                {
                    customerEntity = item;
                    break;
                }
            }

            if (customerEntity != null)
            {
                var retval = new Customer
                {
                    Email = customerEntity.email,
                    FirstName = customerEntity.firstname,
                    LastName = customerEntity.lastname,
                    Id = customerEntity.customer_id,
                    StoreId = customerEntity.store_id,
                    WebsiteId = customerEntity.website_id
                };

                var addresses = this._client.customerAddressList(_sessionId, customerEntity.customer_id);

                retval.Addressess = addresses.Select(x => new Address
                    {
                        Address1 = x.street,
                        City = x.city,
                        State = x.region_id.ToString(),
                        StateCode = x.region,
                        PostalCode = x.postcode,
                        Company = x.company,
                        Country = x.country_id,
                        CountryCode = x.country_id,
                        DefaultBilling = x.is_default_billing,
                        DefaultShipping = x.is_default_shipping,
                        AddressType = (x.is_default_billing ? AddressType.Billing : (x.is_default_shipping ? AddressType.Shipping : AddressType.NotSet)),
                        FirstName = x.firstname,
                        LastName = x.lastname,
                    }).ToList();

                retval.DefaultAddress = retval.Addressess.FirstOrDefault(x => x.DefaultBilling || x.DefaultShipping);
            
                return retval;
            }

            return null;
        }

        public List<Category> GetCategories() 
        {
            var tree = this._client.catalogCategoryTree(this._sessionId, null, null);

            var retval = new List<Category>();
            if (tree.children.Count() > 0)
            {
                foreach (var child in tree.children[0].children)
                {
                    var categories = this.ConvertToCategories(child);
                    retval.AddRange(categories);
                }
            }
            return retval;
        }

		public List<Product> GetProducts()
		{
            var filter = this.ConfigureFilter("type", "in", "simple");
            var products = this._client.catalogProductList(this._sessionId, filter, null);

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
				var product = this.GetProduct(id);
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
                Description = product.description,
				Tags = product.meta_keyword,
                Title = product.name
			};

            var variant = new ProductVariant
            { 
                    Id = Int32.Parse(product.product_id),
                    Weight = Decimal.Parse(product.weight),
                    Price = Decimal.Parse(product.price),
                    ProductId = Int32.Parse(product.product_id),
                    Sku = product.sku,
                    Title = product.name
            };

            retval.Variants = new List<ProductVariant> { variant };

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

            var assignedProducts = this._client.catalogCategoryAssignedProducts(this._sessionId, Int32.Parse(id));

            foreach (var assignedProduct in assignedProducts)
            {
                var product = this.GetProduct(assignedProduct.product_id.ToString());
                retval.Add(product);
            }

			return retval;
		}

        public int CreateCart(int customerId)
        {
            var cartId = this._client.shoppingCartCreate(_sessionId, null);
            var customer = this._client.customerCustomerInfo(_sessionId, customerId, null);

            if (customer != null)
            {
                var customerEntity = new shoppingCartCustomerEntity
                {
                    customer_id = customer.customer_id,
                    email = customer.email,
                    firstname = customer.firstname,
                    lastname = customer.lastname,
                    group_id = customer.group_id,
                    store_id = customer.store_id,
                    website_id = customer.website_id
                };

                if (!this._client.shoppingCartCustomerSet(_sessionId, cartId, customerEntity, customer.store_id.ToString()))
                {
                    throw new Exception("Unable to add customer to shopping cart.");
                }
            }
            else
            {
                throw new Exception("Unable to find customer.");
            }

            return cartId;
        }

        public Cart GetCart(int cartId)
        {
            var cartInfo = this._client.shoppingCartInfo(_sessionId, cartId, null);

            var cart = new Cart
            {
                    Id = cartInfo.quote_id,
                    Active = cartInfo.is_active == 1,
                    BillingAddress = new Address 
                        {
                            Address1 = cartInfo.billing_address.street,
                            City = cartInfo.billing_address.city,
                            State = cartInfo.billing_address.region,
                            StateCode = cartInfo.billing_address.region_id,
                            PostalCode = cartInfo.billing_address.postcode,
                            Company = cartInfo.billing_address.company,
                            FirstName = cartInfo.billing_address.firstname,
                            LastName = cartInfo.billing_address.lastname,
                            Id = Int32.Parse(cartInfo.billing_address.address_id),
                            Phone = cartInfo.billing_address.telephone,
                            AddressType = AddressType.Billing
                        },
                    CreatedAt = DateTime.Parse(cartInfo.created_at),
                    CustomerEmail = cartInfo.customer_email,
                    CustomerFirstName = cartInfo.customer_firstname,
                    CustomerLastName = cartInfo.customer_lastname,
                    CustomerId = Int32.Parse(cartInfo.customer_id),
                    ItemsCount = (int)cartInfo.items_count,
                    ItemsQty = (int)cartInfo.items_qty,
                    ShippingAddress = new Address
                        {
                            Address1 = cartInfo.shipping_address.street,
                            City = cartInfo.shipping_address.city,
                            State = cartInfo.shipping_address.region,
                            StateCode = cartInfo.shipping_address.region_id,
                            PostalCode = cartInfo.shipping_address.postcode,
                            Company = cartInfo.shipping_address.company,
                            FirstName = cartInfo.shipping_address.firstname,
                            LastName = cartInfo.shipping_address.lastname,
                            Id = Int32.Parse(cartInfo.shipping_address.address_id),
                            Phone = cartInfo.shipping_address.telephone,
                            AddressType = AddressType.Shipping
                        },
                    StoreId = Int32.Parse(cartInfo.store_id),
                    Subtotal = (decimal)cartInfo.subtotal,
                    Total = Decimal.Parse(cartInfo.grand_total),
                    Items = cartInfo.items.Select(x => new Product 
                        {
                            Description = x.description,
                            Id = Int32.Parse(x.item_id),
                            Name = x.name,
                            Title = x.name,
                            Variants = new List<ProductVariant> 
                                {
                                    new ProductVariant 
                                    {
                                        Id = Int32.Parse(x.item_id),
                                        Price = (decimal)x.price,
                                        ProductId = Int32.Parse(x.item_id),
                                        Sku = x.sku,
                                        Title = x.name,
                                        Weight = (decimal)x.weight
                                    }
                                }
                        }).ToList()
            };

            return cart;
        }

        public bool AddToCart(int cartId, List<CartItem> cartItems)
        {
            var list = new  List<shoppingCartProductEntity>();

            cartItems.ForEach(x => list.Add(new shoppingCartProductEntity 
                {
                    product_id = x.Id.ToString(),
                    sku = x.Variants[0].Sku,
                    qty = x.Quantity
                }));

            var retval = this._client.shoppingCartProductAdd(_sessionId, cartId, list.ToArray(), null);
            return retval;
        }

        public bool AddPaymentMethodToCart(int cartId, Payment payment)
        {
            var paymentEntity = new shoppingCartPaymentMethodEntity
            {
                    cc_exp_month = payment.ExpMonth,
                    cc_exp_year = payment.ExpYear,
                    cc_number = payment.CardNumber,
                    cc_owner = payment.NameOnCard
            };

            return this._client.shoppingCartPaymentMethod(_sessionId, cartId, paymentEntity, null);
        }

        public bool AddAddressToCart(int cartId, int addressId, AddressType addressType)
        {
            var address = new shoppingCartCustomerAddressEntity
                {
                    mode = (addressType == AddressType.Shipping ? "shipping" : "billing"),
                    address_id = addressId.ToString()
                };

            return this._client.shoppingCartCustomerAddresses(_sessionId, cartId, new[] { address }, null);
        }

        public string PlaceOrder(int cartId)
        {
            var retval = this._client.shoppingCartOrder(_sessionId, cartId, null, null);
            return retval;
        }

        public Order GetOrder(int orderId)
        {
            var orderEntity = this._client.salesOrderInfo(_sessionId, orderId.ToString());

            var retval = new Order
                {
                    CreatedAt = DateTime.Parse(orderEntity.created_at),
                    Currency = orderEntity.order_currency_code,
                    Email = orderEntity.customer_email,
                    Id = Int32.Parse(orderEntity.order_id),
                    Name = "",
                    Note = "",
                    NumericalIdentifier = Int32.Parse(orderEntity.increment_id),
                    OrderNumber = Int32.Parse(orderEntity.increment_id),
                    PaymentStatus = PaymentStatusType.Paid,
                    Refunds = new List<Refund>(),
                    Shipments = null,
                    Subtotal = Decimal.Parse(orderEntity.subtotal),
                    Taxes = new List<TaxInfo>(),
                    TaxesIncluded = true,
                    TotalDiscount = Decimal.Parse(orderEntity.discount_amount),
                    TotalPrice = Decimal.Parse(orderEntity.grand_total),
                    TotalTax = Decimal.Parse(orderEntity.tax_amount),
                    TotalWeight = Int32.Parse(orderEntity.weight),
                    UpdatedAt = DateTime.Parse(orderEntity.updated_at)
                };

            OrderStatusType status;
            Enum<OrderStatusType>.TryParse(orderEntity.state, out status);
            retval.Status = status;

            retval.Customer = new Customer
            {
                Email = orderEntity.customer_email,
                FirstName = orderEntity.customer_firstname,
                LastName = orderEntity.customer_lastname,
                Id = Int32.Parse(orderEntity.customer_id),
                StoreId = Int32.Parse(orderEntity.store_id)
            };

            retval.LineItems = orderEntity.items.Select(x => new LineItem
                {
                    Id = Int32.Parse(x.item_id),
                    Name = x.name,
                    Price = Decimal.Parse(x.price),
                    ProductExists = x.is_virtual != "0",
                    ProductId = Int32.Parse(x.product_id),
                    Quantity = Int32.Parse(x.qty_ordered),
                    RequiresShipping = x.is_virtual != "0",
                    Sku = x.sku,
                    Title = x.name,
                    VariantId = Int32.Parse(x.product_id),
                    VariantTitle = x.name
                }).ToList();

            retval.Transactions = new List<Transaction>
            {
                    new Transaction
                    {
                        Amount = Decimal.Parse(orderEntity.payment.amount_ordered),
                        CreatedAt = DateTime.Parse(orderEntity.created_at),
                        OrderId = Int32.Parse(orderEntity.order_id),
                        TransactionType = TransactionType.Sale,
                        UserId = Int32.Parse(orderEntity.customer_id),
                        Status = TransactionStatusType.Success,
                        PaymentDetail = new PaymentDetail
                            {
                                CreditCardNumber = orderEntity.payment.cc_number_enc,
                                CreditCardCompany = orderEntity.payment.cc_type
                            }
                    }
            };

            retval.BillingAddress = new Address
            {
                Address1 = orderEntity.billing_address.street,
                City = orderEntity.billing_address.city,
                State = orderEntity.billing_address.region,
                StateCode = orderEntity.billing_address.region_id,
                PostalCode = orderEntity.billing_address.postcode,
                Company = orderEntity.billing_address.company,
                FirstName = orderEntity.billing_address.firstname,
                LastName = orderEntity.billing_address.lastname,
                Id = Int32.Parse(orderEntity.billing_address.address_id),
                Phone = orderEntity.billing_address.telephone,
                AddressType = AddressType.Billing
            };

            retval.ShippingAddress = new Address
            {
                Address1 = orderEntity.shipping_address.street,
                City = orderEntity.shipping_address.city,
                State = orderEntity.shipping_address.region,
                StateCode = orderEntity.shipping_address.region_id,
                PostalCode = orderEntity.shipping_address.postcode,
                Company = orderEntity.shipping_address.company,
                FirstName = orderEntity.shipping_address.firstname,
                LastName = orderEntity.shipping_address.lastname,
                Id = Int32.Parse(orderEntity.shipping_address.address_id),
                Phone = orderEntity.shipping_address.telephone,
                AddressType = AddressType.Shipping
            };
            
            var filter = this.ConfigureFilter("order_id", "=", orderEntity.order_id);
            var shipmentList = this._client.salesOrderShipmentList(_sessionId, filter);

            retval.Shipments = shipmentList.Select(x => new Shipment
                {
                    CreatedAt = DateTime.Parse(x.created_at),
                    Id = Int32.Parse(x.shipment_id),
                    OrderId = Int32.Parse(x.order_id),
                    Status = ShipmentStatusType.Pending,
                    TrackingCompany = ((x.tracks.Count() > 0) ? x.tracks[0].title : ""),
                    TrackingNumber = ((x.tracks.Count() > 0) ? x.tracks[0].number : ""),
                    TrackingUrls = new List<string>(),
                    UpdatedAt = DateTime.Parse(x.updated_at)
                }).ToList();

            return retval;
        }

//        public void GetCartPaymentMethods(int cartId)
//        {
//            var pm = this._client.shoppingCartPaymentList(_sessionId, cartId, null);
//        }

//        public Order CreateOrder(Order order) 
//        {
//            this._client.salesOrder
//        }

        private List<Category> ConvertToCategories(catalogCategoryEntity entity)
        {
            var retval = new List<Category>();

            var cat = this._client.catalogCategoryInfo(this._sessionId, entity.category_id, null, null);

            var category = new Category
            {
                    Id = Int32.Parse(cat.category_id),
                    Name = cat.name,
                    ParentId = Int32.Parse(cat.parent_id),
                    SortOrder = cat.position.ToString(),
                    Title = cat.name,
                    Description = cat.description,
                    Visible = cat.is_active > 0,
                    ImageUrl = "http://api.solaricsoftware.com/images/category_default.png"
            };

            foreach (var child in entity.children.OrderBy(x => x.position))
            {
                category.Children.AddRange(this.ConvertToCategories(child));
            }

            retval.Add(category);


            return retval;
        }

        private filters ConfigureFilter(string key, string op, string value)
        {
            var entity = new associativeEntity();
            entity.key = op;
            entity.value = value;

            var complexFilter = new complexFilter();
            complexFilter.key = key;
            complexFilter.value = entity;

            var filter = new filters();
            filter.complex_filter = new[] { complexFilter };

            return filter;
        }

    }
}

