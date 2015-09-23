using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.App_Code
{
    public static class Constants
    {
        public const string SUCESS_DELETE = "Deleted Sucessfully";
        public const string SUCESS_UPDATE = "Updated Sucessfully";
        public const string SUCESS_INSERT = "Inserted Sucessfully";
        public const string DATA_NOT_FOUND = "Data Not Found";
        public const string ALREADY_EXIST = "Already Exists";
        public const string ERROR = "Error in Retrieving Data";
        public const string SELECT_HERE = "Select here";


        #region SP RETURN NUMBERS
        public const string SP_SUCESS_INSERT = "0";
        public const string SP_ALREADY_EXIST = "1";
        public const string SP_SUCESS_DELETE = "2";
        public const string SP_DATA_NOT_FOUND = "3";
        public const string SP_SUCESS_UPDATE = "4";
        #endregion
    }
}
