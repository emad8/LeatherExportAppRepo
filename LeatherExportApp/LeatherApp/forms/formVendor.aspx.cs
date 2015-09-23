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
    public partial class formVendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Vendor _Vendor = new Vendor();
            _Vendor.Name = Name.Text;
            _Vendor.Description = Description.Text;
            _Vendor.IsDeleted = false;

            lblMessage.Text = Vendor_DA.InsertVendor(_Vendor);
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