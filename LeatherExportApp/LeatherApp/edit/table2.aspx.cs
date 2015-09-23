using DataAccess;
using DataAccess.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeatherExportApp.edit
{
    public partial class table2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill_Lot1();
            }

        }
        private void Fill_Lot1()
        {
            ddlLot1.DataSource = Cutting_DA.Get_ddl_Lots_Sum_Of_Sqft_Pcs();
            ddlLot1.DataBind();
            ddlLot1.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
        protected void ddlLot1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLot1.SelectedValue != "")
            {
                DataTable dt = Cutting_DA.Get_ddl_Lots_Sum_Of_Sqft_Pcs();
                if (dt.Rows.Count == 0)
                    ddlLot2.Items.Clear();
                else
                {
                    ddlLot2.DataSource = dt;
                    ddlLot2.DataBind();
                    ddlLot2.Items.Remove(ddlLot1.SelectedItem);
                }
                ddlLot2.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
            }
            else
            {
                ddlLot2.SelectedIndex = 0;
            }
        }
    }
}