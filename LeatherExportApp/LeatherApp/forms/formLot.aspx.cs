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
    public partial class formLot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Lot _Lot = new Lot();
            _Lot.Name = Name.Text;
            _Lot.Description = Description.Text;
            _Lot.IsDeleted = false;

            lblMessage.Text = Lot_DA.InsertLot(_Lot);
            if (lblMessage.Text == Constants.ALREADY_EXIST)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
                lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}