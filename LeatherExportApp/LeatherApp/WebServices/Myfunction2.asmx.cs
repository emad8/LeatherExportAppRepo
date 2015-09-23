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
using System.Data.SqlClient;

namespace LeatherExportApp.WebServices
{
    /// <summary>
    /// Summary description for Myfunction2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Myfunction2 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Filter_Get_Style(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Styles> StylesList = new List<Styles>();

            DataTable dt = Style_DA.Filter_Get_Style(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {
                int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());
                filteredCount = int.Parse(row["TotalCount"].ToString());
                StylesList.Add(new Styles
                {
                    Id = Id,
                    Name = Name,
                    Description = Description,
                    ForEdit = Id,
                    ForDelete = Id
                });
            }
            var result = new
            {
                iTotalRecords = GetTotalStyleCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = StylesList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalStyleCount()
        {
            int totalStyleCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Style where IsDeleted=0", con);
                con.Open();
                totalStyleCount = (int)cmd.ExecuteScalar();
            }
            return totalStyleCount;
        }

        //[WebMethod]
        ////[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void getListOfStyles()
        //{
        //    List<Styles> StylesList = new List<Styles>();

        //    DataTable dt = Style_DA.Get_All_Styles();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        int Id = int.Parse(row["Id"].ToString());
        //        string Name = row["Name"].ToString();
        //        string Description = row["Description"].ToString();
        //        bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

        //        StylesList.Add(new Styles
        //        {
        //            Id = Id,
        //            Name = Name,
        //            Description = Description,
        //            ForEdit = Id,
        //            ForDelete = Id
        //        });
        //    }
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    Context.Response.Write(js.Serialize(StylesList));
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Styles Get_Style_By_Id(int Id)
        {
            Styles _Style = new Styles();

            DataTable dt = Style_DA.Get_Style_By_Id(Id);

            foreach (DataRow row in dt.Rows)
            {
                //int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

                _Style.Id = Id;
                _Style.Name = Name;
                _Style.Description = Description;
                _Style.IsDeleted = IsDeleted;

            }
            return _Style;
        }

        [WebMethod]
        public bool DeleteStyleById(int Id)
        {
            if (Style_DA.Delete_Style_By_Id(Id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public string Update(int Id, string Name, string Description)
        {
            Styles _Style = new Styles();
            _Style.Id = Id;
            _Style.Name = Name;
            _Style.Description = Description;

            return Style_DA.UpdateStyle(_Style);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Lot> GetDDl(int Id)
        {
            List<Lot> _Lots = new List<Lot>();
            DataTable dt =Cutting_DA.Get_ddl_Lots_Sum_Of_Sqft_Pcs();

            foreach (DataRow row in dt.Rows)
            {
                if (int.Parse(row["Id"].ToString()) != Id)
                {
                    _Lots.Add(new Lot
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Name = row["Name"].ToString(),
                    });
                }

            }
            return _Lots;
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(_Lots));
        }
    }
}

