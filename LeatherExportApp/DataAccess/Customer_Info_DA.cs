using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Model;
using DataAccess.App_Code;

namespace DataAccess
{
   public class Customer_Info_DA
    {
        public static string Insert(Customer_Info _Customer)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_insertCustomer_Info";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Code";
            param.Value = _Customer.Code;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = _Customer.Name;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = _Customer.Address;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Zip_Postal";
            param.Value = _Customer.Zip_Postal;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@State_Province";
            param.Value = _Customer.State_Province;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Phone";
            param.Value = _Customer.Phone;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@City";
            param.Value = _Customer.City;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Country";
            param.Value = _Customer.Country;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Fax";
            param.Value = _Customer.Fax;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@CreatedBy";
            param.Value = _Customer.CreatedBy;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Return";
            param.DbType = DbType.String;
            param.Size = 2;
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);

            Catalog_Access.ExecuteNonQuery(command);

            string Return = command.Parameters["@Return"].Value.ToString();

            return Return;
        }

        public static DataTable Filter_Get_Customer_Info(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Filter_Get_Customer_Info";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@DisplayLength";
            param.Value = iDisplayLength;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@DisplayStart";
            param.Value = iDisplayStart;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SortCol";
            param.Value = iSortCol_0;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SortDir";
            param.Value = sSortDir_0;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Search";
            param.Value = sSearch;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static string Update(Customer_Info _Customer)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_UpdateCustomer_Info";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = _Customer.ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Code";
            param.Value = _Customer.Code;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = _Customer.Name;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = _Customer.Address;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Zip_Postal";
            param.Value = _Customer.Zip_Postal;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@State_Province";
            param.Value = _Customer.State_Province;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Phone";
            param.Value = _Customer.Phone;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@City";
            param.Value = _Customer.City;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Country";
            param.Value = _Customer.Country;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Fax";
            param.Value = _Customer.Fax;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@UpdatedBy";
            param.Value = _Customer.UpdatedBy;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Return";
            param.DbType = DbType.String;
            param.Size = 2;
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);
            Catalog_Access.ExecuteNonQuery(command);

            string Return = command.Parameters["@Return"].Value.ToString();

            return Return;
        }

        public static DataTable Get_Customer_Info_By_Id(int ID)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Customer_Info_By_Id";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static int Delete_Customer_Info_By_Id(int ID)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Delete_Customer_Info_By_Id";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteNonQuery(command);
        }


    }
}
