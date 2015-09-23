using DataAccess;
using DataAccess.App_Code;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LeatherApp.forms
{
    public partial class formPayment_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCus.DataSource = SqlCus;
                ddlCus.DataBind();
                ddlCus.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));

                if ((string)Session["btnNav"]!=null && Session["btnNav"].ToString().Contains("Payment"))
                {
                    Session["btnNav"] = null;
                    hfNavBack.Value = "true";

                    ddlCus.SelectedValue=Session["ddlCus"].ToString();
                    txtPT.Text = Session["txtPT"].ToString();
                    txtBN.Text=Session["txtBN"].ToString();
                    txtAddress.Text = Session["txtAddress"].ToString();
                    txtZP.Text=Session["txtZP"].ToString() ;
                    txtSP.Text = Session["txtSP"].ToString();
                    txtPhone.Text = Session["txtPhone"].ToString();
                    txtCity.Text=Session["txtCity"].ToString();
                    txtCountry.Text = Session["txtCountry"].ToString();
                    txtFax.Text=Session["txtFax"].ToString();
                }
            }
        }

        protected void btnNav_Click(object sender, EventArgs e)
        {
            Session["ddlCus"] = ddlCus.SelectedValue;
            Session["txtPT"] = txtPT.Text;
            Session["txtBN"] = txtBN.Text;
            Session["txtAddress"] = txtAddress.Text;
            Session["txtZP"] = txtZP.Text;
            Session["txtSP"] = txtSP.Text;
            Session["txtPhone"] = txtPhone.Text;
            Session["txtCity"] = txtCity.Text;
            Session["txtCountry"] = txtCountry.Text;
            Session["txtFax"] = txtFax.Text;

            Session["btnNav"] = "../forms/formPayment_Info.aspx";
            Response.Redirect("../forms/formCustomer_Info.aspx");

        }
    }
}