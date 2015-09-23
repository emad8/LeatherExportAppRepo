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
    /// Summary description for ServiceCuttingIssuance
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ServiceCuttingIssuance : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void FilterGet(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch, string sSearch_1, string sSearch_2, string sSearch_3, string sSearch_4, string sSearch_5, string sSearch_6, string min,string max)
        {
            int filteredCount = 0;

            List<Stitching> CuttingIssuanceList = new List<Stitching>();

            DataTable dt = Stitching_DA.Filter_Get_CuttingIssuance(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch,  sSearch_1,  sSearch_2,  sSearch_3,  sSearch_4,  sSearch_5,  sSearch_6, min,max);

            foreach (DataRow row in dt.Rows)
            {
                filteredCount = int.Parse(row["TotalCount"].ToString());
                CuttingIssuanceList.Add(new Stitching
                {
                    Id = int.Parse(row["Id"].ToString()),
                    EmployeeName = row["EmployeeName"].ToString(),
                    OrderNo = row["OrderNo"].ToString(),
                    StyleName = row["StyleName"].ToString(),
                    SizeNo = row["SizeNo"].ToString(),
                    Pairs_Issued = int.Parse(row["Pairs_Issued"].ToString()),
                    Date = Convert.ToDateTime(row["Date_Issued"].ToString()).ToShortDateString(),
                    ForEdit = int.Parse(row["Id"].ToString()),
                    ForDelete = int.Parse(row["Id"].ToString()),
                });
            }
            var result = new
            {
                iTotalRecords = GetTotalCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = CuttingIssuanceList
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
                    new SqlCommand("select Count(*) from Stitching where IsDeletedCI=0", con);
                con.Open();
                totalCount = (int)cmd.ExecuteScalar();
            }
            return totalCount;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Stitching Get(int Id)
        {
            Stitching _CuttingIssuance = new Stitching();

            DataTable dt = Stitching_DA.Get_CuttingIssuance_By_ID(Id);

            foreach (DataRow row in dt.Rows)
            {
                _CuttingIssuance.Employee_ID = int.Parse(row["Employee_ID"].ToString());
                _CuttingIssuance.Order_ID = int.Parse(row["Order_ID"].ToString());
                _CuttingIssuance.Style_ID = int.Parse(row["Style_ID"].ToString());
                _CuttingIssuance.Size_ID = int.Parse(row["Size_ID"].ToString());
                _CuttingIssuance.Pairs_Issued = int.Parse(row["Pairs_Issued"].ToString());
                _CuttingIssuance.Date = Convert.ToDateTime(row["Date_Issued"].ToString()).ToShortDateString();

            }
            return _CuttingIssuance;
        }

        [WebMethod]
        public bool Delete(int Id)
        {
            if (Stitching_DA.Delete_CuttingIssuance_By_ID(Id) > 0)
            {
                DataTable dt = Stitching_DA.Get_CuttingIssuance_By_ID(Id);
                OldPairsCuttingEntry(int.Parse(dt.Rows[0]["Order_ID"].ToString()), int.Parse(dt.Rows[0]["Style_ID"].ToString()), int.Parse(dt.Rows[0]["Size_ID"].ToString()), int.Parse(dt.Rows[0]["Pairs_Issued"].ToString()));
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Styles> GetStyle(int Order_ID, int Style_ID, int Size_ID)
        {
            List<Styles> _Styles = new List<Styles>();

            Stitching _Stitching = new Stitching();
            if (Order_ID != 0)
                _Stitching.Order_ID = Order_ID;
            if (Style_ID != 0)
                _Stitching.Style_ID = Style_ID;
            if (Size_ID != 0)
                _Stitching.Size_ID = Size_ID;

            DataTable dt = Stitching_DA.Get_Style_From_Cutting(_Stitching);


            foreach (DataRow row in dt.Rows)
            {
                _Styles.Add(new Styles
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                });

            }
            return _Styles;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Size> GetSize(int Order_ID, int Style_ID, int Size_ID)
        {
            List<Size> _Size = new List<Size>();

            Stitching _Stitching = new Stitching();
            if (Order_ID != 0)
                _Stitching.Order_ID = Order_ID;
            if (Style_ID != 0)
                _Stitching.Style_ID = Style_ID;
            if (Size_ID != 0)
                _Stitching.Size_ID = Size_ID;

            DataTable dt = Stitching_DA.Get_Size_From_Cutting(_Stitching);

            foreach (DataRow row in dt.Rows)
            {
                _Size.Add(new Size
                {
                    Id = int.Parse(row["Id"].ToString()),
                    No = int.Parse(row["No"].ToString())
                });

            }
            return _Size;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Order> GetOrder(int Order_ID, int Style_ID, int Size_ID)
        {
            List<Order> _Order = new List<Order>();

            Stitching _Stitching = new Stitching();
            if (Order_ID != 0)
                _Stitching.Order_ID = Order_ID;
            if (Style_ID != 0)
                _Stitching.Style_ID = Style_ID;
            if (Size_ID != 0)
                _Stitching.Size_ID = Size_ID;

            DataTable dt = Stitching_DA.Get_Order_From_Cutting(_Stitching);

            foreach (DataRow row in dt.Rows)
            {
                _Order.Add(new Order
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Order_No = row["Order_No"].ToString()
                });

            }
            return _Order;
        }

        [WebMethod]
        public string GetPairs(int Order_ID, int Style_ID, int Size_ID)
        {
            Stitching _Stitching = new Stitching();

            _Stitching.Order_ID = Order_ID;
            _Stitching.Style_ID = Style_ID;
            _Stitching.Size_ID = Size_ID;

            DataTable dt = Stitching_DA.Get_Pairs_SUM_From_Cutting(_Stitching);

            return dt.Rows[0][0].ToString();
        }

        /// Update hardword
        /// </summary>
        [WebMethod]
        public string Update(int Id, int Employee_ID, int Order_ID, int Style_ID, int Size_ID, int Pairs_Issued, string Date_Issued)//, int OldOrder_ID, int OldStyle_ID, int OldSize_ID, int OldPairs)
        {
            Stitching _Stitching = new Stitching();
            _Stitching.Id = Id;
            _Stitching.Employee_ID = Employee_ID;
            _Stitching.Order_ID = Order_ID;
            _Stitching.Style_ID = Style_ID;
            _Stitching.Size_ID = Size_ID;

            _Stitching.Pairs_Issued = Pairs_Issued;
            _Stitching.Date_Issued = Convert.ToDateTime(Date_Issued);

            DataTable dt = Stitching_DA.Get_CuttingIssuance_By_ID(Id);
            
            int OldOrder_ID=int.Parse(dt.Rows[0]["Order_ID"].ToString());
            int OldStyle_ID=int.Parse(dt.Rows[0]["Style_ID"].ToString());
            int OldSize_ID=int.Parse(dt.Rows[0]["Size_ID"].ToString());
            int OldPairs=int.Parse(dt.Rows[0]["Pairs_Issued"].ToString());

            string msg = Validate(_Stitching, OldOrder_ID,OldStyle_ID , OldSize_ID, OldPairs);

            msg += Stitching_DA.UpdateCuttingIssuance(_Stitching);

            if (!msg.Contains(Constants.SP_ALREADY_EXIST))
            {
                OldPairsCuttingEntry(OldOrder_ID, OldStyle_ID, OldSize_ID, OldPairs);
                UpdateCuttingForCuttingIssuance(_Stitching);
            }

            return msg;
        }

        private string Validate(Stitching _Stitching, int OldOrder_ID, int OldStyle_ID, int OldSize_ID, int OldPairs)
        {
            DataTable dt = Stitching_DA.Get_Pairs_SUM_From_Cutting(_Stitching);
            int result;
            if (!int.TryParse(dt.Rows[0][0].ToString(), out result))
            {
                return "No Pairs to Issue<br>";
            }
            else
            {
                if (IsOSSsame(_Stitching, OldOrder_ID, OldStyle_ID, OldSize_ID, OldPairs))
                {
                    if (OldPairs + int.Parse(dt.Rows[0][0].ToString()) >= _Stitching.Pairs_Issued)
                        return "";
                    else
                        return "Issuing More Pairs Then already have in Cutting<br>";
                }
                else
                {
                    if (int.Parse(dt.Rows[0][0].ToString()) >= _Stitching.Pairs_Issued)
                        return "";
                    else
                        return "Issuing More Pairs Then already have in Cutting<br>";
                }
            }
        }
        
        private bool IsOSSsame(Stitching _Stitching, int OldOrder_ID, int OldStyle_ID, int OldSize_ID, int OldPairs)
        {
            if (_Stitching.Order_ID == OldOrder_ID && _Stitching.Style_ID == OldStyle_ID && _Stitching.Size_ID == OldSize_ID)
                return true;
            else
                return false;
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

        private void OldPairsCuttingEntry(int OldOrder_ID, int OldStyle_ID, int OldSize_ID, int OldPairs)
        {
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Top 1 Id from Cutting Where [Order]= "+OldOrder_ID+" and Style="+OldStyle_ID+" and Size="+OldSize_ID+" and IsDeleted=0", con);
                con.Open();
                int Id = (int)cmd.ExecuteScalar();

                cmd =
                    new SqlCommand("Update Cutting Set Pairs_Rem +="+OldPairs+" where Id="+Id, con);
                
                cmd.ExecuteNonQuery();
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Order> GetOrderAll()
        {
            DataTable dt = new DataTable();

            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select * from [Order] Where IsDeleted=0", con);

                dt = Catalog_Access.ExecuteSelectCommand(cmd);

            }

            List<Order> _Order = new List<Order>();

            foreach (DataRow row in dt.Rows)
            {
                _Order.Add(new Order
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Order_No = row["Order_No"].ToString(),
                });

            }
            return _Order;
        }
        
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Styles> GetStylesAll()
        {
            DataTable dt = new DataTable();

            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select * from [Style] Where IsDeleted=0", con);

                dt = Catalog_Access.ExecuteSelectCommand(cmd);

            }

            List<Styles> _Styles = new List<Styles>();

            foreach (DataRow row in dt.Rows)
            {
                _Styles.Add(new Styles
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                });

            }
            return _Styles;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Size> GetSizeAll()
        {
            DataTable dt = new DataTable();

            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select * from [Size] Where IsDeleted=0", con);

                dt = Catalog_Access.ExecuteSelectCommand(cmd);

            }

            List<Size> _Size = new List<Size>();

            foreach (DataRow row in dt.Rows)
            {
                _Size.Add(new Size
                {
                    Id = int.Parse(row["Id"].ToString()),
                    No = int.Parse(row["No"].ToString()),
                });

            }
            return _Size;
        }
    }
}

