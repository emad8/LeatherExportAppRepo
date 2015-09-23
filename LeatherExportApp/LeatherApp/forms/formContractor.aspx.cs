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
    public partial class formContractor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Contractor _Contractor = new Contractor();
            _Contractor.Name = Name.Text;
            _Contractor.Description = Description.Text;
            _Contractor.IsDeleted = false;

            lblMessage.Text = Contractor_DA.InsertContractor(_Contractor);
            if (lblMessage.Text == Constants.ALREADY_EXIST)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
                lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}