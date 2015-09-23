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
    /// Summary description for ServicePayment
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServicePayment : System.Web.Services.WebService
    {

        [WebMethod]
        public void Filter_Get_Payment_Info(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Payment_Info> Payment_Info_List = new List<Payment_Info>();

            DataTable dt = Payment_Info_DA.Filter_Get_Payment_Info(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {

                filteredCount = int.Parse(row["TotalCount"].ToString());

                Payment_Info_List.Add(new Payment_Info
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Customer_ID = int.Parse(row["Customer_ID"].ToString()),
                    Customer_Code = row["Code"].ToString(),
                    Customer_Name = row["Name"].ToString(),
                    Payment_Terms = row["Payment_Terms"].ToString(),
                    Bank_Name = row["Bank_Name"].ToString(),
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
                iTotalRecords = GetTotal_Payment_Info_Count(),
                iTotalDisplayRecords = filteredCount,
                aaData = Payment_Info_List
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotal_Payment_Info_Count()
        {
            int totalPayment_Info_Count = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Payment_Info where IsDeleted=0", con);
                con.Open();
                totalPayment_Info_Count = (int)cmd.ExecuteScalar();
            }
            return totalPayment_Info_Count;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Payment_Info Get_Payment_Info_By_Id(int ID)
        {
            Payment_Info _Payment_Info = new Payment_Info();

            DataTable dt = Payment_Info_DA.Get_Payment_Info_By_Id(ID);

            foreach (DataRow row in dt.Rows)
            {
                ID = int.Parse(row["ID"].ToString());
                _Payment_Info.Customer_ID = int.Parse(row["Customer_ID"].ToString());
                _Payment_Info.Payment_Terms = row["Payment_Terms"].ToString();
                _Payment_Info.Bank_Name = row["Bank_Name"].ToString();
                _Payment_Info.Address = row["Address"].ToString();
                _Payment_Info.Zip_Postal = row["Zip/Postal"].ToString();
                _Payment_Info.State_Province = row["State/Province"].ToString();
                _Payment_Info.Phone = row["Phone"].ToString();
                _Payment_Info.City = row["City"].ToString();
                _Payment_Info.Country = row["Country"].ToString();
                _Payment_Info.Fax = row["Fax"].ToString();
            }
            return _Payment_Info;
        }

        [WebMethod]
        public bool Delete_Payment_Info_By_Id(int ID)
        {
            if (Payment_Info_DA.Delete_Payment_Info_By_Id(ID) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        public string Update(int ID, int Customer_ID, string Payment_Terms, string Bank_Name, string Address, string Zip_Postal,
            string State_Province, string Phone, string City, string Country, string Fax)
        {
            Payment_Info _Payment_Info = new Payment_Info();
            _Payment_Info.ID = ID;
            _Payment_Info.Customer_ID = Customer_ID;
            _Payment_Info.Payment_Terms = Payment_Terms;
            _Payment_Info.Bank_Name = Bank_Name;
            _Payment_Info.Address = Address;
            _Payment_Info.Zip_Postal = Zip_Postal;
            _Payment_Info.State_Province = State_Province;
            _Payment_Info.Phone = Phone;
            _Payment_Info.City = City;
            _Payment_Info.Country = Country;
            _Payment_Info.Fax = Fax;
            _Payment_Info.UpdatedBy = Session["User"].ToString();


            return Payment_Info_DA.Update(_Payment_Info);
        }

        [WebMethod(EnableSession = true)]
        public string Insert(int Customer_ID, string Payment_Terms, string Bank_Name, string Address, string Zip_Postal,
            string State_Province, string Phone, string City, string Country, string Fax)
        {
            Payment_Info _Payment_Info = new Payment_Info();
            _Payment_Info.Customer_ID = Customer_ID;
            _Payment_Info.Payment_Terms = Payment_Terms;
            _Payment_Info.Bank_Name = Bank_Name;
            _Payment_Info.Address = Address;
            _Payment_Info.Zip_Postal = Zip_Postal;
            _Payment_Info.State_Province = State_Province;
            _Payment_Info.Phone = Phone;
            _Payment_Info.City = City;
            _Payment_Info.Country = Country;
            _Payment_Info.Fax = Fax;
            _Payment_Info.CreatedBy = Session["User"].ToString();


            return Payment_Info_DA.Insert(_Payment_Info);
        }
    }
}
