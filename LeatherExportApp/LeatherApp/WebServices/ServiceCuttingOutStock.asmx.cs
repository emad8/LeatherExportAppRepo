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
using DataAccess.App_Code;

namespace LeatherExportApp.WebServices
{
    /// <summary>
    /// Summary description for ServiceCuttingOutStock
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceCuttingOutStock : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FilterGet(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch, string sSearch_1, string sSearch_2, string sSearch_3, string sSearch_4, string sSearch_5, string sSearch_6, string sSearch_7, string sSearch_8, string sSearch_9, string min, string max)
        {
            int filteredCount = 0;

            List<CuttingOutStock> CuttingOutStockList = new List<CuttingOutStock>();

            DataTable dt = CuttingOutStock_DA.Filter_Get_CuttingOutstock(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch,  sSearch_1,  sSearch_2,  sSearch_3,  sSearch_4,  sSearch_5,  sSearch_6,  sSearch_7,  sSearch_8,  sSearch_9,  min,  max);

            foreach (DataRow row in dt.Rows)
            {
                filteredCount = int.Parse(row["TotalCount"].ToString());
                CuttingOutStockList.Add(new CuttingOutStock
                {
                    Id = int.Parse(row["Id"].ToString()),
                    CompanyName = row["CompanyName"].ToString(),
                    Lot_1Name = row["Lot_1Name"].ToString(),
                    Pcs = int.Parse(row["Pcs"].ToString()),
                    Sqft = float.Parse(row["Sqft"].ToString()),
                    Lot_2Name = row["Lot_2Name"].ToString(),
                    Pcs2 = int.Parse(row["Pcs2"].ToString()),
                    Sqft2 = float.Parse(row["Sqft2"].ToString()),

                    Description = row["Description"].ToString(),
                    Date2 = Convert.ToDateTime(row["Date"].ToString()).ToShortDateString(),
                    ForEdit = int.Parse(row["Id"].ToString()),
                    ForDelete = int.Parse(row["Id"].ToString()),
                });
            }
            var result = new
            {
                iTotalRecords = GetTotalCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = CuttingOutStockList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalCount()
        {
            int totalCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from Cutting_Outstock where IsDeleted=0", con);
                con.Open();
                totalCount = (int)cmd.ExecuteScalar();
            }
            return totalCount;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public CuttingOutStock Get(int Id)
        {
            CuttingOutStock _CuttingOutStock = new CuttingOutStock();

            DataTable dt = CuttingOutStock_DA.Get_CuttingOutstock_By_ID(Id);

            foreach (DataRow row in dt.Rows)
            {
                _CuttingOutStock.Company = int.Parse(row["Company"].ToString());
                _CuttingOutStock.Lot_1 = int.Parse(row["Lot_1"].ToString());
                _CuttingOutStock.Pcs = int.Parse(row["Pcs"].ToString());
                _CuttingOutStock.Sqft = float.Parse(row["Sqft"].ToString());
                if (row["Lot_2"].ToString() != "")
                    _CuttingOutStock.Lot_2 = int.Parse(row["Lot_2"].ToString());
                if (row["Pcs2"].ToString() != "")
                    _CuttingOutStock.Pcs2 = int.Parse(row["Pcs2"].ToString());
                if (row["Sqft2"].ToString() != "")
                    _CuttingOutStock.Sqft2 = float.Parse(row["Sqft2"].ToString());
                _CuttingOutStock.Date2 = Convert.ToDateTime(row["Date"].ToString()).ToShortDateString();
                _CuttingOutStock.Description = row["Description"].ToString();

            }
            return _CuttingOutStock;
        }

        [WebMethod]
        public bool Delete(int Id)
        {
            if (CuttingOutStock_DA.Delete_CuttingOutstock_By_ID(Id) > 0)
            {
                DataTable dt = CuttingOutStock_DA.Get_CuttingOutstock_By_ID(Id);
                OldPcsSqftEntry(dt.Rows[0]["Lot_1"].ToString(), dt.Rows[0]["Pcs"].ToString(), dt.Rows[0]["Sqft"].ToString());
                if (dt.Rows[0]["Lot_2"].ToString() != "")
                {
                    OldPcsSqftEntry(dt.Rows[0]["Lot_2"].ToString(), dt.Rows[0]["Pcs2"].ToString(), dt.Rows[0]["Sqft2"].ToString());
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Lot> GetLot1()
        {
            List<Lot> _Lot = new List<Lot>();


            DataTable dt = Cutting_DA.Get_ddl_Lots_Sum_Of_Sqft_Pcs();


            foreach (DataRow row in dt.Rows)
            {
                _Lot.Add(new Lot
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                });

            }
            return _Lot;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Lot> GetLotAll()
        {
            DataTable dt = new DataTable();

            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select * from Lot Where IsDeleted=0", con);

                dt = Catalog_Access.ExecuteSelectCommand(cmd);

            }

            List<Lot> _Lot = new List<Lot>();

            foreach (DataRow row in dt.Rows)
            {
                _Lot.Add(new Lot
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                });

            }
            return _Lot;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Lot> GetLot2(int Lot1_ID)
        {
            List<Lot> _Lot = new List<Lot>();


            DataTable dt = Cutting_DA.Get_ddl_Lots_Sum_Of_Sqft_Pcs();


            foreach (DataRow row in dt.Rows)
            {
                if (int.Parse(row["Id"].ToString()) != Lot1_ID)
                {
                    _Lot.Add(new Lot
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Name = row["Name"].ToString(),
                    });
                }


            }
            return _Lot;
        }

        [WebMethod]
        public string GetLot_PcsSqft(int Lot_ID)
        {
            DataTable dt = Cutting_DA.Get_Lot_Pcs_Sqft(Lot_ID.ToString());
            string info = "";
            if (dt.Rows.Count > 0)
            {
                info += "Pcs: " + dt.Rows[0][0].ToString();
                info += "   Sqft: " + dt.Rows[0][1].ToString();
            }
            return info;
        }

        /// Update hardword
        /// </summary>
        [WebMethod]
        public string Update(int Id, int Company, int Lot1, int Pcs, float Sqft, int Lot2, int Pcs2, float Sqft2, string Description, string Date)
        {
            CuttingOutStock _CuttingOutStock = new CuttingOutStock();

            _CuttingOutStock.Id = Id;
            _CuttingOutStock.Lot_1 = Lot1;
            _CuttingOutStock.Company = Company;
            if (Lot2 != -1)
            {
                _CuttingOutStock.Lot_2 = Lot2;
                _CuttingOutStock.Pcs2 = Pcs2;
                _CuttingOutStock.Sqft2 = Sqft2;
            }
            _CuttingOutStock.Pcs = Pcs;
            _CuttingOutStock.Sqft = Sqft;
            _CuttingOutStock.Date = Convert.ToDateTime(Date);
            _CuttingOutStock.Description = Description;

            #region Cutting
            Cutting _Cutting = new Cutting();

            _Cutting.Lot_1 = Lot1;
            if (Lot2 != -1)
            {
                _Cutting.Lot_2 = Lot2;
                _Cutting.Pcs2 = Pcs2;
                _Cutting.Sqft2 = Sqft2;
            }
            _Cutting.Pcs = Pcs;
            _Cutting.Sqft = Sqft;


            #endregion

            DataTable dt = CuttingOutStock_DA.Get_CuttingOutstock_By_ID(Id);

            string msg = validating_Pcs_Sqft_For_Cutter(ref _Cutting, dt.Rows[0]["Lot_1"].ToString(), dt.Rows[0]["Pcs"].ToString(), dt.Rows[0]["Sqft"].ToString(), dt.Rows[0]["Lot_2"].ToString(), dt.Rows[0]["Pcs2"].ToString(), dt.Rows[0]["Sqft2"].ToString());

            msg += CuttingOutStock_DA.UpdateCuttingOutstock(_CuttingOutStock);

            OldPcsSqftEntry(dt.Rows[0]["Lot_1"].ToString(), dt.Rows[0]["Pcs"].ToString(), dt.Rows[0]["Sqft"].ToString());

            if (dt.Rows[0]["Lot_2"].ToString() != "")
                OldPcsSqftEntry(dt.Rows[0]["Lot_2"].ToString(), dt.Rows[0]["Pcs2"].ToString(), dt.Rows[0]["Sqft2"].ToString());

            UpdateDeliveryForCuttingOutStock(Lot1, Pcs, Sqft, Lot2, Pcs2, Sqft2);

            return msg;
        }

        protected void UpdateCuttingForCuttingIssuance(Stitching _Stitching)
        {
            int BalancePairs = _Stitching.Pairs_Issued;
            DataTable dt = Stitching_DA.Get_Pairs_ANd_ID_From_Cutting(_Stitching);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int pairs = int.Parse(dt.Rows[i][1].ToString());

                if (pairs >= BalancePairs || i + 1 == dt.Rows.Count)
                {
                    Stitching_DA.Update_Cutting_By_ID_For_CuttingIssuance_Pairs(BalancePairs, dt.Rows[i][0].ToString());
                    BalancePairs = 0;

                    break;
                }
                else
                {
                    Stitching_DA.Update_Cutting_By_ID_For_CuttingIssuance_Pairs(pairs, dt.Rows[i][0].ToString());
                    BalancePairs -= pairs;
                }

            }
        }

        private void OldPcsSqftEntry(string Lot_Id, string Pcs, string Sqft)
        {
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Top 1 Id from Delivery Where [Lot_Id]= " + Lot_Id + " and IsDeleted=0", con);
                con.Open();
                int Id = (int)cmd.ExecuteScalar();

                cmd =
                    new SqlCommand("Update Delivery Set Pcs_Rem +=" + Pcs + ",Sqrft_Rem +=" + Sqft + " where Id=" + Id, con);

                cmd.ExecuteNonQuery();
            }
        }

        protected void UpdateDeliveryForCuttingOutStock(int Lot1, int Pcs, float Sqft, int Lot2, int Pcs2, float Sqft2)
        {
            int BalancePcs = Pcs;
            float BalanceSqft = Sqft;

            DataTable dt = Cutting_DA.Get_Delivery_By_LotId(Lot1.ToString());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int vpcs = int.Parse(dt.Rows[i][0].ToString());
                float vsqft = float.Parse(dt.Rows[i][1].ToString());
                if (vpcs >= BalancePcs && vsqft >= BalanceSqft || i == dt.Rows.Count - 1)
                {
                    Cutting_DA.Update_Delivery_By_LotId_For_Pcs_Sqft(BalancePcs, BalanceSqft, dt.Rows[i][2].ToString());
                    BalancePcs = 0;
                    BalanceSqft = 0;
                    break;
                }
                else
                {
                    Cutting_DA.Update_Delivery_By_LotId_For_Pcs_Sqft(vpcs, vsqft, dt.Rows[i][2].ToString());
                    BalancePcs -= vpcs;
                    BalanceSqft -= vsqft;
                }
            }

            if (Lot2 != -1)
            {
                BalancePcs = Pcs2;
                BalanceSqft = Sqft2;

                DataTable dt2 = Cutting_DA.Get_Delivery_By_LotId(Lot2.ToString());

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    int pcs = int.Parse(dt2.Rows[i][0].ToString());
                    float sqft = float.Parse(dt2.Rows[i][1].ToString());
                    if (pcs >= BalancePcs && sqft >= BalanceSqft || i == dt2.Rows.Count - 1)
                    {
                        Cutting_DA.Update_Delivery_By_LotId_For_Pcs_Sqft(BalancePcs, BalanceSqft, dt2.Rows[i][2].ToString());
                        BalancePcs = 0;
                        BalanceSqft = 0;
                        break;
                    }
                    else
                    {
                        Cutting_DA.Update_Delivery_By_LotId_For_Pcs_Sqft(pcs, sqft, dt2.Rows[i][2].ToString());
                        BalancePcs -= pcs;
                        BalanceSqft -= sqft;
                    }
                }
            }
        }

        private string validating_Pcs_Sqft_For_Cutter(ref Cutting _Cutting, string Lot1, string Pcs, string Sqft, string Lot2, string Pcs2, string Sqft2)
        {
            string msg = " ";
            DataTable dt1 = Cutting_DA.Get_Lot_Pcs_Sqft(_Cutting.Lot_1.ToString());
            if (dt1.Rows.Count > 0)
            {
                if (_Cutting.Lot_1.ToString() == Lot1.ToString())
                {
                    if (_Cutting.Pcs > int.Parse(dt1.Rows[0][0].ToString()) + int.Parse(Pcs))
                    {
                        msg += "Using More Pcs then Then you have in Lot1 </br>";
                    }
                    if (_Cutting.Sqft > float.Parse(dt1.Rows[0][1].ToString()) + float.Parse(Sqft))
                    {
                        msg += "Using More Sqft then Then you have in Lot1 </br>";
                    }
                }
                else
                {
                    if (_Cutting.Pcs > int.Parse(dt1.Rows[0][0].ToString()))
                    {
                        msg += "Using More Pcs then Then you have in Lot1 </br>";
                    }
                    if (_Cutting.Sqft > float.Parse(dt1.Rows[0][1].ToString()))
                    {
                        msg += "Using More Sqft then Then you have in Lot1 </br>";
                    }
                }
            }

            if (_Cutting.Lot_2 != null)
            {
                DataTable dt2 = Cutting_DA.Get_Lot_Pcs_Sqft(_Cutting.Lot_2.ToString());
                if (dt2.Rows.Count > 0)
                {
                    if (_Cutting.Lot_2.ToString() == Lot2.ToString())
                    {
                        if (_Cutting.Pcs2 > int.Parse(dt2.Rows[0][0].ToString()) + int.Parse(Pcs2))
                        {
                            msg += "Using More Pcs then you have in Lot2 </br>";
                        }
                        if (_Cutting.Sqft2 > float.Parse(dt2.Rows[0][1].ToString()) + float.Parse(Sqft2))
                        {
                            msg += "Using More Sqft then you have in Lot2 </br>";
                        }
                    }
                    else
                    {
                        if (_Cutting.Pcs2 > int.Parse(dt2.Rows[0][0].ToString()))
                        {
                            msg += "Using More Pcs then you have in Lot2 </br>";
                        }
                        if (_Cutting.Sqft2 > float.Parse(dt2.Rows[0][1].ToString()))
                        {
                            msg += "Using More Sqft then you have in Lot2 </br>";
                        }
                    }
                }

            }
            return msg;
        }
    }
}

