﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.App_Code;

namespace LeatherExportApp.edit
{
    public partial class formOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            ddlVendor.DataSource = SqlVendor;
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
            }
        }
    }
}