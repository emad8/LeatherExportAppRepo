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
    public static class Packing_DA
    {
        public static int Update_Stitching_By_ID_For_Packing_Pairs(int Pairs, string Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Update_Stitching_By_ID_For_Packing_Pairs";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pairs";
            param.Value = Pairs;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteNonQuery(command);

        }

        public static DataTable Get_Pairs_ANd_ID_From_Stitching(Packing _Packing)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Pairs_ANd_ID_From_Stitching";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Packing.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Packing.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Packing.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        
        public static DataTable Get_Order_From_Stitching_For_Packing(Packing _Packing)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Order_From_Stitching_For_Packing";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Packing.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Packing.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Style_From_Stitching_For_Packing(Packing _Packing)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Style_From_Stitching_For_Packing";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Packing.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Packing.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Size_From_Stitching_For_Packing(Packing _Packing)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Size_From_Stitching_For_Packing";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Packing.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Packing.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }

        public static DataTable Get_Pairs_SUM_From_Stitching(Packing _Packing)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Pairs_SUM_From_Stitching";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Packing.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Packing.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Packing.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }

        public static string InsertPacking(Packing _Packing)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_InsertPacking";

            DbParameter param;

            //param = command.CreateParameter();
            //param.ParameterName = "@Employee_ID";
            //param.Value = _Packing.Employee_ID;
            //param.DbType = DbType.Int32;
            //command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Order_ID";
            param.Value = _Packing.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Style_ID";
            param.Value = _Packing.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Size_ID";
            param.Value = _Packing.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pairs_Packed";
            param.Value = _Packing.Pairs_Packed;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date";
            param.Value = _Packing.Date;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _Packing.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Packing.IsDeleted;
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
    }
}
