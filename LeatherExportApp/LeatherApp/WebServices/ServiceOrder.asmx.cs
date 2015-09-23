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
    /// Summary description for ServiceOrder
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ServiceOrder : System.Web.Services.WebService
    {

        [WebMethod]
        public void Filter_Get_Order(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int filteredCount = 0;

            List<Order> OrderList = new List<Order>();

            DataTable dt = Order_DA.Filter_Get_Order(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);

            foreach (DataRow row in dt.Rows)
            {
                int Id = int.Parse(row["Id"].ToString());
                string Order_No = row["Order_No"].ToString();
                string Description = row["Description"].ToString();
                DateTime Date_Of_Shipping = Convert.ToDateTime(row["Date_Of_Shipping"].ToString());
                int Vendor_ID = int.Parse(row["Vendor_ID"].ToString());
                string Vendor_Name = row["Name"].ToString();
                filteredCount = int.Parse(row["TotalCount"].ToString());
                OrderList.Add(new Order
                {

                    Id = Id,
                    Order_No = Order_No,
                    Description = Description,
                    DateString = Date_Of_Shipping.ToShortDateString(),
                    Name = Vendor_Name,
                    Vendor_ID = Vendor_ID,
                    ForEdit = Id,
                    ForDelete = Id
                });
            }
            var result = new
            {
                iTotalRecords = GetTotalOrderCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = OrderList
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetTotalOrderCount()
        {
            int totalOrderCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd =
                    new SqlCommand("select Count(*) from [Order] where IsDeleted=0", con);
                con.Open();
                totalOrderCount = (int)cmd.ExecuteScalar();
            }
            return totalOrderCount;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Order Get_Order_By_Id(int Id)
        {
            Order _Order = new Order();

            DataTable dt = Order_DA.Get_Order_By_Id(Id);

            foreach (DataRow row in dt.Rows)
            {
                string Order_No = row["Order_No"].ToString();
                string Description = row["Description"].ToString();
                DateTime Date_Of_Shipping = Convert.ToDateTime(row["Date_Of_Shipping"].ToString());
                int Vendor_ID = int.Parse(row["Vendor_ID"].ToString());

                _Order.Id = Id;
                _Order.Order_No = Order_No;
                _Order.Description = Description;
                //_Order.Date_Of_shipping = Date_Of_Shipping;
                _Order.DateString = Date_Of_Shipping.ToShortDateString();
                _Order.Vendor_ID = Vendor_ID;

            }
            return _Order;
        }

        [WebMethod]
        public bool DeleteOrderById(int Id)
        {
            if (Order_DA.Delete_Order_By_Id(Id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public string Update(int Id, string Order_No, string Description, DateTime Date_Of_Shipping, int Vendor_ID)
        {
            Order _Order = new Order();
            _Order.Id = Id;
            _Order.Order_No = Order_No;
            _Order.Description = Description;
            _Order.Date_Of_shipping = Date_Of_Shipping;
            _Order.DateString = Date_Of_Shipping.ToString("mm/dd/yyyy");
            _Order.Vendor_ID = Vendor_ID;

            return Order_DA.UpdateOrder(_Order);
        }
    }
}

