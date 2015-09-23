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
    public static class Stitching_DA
    {
        /// <summary>
        /// these are for Cutting Issuance
        /// </summary>
        /// <param name="_Stitching"></param>
        /// <returns></returns>
        public static string InsertCuttingIssuance(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_InsertCuttingIssuance";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Employee_ID";
            param.Value = _Stitching.Employee_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Order_ID";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Style_ID";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Size_ID";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pairs_Issued";
            param.Value = _Stitching.Pairs_Issued;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date_Issued";
            param.Value = _Stitching.Date_Issued;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Stitching.IsDeleted;
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

        public static int Update_Cutting_By_ID_For_CuttingIssuance_Pairs(int Pairs, string Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Update_Cutting_By_ID_For_CuttingIssuance_Pairs";

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

        public static DataTable Get_Order_From_Cutting(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Order_From_Cutting";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Style_From_Cutting(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Style_From_Cutting";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        
        public static DataTable Get_Size_From_Cutting(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Size_From_Cutting";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Pairs_SUM_From_Cutting(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Pairs_SUM_From_Cutting_";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }

        public static DataTable Get_Pairs_ANd_ID_From_Cutting(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Pairs_ANd_ID_From_Cutting_";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }

        public static DataTable Filter_Get_CuttingIssuance(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch, string sSearch_1, string sSearch_2, string sSearch_3, string sSearch_4, string sSearch_5, string sSearch_6, string min, string max)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Filter_Get_CuttingIssuance";

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

            param = command.CreateParameter();
            param.ParameterName = "@sSearch_1";
            param.Value = sSearch_1;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@sSearch_2";
            param.Value = sSearch_2;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@sSearch_3";
            param.Value = sSearch_3;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@sSearch_4";
            param.Value = sSearch_4;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@sSearch_5";
            param.Value = sSearch_5;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@sSearch_6";
            param.Value = sSearch_6;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@min";
            param.Value = (min == "") ? null : min;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@max";
            param.Value = (max == "") ? null : max;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static DataTable Get_CuttingIssuance_By_ID(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_CuttingIssuance_By_ID";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }
        
        public static int Delete_CuttingIssuance_By_ID(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Delete_CuttingIssuance_By_ID";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteNonQuery(command);
        }

        public static string UpdateCuttingIssuance(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_UpdateCuttingIssuance";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = _Stitching.Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Employee_ID";
            param.Value = _Stitching.Employee_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Order_ID";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Style_ID";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Size_ID";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pairs_Issued";
            param.Value = _Stitching.Pairs_Issued;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date_Issued";
            param.Value = _Stitching.Date_Issued;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Stitching.IsDeleted;
            param.DbType = DbType.Boolean;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Return";
            param.DbType = DbType.String;
            param.Size = 2;
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);


            Catalog_Access.ExecuteNonQuery(command);
            if (command.Parameters["@Return"].Value.ToString()==Constants.SP_ALREADY_EXIST)
            {
                return Constants.ALREADY_EXIST;
            }
            else
            {
                return Constants.SUCESS_UPDATE;
            }
        }
        /// <summary>
        /// these are Stitching
        /// </summary>
        /// <param name="_Stitching"></param>
        /// <returns></returns>
        public static DataTable Get_Order_From_Stitching(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Order_From_Stitching";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Employee_ID";
            param.Value = _Stitching.Employee_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Style_From_Stitching(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Style_From_Stitching";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Employee_ID";
            param.Value = _Stitching.Employee_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Size_From_Stitching(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Size_From_Stitching";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Employee_ID";
            param.Value = _Stitching.Employee_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }
        public static DataTable Get_Stitcher_From_Stitching(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Employee_From_Stitching";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }

        public static DataTable Get_Pairs_From_Stitching(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Pairs_From_Stitching";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Employee_ID";
            param.Value = _Stitching.Employee_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date_Issued";
            param.Value = _Stitching.Date_Issued;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);

        }

        public static DataTable Get_DateIssued_From_Stitching(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_DateIssued_From_Stitching";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@OrderId";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@StyleId";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@SizeId";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Employee_ID";
            param.Value = _Stitching.Employee_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static string InsertStitching(Stitching _Stitching)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_InsertStitching";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Employee_ID";
            param.Value = _Stitching.Employee_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Contractor_ID";
            param.Value = _Stitching.Contractor_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Order_ID";
            param.Value = _Stitching.Order_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Style_ID";
            param.Value = _Stitching.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Size_ID";
            param.Value = _Stitching.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pairs_Rec";
            param.Value = _Stitching.Pairs_Rec;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date_Rec";
            param.Value = _Stitching.Date_Rec;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date_Issued";
            param.Value = _Stitching.Date_Issued;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _Stitching.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Stitching.IsDeleted;
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
