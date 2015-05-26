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

        public bool CanAccess(string accessKey, out string error)
        {
//            Guid ak;
//            if (Guid.TryParse(accessKey, out ak))
//            {
//                error = String.Empty;
//                return this.CanAccess(ak);
//            }
//            else
//            {
//                error = "Access Key is missing or invalid.";
//                return false;
//            }
            error = String.Empty;
            return true;
        }
            
        public bool CanAccess(Guid accessKey)
        {
            return this.AppCustomers.Any(x => x.AccessKey == accessKey && x.Active == true);
        }
	}
}

