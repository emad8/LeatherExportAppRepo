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
    public class ServiceStyle : System.Web.Services.WebService
    {

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Filter_Get_Style(string sEcho, int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
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

        //[WebMethod(EnableSession = true)]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        //public void Filter_Get_Style()
        //{
        //    int filteredCount = 0;

        //    int sEcho=int.Parse (HttpContext.Current.Request.Params["sEcho"]);
        //    int iDisplayLength = int.Parse(HttpContext.Current.Request.Params["iDisplayLength"]);
        //    int iDisplayStart = int.Parse(HttpContext.Current.Request.Params["iDisplayStart"]);
        //    int iSortCol_0 = int.Parse( HttpContext.Current.Request.Params["iSortCol_0"].ToString());
        //    string sSortDir_0=HttpContext.Current.Request.Params["sSortDir_0"].ToString();
        //    string sSearch = HttpContext.Current.Request.Params["sSearch"].ToString();

        //    List<Styles> StylesList = new List<Styles>();

        //    DataTable dt = Style_DA.Filter_Get_Style(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        int Id = int.Parse(row["Id"].ToString());
        //        string Name = row["Name"].ToString();
        //        string Description = row["Description"].ToString();
        //        bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());
        //        filteredCount = int.Parse(row["TotalCount"].ToString());
        //        StylesList.Add(new Styles
        //        {

        //            Name = Name,
        //            Description = Description,
        //            ForEdit = Id,
        //            ForDelete = Id
        //        });
        //    }
        //    var result = new
        //    {
        //        iTotalRecords = GetTotalStyleCount(),
        //        iTotalDisplayRecords = filteredCount,
        //        aaData = StylesList
        //    };

        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    Context.Response.Write(js.Serialize(result));
        //}


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

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getListOfStyles()
        {
            List<Styles> StylesList = new List<Styles>();

            DataTable dt = Style_DA.Get_All_Styles();

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
                    Description = Description,
                    ForEdit = Id,
                    ForDelete = Id
                });
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(StylesList));
        }

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
    }
}

