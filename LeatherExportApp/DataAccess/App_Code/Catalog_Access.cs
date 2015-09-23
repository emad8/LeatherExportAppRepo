using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace DataAccess.App_Code
{
    public class Catalog_Access
    {
        public static DbCommand CreateCommand()
        {
            string dbConnectionString = Application_Configuration.DBConnectionString;
            string dbProviderName = Application_Configuration.DBProviderName;

            DbProviderFactory factory = DbProviderFactories.GetFactory(dbProviderName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = dbConnectionString;

            DbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public static DataTable ExecuteSelectCommand(DbCommand command)
        {
            DataTable table;

            command.Connection.Open();
            DbDataReader reader = command.ExecuteReader();
            table = new DataTable();
            table.Load(reader);
            reader.Close();
            command.Connection.Close();

            return table;
        }

        // insert update delete command
        // return no of affected rows
        public static int ExecuteNonQuery(DbCommand command)
        {
            int affectedRows = -1;

            command.Connection.Open();
            affectedRows = command.ExecuteNonQuery();


            return affectedRows;

        }

        // execute a select command, return single result as a string
        public static string ExecuteScalar(DbCommand command)
        {
            string result = "";
            command.Connection.Open();
            result = command.ExecuteScalar().ToString();
            return result;
        }
    }
}
