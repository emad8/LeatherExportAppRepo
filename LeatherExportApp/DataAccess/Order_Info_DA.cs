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
    public static class Order_Info_DA
    {
        public static string InsertOrder_Info(Order_Info _Order_Info)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_insertOrder_Info";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Order";
            param.Value = _Order_Info.Order;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Size";
            param.Value = _Order_Info.Size;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Style";
            param.Value = _Order_Info.Style;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@No_Order";
            param.Value = _Order_Info.No_Order;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            
            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _Order_Info.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            
            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Order_Info.IsDeleted;
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
    }
}
