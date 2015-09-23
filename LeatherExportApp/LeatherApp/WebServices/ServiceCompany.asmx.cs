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
    /// Summary description for
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceCompany : System.Web.Services.WebService
    {

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Filter_Get_Company(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Company> CompanysList = new List<Company>();

            DataTable dt = Company_DA.Filter_Get_Company(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {
                int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());
                filteredCount = int.Parse(row["TotalCount"].ToString());
                CompanysList.Add(new Company
                {

                    Name = Name,
                    Description = Description,
                    ForEdit = Id,
                    ForDelete = Id
                });
            }
            var result = new
            {
                iTotalRecords = GetTotalCompanyCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = CompanysList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalCompanyCount()
        {
            int totalCompanyCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Company where IsDeleted=0", con);
                con.Open();
                totalCompanyCount = (int)cmd.ExecuteScalar();
            }
            return totalCompanyCount;
        }

        //[WebMethod]
        ////[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void getListOfCompanys()
        //{
        //    List<Companys> CompanysList = new List<Companys>();

        //    DataTable dt = Company_DA.Get_All_Companys();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        int Id = int.Parse(row["Id"].ToString());
        //        string Name = row["Name"].ToString();
        //        string Description = row["Description"].ToString();
        //        bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

        //        CompanysList.Add(new Companys
        //        {
        //            Id = Id,
        //            Name = Name,
        //            Descripton = Description,
        //            ForEdit = Id,
        //            ForDelete = Id
        //        });
        //    }
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    Context.Response.Write(js.Serialize(CompanysList));
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Company Get_Company_By_Id(int Id)
        {
            Company _Company = new Company();

            DataTable dt = Company_DA.Get_Company_By_Id(Id);

            foreach (DataRow row in dt.Rows)
            {
                //int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

                _Company.Id = Id;
                _Company.Name = Name;
                _Company.Description = Description;
                _Company.IsDeleted = IsDeleted;

            }
            return _Company;
        }

        [WebMethod]
        public bool DeleteCompanyById(int Id)
        {
            if (Company_DA.Delete_Company_By_Id(Id) > 0)
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
            Company _Company = new Company();
            _Company.Id = Id;
            _Company.Name = Name;
            _Company.Description = Description;

            return Company_DA.UpdateCompany(_Company);
        }
    }
}

