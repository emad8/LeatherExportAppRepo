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
    public static class Rate_DA
    {
        public static string InsertRate(Rate _Rate)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_insertRate";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Style_ID";
            param.Value = _Rate.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Size_ID";
            param.Value = _Rate.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Standard_Value";
            param.Value = _Rate.Standard_Value;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Cutting_Rate";
            param.Value = _Rate.Cutting_Rate;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Elastic_Stitching";
            param.Value = _Rate.Elastic_Stitching;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@OverLock";
            param.Value = _Rate.OverLock;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Contractor_Commission";
            param.Value = _Rate.Contractor_Commission;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@BindingRate";
            param.Value = _Rate.BindingRate;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@GloveStitchingRate";
            param.Value = _Rate.GloveStitchingRate;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _Rate.IsDeleted;
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

        public static string UpdateRate(Rate _Rate)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_UpdateRate";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = _Rate.Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Style_ID";
            param.Value = _Rate.Style_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Size_ID";
            param.Value = _Rate.Size_ID;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Standard_Value";
            param.Value = _Rate.Standard_Value;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Cutting_Rate";
            param.Value = _Rate.Cutting_Rate;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Elastic_Stitching";
            param.Value = _Rate.Elastic_Stitching;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@OverLock";
            param.Value = _Rate.OverLock;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Contractor_Commission";
            param.Value = _Rate.Contractor_Commission;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@BindingRate";
            param.Value = _Rate.BindingRate;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@GloveStitchingRate";
            param.Value = _Rate.GloveStitchingRate;
            param.DbType = DbType.Decimal;
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

        public static DataTable Get_Rate_By_Id(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_Rate_By_Id";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static DataTable Filter_Get_Rate(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Filter_Get_Rate";

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

        public static int Delete_Rate_By_Id(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Delete_Rate_By_Id";

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
