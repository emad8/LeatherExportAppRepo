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
    public static class Order_DA
    {
        public static string InsertOrder(Order _Order)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_insertOrder";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Vendor_ID";
            param.Value = _Order.Vendor_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Order_No";
            param.Value = _Order.Order_No;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            
            param = command.CreateParameter();
            param.ParameterName = "@Date_Of_shipping";
            param.Value = _Order.Date_Of_shipping;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _Order.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            
            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Order.IsDeleted;
            param.DbType = DbType.Boolean;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Return";
            param.DbType = DbType.String;
            param.Size = 2;
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);

            Catalog_Access.ExecuteNonQuery(command);

            string Return = command.Parameters["@Return"].Value.ToString();

            if (Return == Constants.SP_SUCESS_INSERT)
            {
                return Constants.SUCESS_INSERT;
            }
            else
            {
                return Constants.ALREADY_EXIST;
            }
        }

        public static string UpdateOrder(Order _Order)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_UpdateOrder";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = _Order.Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Vendor_ID";
            param.Value = _Order.Vendor_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Order_No";
            param.Value = _Order.Order_No;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date_Of_shipping";
            param.Value = _Order.Date_Of_shipping;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _Order.Description;
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

        public static DataTable Get_Order_By_Id(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Order_By_Id";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static DataTable Filter_Get_Order(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Filter_Get_Order";

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


        public static int Delete_Order_By_Id(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Delete_Order_By_Id";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteNonQuery(command);
        }
    }
}
