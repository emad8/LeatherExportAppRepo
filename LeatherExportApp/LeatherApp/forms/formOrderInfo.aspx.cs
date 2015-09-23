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
    public partial class formOrderInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                Fill_Style();
                Fill_Size();
                Fill_Order();
            }
        }

        private void Fill_Style()
        {
            ddlStyle.DataSource = SqlStyle;
            ddlStyle.DataBind();
            ddlStyle.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
        private void Fill_Size()
        {
            ddlSize.DataSource = sqlSize;
            ddlSize.DataBind();
            ddlSize.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
        private void Fill_Order()
        {
            ddlOrder.DataSource = SqlOrder;
            ddlOrder.DataBind();
            ddlOrder.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertOrder_Info();
            if (Constants.SUCESS_INSERT == lblMessage.Text)
            {
                ClearFields();
            }

        }

        protected void InsertOrder_Info()
        {
            #region Order_Info
            Order_Info _Order_Info = new Order_Info();
            _Order_Info.Order = int.Parse(ddlOrder.SelectedValue);
            _Order_Info.No_Order = int.Parse(txtNoOfOrders.Text);
            _Order_Info.Style = int.Parse(ddlStyle.SelectedValue);
            _Order_Info.Size = int.Parse(ddlSize.SelectedValue);

            _Order_Info.Description = txtDescription.Text;

            _Order_Info.IsDeleted = false;
            #endregion

            lblMessage.Text = Order_Info_DA.InsertOrder_Info(_Order_Info);

            lblMessage.ForeColor = System.Drawing.Color.Green;
        }

        protected void ClearFields()
        {
            ddlSize.SelectedIndex = 0;
            ddlStyle.SelectedIndex = 0;
            ddlOrder.SelectedIndex = 0;

            txtDescription.Text = "";
            txtNoOfOrders.Text = "";
        }
    }
}