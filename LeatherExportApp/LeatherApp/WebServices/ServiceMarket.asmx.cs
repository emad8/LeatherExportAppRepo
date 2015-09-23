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
    /// Summary description for ServiceMarket
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceMarket : System.Web.Services.WebService
    {

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Filter_Get_Market(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Market> MarketsList = new List<Market>();

            DataTable dt = Market_DA.Filter_Get_Market(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {
                int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());
                filteredCount = int.Parse(row["TotalCount"].ToString());
                MarketsList.Add(new Market
                {

                    Name = Name,
                    Description = Description,
                    ForEdit = Id,
                    ForDelete = Id
                });
            }
            var result = new
            {
                iTotalRecords = GetTotalMarketCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = MarketsList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalMarketCount()
        {
            int totalMarketCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Market where IsDeleted=0", con);
                con.Open();
                totalMarketCount = (int)cmd.ExecuteScalar();
            }
            return totalMarketCount;
        }

        //[WebMethod]
        ////[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void getListOfMarkets()
        //{
        //    List<Markets> MarketsList = new List<Markets>();

        //    DataTable dt = Market_DA.Get_All_Markets();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        int Id = int.Parse(row["Id"].ToString());
        //        string Name = row["Name"].ToString();
        //        string Description = row["Description"].ToString();
        //        bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

        //        MarketsList.Add(new Markets
        //        {
        //            Id = Id,
        //            Name = Name,
        //            Descripton = Description,
        //            ForEdit = Id,
        //            ForDelete = Id
        //        });
        //    }
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    Context.Response.Write(js.Serialize(MarketsList));
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Market Get_Market_By_Id(int Id)
        {
            Market _Market = new Market();

            DataTable dt = Market_DA.Get_Market_By_Id(Id);

            foreach (DataRow row in dt.Rows)
            {
                //int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

                _Market.Id = Id;
                _Market.Name = Name;
                _Market.Description = Description;
                _Market.IsDeleted = IsDeleted;

            }
            return _Market;
        }

        [WebMethod]
        public bool DeleteMarketById(int Id)
        {
            if (Market_DA.Delete_Market_By_Id(Id) > 0)
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
            Market _Market = new Market();
            _Market.Id = Id;
            _Market.Name = Name;
            _Market.Description = Description;

            return Market_DA.UpdateMarket(_Market);
        }
    }
}
