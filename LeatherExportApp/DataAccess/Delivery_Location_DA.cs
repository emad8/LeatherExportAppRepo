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
   public class Delivery_Location_DA
    {
        public static string Insert(Delivery_Location _Delivery_Location)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_insertDelivery_Location";

            DbParameter param;


            param = command.CreateParameter();
            param.ParameterName = "@Customer_ID";
            param.Value = _Delivery_Location.Customer_ID;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = _Delivery_Location.Address;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@ZP";
            param.Value = _Delivery_Location.ZP;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SP";
            param.Value = _Delivery_Location.SP;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@City";
            param.Value = _Delivery_Location.City;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Country";
            param.Value = _Delivery_Location.Country;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@CreatedBy";
            param.Value = _Delivery_Location.CreatedBy;
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

        public static DataTable Filter_Get_Delivery_Location(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Filter_Get_Delivery_Location";

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

        public static string Update(Delivery_Location _Delivery_Location)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_UpdateDelivery_Location";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = _Delivery_Location.ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);


            param = command.CreateParameter();
            param.ParameterName = "@Customer_ID";
            param.Value = _Delivery_Location.Customer_ID;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = _Delivery_Location.Address;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@ZP";
            param.Value = _Delivery_Location.ZP;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SP";
            param.Value = _Delivery_Location.SP;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@City";
            param.Value = _Delivery_Location.City;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Country";
            param.Value = _Delivery_Location.Country;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@UpdatedBy";
            param.Value = _Delivery_Location.UpdatedBy;
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

        public static DataTable Get_Delivery_Location_By_Id(int ID)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Delivery_Location_By_Id";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static int Delete_Delivery_Location_By_Id(int ID)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Delete_Delivery_Location_By_Id";

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
