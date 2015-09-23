using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LeatherExportApp.edit
{
    public partial class formCustomer_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["btnNav"] != null)
                {
                    hfNav.Value= Session["btnNav"].ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((string)Session["btnNav"] != null)
            {
                Response.Redirect(Session["btnNav"].ToString());
            }
        }
    }
}