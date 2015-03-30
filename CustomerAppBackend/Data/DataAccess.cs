// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from CustomerApp on 2015-03-30 12:08:31Z.
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

		public Table<AppCustomer> AppCustomer
		{
			get
			{
				return this.GetTable <AppCustomer>();
			}
		}

		public Table<AppUser> AppUser
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

		private EntitySet<AppUser> _appUser;

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
			_appUser = new EntitySet<AppUser>(new Action<AppUser>(this.AppUser_Attach), new Action<AppUser>(this.AppUser_Detach));
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
		[Association(Storage="_appUser", OtherKey="AppCustomerID", ThisKey="ID", Name="FK__AppUser__AppCust__4CA06362")]
		[DebuggerNonUserCode()]
		public EntitySet<AppUser> AppUser
		{
			get
			{
				return this._appUser;
			}
			set
			{
				this._appUser = value;
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
		private void AppUser_Attach(AppUser entity)
		{
			this.SendPropertyChanging();
			entity.AppCustomer = this;
		}

		private void AppUser_Detach(AppUser entity)
		{
			this.SendPropertyChanging();
			entity.AppCustomer = null;
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
						previousAppCustomer.AppUser.Remove(this);
					}
					this._appCustomer.Entity = value;
					if ((value != null))
					{
						value.AppUser.Add(this);
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
