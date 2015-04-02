// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from CustomerApp on 2015-04-02 11:31:15Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace CustomerAppBackend.Data
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Diagnostics;


    public partial class DataAccess : DataContext
    {

        #region Extensibility Method Declarations
        partial void OnCreated();
        #endregion


        public DataAccess(string connectionString) : 
        base(connectionString)
        {
            this.OnCreated();
        }

        public DataAccess(IDbConnection connection) : 
        base(connection)
        {
            this.OnCreated();
        }

        public DataAccess(string connection, MappingSource mappingSource) : 
        base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public DataAccess(IDbConnection connection, MappingSource mappingSource) : 
        base(connection, mappingSource)
        {
            this.OnCreated();
        }

        public Table<AppCustomer> AppCustomers
        {
            get
            {
                return this.GetTable <AppCustomer>();
            }
        }

        public Table<AppCustomerItem> AppCustomerItems
        {
            get
            {
                return this.GetTable <AppCustomerItem>();
            }
        }

        public Table<AppCustomerItemFeatured> AppCustomerItemFeatured
        {
            get
            {
                return this.GetTable <AppCustomerItemFeatured>();
            }
        }

        public Table<AppCustomerItemImage> AppCustomerItemImages
        {
            get
            {
                return this.GetTable <AppCustomerItemImage>();
            }
        }

        public Table<AppCustomerItemProperty> AppCustomerItemProperties
        {
            get
            {
                return this.GetTable <AppCustomerItemProperty>();
            }
        }

        public Table<AppCustomerItemSale> AppCustomerItemSales
        {
            get
            {
                return this.GetTable <AppCustomerItemSale>();
            }
        }

        public Table<AppCustomerLocation> AppCustomerLocations
        {
            get
            {
                return this.GetTable <AppCustomerLocation>();
            }
        }

        public Table<AppUser> AppUsers
        {
            get
            {
                return this.GetTable <AppUser>();
            }
        }
    }

    [Table(Name="CustomerAppUser.AppCustomer")]
    public partial class AppCustomer : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.Guid _accessKey;

        private bool _active;

        private string _address1;

        private string _address2;

        private string _city;

        private string _country;

        private int _id;

        private string _name;

        private string _postalCode;

        private string _state;

        private EntitySet<AppCustomerLocation> _appCustomerLocations;

        private EntitySet<AppUser> _appUsers;

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnAccessKeyChanged();

        partial void OnAccessKeyChanging(System.Guid value);

        partial void OnActiveChanged();

        partial void OnActiveChanging(bool value);

        partial void OnAddress1Changed();

        partial void OnAddress1Changing(string value);

        partial void OnAddress2Changed();

        partial void OnAddress2Changing(string value);

        partial void OnCityChanged();

        partial void OnCityChanging(string value);

        partial void OnCountryChanged();

        partial void OnCountryChanging(string value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnPostalCodeChanged();

        partial void OnPostalCodeChanging(string value);

        partial void OnStateChanged();

        partial void OnStateChanging(string value);
        #endregion


        public AppCustomer()
        {
            _appCustomerLocations = new EntitySet<AppCustomerLocation>(new Action<AppCustomerLocation>(this.AppCustomerLocations_Attach), new Action<AppCustomerLocation>(this.AppCustomerLocations_Detach));
            _appUsers = new EntitySet<AppUser>(new Action<AppUser>(this.AppUsers_Attach), new Action<AppUser>(this.AppUsers_Detach));
            this.OnCreated();
        }

        [Column(Storage="_accessKey", Name="AccessKey", DbType="uniqueidentifier", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public System.Guid AccessKey
        {
            get
            {
                return this._accessKey;
            }
            set
            {
                if ((_accessKey != value))
                {
                    this.OnAccessKeyChanging(value);
                    this.SendPropertyChanging();
                    this._accessKey = value;
                    this.SendPropertyChanged("AccessKey");
                    this.OnAccessKeyChanged();
                }
            }
        }

        [Column(Storage="_active", Name="Active", DbType="bit", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public bool Active
        {
            get
            {
                return this._active;
            }
            set
            {
                if ((_active != value))
                {
                    this.OnActiveChanging(value);
                    this.SendPropertyChanging();
                    this._active = value;
                    this.SendPropertyChanged("Active");
                    this.OnActiveChanged();
                }
            }
        }

        [Column(Storage="_address1", Name="Address1", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Address1
        {
            get
            {
                return this._address1;
            }
            set
            {
                if (((_address1 == value) == false))
                {
                    this.OnAddress1Changing(value);
                    this.SendPropertyChanging();
                    this._address1 = value;
                    this.SendPropertyChanged("Address1");
                    this.OnAddress1Changed();
                }
            }
        }

        [Column(Storage="_address2", Name="Address2", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Address2
        {
            get
            {
                return this._address2;
            }
            set
            {
                if (((_address2 == value) == false))
                {
                    this.OnAddress2Changing(value);
                    this.SendPropertyChanging();
                    this._address2 = value;
                    this.SendPropertyChanged("Address2");
                    this.OnAddress2Changed();
                }
            }
        }

        [Column(Storage="_city", Name="City", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                if (((_city == value) == false))
                {
                    this.OnCityChanging(value);
                    this.SendPropertyChanging();
                    this._city = value;
                    this.SendPropertyChanged("City");
                    this.OnCityChanged();
                }
            }
        }

        [Column(Storage="_country", Name="Country", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                if (((_country == value) == false))
                {
                    this.OnCountryChanging(value);
                    this.SendPropertyChanging();
                    this._country = value;
                    this.SendPropertyChanged("Country");
                    this.OnCountryChanged();
                }
            }
        }

        [Column(Storage="_id", Name="Id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage="_name", Name="Name", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value) == false))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage="_postalCode", Name="PostalCode", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string PostalCode
        {
            get
            {
                return this._postalCode;
            }
            set
            {
                if (((_postalCode == value) == false))
                {
                    this.OnPostalCodeChanging(value);
                    this.SendPropertyChanging();
                    this._postalCode = value;
                    this.SendPropertyChanged("PostalCode");
                    this.OnPostalCodeChanged();
                }
            }
        }

        [Column(Storage="_state", Name="State", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string State
        {
            get
            {
                return this._state;
            }
            set
            {
                if (((_state == value) == false))
                {
                    this.OnStateChanging(value);
                    this.SendPropertyChanging();
                    this._state = value;
                    this.SendPropertyChanged("State");
                    this.OnStateChanged();
                }
            }
        }

        #region Children
        [Association(Storage="_appCustomerLocations", OtherKey="AppCustomerID", ThisKey="ID", Name="FK__AppCustom__AppCu__60A75C0F")]
        [DebuggerNonUserCode()]
        public EntitySet<AppCustomerLocation> AppCustomerLocations
        {
            get
            {
                return this._appCustomerLocations;
            }
            set
            {
                this._appCustomerLocations = value;
            }
        }

        [Association(Storage="_appUsers", OtherKey="AppCustomerID", ThisKey="ID", Name="FK__AppUser__AppCust__4CA06362")]
        [DebuggerNonUserCode()]
        public EntitySet<AppUser> AppUsers
        {
            get
            {
                return this._appUsers;
            }
            set
            {
                this._appUsers = value;
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void AppCustomerLocations_Attach(AppCustomerLocation entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomer = this;
        }

        private void AppCustomerLocations_Detach(AppCustomerLocation entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomer = null;
        }

        private void AppUsers_Attach(AppUser entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomer = this;
        }

        private void AppUsers_Detach(AppUser entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomer = null;
        }
        #endregion
    }

    [Table(Name="CustomerAppUser.AppCustomerItem")]
    public partial class AppCustomerItem : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private bool _active;

        private int _appCustomerLocationID;

        private string _description;

        private int _id;

        private string _name;

        private decimal _price;

        private int _quantity;

        private string _stockNumber;

        private EntitySet<AppCustomerItemProperty> _appCustomerItemProperties;

        private EntitySet<AppCustomerItemFeatured> _appCustomerItemFeatured;

        private EntitySet<AppCustomerItemImage> _appCustomerItemImages;

        private EntitySet<AppCustomerItemSale> _appCustomerItemSales;

        private EntityRef<AppCustomerLocation> _appCustomerLocation = new EntityRef<AppCustomerLocation>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnActiveChanged();

        partial void OnActiveChanging(bool value);

        partial void OnAppCustomerLocationIDChanged();

        partial void OnAppCustomerLocationIDChanging(int value);

        partial void OnDescriptionChanged();

        partial void OnDescriptionChanging(string value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnPriceChanged();

        partial void OnPriceChanging(decimal value);

        partial void OnQuantityChanged();

        partial void OnQuantityChanging(int value);

        partial void OnStockNumberChanged();

        partial void OnStockNumberChanging(string value);
        #endregion


        public AppCustomerItem()
        {
            _appCustomerItemProperties = new EntitySet<AppCustomerItemProperty>(new Action<AppCustomerItemProperty>(this.AppCustomerItemProperties_Attach), new Action<AppCustomerItemProperty>(this.AppCustomerItemProperties_Detach));
            _appCustomerItemFeatured = new EntitySet<AppCustomerItemFeatured>(new Action<AppCustomerItemFeatured>(this.AppCustomerItemFeatured_Attach), new Action<AppCustomerItemFeatured>(this.AppCustomerItemFeatured_Detach));
            _appCustomerItemImages = new EntitySet<AppCustomerItemImage>(new Action<AppCustomerItemImage>(this.AppCustomerItemImages_Attach), new Action<AppCustomerItemImage>(this.AppCustomerItemImages_Detach));
            _appCustomerItemSales = new EntitySet<AppCustomerItemSale>(new Action<AppCustomerItemSale>(this.AppCustomerItemSales_Attach), new Action<AppCustomerItemSale>(this.AppCustomerItemSales_Detach));
            this.OnCreated();
        }

        [Column(Storage="_active", Name="Active", DbType="bit", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public bool Active
        {
            get
            {
                return this._active;
            }
            set
            {
                if ((_active != value))
                {
                    this.OnActiveChanging(value);
                    this.SendPropertyChanging();
                    this._active = value;
                    this.SendPropertyChanged("Active");
                    this.OnActiveChanged();
                }
            }
        }

        [Column(Storage="_appCustomerLocationID", Name="AppCustomerLocationId", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int AppCustomerLocationID
        {
            get
            {
                return this._appCustomerLocationID;
            }
            set
            {
                if ((_appCustomerLocationID != value))
                {
                    this.OnAppCustomerLocationIDChanging(value);
                    this.SendPropertyChanging();
                    this._appCustomerLocationID = value;
                    this.SendPropertyChanged("AppCustomerLocationID");
                    this.OnAppCustomerLocationIDChanged();
                }
            }
        }

        [Column(Storage="_description", Name="Description", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (((_description == value) == false))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        [Column(Storage="_id", Name="Id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage="_name", Name="Name", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value) == false))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage="_price", Name="Price", DbType="decimal", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public decimal Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((_price != value))
                {
                    this.OnPriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("Price");
                    this.OnPriceChanged();
                }
            }
        }

        [Column(Storage="_quantity", Name="Quantity", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int Quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if ((_quantity != value))
                {
                    this.OnQuantityChanging(value);
                    this.SendPropertyChanging();
                    this._quantity = value;
                    this.SendPropertyChanged("Quantity");
                    this.OnQuantityChanged();
                }
            }
        }

        [Column(Storage="_stockNumber", Name="StockNumber", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string StockNumber
        {
            get
            {
                return this._stockNumber;
            }
            set
            {
                if (((_stockNumber == value) == false))
                {
                    this.OnStockNumberChanging(value);
                    this.SendPropertyChanging();
                    this._stockNumber = value;
                    this.SendPropertyChanged("StockNumber");
                    this.OnStockNumberChanged();
                }
            }
        }

        #region Children
        [Association(Storage="_appCustomerItemProperties", OtherKey="AppCustomerItemID", ThisKey="ID", Name="FK__AppCustom__AppCu__74AE54BC")]
        [DebuggerNonUserCode()]
        public EntitySet<AppCustomerItemProperty> AppCustomerItemProperties
        {
            get
            {
                return this._appCustomerItemProperties;
            }
            set
            {
                this._appCustomerItemProperties = value;
            }
        }

        [Association(Storage="_appCustomerItemFeatured", OtherKey="ItemID", ThisKey="ID", Name="FK__AppCustom__ItemI__09A971A2")]
        [DebuggerNonUserCode()]
        public EntitySet<AppCustomerItemFeatured> AppCustomerItemFeatured
        {
            get
            {
                return this._appCustomerItemFeatured;
            }
            set
            {
                this._appCustomerItemFeatured = value;
            }
        }

        [Association(Storage="_appCustomerItemImages", OtherKey="ItemID", ThisKey="ID", Name="FK__AppCustom__ItemI__787EE5A0")]
        [DebuggerNonUserCode()]
        public EntitySet<AppCustomerItemImage> AppCustomerItemImages
        {
            get
            {
                return this._appCustomerItemImages;
            }
            set
            {
                this._appCustomerItemImages = value;
            }
        }

        [Association(Storage="_appCustomerItemSales", OtherKey="ItemID", ThisKey="ID", Name="FK__AppCustom__ItemI__7F2BE32F")]
        [DebuggerNonUserCode()]
        public EntitySet<AppCustomerItemSale> AppCustomerItemSales
        {
            get
            {
                return this._appCustomerItemSales;
            }
            set
            {
                this._appCustomerItemSales = value;
            }
        }
        #endregion

        #region Parents
        [Association(Storage="_appCustomerLocation", OtherKey="ID", ThisKey="AppCustomerLocationID", Name="FK__AppCustom__AppCu__6FE99F9F", IsForeignKey=true)]
        [DebuggerNonUserCode()]
        public AppCustomerLocation AppCustomerLocation
        {
            get
            {
                return this._appCustomerLocation.Entity;
            }
            set
            {
                if (((this._appCustomerLocation.Entity == value) == false))
                {
                    if ((this._appCustomerLocation.Entity != null))
                    {
                        AppCustomerLocation previousAppCustomerLocation = this._appCustomerLocation.Entity;
                        this._appCustomerLocation.Entity = null;
                        previousAppCustomerLocation.AppCustomerItems.Remove(this);
                    }
                    this._appCustomerLocation.Entity = value;
                    if ((value != null))
                    {
                        value.AppCustomerItems.Add(this);
                        _appCustomerLocationID = value.ID;
                    }
                    else
                    {
                        _appCustomerLocationID = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void AppCustomerItemProperties_Attach(AppCustomerItemProperty entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerItem = this;
        }

        private void AppCustomerItemProperties_Detach(AppCustomerItemProperty entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerItem = null;
        }

        private void AppCustomerItemFeatured_Attach(AppCustomerItemFeatured entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerItem = this;
        }

        private void AppCustomerItemFeatured_Detach(AppCustomerItemFeatured entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerItem = null;
        }

        private void AppCustomerItemImages_Attach(AppCustomerItemImage entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerItem = this;
        }

        private void AppCustomerItemImages_Detach(AppCustomerItemImage entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerItem = null;
        }

        private void AppCustomerItemSales_Attach(AppCustomerItemSale entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerItem = this;
        }

        private void AppCustomerItemSales_Detach(AppCustomerItemSale entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerItem = null;
        }
        #endregion
    }

    [Table(Name="CustomerAppUser.AppCustomerItemFeatured")]
    public partial class AppCustomerItemFeatured : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.DateTime _effectiveDate;

        private System.DateTime _expireDate;

        private int _id;

        private int _itemID;

        private EntityRef<AppCustomerItem> _appCustomerItem = new EntityRef<AppCustomerItem>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnEffectiveDateChanged();

        partial void OnEffectiveDateChanging(System.DateTime value);

        partial void OnExpireDateChanged();

        partial void OnExpireDateChanging(System.DateTime value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnItemIDChanged();

        partial void OnItemIDChanging(int value);
        #endregion


        public AppCustomerItemFeatured()
        {
            this.OnCreated();
        }

        [Column(Storage="_effectiveDate", Name="EffectiveDate", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public System.DateTime EffectiveDate
        {
            get
            {
                return this._effectiveDate;
            }
            set
            {
                if ((_effectiveDate != value))
                {
                    this.OnEffectiveDateChanging(value);
                    this.SendPropertyChanging();
                    this._effectiveDate = value;
                    this.SendPropertyChanged("EffectiveDate");
                    this.OnEffectiveDateChanged();
                }
            }
        }

        [Column(Storage="_expireDate", Name="ExpireDate", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public System.DateTime ExpireDate
        {
            get
            {
                return this._expireDate;
            }
            set
            {
                if ((_expireDate != value))
                {
                    this.OnExpireDateChanging(value);
                    this.SendPropertyChanging();
                    this._expireDate = value;
                    this.SendPropertyChanged("ExpireDate");
                    this.OnExpireDateChanged();
                }
            }
        }

        [Column(Storage="_id", Name="Id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage="_itemID", Name="ItemId", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ItemID
        {
            get
            {
                return this._itemID;
            }
            set
            {
                if ((_itemID != value))
                {
                    this.OnItemIDChanging(value);
                    this.SendPropertyChanging();
                    this._itemID = value;
                    this.SendPropertyChanged("ItemID");
                    this.OnItemIDChanged();
                }
            }
        }

        #region Parents
        [Association(Storage="_appCustomerItem", OtherKey="ID", ThisKey="ItemID", Name="FK__AppCustom__ItemI__09A971A2", IsForeignKey=true)]
        [DebuggerNonUserCode()]
        public AppCustomerItem AppCustomerItem
        {
            get
            {
                return this._appCustomerItem.Entity;
            }
            set
            {
                if (((this._appCustomerItem.Entity == value) == false))
                {
                    if ((this._appCustomerItem.Entity != null))
                    {
                        AppCustomerItem previousAppCustomerItem = this._appCustomerItem.Entity;
                        this._appCustomerItem.Entity = null;
                        previousAppCustomerItem.AppCustomerItemFeatured.Remove(this);
                    }
                    this._appCustomerItem.Entity = value;
                    if ((value != null))
                    {
                        value.AppCustomerItemFeatured.Add(this);
                        _itemID = value.ID;
                    }
                    else
                    {
                        _itemID = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name="CustomerAppUser.AppCustomerItemImage")]
    public partial class AppCustomerItemImage : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private sbyte _displayOrder;

        private string _fileLocation;

        private int _id;

        private int _itemID;

        private bool _primary;

        private string _url;

        private EntityRef<AppCustomerItem> _appCustomerItem = new EntityRef<AppCustomerItem>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnDisplayOrderChanged();

        partial void OnDisplayOrderChanging(sbyte value);

        partial void OnFileLocationChanged();

        partial void OnFileLocationChanging(string value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnItemIDChanged();

        partial void OnItemIDChanging(int value);

        partial void OnPrimaryChanged();

        partial void OnPrimaryChanging(bool value);

        partial void OnUrlChanged();

        partial void OnUrlChanging(string value);
        #endregion


        public AppCustomerItemImage()
        {
            this.OnCreated();
        }

        [Column(Storage="_displayOrder", Name="DisplayOrder", DbType="tinyint", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public sbyte DisplayOrder
        {
            get
            {
                return this._displayOrder;
            }
            set
            {
                if ((_displayOrder != value))
                {
                    this.OnDisplayOrderChanging(value);
                    this.SendPropertyChanging();
                    this._displayOrder = value;
                    this.SendPropertyChanged("DisplayOrder");
                    this.OnDisplayOrderChanged();
                }
            }
        }

        [Column(Storage="_fileLocation", Name="FileLocation", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string FileLocation
        {
            get
            {
                return this._fileLocation;
            }
            set
            {
                if (((_fileLocation == value) == false))
                {
                    this.OnFileLocationChanging(value);
                    this.SendPropertyChanging();
                    this._fileLocation = value;
                    this.SendPropertyChanged("FileLocation");
                    this.OnFileLocationChanged();
                }
            }
        }

        [Column(Storage="_id", Name="Id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage="_itemID", Name="ItemId", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ItemID
        {
            get
            {
                return this._itemID;
            }
            set
            {
                if ((_itemID != value))
                {
                    this.OnItemIDChanging(value);
                    this.SendPropertyChanging();
                    this._itemID = value;
                    this.SendPropertyChanged("ItemID");
                    this.OnItemIDChanged();
                }
            }
        }

        [Column(Storage="_primary", Name="Primary", DbType="bit", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public bool Primary
        {
            get
            {
                return this._primary;
            }
            set
            {
                if ((_primary != value))
                {
                    this.OnPrimaryChanging(value);
                    this.SendPropertyChanging();
                    this._primary = value;
                    this.SendPropertyChanged("Primary");
                    this.OnPrimaryChanged();
                }
            }
        }

        [Column(Storage="_url", Name="Url", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                if (((_url == value) == false))
                {
                    this.OnUrlChanging(value);
                    this.SendPropertyChanging();
                    this._url = value;
                    this.SendPropertyChanged("Url");
                    this.OnUrlChanged();
                }
            }
        }

        #region Parents
        [Association(Storage="_appCustomerItem", OtherKey="ID", ThisKey="ItemID", Name="FK__AppCustom__ItemI__787EE5A0", IsForeignKey=true)]
        [DebuggerNonUserCode()]
        public AppCustomerItem AppCustomerItem
        {
            get
            {
                return this._appCustomerItem.Entity;
            }
            set
            {
                if (((this._appCustomerItem.Entity == value) == false))
                {
                    if ((this._appCustomerItem.Entity != null))
                    {
                        AppCustomerItem previousAppCustomerItem = this._appCustomerItem.Entity;
                        this._appCustomerItem.Entity = null;
                        previousAppCustomerItem.AppCustomerItemImages.Remove(this);
                    }
                    this._appCustomerItem.Entity = value;
                    if ((value != null))
                    {
                        value.AppCustomerItemImages.Add(this);
                        _itemID = value.ID;
                    }
                    else
                    {
                        _itemID = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name="CustomerAppUser.AppCustomerItemProperty")]
    public partial class AppCustomerItemProperty : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private int _appCustomerItemID;

        private int _id;

        private string _name;

        private string _value;

        private EntityRef<AppCustomerItem> _appCustomerItem = new EntityRef<AppCustomerItem>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnAppCustomerItemIDChanged();

        partial void OnAppCustomerItemIDChanging(int value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnValueChanged();

        partial void OnValueChanging(string value);
        #endregion


        public AppCustomerItemProperty()
        {
            this.OnCreated();
        }

        [Column(Storage="_appCustomerItemID", Name="AppCustomerItemId", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int AppCustomerItemID
        {
            get
            {
                return this._appCustomerItemID;
            }
            set
            {
                if ((_appCustomerItemID != value))
                {
                    this.OnAppCustomerItemIDChanging(value);
                    this.SendPropertyChanging();
                    this._appCustomerItemID = value;
                    this.SendPropertyChanged("AppCustomerItemID");
                    this.OnAppCustomerItemIDChanged();
                }
            }
        }

        [Column(Storage="_id", Name="Id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage="_name", Name="Name", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value) == false))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage="_value", Name="Value", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (((_value == value) == false))
                {
                    this.OnValueChanging(value);
                    this.SendPropertyChanging();
                    this._value = value;
                    this.SendPropertyChanged("Value");
                    this.OnValueChanged();
                }
            }
        }

        #region Parents
        [Association(Storage="_appCustomerItem", OtherKey="ID", ThisKey="AppCustomerItemID", Name="FK__AppCustom__AppCu__74AE54BC", IsForeignKey=true)]
        [DebuggerNonUserCode()]
        public AppCustomerItem AppCustomerItem
        {
            get
            {
                return this._appCustomerItem.Entity;
            }
            set
            {
                if (((this._appCustomerItem.Entity == value) == false))
                {
                    if ((this._appCustomerItem.Entity != null))
                    {
                        AppCustomerItem previousAppCustomerItem = this._appCustomerItem.Entity;
                        this._appCustomerItem.Entity = null;
                        previousAppCustomerItem.AppCustomerItemProperties.Remove(this);
                    }
                    this._appCustomerItem.Entity = value;
                    if ((value != null))
                    {
                        value.AppCustomerItemProperties.Add(this);
                        _appCustomerItemID = value.ID;
                    }
                    else
                    {
                        _appCustomerItemID = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name="CustomerAppUser.AppCustomerItemSale")]
    public partial class AppCustomerItemSale : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private System.DateTime _effectiveDate;

        private System.DateTime _expireDate;

        private int _id;

        private int _itemID;

        private decimal _price;

        private EntityRef<AppCustomerItem> _appCustomerItem = new EntityRef<AppCustomerItem>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnEffectiveDateChanged();

        partial void OnEffectiveDateChanging(System.DateTime value);

        partial void OnExpireDateChanged();

        partial void OnExpireDateChanging(System.DateTime value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnItemIDChanged();

        partial void OnItemIDChanging(int value);

        partial void OnPriceChanged();

        partial void OnPriceChanging(decimal value);
        #endregion


        public AppCustomerItemSale()
        {
            this.OnCreated();
        }

        [Column(Storage="_effectiveDate", Name="EffectiveDate", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public System.DateTime EffectiveDate
        {
            get
            {
                return this._effectiveDate;
            }
            set
            {
                if ((_effectiveDate != value))
                {
                    this.OnEffectiveDateChanging(value);
                    this.SendPropertyChanging();
                    this._effectiveDate = value;
                    this.SendPropertyChanged("EffectiveDate");
                    this.OnEffectiveDateChanged();
                }
            }
        }

        [Column(Storage="_expireDate", Name="ExpireDate", DbType="datetime", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public System.DateTime ExpireDate
        {
            get
            {
                return this._expireDate;
            }
            set
            {
                if ((_expireDate != value))
                {
                    this.OnExpireDateChanging(value);
                    this.SendPropertyChanging();
                    this._expireDate = value;
                    this.SendPropertyChanged("ExpireDate");
                    this.OnExpireDateChanged();
                }
            }
        }

        [Column(Storage="_id", Name="Id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage="_itemID", Name="ItemId", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ItemID
        {
            get
            {
                return this._itemID;
            }
            set
            {
                if ((_itemID != value))
                {
                    this.OnItemIDChanging(value);
                    this.SendPropertyChanging();
                    this._itemID = value;
                    this.SendPropertyChanged("ItemID");
                    this.OnItemIDChanged();
                }
            }
        }

        [Column(Storage="_price", Name="Price", DbType="decimal", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public decimal Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if ((_price != value))
                {
                    this.OnPriceChanging(value);
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("Price");
                    this.OnPriceChanged();
                }
            }
        }

        #region Parents
        [Association(Storage="_appCustomerItem", OtherKey="ID", ThisKey="ItemID", Name="FK__AppCustom__ItemI__7F2BE32F", IsForeignKey=true)]
        [DebuggerNonUserCode()]
        public AppCustomerItem AppCustomerItem
        {
            get
            {
                return this._appCustomerItem.Entity;
            }
            set
            {
                if (((this._appCustomerItem.Entity == value) == false))
                {
                    if ((this._appCustomerItem.Entity != null))
                    {
                        AppCustomerItem previousAppCustomerItem = this._appCustomerItem.Entity;
                        this._appCustomerItem.Entity = null;
                        previousAppCustomerItem.AppCustomerItemSales.Remove(this);
                    }
                    this._appCustomerItem.Entity = value;
                    if ((value != null))
                    {
                        value.AppCustomerItemSales.Add(this);
                        _itemID = value.ID;
                    }
                    else
                    {
                        _itemID = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Table(Name="CustomerAppUser.AppCustomerLocation")]
    public partial class AppCustomerLocation : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private bool _active;

        private string _address1;

        private string _address2;

        private int _appCustomerID;

        private string _city;

        private string _country;

        private int _id;

        private string _name;

        private string _postalCode;

        private string _state;

        private EntitySet<AppCustomerItem> _appCustomerItems;

        private EntityRef<AppCustomer> _appCustomer = new EntityRef<AppCustomer>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnActiveChanged();

        partial void OnActiveChanging(bool value);

        partial void OnAddress1Changed();

        partial void OnAddress1Changing(string value);

        partial void OnAddress2Changed();

        partial void OnAddress2Changing(string value);

        partial void OnAppCustomerIDChanged();

        partial void OnAppCustomerIDChanging(int value);

        partial void OnCityChanged();

        partial void OnCityChanging(string value);

        partial void OnCountryChanged();

        partial void OnCountryChanging(string value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnNameChanged();

        partial void OnNameChanging(string value);

        partial void OnPostalCodeChanged();

        partial void OnPostalCodeChanging(string value);

        partial void OnStateChanged();

        partial void OnStateChanging(string value);
        #endregion


        public AppCustomerLocation()
        {
            _appCustomerItems = new EntitySet<AppCustomerItem>(new Action<AppCustomerItem>(this.AppCustomerItems_Attach), new Action<AppCustomerItem>(this.AppCustomerItems_Detach));
            this.OnCreated();
        }

        [Column(Storage="_active", Name="Active", DbType="bit", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public bool Active
        {
            get
            {
                return this._active;
            }
            set
            {
                if ((_active != value))
                {
                    this.OnActiveChanging(value);
                    this.SendPropertyChanging();
                    this._active = value;
                    this.SendPropertyChanged("Active");
                    this.OnActiveChanged();
                }
            }
        }

        [Column(Storage="_address1", Name="Address1", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Address1
        {
            get
            {
                return this._address1;
            }
            set
            {
                if (((_address1 == value) == false))
                {
                    this.OnAddress1Changing(value);
                    this.SendPropertyChanging();
                    this._address1 = value;
                    this.SendPropertyChanged("Address1");
                    this.OnAddress1Changed();
                }
            }
        }

        [Column(Storage="_address2", Name="Address2", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Address2
        {
            get
            {
                return this._address2;
            }
            set
            {
                if (((_address2 == value) == false))
                {
                    this.OnAddress2Changing(value);
                    this.SendPropertyChanging();
                    this._address2 = value;
                    this.SendPropertyChanged("Address2");
                    this.OnAddress2Changed();
                }
            }
        }

        [Column(Storage="_appCustomerID", Name="AppCustomerId", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int AppCustomerID
        {
            get
            {
                return this._appCustomerID;
            }
            set
            {
                if ((_appCustomerID != value))
                {
                    this.OnAppCustomerIDChanging(value);
                    this.SendPropertyChanging();
                    this._appCustomerID = value;
                    this.SendPropertyChanged("AppCustomerID");
                    this.OnAppCustomerIDChanged();
                }
            }
        }

        [Column(Storage="_city", Name="City", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                if (((_city == value) == false))
                {
                    this.OnCityChanging(value);
                    this.SendPropertyChanging();
                    this._city = value;
                    this.SendPropertyChanged("City");
                    this.OnCityChanged();
                }
            }
        }

        [Column(Storage="_country", Name="Country", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                if (((_country == value) == false))
                {
                    this.OnCountryChanging(value);
                    this.SendPropertyChanging();
                    this._country = value;
                    this.SendPropertyChanged("Country");
                    this.OnCountryChanged();
                }
            }
        }

        [Column(Storage="_id", Name="Id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage="_name", Name="Name", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (((_name == value) == false))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage="_postalCode", Name="PostalCode", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string PostalCode
        {
            get
            {
                return this._postalCode;
            }
            set
            {
                if (((_postalCode == value) == false))
                {
                    this.OnPostalCodeChanging(value);
                    this.SendPropertyChanging();
                    this._postalCode = value;
                    this.SendPropertyChanged("PostalCode");
                    this.OnPostalCodeChanged();
                }
            }
        }

        [Column(Storage="_state", Name="State", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string State
        {
            get
            {
                return this._state;
            }
            set
            {
                if (((_state == value) == false))
                {
                    this.OnStateChanging(value);
                    this.SendPropertyChanging();
                    this._state = value;
                    this.SendPropertyChanged("State");
                    this.OnStateChanged();
                }
            }
        }

        #region Children
        [Association(Storage="_appCustomerItems", OtherKey="AppCustomerLocationID", ThisKey="ID", Name="FK__AppCustom__AppCu__6FE99F9F")]
        [DebuggerNonUserCode()]
        public EntitySet<AppCustomerItem> AppCustomerItems
        {
            get
            {
                return this._appCustomerItems;
            }
            set
            {
                this._appCustomerItems = value;
            }
        }
        #endregion

        #region Parents
        [Association(Storage="_appCustomer", OtherKey="ID", ThisKey="AppCustomerID", Name="FK__AppCustom__AppCu__60A75C0F", IsForeignKey=true)]
        [DebuggerNonUserCode()]
        public AppCustomer AppCustomer
        {
            get
            {
                return this._appCustomer.Entity;
            }
            set
            {
                if (((this._appCustomer.Entity == value) == false))
                {
                    if ((this._appCustomer.Entity != null))
                    {
                        AppCustomer previousAppCustomer = this._appCustomer.Entity;
                        this._appCustomer.Entity = null;
                        previousAppCustomer.AppCustomerLocations.Remove(this);
                    }
                    this._appCustomer.Entity = value;
                    if ((value != null))
                    {
                        value.AppCustomerLocations.Add(this);
                        _appCustomerID = value.ID;
                    }
                    else
                    {
                        _appCustomerID = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #region Attachment handlers
        private void AppCustomerItems_Attach(AppCustomerItem entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerLocation = this;
        }

        private void AppCustomerItems_Detach(AppCustomerItem entity)
        {
            this.SendPropertyChanging();
            entity.AppCustomerLocation = null;
        }
        #endregion
    }

    [Table(Name="CustomerAppUser.AppUser")]
    public partial class AppUser : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");

        private bool _active;

        private int _appCustomerID;

        private string _firstName;

        private int _id;

        private string _lastName;

        private string _password;

        private string _userName;

        private EntityRef<AppCustomer> _appCustomer = new EntityRef<AppCustomer>();

        #region Extensibility Method Declarations
        partial void OnCreated();

        partial void OnActiveChanged();

        partial void OnActiveChanging(bool value);

        partial void OnAppCustomerIDChanged();

        partial void OnAppCustomerIDChanging(int value);

        partial void OnFirstNameChanged();

        partial void OnFirstNameChanging(string value);

        partial void OnIDChanged();

        partial void OnIDChanging(int value);

        partial void OnLastNameChanged();

        partial void OnLastNameChanging(string value);

        partial void OnPasswordChanged();

        partial void OnPasswordChanging(string value);

        partial void OnUserNameChanged();

        partial void OnUserNameChanging(string value);
        #endregion


        public AppUser()
        {
            this.OnCreated();
        }

        [Column(Storage="_active", Name="Active", DbType="bit", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public bool Active
        {
            get
            {
                return this._active;
            }
            set
            {
                if ((_active != value))
                {
                    this.OnActiveChanging(value);
                    this.SendPropertyChanging();
                    this._active = value;
                    this.SendPropertyChanged("Active");
                    this.OnActiveChanged();
                }
            }
        }

        [Column(Storage="_appCustomerID", Name="AppCustomerId", DbType="int", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int AppCustomerID
        {
            get
            {
                return this._appCustomerID;
            }
            set
            {
                if ((_appCustomerID != value))
                {
                    this.OnAppCustomerIDChanging(value);
                    this.SendPropertyChanging();
                    this._appCustomerID = value;
                    this.SendPropertyChanged("AppCustomerID");
                    this.OnAppCustomerIDChanged();
                }
            }
        }

        [Column(Storage="_firstName", Name="FirstName", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                if (((_firstName == value) == false))
                {
                    this.OnFirstNameChanging(value);
                    this.SendPropertyChanging();
                    this._firstName = value;
                    this.SendPropertyChanged("FirstName");
                    this.OnFirstNameChanged();
                }
            }
        }

        [Column(Storage="_id", Name="Id", DbType="int", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((_id != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage="_lastName", Name="LastName", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                if (((_lastName == value) == false))
                {
                    this.OnLastNameChanging(value);
                    this.SendPropertyChanging();
                    this._lastName = value;
                    this.SendPropertyChanged("LastName");
                    this.OnLastNameChanged();
                }
            }
        }

        [Column(Storage="_password", Name="Password", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if (((_password == value) == false))
                {
                    this.OnPasswordChanging(value);
                    this.SendPropertyChanging();
                    this._password = value;
                    this.SendPropertyChanged("Password");
                    this.OnPasswordChanged();
                }
            }
        }

        [Column(Storage="_userName", Name="UserName", DbType="nvarchar", AutoSync=AutoSync.Never, CanBeNull=false)]
        [DebuggerNonUserCode()]
        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                if (((_userName == value) == false))
                {
                    this.OnUserNameChanging(value);
                    this.SendPropertyChanging();
                    this._userName = value;
                    this.SendPropertyChanged("UserName");
                    this.OnUserNameChanged();
                }
            }
        }

        #region Parents
        [Association(Storage="_appCustomer", OtherKey="ID", ThisKey="AppCustomerID", Name="FK__AppUser__AppCust__4CA06362", IsForeignKey=true)]
        [DebuggerNonUserCode()]
        public AppCustomer AppCustomer
        {
            get
            {
                return this._appCustomer.Entity;
            }
            set
            {
                if (((this._appCustomer.Entity == value) == false))
                {
                    if ((this._appCustomer.Entity != null))
                    {
                        AppCustomer previousAppCustomer = this._appCustomer.Entity;
                        this._appCustomer.Entity = null;
                        previousAppCustomer.AppUsers.Remove(this);
                    }
                    this._appCustomer.Entity = value;
                    if ((value != null))
                    {
                        value.AppUsers.Add(this);
                        _appCustomerID = value.ID;
                    }
                    else
                    {
                        _appCustomerID = default(int);
                    }
                }
            }
        }
        #endregion

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
            if ((h != null))
            {
                h(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
            if ((h != null))
            {
                h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
