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
    /// Summary description for ServiceDelivery
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceDelivery : System.Web.Services.WebService
    {

        [WebMethod]
        public void Filter_Get_Delivery(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Delivery> DeliveryList = new List<Delivery>();

            DataTable dt = Delivery_DA.Filter_Get_Delivery(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);
         
            foreach (DataRow row in dt.Rows)
            {
                filteredCount = int.Parse(row["TotalCount"].ToString());

                DateTime Date = Convert.ToDateTime(row["Date_Rec"].ToString());

                DeliveryList.Add(new Delivery
                {
                Id = int.Parse(row["Id"].ToString()),
                Pcs = int.Parse(row["Pcs_Rec"].ToString()),
                Sqft = float.Parse(row["Sqrft_Rec"].ToString()),
                Description = row["Description"].ToString(),
                DateString = Date.ToShortDateString(),      
                LotID = int.Parse(row["Lot_ID"].ToString()),
                ForEdit = int.Parse(row["Id"].ToString()),
                ForDelete = int.Parse(row["Id"].ToString()),
                Name = row["Name"].ToString()
                });
                
            }
            var result = new
            {
                iTotalRecords = GetTotalDeliveryCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = DeliveryList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalDeliveryCount()
        {
            int totalDeliveryCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Delivery where IsDeleted=0", con);
                con.Open();
                totalDeliveryCount = (int)cmd.ExecuteScalar();
            }
            return totalDeliveryCount;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Delivery Get_Delivery_By_Id(int Id)
        {
            Delivery _Delivery = new Delivery();

            DataTable dt = Delivery_DA.Get_Delivery_By_Id(Id);

            foreach (DataRow row in dt.Rows)
            {
                DateTime Date = Convert.ToDateTime(row["Date_Rec"].ToString());

                _Delivery.Id = Id;
                _Delivery.Pcs = int.Parse(row["Pcs_Rec"].ToString());
               _Delivery.Sqft= float.Parse(row["Sqrft_Rec"].ToString());
                _Delivery.Description = row["Description"].ToString();
                _Delivery.DateString = Date.ToShortDateString();      
                _Delivery.LotID = int.Parse(row["Lot_ID"].ToString());

            }
            return _Delivery;
        }

        [WebMethod]
        public bool DeleteDeliveryById(int Id)
        {
            if (Delivery_DA.Delete_Delivery_By_Id(Id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public void Update(int Id, int Pcs, float Sqft , string Description, string Date, int LotID)
        {
            Delivery _Delivery = new Delivery();
            _Delivery.Id = Id;
            _Delivery.Pcs = Pcs;
            _Delivery.Sqft = Sqft;
            _Delivery.Description = Description;
            //_Delivery.Date = Date;
            _Delivery.DateString = Date;
            _Delivery.LotID = LotID;

             Delivery_DA.UpdateDelivery(_Delivery);
        }
    }
}
