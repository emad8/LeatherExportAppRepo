using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.App_Code;

namespace LeatherExportApp.edit
{
    public partial class formRate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlStyle.DataSource = SqlStyle;
                ddlStyle.DataBind();
                ddlStyle.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));

                ddlSize.DataSource = SqlSize;
                ddlSize.DataBind();
                ddlSize.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
            }
        }
    }
}