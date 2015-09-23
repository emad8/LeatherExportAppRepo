using DataAccess;
using DataAccess.App_Code;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeatherExportApp.edit
{
    public partial class formCuttingOutStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                InitialSet();
            }

        }
        private void InitialSet()
        {
            //Fill_Lot1();
            //Fill_Lot2();
            Fill_Company();
        }

        private void Fill_Lot1()
        {
            ddlLot1.DataSource = SqlLot1;
            ddlLot1.DataBind();
            ddlLot1.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
        private void Fill_Lot2()
        {
            ddlLot2.DataSource = SqlLot2;
            ddlLot2.DataBind();
            ddlLot2.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
        private void Fill_Company()
        {
            ddlCompany.DataSource = sqlCompany;
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
    }
}