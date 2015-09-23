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
    /// Summary description for ServiceContractor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceContractor : System.Web.Services.WebService
    {

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Filter_Get_Contractor(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Contractor> ContractorsList = new List<Contractor>();

            DataTable dt = Contractor_DA.Filter_Get_Contractor(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {
                int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());
                filteredCount = int.Parse(row["TotalCount"].ToString());
                ContractorsList.Add(new Contractor
                {

                    Name = Name,
                    Description = Description,
                    ForEdit = Id,
                    ForDelete = Id
                });
            }
            var result = new
            {
                iTotalRecords = GetTotalContractorCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = ContractorsList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalContractorCount()
        {
            int totalContractorCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Contractor where IsDeleted=0", con);
                con.Open();
                totalContractorCount = (int)cmd.ExecuteScalar();
            }
            return totalContractorCount;
        }

        //[WebMethod]
        ////[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void getListOfContractors()
        //{
        //    List<Contractors> ContractorsList = new List<Contractors>();

        //    DataTable dt = Contractor_DA.Get_All_Contractors();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        int Id = int.Parse(row["Id"].ToString());
        //        string Name = row["Name"].ToString();
        //        string Description = row["Description"].ToString();
        //        bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

        //        ContractorsList.Add(new Contractors
        //        {
        //            Id = Id,
        //            Name = Name,
        //            Descripton = Description,
        //            ForEdit = Id,
        //            ForDelete = Id
        //        });
        //    }
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    Context.Response.Write(js.Serialize(ContractorsList));
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Contractor Get_Contractor_By_Id(int Id)
        {
            Contractor _Contractor = new Contractor();

            DataTable dt = Contractor_DA.Get_Contractor_By_Id(Id);

            foreach (DataRow row in dt.Rows)
            {
                //int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

                _Contractor.Id = Id;
                _Contractor.Name = Name;
                _Contractor.Description = Description;
                _Contractor.IsDeleted = IsDeleted;

            }
            return _Contractor;
        }

        [WebMethod]
        public bool DeleteContractorById(int Id)
        {
            if (Contractor_DA.Delete_Contractor_By_Id(Id) > 0)
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
            Contractor _Contractor = new Contractor();
            _Contractor.Id = Id;
            _Contractor.Name = Name;
            _Contractor.Description = Description;

            return Contractor_DA.UpdateContractor(_Contractor);
        }
    }
}
