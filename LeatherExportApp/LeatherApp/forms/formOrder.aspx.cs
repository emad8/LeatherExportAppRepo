using DataAccess;
using DataAccess.App_Code;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeatherExportApp.forms
{
    public partial class formOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                Fill_Vendor();
            }
        }

        private void Fill_Vendor()
        {
            ddlVendor.DataSource = SqlVendor;
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertOrder();
            if (Constants.SUCESS_INSERT == lblMessage.Text)
            {
                ClearFields();
            }

        }

        protected void InsertOrder()
        {
            #region Order
            Order _Order = new Order();
            _Order.Vendor_ID = int.Parse(ddlVendor.SelectedValue);
            
            _Order.Description = txtDescription.Text;
            _Order.Date_Of_shipping = Convert.ToDateTime( txtDate.Text);
            _Order.Order_No = txtOrderNo.Text;

            

            _Order.IsDeleted = false;
            #endregion

            lblMessage.Text = Order_DA.InsertOrder(_Order);

            lblMessage.ForeColor = System.Drawing.Color.Green;
        }

        protected void ClearFields()
        {
            ddlVendor.SelectedIndex = 0;


            txtOrderNo.Text = "";
            txtDescription.Text = "";
            txtDate.Text = "";

        }
    }
}