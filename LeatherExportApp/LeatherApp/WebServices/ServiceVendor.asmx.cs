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
    public class ServiceVendor : System.Web.Services.WebService
    {

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Filter_Get_Vendor(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Vendor> VendorsList = new List<Vendor>();

            DataTable dt = Vendor_DA.Filter_Get_Vendor(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {
                int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());
                filteredCount = int.Parse(row["TotalCount"].ToString());
                VendorsList.Add(new Vendor
                {

                    Name = Name,
                    Description = Description,
                    ForEdit = Id,
                    ForDelete = Id
                });
            }
            var result = new
            {
                iTotalRecords = GetTotalVendorCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = VendorsList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalVendorCount()
        {
            int totalVendorCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Vendor where IsDeleted=0", con);
                con.Open();
                totalVendorCount = (int)cmd.ExecuteScalar();
            }
            return totalVendorCount;
        }

        //[WebMethod]
        ////[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void getListOfVendors()
        //{
        //    List<Vendors> VendorsList = new List<Vendors>();

        //    DataTable dt = Vendor_DA.Get_All_Vendors();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        int Id = int.Parse(row["Id"].ToString());
        //        string Name = row["Name"].ToString();
        //        string Description = row["Description"].ToString();
        //        bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

        //        VendorsList.Add(new Vendors
        //        {
        //            Id = Id,
        //            Name = Name,
        //            Descripton = Description,
        //            ForEdit = Id,
        //            ForDelete = Id
        //        });
        //    }
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    Context.Response.Write(js.Serialize(VendorsList));
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Vendor Get_Vendor_By_Id(int Id)
        {
            Vendor _Vendor = new Vendor();

            DataTable dt = Vendor_DA.Get_Vendor_By_Id(Id);

            foreach (DataRow row in dt.Rows)
            {
                //int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Description = row["Description"].ToString();
                bool IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

                _Vendor.Id = Id;
                _Vendor.Name = Name;
                _Vendor.Description = Description;
                _Vendor.IsDeleted = IsDeleted;

            }
            return _Vendor;
        }

        [WebMethod]
        public bool DeleteVendorById(int Id)
        {
            if (Vendor_DA.Delete_Vendor_By_Id(Id) > 0)
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
            Vendor _Vendor = new Vendor();
            _Vendor.Id = Id;
            _Vendor.Name = Name;
            _Vendor.Description = Description;

            return Vendor_DA.UpdateVendor(_Vendor);
        }
    }
}

