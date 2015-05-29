using System;
using System.Web.Script.Serialization;

namespace CustomerAppBackend.DataObject
{
    public static class Helper
    {
        public static string Serialize(object data)
        {
            var retval = (new JavaScriptSerializer()).Serialize(data).Replace("\"[", "[").Replace("\\\"", "\"").Replace("]\"", "]").Replace("\"{", "{").Replace("}\"", "}");
            return retval;
        }
    }
}

