using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess.App_Code
{
    class Application_Configuration
    {
        private readonly static string _dbConnectionString;
        private readonly static string _dbProviderName;

        static Application_Configuration()
        {
            _dbConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _dbProviderName = ConfigurationManager.ConnectionStrings["DefaultConnection"].ProviderName;
        }

        public static string DBConnectionString
        {
            get { return _dbConnectionString; }
        }
        public static string DBProviderName
        {
            get { return _dbProviderName; }
        }
        public static bool EnableErrorLog
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["EnableErrorLog"]);
            }
        }
        public static string ErrorLogEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorLogEmail"];
            }
        }
        public static string SiteName
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteName"];
            }
        }

        public static string MailServer
        {
            get
            {
                return ConfigurationManager.AppSettings["MailServer"];
            }
        }

        public static string DescriptionLength
        {
            get
            {
                return ConfigurationManager.AppSettings["DescriptionLength"];
            }
        }

        public static string ProductsPerPage
        {
            get
            {
                return ConfigurationManager.AppSettings["ProductsPerPage"];
            }
        }
    }
}
