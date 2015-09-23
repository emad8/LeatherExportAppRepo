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
    public partial class formDelivery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                Fill_Lot1();
            }
        }

        private void Fill_Lot1()
        {
            ddlLot1.DataSource = SqlLot1;
            ddlLot1.DataBind();
            ddlLot1.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertDelivery();
            ClearFields();
        }

        protected void InsertDelivery()
        {
            #region Delivery
            Delivery _Delivery = new Delivery();
            _Delivery.LotID = int.Parse(ddlLot1.SelectedValue);
            _Delivery.Pcs = int.Parse(txtPcs.Text);
            _Delivery.Sqft = float.Parse(txtSqFt.Text);
            _Delivery.Date = Convert.ToDateTime(txtDate.Text);
            _Delivery.Description = txtDescription.Text;

            _Delivery.IsDeleted = false;
            #endregion

            lblMessage.Text = Delivery_DA.InsertDelivery(_Delivery);

            lblMessage.ForeColor = System.Drawing.Color.Green;
        }

        protected void ClearFields()
        {
            ddlLot1.SelectedIndex = 0;
            
            
            txtPcs.Text = "";
            txtSqFt.Text = "";
            txtDate.Text = "";
            txtDescription.Text = "";

            lblLot1Pcs.Text = "";
            lblLot1Sqft.Text = "";
            
            
        }
    }
}