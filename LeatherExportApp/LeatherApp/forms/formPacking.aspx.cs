using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.App_Code;
using Model;
using System.Data;

namespace LeatherExportApp.forms
{
    public partial class formPacking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {

                InitialSet();
            }

        }
        protected void InitialSet()
        {
            Fill_Order();
            Fill_Size();
            Fill_Style();

            //FillPacker();
        }

        protected void Fill_Style()
        {
            Packing _Packing = new Packing();

            if (ddlOrderNo.SelectedValue != "")
            {
                _Packing.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            }
            if (ddlStyle.SelectedValue != "")
            {
                _Packing.Style_ID = int.Parse(ddlStyle.SelectedValue);
            }
            if (ddlSize.SelectedValue != "")
            {
                _Packing.Size_ID = int.Parse(ddlSize.SelectedValue);
            }

            DataTable dt = Packing_DA.Get_Style_From_Stitching_For_Packing(_Packing);

            if (ddlStyle.SelectedValue == "")
            {

                if (dt.Rows.Count == 0)
                    ddlStyle.Items.Clear();
                else
                {
                    ddlStyle.DataSource = dt;
                    ddlStyle.DataTextField = "Name";
                    ddlStyle.DataValueField = "Id";
                    ddlStyle.DataBind();
                }
                ddlStyle.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
                ddlStyle.SelectedIndex = 0;
            }
        }
        protected void Fill_Size()
        {
            Packing _Packing = new Packing();
            if (ddlOrderNo.SelectedValue != "")
            {
                _Packing.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            }
            if (ddlStyle.SelectedValue != "")
            {
                _Packing.Style_ID = int.Parse(ddlStyle.SelectedValue);
            }
            if (ddlSize.SelectedValue != "")
            {
                _Packing.Size_ID = int.Parse(ddlSize.SelectedValue);
            }

            DataTable dt = Packing_DA.Get_Size_From_Stitching_For_Packing(_Packing);

            if (ddlSize.SelectedValue == "")
            {
                
                if (dt.Rows.Count == 0)
                    ddlSize.Items.Clear();
                else
                {
                    ddlSize.DataSource = dt;
                    ddlSize.DataTextField = "No";
                    ddlSize.DataValueField = "Id";
                    ddlSize.DataBind();
                }
                ddlSize.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
                ddlSize.SelectedIndex = 0;
            }
        }
        protected void Fill_Order()
        {
            Packing _Packing = new Packing();
            if (ddlOrderNo.SelectedValue != "")
            {
                _Packing.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            }
            if (ddlStyle.SelectedValue != "")
            {
                _Packing.Style_ID = int.Parse(ddlStyle.SelectedValue);
            }
            if (ddlSize.SelectedValue != "")
            {
                _Packing.Size_ID = int.Parse(ddlSize.SelectedValue);
            }

            DataTable dt = Packing_DA.Get_Order_From_Stitching_For_Packing(_Packing);

            if (ddlOrderNo.SelectedValue == "")
            {
                
                if (dt.Rows.Count == 0)
                    ddlOrderNo.Items.Clear();
                else
                {
                    ddlOrderNo.DataSource = dt;
                    ddlOrderNo.DataTextField = "Order_No";
                    ddlOrderNo.DataValueField = "id";
                    ddlOrderNo.DataBind();
                    
                }
                ddlOrderNo.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
                ddlOrderNo.SelectedIndex = 0;
            }
        }
        //protected void FillPacker()
        //{
            //ddlPacker.DataSource = sqlPacker;
            //ddlPacker.DataBind();
            //ddlPacker.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        //}

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlOrderNo.SelectedIndex = 0;
            ddlStyle.SelectedIndex = 0;
            ddlSize.SelectedIndex = 0;

            HiddenField1.Value = "";
            HiddenField2.Value = "";
            HiddenField3.Value = "";
            InitialSet();
            txtPairs.Text = "";

        }
        protected void ClearFields()
        {
            //ddlPacker.SelectedIndex = 0;

            ddlOrderNo.SelectedIndex = 0;
            ddlStyle.SelectedIndex = 0;
            ddlSize.SelectedIndex = 0;

            HiddenField1.Value = "";
            HiddenField2.Value = "";
            HiddenField3.Value = "";

            InitialSet();
            txtPairs.Text = "";
            txtDescription.Text = "";
            txtDate.Text = "";
        }

        protected void ddlOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            #region Filling Relatively
            if (ddlStyle.SelectedValue == "")
            {
                Fill_Style();
            }
            if (ddlSize.SelectedValue == "")
            {
                Fill_Size();
            }

            if (HiddenField1.Value == "Order")
            {
                ddlSize.SelectedIndex = 0;
                ddlStyle.SelectedIndex = 0;
                Fill_Size();
                Fill_Style();
            }
            else if (HiddenField2.Value == "Order")
            {
                if (HiddenField3.Value == "Style")
                {
                    ddlStyle.SelectedIndex = 0;
                    Fill_Style();
                }
                else if (HiddenField3.Value == "Size")
                {
                    ddlSize.SelectedIndex = 0;
                    Fill_Size();
                }
            }

            if (HiddenField1.Value == "")
            {
                HiddenField1.Value = "Order";
            }
            else if (HiddenField2.Value == "")
            {
                HiddenField2.Value = "Order";
            }
            else if (HiddenField3.Value == "")
            {
                HiddenField3.Value = "Order";
            }

            #endregion

            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0)
            {
                btnRefresh_Click(sender, e);
            }

            Fill_PairsBox();
        }
        protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            #region Filling Relatively
            if (ddlOrderNo.SelectedValue == "")
            {
                Fill_Order();
            }
            if (ddlSize.SelectedValue == "")
            {
                Fill_Size();
            }

            if (HiddenField1.Value == "Style")
            {
                ddlSize.SelectedIndex = 0;
                ddlOrderNo.SelectedIndex = 0;
                Fill_Size();
                Fill_Order();
            }
            else if (HiddenField2.Value == "Style")
            {
                if (HiddenField3.Value == "Order")
                {
                    ddlOrderNo.SelectedIndex = 0;
                    Fill_Order();
                }
                else if (HiddenField3.Value == "Size")
                {
                    ddlSize.SelectedIndex = 0;
                    Fill_Size();
                }
            }

            if (HiddenField1.Value == "")
            {
                HiddenField1.Value = "Style";
            }
            else if (HiddenField2.Value == "")
            {
                HiddenField2.Value = "Style";
            }
            else if (HiddenField3.Value == "")
            {
                HiddenField3.Value = "Style";
            }

            #endregion

            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0)
            {
                btnRefresh_Click(sender, e);
            }
            Fill_PairsBox();
        }
        protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            #region Filling Relatively

            if (ddlStyle.SelectedValue == "")
            {
                Fill_Style();
            }
            if (ddlOrderNo.SelectedValue == "")
            {
                Fill_Order();
            }

            if (HiddenField1.Value == "Size")
            {
                ddlOrderNo.SelectedIndex = 0;
                ddlStyle.SelectedIndex = 0;
                Fill_Order();
                Fill_Style();
            }
            else if (HiddenField2.Value == "Size")
            {
                if (HiddenField3.Value == "Order")
                {
                    ddlOrderNo.SelectedIndex = 0;
                    Fill_Order();
                }
                else if (HiddenField3.Value == "Size")
                {
                    ddlStyle.SelectedIndex = 0;
                    Fill_Size();
                }
            }

            if (HiddenField1.Value == "")
            {
                HiddenField1.Value = "Size";
            }
            else if (HiddenField2.Value == "")
            {
                HiddenField2.Value = "Size";
            }
            else if (HiddenField3.Value == "")
            {
                HiddenField3.Value = "Size";
            }

            #endregion

            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0)
            {
                btnRefresh_Click(sender, e);
            }
            Fill_PairsBox();
        }

        protected void Fill_PairsBox()
        {
            if (ddlOrderNo.SelectedValue != "" && ddlSize.SelectedValue != "" && ddlStyle.SelectedValue != "")
            {
                Packing _Packing = new Packing();

                _Packing.Order_ID = int.Parse(ddlOrderNo.SelectedValue);

                _Packing.Style_ID = int.Parse(ddlStyle.SelectedValue);

                _Packing.Size_ID = int.Parse(ddlSize.SelectedValue);

                DataTable dt = Packing_DA.Get_Pairs_SUM_From_Stitching(_Packing);

                if (dt.Rows.Count > 0)
                {
                    txtPairs.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    txtPairs.Text = "";
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidatePage())
            {
                InsertPacking();
                ClearFields();
            }

        }

        protected bool ValidatePage()
        {
            bool flag = true;
            lblMessage.Text = "";
            #region Packing
            Packing _Packing = new Packing();

            //_Packing.Employee_ID = int.Parse(ddlPacker.SelectedValue);
            _Packing.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            _Packing.Style_ID = int.Parse(ddlStyle.SelectedValue);
            _Packing.Size_ID = int.Parse(ddlSize.SelectedValue);

            _Packing.Pairs_Packed = int.Parse(txtPairs.Text);

            #endregion

            validatingPairs(ref flag, ref _Packing);


            if (flag == false)
                lblMessage.ForeColor = System.Drawing.Color.Red;
            else
                lblMessage.ForeColor = System.Drawing.Color.Green;
            return flag;
        }
        protected void validatingPairs(ref bool flag, ref Packing _Packing)
        {
            DataTable dt = Packing_DA.Get_Pairs_SUM_From_Stitching(_Packing);
            if (dt.Rows.Count > 0)
            {
                if (_Packing.Pairs_Packed > int.Parse(dt.Rows[0][0].ToString()))
                {
                    lblMessage.Text += "USing More Pairs then Have </br>";
                    flag = false;
                }
            }
        }

        protected void InsertPacking()
        {
            #region Packing
            Packing _Packing = new Packing();

            //_Packing.Employee_ID = int.Parse(ddlPacker.SelectedValue);


            _Packing.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            _Packing.Style_ID = int.Parse(ddlStyle.SelectedValue);
            _Packing.Size_ID = int.Parse(ddlSize.SelectedValue);
            _Packing.Pairs_Packed = int.Parse(txtPairs.Text);
            _Packing.Date = Convert.ToDateTime(txtDate.Text);
            _Packing.Description = txtDescription.Text;
            _Packing.IsDeleted = false;
            #endregion

            lblMessage.Text += Packing_DA.InsertPacking(_Packing);
            if (!lblMessage.Text.Contains(Constants.ALREADY_EXIST))
            {
                UpdateStitchingForPacking();
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void UpdateStitchingForPacking()
        {
            Packing _Packing = new Packing();
            _Packing.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            _Packing.Style_ID = int.Parse(ddlStyle.SelectedValue);
            _Packing.Size_ID = int.Parse(ddlSize.SelectedValue);
            int BalancePairs = int.Parse(txtPairs.Text);

            DataTable dt = Packing_DA.Get_Pairs_ANd_ID_From_Stitching(_Packing);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int pairs = int.Parse(dt.Rows[i][1].ToString());

                if (pairs >= BalancePairs)
                {
                    Packing_DA.Update_Stitching_By_ID_For_Packing_Pairs(BalancePairs, dt.Rows[i][0].ToString());
                    BalancePairs = 0;

                    break;
                }
                else
                {
                    Packing_DA.Update_Stitching_By_ID_For_Packing_Pairs(pairs, dt.Rows[i][0].ToString());
                    BalancePairs -= pairs;
                }

            }
        }
    }
}