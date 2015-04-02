using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using CustomerAppBackend.DataObject;

namespace CustomerAppBackend.Data
{
	public partial class DataAccess
	{
		public DataAccess ()
			: this ("Server=calantha.arvixe.com;Database=CustomerApp;User Id=CustomerAppUser;Password=password1;")
		{
		}
	}
}

