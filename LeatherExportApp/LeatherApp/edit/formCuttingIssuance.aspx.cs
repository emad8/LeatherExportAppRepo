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
    public partial class formCuttingIssuance : System.Web.UI.Page
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
            //Fill_Order();
            //Fill_Size();
            //Fill_Style();

            FillStitcher();
        }
        //protected void Fill_Style()
        //{
        //    Stitching _Stitching = new Stitching();

        //    if (ddlOrder.SelectedValue != "")
        //    {
        //        _Stitching.Order_ID = int.Parse(ddlOrder.SelectedValue);
        //    }
        //    if (ddlStyle.SelectedValue != "")
        //    {
        //        _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
        //    }
        //    if (ddlSize.SelectedValue != "")
        //    {
        //        _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);
        //    }

        //    DataTable dt = Stitching_DA.Get_Style_From_Cutting(_Stitching);

        //    if (ddlStyle.SelectedValue == "")
        //    {
        //        ddlStyle.DataSource = dt;
        //        ddlStyle.DataTextField = "Name";
        //        ddlStyle.DataValueField = "Id";
        //        ddlStyle.DataBind();
        //        ddlStyle.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        //        ddlStyle.SelectedIndex = 0;
        //    }
        //}

        //protected void Fill_Size()
        //{
        //    Stitching _Stitching = new Stitching();
        //    if (ddlOrder.SelectedValue != "")
        //    {
        //        _Stitching.Order_ID = int.Parse(ddlOrder.SelectedValue);
        //    }
        //    if (ddlStyle.SelectedValue != "")
        //    {
        //        _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
        //    }
        //    if (ddlSize.SelectedValue != "")
        //    {
        //        _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);
        //    }

        //    DataTable dt = Stitching_DA.Get_Size_From_Cutting(_Stitching);

        //    if (ddlSize.SelectedValue == "")
        //    {
        //        ddlSize.DataSource = dt;
        //        ddlSize.DataTextField = "No";
        //        ddlSize.DataValueField = "Id";
        //        ddlSize.DataBind();
        //        ddlSize.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        //        ddlSize.SelectedIndex = 0;
        //    }
        //}

        //protected void Fill_Order()
        //{
        //    Stitching _Stitching = new Stitching();
        //    if (ddlOrder.SelectedValue != "")
        //    {
        //        _Stitching.Order_ID = int.Parse(ddlOrder.SelectedValue);
        //    }
        //    if (ddlStyle.SelectedValue != "")
        //    {
        //        _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
        //    }
        //    if (ddlSize.SelectedValue != "")
        //    {
        //        _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);
        //    }

        //    DataTable dt = Stitching_DA.Get_Order_From_Cutting(_Stitching);

        //    if (ddlOrder.SelectedValue == "")
        //    {
        //        ddlOrder.DataSource = dt;
        //        ddlOrder.DataTextField = "Order_No";
        //        ddlOrder.DataValueField = "id";
        //        ddlOrder.DataBind();
        //        ddlOrder.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        //        ddlOrder.SelectedIndex = 0;
        //    }
        //}
        protected void FillStitcher()
        {
            ddlStitcher.DataSource = sqlStitcher;
            ddlStitcher.DataBind();
            ddlStitcher.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
        private void Fill_Style()
        {
            ddlStyle.DataSource = SqlStyle;
            ddlStyle.DataBind();
            ddlStyle.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
        private void Fill_Size()
        {
            ddlSize.DataSource = sqlSize;
            ddlSize.DataBind();
            ddlSize.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
        private void Fill_Order()
        {
            ddlOrder.DataSource = SqlOrder;
            ddlOrder.DataBind();
            ddlOrder.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }
    }
}