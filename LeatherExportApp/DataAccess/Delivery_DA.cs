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
    public static class Delivery_DA
    {
        public static string InsertDelivery(Delivery _Delivery)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_insertDelivery";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@LotID";
            param.Value = _Delivery.LotID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pcs";
            param.Value = _Delivery.Pcs;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Sqft";
            param.Value = _Delivery.Sqft;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date";
            param.Value = _Delivery.Date;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _Delivery.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Delivery.IsDeleted;
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
                return "Error Entering Data";
            }
        }

        public static void UpdateDelivery(Delivery _Delivery)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_UpdateDelivery";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = _Delivery.Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@LotID";
            param.Value = _Delivery.LotID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pcs";
            param.Value = _Delivery.Pcs;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Sqft";
            param.Value = _Delivery.Sqft;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date";
            param.Value = _Delivery.DateString;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _Delivery.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            

            Catalog_Access.ExecuteNonQuery(command);

            
        }

        public static DataTable Get_Delivery_By_Id(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Delivery_By_Id";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static DataTable Filter_Get_Delivery(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Filter_Get_Delivery";

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


        public static int Delete_Delivery_By_Id(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Delete_Delivery_By_Id";

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
