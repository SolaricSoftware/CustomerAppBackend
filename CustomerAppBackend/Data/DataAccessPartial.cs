using System;

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

