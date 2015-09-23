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

namespace LeatherApp.WebServices
{
    /// <summary>
    /// Summary description for ServiceDelivery_Location
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceDelivery_Location : System.Web.Services.WebService
    {

        [WebMethod]
        public void Filter_Get_Delivery_Location(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Delivery_Location> Delivery_Location_List = new List<Delivery_Location>();

            DataTable dt = Delivery_Location_DA.Filter_Get_Delivery_Location(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {

                filteredCount = int.Parse(row["TotalCount"].ToString());

                Delivery_Location_List.Add(new Delivery_Location
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Customer_ID = int.Parse(row["Customer_ID"].ToString()),
                    Customer_Code = row["Code"].ToString(),
                    Customer_Name = row["Customer_Name"].ToString(),
                    Address = row["Address"].ToString(),
                    ZP = row["Zip/Postal"].ToString(),
                    SP = row["State/Province"].ToString(),
                    City = row["City"].ToString(),
                    Country = row["Country"].ToString(),
                    
                    ForEdit = row["ID"].ToString(),
                    ForDelete = row["ID"].ToString()
                });
            }
            var result = new
            {
                iTotalRecords = GetTotal_Delivery_Location_Count(),
                iTotalDisplayRecords = filteredCount,
                aaData = Delivery_Location_List
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotal_Delivery_Location_Count()
        {
            int totalDelivery_Location_Count = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Delivery_Location where IsDeleted=0", con);
                con.Open();
                totalDelivery_Location_Count = (int)cmd.ExecuteScalar();
            }
            return totalDelivery_Location_Count;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Delivery_Location Get_Delivery_Location_By_Id(int ID)
        {
            Delivery_Location _Delivery_Location = new Delivery_Location();

            DataTable dt = Delivery_Location_DA.Get_Delivery_Location_By_Id(ID);

            foreach (DataRow row in dt.Rows)
            {
                ID = int.Parse(row["ID"].ToString());
                _Delivery_Location.Customer_ID = int.Parse(row["Customer_ID"].ToString());
                _Delivery_Location.Address = row["Address"].ToString();
                _Delivery_Location.ZP = row["Zip/Postal"].ToString();
                _Delivery_Location.SP = row["State/Province"].ToString();
                _Delivery_Location.City = row["City"].ToString();
                _Delivery_Location.Country = row["Country"].ToString();

            }
            return _Delivery_Location;
        }

        [WebMethod]
        public bool Delete_Delivery_Location_By_Id(int ID)
        {
            if (Delivery_Location_DA.Delete_Delivery_Location_By_Id(ID) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        public string Update(int ID, int Customer_ID, string Address, string ZP, string SP, string City,string Country)
        {
            Delivery_Location _Delivery_Location = new Delivery_Location();
            _Delivery_Location.ID = ID;
            _Delivery_Location.Customer_ID = Customer_ID;
            _Delivery_Location.Address = Address;
            _Delivery_Location.ZP = ZP;
            _Delivery_Location.SP = SP;
            _Delivery_Location.City = City;
            _Delivery_Location.Country = Country;
            
            _Delivery_Location.UpdatedBy = Session["User"].ToString();


            return Delivery_Location_DA.Update(_Delivery_Location);
        }

        [WebMethod(EnableSession = true)]
        public string Insert(int Customer_ID, string Address, string ZP, string SP, string City,string Country)
        
        {
            Delivery_Location _Delivery_Location = new Delivery_Location();
            _Delivery_Location.Customer_ID = Customer_ID;
            _Delivery_Location.Address = Address;
            _Delivery_Location.ZP = ZP;
            _Delivery_Location.SP = SP;
            _Delivery_Location.City = City;
            _Delivery_Location.Country = Country;

            _Delivery_Location.CreatedBy = Session["User"].ToString();


            return Delivery_Location_DA.Insert(_Delivery_Location);
        }
    }
}
