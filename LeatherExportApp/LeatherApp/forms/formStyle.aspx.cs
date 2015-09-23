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
    public partial class formStyle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Styles _Style = new Styles();
            _Style.Name = Name.Text;
            _Style.Description = Description.Text;
            _Style.IsDeleted = false;

            lblMessage.Text = Style_DA.InsertStyle(_Style);
            
            if (lblMessage.Text == Constants.ALREADY_EXIST)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
                lblMessage.ForeColor = System.Drawing.Color.Green;
        }


            
        }
    }