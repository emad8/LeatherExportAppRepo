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
            Fill_Order();
            Fill_Size();
            Fill_Style();

            FillStitcher();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidatePage();

            InsertStitching();
            
            ClearFields();
        }

        protected void UpdateCuttingForCuttingIssuance()
        {
            Stitching _Stitching = new Stitching();
            _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
            _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);
            int BalancePairs = int.Parse(txtPairs.Text);

            DataTable dt = Stitching_DA.Get_Pairs_ANd_ID_From_Cutting(_Stitching);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int pairs = int.Parse(dt.Rows[i][1].ToString());

                if (pairs >= BalancePairs || i+1 == dt.Rows.Count)
                {
                    Stitching_DA.Update_Cutting_By_ID_For_CuttingIssuance_Pairs(BalancePairs, dt.Rows[i][0].ToString());
                    BalancePairs = 0;

                    break;
                }
                else
                {
                    Stitching_DA.Update_Cutting_By_ID_For_CuttingIssuance_Pairs(pairs, dt.Rows[i][0].ToString());
                    BalancePairs -= pairs;
                }

            }
        }

        protected bool ValidatePage()
        {
            bool flag = true;
            lblMessage.Text = "";
            #region Stitching
            Stitching _Stitching = new Stitching();

            _Stitching.Employee_ID = int.Parse(ddlStitcher.SelectedValue);
            _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
            _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);

            _Stitching.Pairs_Issued = int.Parse(txtPairs.Text);

            #endregion

            validatingPairs( ref _Stitching);


            if (flag == false)
                lblMessage.ForeColor = System.Drawing.Color.Red;
            else
                lblMessage.ForeColor = System.Drawing.Color.Green;
            return flag;
        }

        protected void validatingPairs(ref Stitching _Stitching)
        {
            DataTable dt = Stitching_DA.Get_Pairs_SUM_From_Cutting(_Stitching);
            if (dt.Rows.Count > 0)
            {
                if (_Stitching.Pairs_Issued > int.Parse(dt.Rows[0][0].ToString()))
                {
                    lblMessage.Text += "USing More Pairs then Have </br>";
                }
            }
        }

        protected void InsertStitching()
        {
            #region Stitching
            Stitching _Stitching = new Stitching();

            _Stitching.Employee_ID = int.Parse(ddlStitcher.SelectedValue);


            _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
            _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);
            _Stitching.Pairs_Issued = int.Parse(txtPairs.Text);
            _Stitching.Date_Issued = Convert.ToDateTime(txtDate.Text);
            _Stitching.IsDeleted = false;
            #endregion

            lblMessage.Text += Stitching_DA.InsertCuttingIssuance(_Stitching);
            if (!lblMessage.Text.Contains(Constants.ALREADY_EXIST))
            {
                UpdateCuttingForCuttingIssuance();
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            
        }

        protected void FillStitcher()
        {
            ddlStitcher.DataSource = sqlStitcher;
            ddlStitcher.DataBind();
            ddlStitcher.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
        }

        protected void ddlOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0 ||
               ddlOrderNo.SelectedIndex == 0 && HiddenField1.Value == "Order")
            {
                btnRefresh_Click(sender, e);
            }
            

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
            if (ddlOrderNo.SelectedValue != "")
            {
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
            }
            #endregion
            Fill_PairsBox();
        }

        protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0 ||
               ddlStyle.SelectedIndex == 0 && HiddenField1.Value == "Style")
            {
                btnRefresh_Click(sender, e);
            }

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
            if (ddlStyle.SelectedValue != "")
            {
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
            }
            #endregion
            Fill_PairsBox();
        }

        protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0 ||
               ddlSize.SelectedIndex == 0 && HiddenField1.Value == "Size")
            {
                btnRefresh_Click(sender, e);
            }
            

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
                else if (HiddenField3.Value == "Style")
                {
                    ddlStyle.SelectedIndex = 0;
                    Fill_Style();
                }
            }
            
            if (ddlSize.SelectedValue != "")
            {
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
            }
            #endregion
            Fill_PairsBox();
        }

        protected void Fill_Style()
        {
            Stitching _Stitching = new Stitching();

            if (ddlOrderNo.SelectedValue != "")
            {
                _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            }
            if (ddlStyle.SelectedValue != "")
            {
                _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
            }
            if (ddlSize.SelectedValue != "")
            {
                _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);
            }

            DataTable dt = Stitching_DA.Get_Style_From_Cutting(_Stitching);

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
            Stitching _Stitching = new Stitching();
            if (ddlOrderNo.SelectedValue != "")
            {
                _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            }
            if (ddlStyle.SelectedValue != "")
            {
                _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
            }
            if (ddlSize.SelectedValue != "")
            {
                _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);
            }

            DataTable dt = Stitching_DA.Get_Size_From_Cutting(_Stitching);

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
            Stitching _Stitching = new Stitching();
            if (ddlOrderNo.SelectedValue != "")
            {
                _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            }
            if (ddlStyle.SelectedValue != "")
            {
                _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
            }
            if (ddlSize.SelectedValue != "")
            {
                _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);
            }

            DataTable dt = Stitching_DA.Get_Order_From_Cutting(_Stitching);

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

        protected void Fill_PairsBox()
        {
            if (ddlOrderNo.SelectedValue != "" && ddlSize.SelectedValue != "" && ddlStyle.SelectedValue != "")
            {
                Stitching _Stitching = new Stitching();

                _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);

                _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);

                _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);

                DataTable dt = Stitching_DA.Get_Pairs_SUM_From_Cutting(_Stitching);

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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlOrderNo.SelectedIndex = 0;
            ddlStyle.SelectedIndex = 0;
            ddlSize.SelectedIndex = 0;

            HiddenField1.Value = "";
            HiddenField2.Value = "";
            HiddenField3.Value = "";

            Fill_Order();
            Fill_Size();
            Fill_Style();

            txtPairs.Text = "";

        }

        protected void ClearFields()
        {
            ddlStitcher.SelectedIndex = 0;

            ddlOrderNo.SelectedIndex = 0;
            ddlStyle.SelectedIndex = 0;
            ddlSize.SelectedIndex = 0;

            HiddenField1.Value = "";
            HiddenField2.Value = "";
            HiddenField3.Value = "";

            Fill_Order();
            Fill_Size();
            Fill_Style();

            txtPairs.Text = "";

            txtDate.Text = "";
        }

    }
}