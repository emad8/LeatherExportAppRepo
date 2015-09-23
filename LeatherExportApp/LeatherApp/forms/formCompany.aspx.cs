using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DataAccess;
using DataAccess.App_Code;


namespace LeatherExportApp.forms
{
    public partial class formCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Company _Company = new Company();
            _Company.Name = Name.Text;
            _Company.Description = Description.Text;
            _Company.IsDeleted = false;

            lblMessage.Text = Company_DA.InsertCompany(_Company);

            if (lblMessage.Text == Constants.ALREADY_EXIST)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}