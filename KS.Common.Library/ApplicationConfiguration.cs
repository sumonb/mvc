using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//http://haacked.com/archive/2007/03/12/custom-configuration-sections-in-3-easy-steps.aspx/

namespace KS.Common.Library
{
    public static class ApplicationConfiguration
    {
        public static T? GetAppSettingsValue<T>(string key) where T : struct
        {
            var retVal = System.Configuration.ConfigurationManager.AppSettings[key];
            return (T)Convert.ChangeType(retVal, typeof(T)); 
        }

        public static string GetAppSettingsStringValue(string key) 
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }


        public static NameValueCollection GetCustomSection(string elementName)
        {
            //1. add as custom configuration sections(new) as follows(example).
              //<helloConfig>
              //  <add key="hello" value="world" />
              //  <add key="from" value="AUS" />
              //</helloConfig>

            //2. Now add a section entry inside the configSections as follows:
                //<section name="CustomConfiguration" requirePermission="false"
                //type="System.Configuration.NameValueSectionHandler,System,Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />

            //3. from the result. read like ie. ret["hello"]

            return System.Configuration.ConfigurationManager.GetSection(elementName) as NameValueCollection; 
        }


    }
}
