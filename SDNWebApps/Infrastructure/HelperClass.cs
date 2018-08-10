using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SDNWebApps.Infrastructure
{
    public class HelperClass
    {

        public HelperClass() {
        }

        public string CopyClass<T>(T source, T destion)
        {

            Type destionclass = destion.GetType();
            foreach (PropertyInfo property in source.GetType().GetProperties())
            {   
                PropertyInfo other = destionclass.GetProperty(property.Name);

                if (other != null)
                {
                    var test = property.GetValue(property.Name);
                    other.SetValue(destionclass, property.GetValue(source, null), null);
                }
            }

            return "";

        }


    }
}