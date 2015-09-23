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
    /// Summary description for ServiceCustomer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceCustomer : System.Web.Services.WebService
    {

        [WebMethod]
        public void Filter_Get_Customer_Info(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Customer_Info> Customer_Info_List = new List<Customer_Info>();

            DataTable dt = Customer_Info_DA.Filter_Get_Customer_Info(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

                foreach (DataRow row in dt.Rows)
                    {

                filteredCount = int.Parse(row["TotalCount"].ToString());

                Customer_Info_List.Add(new Customer_Info
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Code = row["Code"].ToString(),
                    Name = row["Name"].ToString(),
                    Address = row["Address"].ToString(),
                    Zip_Postal = row["Zip/Postal"].ToString(),
                    State_Province = row["State/Province"].ToString(),
                    Phone = row["Phone"].ToString(),
                    City = row["City"].ToString(),
                    Country = row["Country"].ToString(),
                    Fax = row["Fax"].ToString(),
                    ForEdit = row["ID"].ToString(),
                    ForDelete = row["ID"].ToString()
                });
            }
            var result = new
            {
                iTotalRecords = GetTotal_Customer_Info_Count(),
                iTotalDisplayRecords = filteredCount,
                aaData = Customer_Info_List
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotal_Customer_Info_Count()
        {
            int totalCustomer_Info_Count = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Customer_Info where IsDeleted=0", con);
                con.Open();
                totalCustomer_Info_Count = (int)cmd.ExecuteScalar();
            }
            return totalCustomer_Info_Count;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        
        public Customer_Info Get_Customer_Info_By_Id(int ID)
        {
            Customer_Info _Customer_Info = new Customer_Info();

            DataTable dt = Customer_Info_DA.Get_Customer_Info_By_Id(ID);

            foreach (DataRow row in dt.Rows)
            {
                    _Customer_Info.ID = ID;
                    _Customer_Info.Code = row["Code"].ToString();
                    _Customer_Info.Name = row["Name"].ToString();
                    _Customer_Info.Address = row["Address"].ToString();
                    _Customer_Info.Zip_Postal = row["Zip/Postal"].ToString();
                    _Customer_Info.State_Province = row["State/Province"].ToString();
                    _Customer_Info.Phone = row["Phone"].ToString();
                    _Customer_Info.City = row["City"].ToString();
                    _Customer_Info.Country = row["Country"].ToString();
                    _Customer_Info.Fax = row["Fax"].ToString();
            }
            return _Customer_Info;
        }

        [WebMethod]
        public bool Delete_Customer_Info_By_Id(int ID)
        {
            if (Customer_Info_DA.Delete_Customer_Info_By_Id(ID) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        public string Update(int ID, string Code, string Name, string Address, string Zip_Postal, 
            string State_Province, string Phone, string City, string Country, string Fax)
        {
            Customer_Info _Customer_Info = new Customer_Info();
            _Customer_Info.ID = ID;
            _Customer_Info.Code = Code;
            _Customer_Info.Name = Name;
            _Customer_Info.Address = Address;
            _Customer_Info.Zip_Postal = Zip_Postal;
            _Customer_Info.State_Province = State_Province;
            _Customer_Info.Phone = Phone;
            _Customer_Info.City = City;
            _Customer_Info.Country = Country;
            _Customer_Info.Fax = Fax;
            _Customer_Info.UpdatedBy = Session["User"].ToString();

            if (_Customer_Info.UpdatedBy.ToString().ToUpper() == ("Mr. Asif").ToString().ToUpper() || _Customer_Info.UpdatedBy.ToString().ToUpper() == ("Saud Piracha").ToString().ToUpper())
            {
                return Customer_Info_DA.Update(_Customer_Info);    
            }
            else
            {
                return "-1";
            }
        }

        [WebMethod(EnableSession=true)]
        public string Insert(string Code, string Name, string Address, string Zip_Postal,
            string State_Province, string Phone, string City, string Country, string Fax)
        {
             Customer_Info _Customer_Info = new Customer_Info();
            _Customer_Info.Code = Code;
            _Customer_Info.Name = Name;
            _Customer_Info.Address = Address;
            _Customer_Info.Zip_Postal = Zip_Postal;
            _Customer_Info.State_Province = State_Province;
            _Customer_Info.Phone = Phone;
            _Customer_Info.City = City;
            _Customer_Info.Country = Country;
            _Customer_Info.Fax = Fax;
            _Customer_Info.CreatedBy = Session["User"].ToString();

            return Customer_Info_DA.Insert(_Customer_Info);
        }

        

    }
}
