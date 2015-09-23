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
    public partial class formContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCus.DataSource = SqlCus;
                ddlCus.DataBind();
                ddlCus.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));

                if ((string)Session["btnNav"] != null && Session["btnNav"].ToString().Contains("Contact"))
                {
                    Session["btnNav"] = null;
                    hfNavBack.Value = "true";

                    ddlCus.SelectedValue = Session["ddlCus"].ToString();
                    txtName.Text = Session["txtName"].ToString();
                    txtTN.Text = Session["txtTN"].ToString();
                    txtMN.Text = Session["txtMN"].ToString();
                    txtDes.Text = Session["txtDes"].ToString();
                    txtEN.Text = Session["txtEN"].ToString();
                    txtEmail.Text = Session["txtEmail"].ToString();
                    txtRemarks.Text = Session["txtRemarks"].ToString();
                }
            }
        }

        protected void btnNav_Click(object sender, EventArgs e)
        {
            Session["ddlCus"] = ddlCus.SelectedValue;
            Session["txtName"] = txtName.Text;
            Session["txtTN"] = txtTN.Text;
            Session["txtMN"] = txtMN.Text;
            Session["txtDes"] = txtDes.Text;
            Session["txtEN"] = txtEN.Text;
            Session["txtEmail"] = txtEmail.Text;
            Session["txtRemarks"] = txtRemarks.Text;

            Session["btnNav"] = "../forms/formContact.aspx";
            Response.Redirect("../forms/formCustomer_Info.aspx");
        }
    }
}