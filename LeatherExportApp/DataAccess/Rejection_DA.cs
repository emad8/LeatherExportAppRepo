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
    public static class Rejection_DA
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
        
        
        

        
        
        
        /// Working right now
        /// 
        /// </summary>
        /// <param name="_Packing"></param>
        /// <returns></returns>
        public static DataTable Get_Pairs_SUM_From_Stitching(Rejection _Rejection)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Pairs_SUM_From_Stitching_For_Rejection";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Rejection.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Rejection.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Rejection.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }

        public static string InsertRejection(Rejection _Rejection)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_InsertRejection";

            DbParameter param;

            //param = command.CreateParameter();
            //param.ParameterName = "@Cutter_ID";
            //param.Value = _Rejection.Cutter_ID;
            //param.DbType = DbType.Int32;
            //command.Parameters.Add(param);
            
            //param = command.CreateParameter();
            //param.ParameterName = "@Stitcher_ID";
            //param.Value = _Rejection.Stitcher_ID;
            //param.DbType = DbType.Int32;
            //command.Parameters.Add(param);


            param = command.CreateParameter();
            param.ParameterName = "@Order_ID";
            param.Value = _Rejection.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Style_ID";
            param.Value = _Rejection.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Size_ID";
            param.Value = _Rejection.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pairs";
            param.Value = _Rejection.Pairs;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);
            
            param = command.CreateParameter();
            param.ParameterName = "@Right";
            param.Value = _Rejection.Right;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Left";
            param.Value = _Rejection.Left;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);


            param = command.CreateParameter();
            param.ParameterName = "@Date";
            param.Value = _Rejection.Date;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _Rejection.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Rejection.IsDeleted;
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
        
        public static DataTable Get_Order_From_Stitching_For_Rejection(Packing _Packing)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Order_From_Stitching_For_Rejection";

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
        public static DataTable Get_Style_From_Stitching_For_Rejection(Packing _Packing)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Style_From_Stitching_For_Rejection";

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
        public static DataTable Get_Size_From_Stitching_For_Rejection(Packing _Packing)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Size_From_Stitching_For_Rejection";

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



        //public static DataTable Get_Cutters_From_Cutting(Rejection _Rejection)
        //{
        //    DbCommand command = Catalog_Access.CreateCommand();
        //    command.CommandText = "sp_Get_Cutters_From_Cutting";

        //    DbParameter param;

        //    param = command.CreateParameter();
        //    param.ParameterName = "@Order_ID";
        //    param.Value = _Rejection.Order_ID;
        //    param.DbType = DbType.Int32;
        //    command.Parameters.Add(param);

        //    param = command.CreateParameter();
        //    param.ParameterName = "@Style_ID";
        //    param.Value = _Rejection.Style_ID;
        //    param.DbType = DbType.Int32;
        //    command.Parameters.Add(param);

        //    param = command.CreateParameter();
        //    param.ParameterName = "@Size_ID";
        //    param.Value = _Rejection.Size_ID;
        //    param.DbType = DbType.Int32;
        //    command.Parameters.Add(param);

        //    return Catalog_Access.ExecuteSelectCommand(command);

        //}

        //public static DataTable Get_Stitchers_From_Stitching(Rejection _Rejection)
        //{
        //    DbCommand command = Catalog_Access.CreateCommand();
        //    command.CommandText = "sp_Get_Stitchers_From_Stitching";

        //    DbParameter param;

        //    param = command.CreateParameter();
        //    param.ParameterName = "@Order_ID";
        //    param.Value = _Rejection.Order_ID;
        //    param.DbType = DbType.Int32;
        //    command.Parameters.Add(param);

        //    param = command.CreateParameter();
        //    param.ParameterName = "@Style_ID";
        //    param.Value = _Rejection.Style_ID;
        //    param.DbType = DbType.Int32;
        //    command.Parameters.Add(param);

        //    param = command.CreateParameter();
        //    param.ParameterName = "@Size_ID";
        //    param.Value = _Rejection.Size_ID;
        //    param.DbType = DbType.Int32;
        //    command.Parameters.Add(param);

        //    return Catalog_Access.ExecuteSelectCommand(command);

        //}
    }
}
