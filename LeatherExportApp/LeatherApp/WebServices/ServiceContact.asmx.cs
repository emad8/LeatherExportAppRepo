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
    /// Summary description for ServiceContact
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceContact : System.Web.Services.WebService
    {

        [WebMethod]
        public void Filter_Get_Contact(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Contact> Contact_List = new List<Contact>();

            DataTable dt = Contact_DA.Filter_Get_Contact(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {

                filteredCount = int.Parse(row["TotalCount"].ToString());

                Contact_List.Add(new Contact
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Customer_ID = int.Parse(row["Customer_ID"].ToString()),
                    Customer_Code = row["Code"].ToString(),
                    Customer_Name = row["Customer_Name"].ToString(),
                    Name = row["Contact_Name"].ToString(),
                    Tel_No = row["Tel_No"].ToString(),
                    Mob_No = row["Mob_No"].ToString(),
                    Designation = row["Designation"].ToString(),
                    Extention_No = row["Extention_No"].ToString(),
                    Email = row["Email"].ToString(),
                    Remarks = row["Remarks"].ToString(),
                    ForEdit = row["ID"].ToString(),
                    ForDelete = row["ID"].ToString()
                });
            }
            var result = new
            {
                iTotalRecords = GetTotal_Contact_Count(),
                iTotalDisplayRecords = filteredCount,
                aaData = Contact_List
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotal_Contact_Count()
        {
            int totalContact_Count = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Contact where IsDeleted=0", con);
                con.Open();
                totalContact_Count = (int)cmd.ExecuteScalar();
            }
            return totalContact_Count;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Contact Get_Contact_By_Id(int ID)
        {
            Contact _Contact = new Contact();

            DataTable dt = Contact_DA.Get_Contact_By_Id(ID);

            foreach (DataRow row in dt.Rows)
            {
                ID = int.Parse(row["ID"].ToString());
                    _Contact.Customer_ID = int.Parse(row["Customer_ID"].ToString());
                    _Contact.Name = row["Name"].ToString();
                    _Contact.Tel_No = row["Tel_No"].ToString();
                    _Contact.Mob_No = row["Mob_No"].ToString();
                    _Contact.Designation = row["Designation"].ToString();
                    _Contact.Extention_No = row["Extention_No"].ToString();
                    _Contact.Email = row["Email"].ToString();
                    _Contact.Remarks = row["Remarks"].ToString();
                    
            }
            return _Contact;
        }

        [WebMethod]
        public bool Delete_Contact_By_Id(int ID)
        {
            if (Contact_DA.Delete_Contact_By_Id(ID) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        public string Update(int ID, int Customer_ID, string Name, string Tel_No, string Mob_No, string Designation,
            string Extention_No, string Email, string Remarks)
        {
            Contact _Contact = new Contact();
            _Contact.ID = ID;
            _Contact.Customer_ID = Customer_ID;
            _Contact.Name = Name;
            _Contact.Tel_No = Tel_No;
            _Contact.Mob_No = Mob_No;
            _Contact.Designation = Designation;
            _Contact.Extention_No = Extention_No;
            _Contact.Email = Email;
            _Contact.Remarks = Remarks;
            _Contact.UpdatedBy = Session["User"].ToString();


            return Contact_DA.Update(_Contact);
        }

        [WebMethod(EnableSession = true)]
        public string Insert(int Customer_ID, string Name, string Tel_No, string Mob_No, string Designation,
            string Extention_No, string Email, string Remarks)
        {
            Contact _Contact = new Contact();
            _Contact.Customer_ID = Customer_ID;
            _Contact.Name = Name;
            _Contact.Tel_No = Tel_No;
            _Contact.Mob_No = Mob_No;
            _Contact.Designation = Designation;
            _Contact.Extention_No = Extention_No;
            _Contact.Email = Email;
            _Contact.Remarks = Remarks;
            _Contact.CreatedBy = Session["User"].ToString();


            return Contact_DA.Insert(_Contact);
        }
    }
}
