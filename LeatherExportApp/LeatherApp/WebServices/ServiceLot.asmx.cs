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
    public class ServiceLot : System.Web.Services.WebService
    {

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Filter_Get_Lot(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Lot> LotsList = new List<Lot>();

            DataTable dt = Lot_DA.Filter_Get_Lot(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {
                int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());
                filteredCount = int.Parse(row["TotalCount"].ToString());
                LotsList.Add(new Lot
                {

                    Name = Name,
                    Description = Description,
                    ForEdit = Id,
                    ForDelete = Id
                });
            }
            var result = new
            {
                iTotalRecords = GetTotalLotCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = LotsList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalLotCount()
        {
            int totalLotCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Lot where IsDeleted=0", con);
                con.Open();
                totalLotCount = (int)cmd.ExecuteScalar();
            }
            return totalLotCount;
        }

        //[WebMethod]
        ////[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void getListOfLots()
        //{
        //    List<Lots> LotsList = new List<Lots>();

        //    DataTable dt = Lot_DA.Get_All_Lots();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        int Id = int.Parse(row["Id"].ToString());
        //        string Name = row["Name"].ToString();
        //        string Description = row["Description"].ToString();
        //        bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

        //        LotsList.Add(new Lots
        //        {
        //            Id = Id,
        //            Name = Name,
        //            Descripton = Description,
        //            ForEdit = Id,
        //            ForDelete = Id
        //        });
        //    }
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    Context.Response.Write(js.Serialize(LotsList));
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Lot Get_Lot_By_Id(int Id)
        {
            Lot _Lot = new Lot();

            DataTable dt = Lot_DA.Get_Lot_By_Id(Id);

            foreach (DataRow row in dt.Rows)
            {
                //int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

                _Lot.Id = Id;
                _Lot.Name = Name;
                _Lot.Description = Description;
                _Lot.IsDeleted = IsDeleted;

            }
            return _Lot;
        }

        [WebMethod]
        public bool DeleteLotById(int Id)
        {
            if (Lot_DA.Delete_Lot_By_Id(Id) > 0)
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
            Lot _Lot = new Lot();
            _Lot.Id = Id;
            _Lot.Name = Name;
            _Lot.Description = Description;

            return Lot_DA.UpdateLot(_Lot);
        }
    }
}

