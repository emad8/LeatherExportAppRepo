using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using DataAccess;

namespace LeatherApp
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class myfunction : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //[WebMethod]
        //[ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        ////public string getListOfCars(List<string> aData)
        //public List<Styles> getListOfStyles()
        //{
        //    SqlDataReader dr;
        //    List<Styles> StylesList = new List<Styles>();

        //    int count = 0;

        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = "sp_Get_All_Styles";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Connection = con;
        //            //cmd.Parameters.AddWithValue("@Id", 1);
        //            con.Open();
        //            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //            if (dr.HasRows)
        //            {
        //                while (dr.Read())
        //                {
        //                    int Id = int.Parse( dr["Id"].ToString());
        //                    string Name = dr["Name"].ToString();
        //                    string Description = dr["Description"].ToString();
        //                    bool IsDeleted = Convert.ToBoolean(dr["IsDeleted"].ToString());


        //                    count++;

        //                    StylesList.Add(new Styles
        //                    {
        //                        Id=Id,
        //                        Name = Name,
        //                        Descripton = Description,
        //                        IsDeleted = IsDeleted,
        //                    });

        //                }
        //            }
        //        }
        //    }
        //    //JavaScriptSerializer serial = new JavaScriptSerializer();
        //    //return serial.Serialize(StylesList);

        //    return StylesList;
        //}
        //*

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public string getListOfCars(List<string> aData)
        public List<Styles> getListOfStyles()
        {
            List<Styles> StylesList = new List<Styles>();

            DataTable dt= Style_DA.Get_All_Styles();
            
            foreach (DataRow row in dt.Rows)
            {
                int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

                StylesList.Add(new Styles
                {
                    Id = Id,
                    Name = Name,
                    Descripton = Description,
                    IsDeleted = IsDeleted,
                });
            }
            return StylesList;
        }
    }
}