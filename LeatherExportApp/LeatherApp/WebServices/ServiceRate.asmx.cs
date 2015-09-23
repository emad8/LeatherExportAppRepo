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
    /// Summary description for ServiceRate
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceRate : System.Web.Services.WebService
    {

        [WebMethod]
        public void Filter_Get_Rate(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Rate> RateList = new List<Rate>();

            DataTable dt = Rate_DA.Filter_Get_Rate(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {
                Rate _Rate = new Rate();

                filteredCount = int.Parse(row["TotalCount"].ToString());

                _Rate.Id = int.Parse(row["Id"].ToString());

                _Rate.Standard_Value = float.Parse(row["Standard_Value"].ToString());


                if (row["Cutting_Rate"].ToString() != "")
                {
                    _Rate.Cutting_Rate = float.Parse(row["Cutting_Rate"].ToString());
                }

                if (row["Elastic_Stitching"].ToString() != "")
                {
                    _Rate.Elastic_Stitching = float.Parse(row["Elastic_Stitching"].ToString());
                }

                if (row["OverLock"].ToString() != "")
                {
                    _Rate.OverLock = float.Parse(row["OverLock"].ToString());
                }

                if (row["Contractor_Commission"].ToString() != "")
                {
                    _Rate.Contractor_Commission = float.Parse(row["Contractor_Commission"].ToString());
                }

                if (row["BindingRate"].ToString() != "")
                {
                    _Rate.BindingRate = float.Parse(row["BindingRate"].ToString());
                }

                if (row["GloveStitchingRate"].ToString() != "")
                {
                    _Rate.GloveStitchingRate = float.Parse(row["GloveStitchingRate"].ToString());
                }

                _Rate.Style_ID = int.Parse(row["Style_ID"].ToString());
                _Rate.Name = row["Name"].ToString();
                _Rate.Size_ID = int.Parse(row["Size_ID"].ToString());
                _Rate.No = int.Parse(row["No"].ToString());
                _Rate.ForEdit = int.Parse(row["Id"].ToString());
                _Rate.ForDelete = int.Parse(row["Id"].ToString());


                RateList.Add(_Rate);
            }
            var result = new
            {
                iTotalRecords = GetTotalRateCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = RateList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalRateCount()
        {
            int totalRateCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Rate where IsDeleted=0", con);
                con.Open();
                totalRateCount = (int)cmd.ExecuteScalar();
            }
            return totalRateCount;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Rate Get_Rate_By_Id(int Id)
        {
            Rate _Rate = new Rate();

            DataTable dt = Rate_DA.Get_Rate_By_Id(Id);

            foreach (DataRow row in dt.Rows)
            {



                _Rate.Standard_Value = float.Parse(row["Standard_Value"].ToString());


                if (row["Cutting_Rate"].ToString() != "")
                {
                    _Rate.Cutting_Rate = float.Parse(row["Cutting_Rate"].ToString());
                }

                if (row["Elastic_Stitching"].ToString() != "")
                {
                    _Rate.Elastic_Stitching = float.Parse(row["Elastic_Stitching"].ToString());
                }

                if (row["OverLock"].ToString() != "")
                {
                    _Rate.OverLock = float.Parse(row["OverLock"].ToString());
                }

                if (row["Contractor_Commission"].ToString() != "")
                {
                    _Rate.Contractor_Commission = float.Parse(row["Contractor_Commission"].ToString());
                }

                if (row["BindingRate"].ToString() != "")
                {
                    _Rate.BindingRate = float.Parse(row["BindingRate"].ToString());
                }

                if (row["GloveStitchingRate"].ToString() != "")
                {
                    _Rate.GloveStitchingRate = float.Parse(row["GloveStitchingRate"].ToString());
                }

                _Rate.Style_ID = int.Parse(row["Style_ID"].ToString());
                //_Rate.Name = row["Name"].ToString();
                _Rate.Size_ID = int.Parse(row["Size_ID"].ToString());
               // _Rate.No = int.Parse(row["No"].ToString());

                //float Standard_Value = float.Parse(row["Standard_Value"].ToString());
                //float Cutting_Rate = float.Parse(row["Cutting_Rate"].ToString());
                //float Elastic_Stitching = float.Parse(row["Elastic_Stitching"].ToString());
                //float OverLock = float.Parse(row["OverLock"].ToString());
                //float Contractor_Commission = float.Parse(row["Contractor_Commission"].ToString());
                //float BindingRate = float.Parse(row["BindingRate"].ToString());
                //float GloveStitchingRate = float.Parse(row["GloveStitchingRate"].ToString());
                //int Style_ID = int.Parse(row["Style_ID"].ToString());
                ////string Style_Name = row["Name"].ToString();
                //int Size_ID = int.Parse(row["Size_ID"].ToString());
                ////int Size_No = int.Parse(row["No"].ToString());

                //_Rate.Id = Id;
                //_Rate.Standard_Value = Standard_Value;
                //_Rate.Cutting_Rate = Cutting_Rate;
                //_Rate.Elastic_Stitching = Elastic_Stitching;
                //_Rate.OverLock = OverLock;
                //_Rate.Contractor_Commission = Contractor_Commission;
                //_Rate.BindingRate = BindingRate;
                //_Rate.GloveStitchingRate = GloveStitchingRate;
                //_Rate.Style_ID = Style_ID;
                ////Name = Style_Name,
                //_Rate.Size_ID = Size_ID;
                ////No = Size_No,


            }
            return _Rate;
        }

        [WebMethod]
        public bool DeleteRateById(int Id)
        {
            if (Rate_DA.Delete_Rate_By_Id(Id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        [WebMethod]
        
        public string Update(int Id, float Standard_Value, float Cutting_Rate, float Elastic_Stitching,
        float OverLock, float Contractor_Commission, float BindingRate, float GloveStitchingRate,
            int Style_ID, int Size_ID)
        {
            Rate _Rate = new Rate();
            _Rate.Id = Id;
            _Rate.Standard_Value = Standard_Value;
            _Rate.Cutting_Rate = Cutting_Rate;
            _Rate.Elastic_Stitching = Elastic_Stitching;
            _Rate.OverLock = OverLock;
            _Rate.Contractor_Commission = Contractor_Commission;
            _Rate.BindingRate = BindingRate;
            _Rate.GloveStitchingRate = GloveStitchingRate;
            _Rate.Style_ID = Style_ID;
            //_Rate.Name = Name;
            _Rate.Size_ID = Size_ID;
            //No = Size_No,

            return Rate_DA.UpdateRate(_Rate);
        }
    }
}
