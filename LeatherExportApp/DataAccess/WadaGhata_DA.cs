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
    public static class WadaGhata_DA
    {
        public static string InsertWadaGhata(WadaGhata _WadaGhata)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_insertWadaGhata";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Lot_1";
            param.Value = _WadaGhata.Lot_1;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Lot_2";
            param.Value = _WadaGhata.Lot_2;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pcs";
            param.Value = _WadaGhata.Pcs;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Sqft";
            param.Value = _WadaGhata.Sqft;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pcs2";
            param.Value = _WadaGhata.Pcs2;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Sqft2";
            param.Value = _WadaGhata.Sqft2;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date";
            param.Value = _WadaGhata.Date;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _WadaGhata.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@IsDeleted";
            param.Value = _WadaGhata.IsDeleted;
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

        public static DataTable Filter_Get_WadaGhata(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch, string sSearch_1, string sSearch_2, string sSearch_3, string sSearch_4, string sSearch_5, string sSearch_6, string sSearch_7, string sSearch_8, string min, string max)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Filter_Get_WadaGhata";

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
            param.ParameterName = "@sSearch_7";
            param.Value = sSearch_7;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@sSearch_8";
            param.Value = sSearch_8;
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

        public static DataTable Get_WadaGhata_By_ID(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Get_WadaGhata_By_ID";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteSelectCommand(command);
        }

        public static int Delete_WadaGhata_By_ID(int Id)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_Delete_WadaGhata_By_ID";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            return Catalog_Access.ExecuteNonQuery(command);
        }

        public static string UpdateWadaGhata(WadaGhata _WadaGhata)
        {
            DbCommand command = Catalog_Access.CreateCommand();
            command.CommandText = "sp_UpdateWadaGhata";

            DbParameter param;

            param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = _WadaGhata.Id;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Date";
            param.Value = _WadaGhata.Date ;
            param.DbType = DbType.Date;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Lot_1";
            param.Value = _WadaGhata.Lot_1;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pcs";
            param.Value = _WadaGhata.Pcs;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);
            
            param = command.CreateParameter();
            param.ParameterName = "@Sqft";
            param.Value = _WadaGhata.Sqft;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Lot_2";
            param.Value = _WadaGhata.Lot_2;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Pcs2";
            param.Value = _WadaGhata.Pcs2;
            param.DbType = DbType.Int32;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Sqft2";
            param.Value = _WadaGhata.Sqft2;
            param.DbType = DbType.Decimal;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Description";
            param.Value = _WadaGhata.Description;
            param.DbType = DbType.String;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@Return";
            param.DbType = DbType.String;
            param.Size = 2;
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);


            Catalog_Access.ExecuteNonQuery(command);
            if (command.Parameters["@Return"].Value.ToString() == Constants.SP_ALREADY_EXIST)
            {
                return Constants.ALREADY_EXIST;
            }
            else
            {
                return Constants.SUCESS_UPDATE;
            }
        }
    }
}
