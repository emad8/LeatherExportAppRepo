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
    public partial class formMarket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Market _Market = new Market();
            _Market.Name = Name.Text;
            _Market.Description = Description.Text;
            _Market.IsDeleted = false;

            lblMessage.Text = Market_DA.InsertMarket(_Market);
            if (lblMessage.Text == Constants.ALREADY_EXIST)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
                lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}