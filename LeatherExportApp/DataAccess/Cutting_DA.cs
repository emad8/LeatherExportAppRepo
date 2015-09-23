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
    public static class Cutting_DA
    {
        public static string InsertCutting(Cutting _Cutting)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_insertCutting";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Lot_1";
            param.Value = _Cutting.Lot_1;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);
            
            param = command.CreateParameter();
            param.ParameterName = "@Lot_2";
            param.Value = _Cutting.Lot_2;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pcs";
            param.Value = _Cutting.Pcs;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Sqft";
            param.Value = _Cutting.Sqft;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pcs2";
            param.Value = _Cutting.Pcs2;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Sqft2";
            param.Value = _Cutting.Sqft2;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date";
            param.Value = _Cutting.Date;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _Cutting.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Gp_No";
            param.Value = _Cutting.Gp_No;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Order";
            param.Value = _Cutting.Order;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Style";
            param.Value = _Cutting.Style;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);
            
            param = command.CreateParameter();
            param.ParameterName = "@Size";
            param.Value = _Cutting.Size;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pairs";
            param.Value = _Cutting.Pairs;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Employee";
            param.Value = _Cutting.Employee;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Company";
            param.Value = _Cutting.Company;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Market";
            param.Value = _Cutting.Market;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Is_Paid";
            param.Value = _Cutting.Is_Paid;
            param.DbType = DbType.Boolean;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Remarks";
            param.Value = _Cutting.Remarks;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Cutting.IsDeleted;
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

            if (Return == Constants.SP_ALREADY_EXIST)
            {
                return Constants.ALREADY_EXIST;
            }
            else
            {
                return Constants.SUCESS_INSERT;
            }



        }

        public static int Update_Delivery_By_LotId_For_Pcs_Sqft(int Pcs, float Sqft,string Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Update_Delivery_By_LotId_For_Pcs_Sqft";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = int.Parse(Id);
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pcs";
            param.Value = Pcs;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Sqft";
            param.Value = Sqft;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteNonQuery(command);

        }
        public static int Update_Outstock_For_Cutting(string CompanyId)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Update_Outstock_For_Cutting";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@CompanyId";
            param.Value = int.Parse(CompanyId);
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteNonQuery(command);

        }

        public static DataTable GetOrder_Info(Cutting _Cutting)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_GetOrder_Info";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Cutting.Order;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Cutting.Style;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Cutting.Size;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Order(Cutting _Cutting)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Order";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Cutting.Style;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Cutting.Size;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Style(Cutting _Cutting)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Style";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Cutting.Order;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Cutting.Size;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Size(Cutting _Cutting)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Size";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Cutting.Order;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Cutting.Style;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Pairs(Cutting _Cutting)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Pairs";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Cutting.Order;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Cutting.Style;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Cutting.Size;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        
        public static DataTable Get_Lot_Pcs_Sqft(string LotId)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Lot_Pcs_Sqft";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@LotId";
            param.Value =int.Parse(LotId);
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }

        public static DataTable Get_ddl_Lots_Sum_Of_Sqft_Pcs()
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_ddl_Lots_Sum_Of_Sqft_Pcs";

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static DataTable Get_Total_Cutted_Pcs_Sqft()
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Total_Cutted_Pcs_Sqft";

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static DataTable Get_Delivery_By_LotId(string LotId)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Delivery_By_LotId";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@LotId";
            param.Value = int.Parse(LotId);
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
    }
}
