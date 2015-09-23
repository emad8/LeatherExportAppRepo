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

namespace LeatherExportApp.forms
{
    public partial class formStitching : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                Fill_Order();
                Fill_Size();
                Fill_Style();

                FillStitcher();

                Fill_Contractor();

            }

        }


        /// <summary>
        /// i think below code will work fine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Fill_Contractor()
        {
            ddlContractor.DataSource = sqlContractor;
            ddlContractor.DataBind();
            ddlContractor.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
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
            if (ddlStitcher.SelectedValue != "")
            {
                _Stitching.Employee_ID = int.Parse(ddlStitcher.SelectedValue);
            }
            DataTable dt = Stitching_DA.Get_Style_From_Stitching(_Stitching);

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
            if (ddlStitcher.SelectedValue != "")
            {
                _Stitching.Employee_ID = int.Parse(ddlStitcher.SelectedValue);
            }
            DataTable dt = Stitching_DA.Get_Size_From_Stitching(_Stitching);

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
            if (ddlStitcher.SelectedValue != "")
            {
                _Stitching.Employee_ID = int.Parse(ddlStitcher.SelectedValue);
            }
            DataTable dt = Stitching_DA.Get_Order_From_Stitching(_Stitching);

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
        protected void FillStitcher()
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
            if (ddlStitcher.SelectedValue != "")
            {
                _Stitching.Employee_ID = int.Parse(ddlStitcher.SelectedValue);
            }
            DataTable dt = Stitching_DA.Get_Stitcher_From_Stitching(_Stitching);

            if (ddlStitcher.SelectedValue == "")
            {
                
                if (dt.Rows.Count == 0)
                    ddlStitcher.Items.Clear();
                else
                {
                    ddlStitcher.DataSource = dt;
                    ddlStitcher.DataTextField = "Name";
                    ddlStitcher.DataValueField = "Id";
                    ddlStitcher.DataBind();
                    
                }
                ddlStitcher.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
                ddlStitcher.SelectedIndex = 0;
            }
        }

        protected void Fill_PairsBox()
        {
            if (ddlOrderNo.SelectedValue != "" && ddlSize.SelectedValue != "" && ddlStyle.SelectedValue != "" && ddlStitcher.SelectedValue != "" && rblDateOfIssuance.SelectedValue != "")
            {
                Stitching _Stitching = new Stitching();

                _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);

                _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);

                _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);

                _Stitching.Employee_ID = int.Parse(ddlStitcher.SelectedValue);

                _Stitching.Date_Issued = DateTime.Parse(rblDateOfIssuance.SelectedValue);


                DataTable dt = Stitching_DA.Get_Pairs_From_Stitching(_Stitching);

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

        protected void Fill_rbl()
        {
            if (ddlOrderNo.SelectedValue != "" && ddlSize.SelectedValue != "" && ddlStyle.SelectedValue != "" && ddlStitcher.SelectedValue != "")
            {
                Stitching _Stitching = new Stitching();

                _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);

                _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);

                _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);

                _Stitching.Employee_ID = int.Parse(ddlStitcher.SelectedValue);

                DataTable dt = Stitching_DA.Get_DateIssued_From_Stitching(_Stitching);
                rblDateOfIssuance.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string date = Convert.ToDateTime(dt.Rows[i][0].ToString()).ToShortDateString();
                    rblDateOfIssuance.Items.Add(new ListItem(date));
                }
                if (dt.Rows.Count > 0)
                {
                    rblDateOfIssuance.SelectedIndex = 0;
                }

                //rblDateOfIssuance.DataSource = dt;
                //rblDateOfIssuance.DataBind();
            }

        }

        protected void ddlOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0 && ddlStitcher.SelectedIndex == 0 ||
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
            if (ddlStitcher.SelectedValue == "")
            {
                FillStitcher();
            }

            if (HiddenField1.Value == "Order")
            {
                ddlSize.SelectedIndex = 0;
                ddlStyle.SelectedIndex = 0;
                ddlStitcher.SelectedIndex = 0;
                Fill_Size();
                Fill_Style();
                FillStitcher();
            }
            else if (HiddenField2.Value == "Order")
            {
                if (HiddenField3.Value == "Style")
                {
                    ddlStyle.SelectedIndex = 0;
                    
                    if (HiddenField4.Value == "Size")
                    {
                        ddlSize.SelectedIndex = 0;
                        Fill_Style();
                        Fill_Size();
                    }
                    else if (HiddenField4.Value == "Stitcher")
                    {
                        ddlStitcher.SelectedIndex = 0;
                        Fill_Style();
                        FillStitcher();
                    }
                }
                else if (HiddenField3.Value == "Size")
                {
                    ddlSize.SelectedIndex = 0;
                    
                    if (HiddenField4.Value == "Style")
                    {
                        ddlStyle.SelectedIndex = 0;
                        Fill_Size();
                        Fill_Style();
                    }
                    else if (HiddenField4.Value == "Stitcher")
                    {
                        ddlStitcher.SelectedIndex = 0;
                        Fill_Size();
                        FillStitcher();
                    }
                }
                else if (HiddenField3.Value == "Stitcher")
                {
                    ddlStitcher.SelectedIndex = 0;
                    
                    if (HiddenField4.Value == "Style")
                    {
                        ddlStyle.SelectedIndex = 0;
                        FillStitcher();
                        Fill_Style();
                    }
                    else if (HiddenField4.Value == "Size")
                    {
                        ddlSize.SelectedIndex = 0;
                        FillStitcher();
                        Fill_Size();
                    }
                }
            }
            else if (HiddenField3.Value == "Order")
            {
                if (HiddenField4.Value == "Style")
                {
                    ddlStyle.SelectedIndex = 0;
                    Fill_Style();
                }
                else if (HiddenField4.Value == "Size")
                {
                    ddlSize.SelectedIndex = 0;
                    Fill_Size();
                }
                else if (HiddenField4.Value == "Stitcher")
                {
                    ddlStitcher.SelectedIndex = 0;
                    FillStitcher();
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
                else if (HiddenField4.Value == "")
                {
                    HiddenField4.Value = "Order";
                }
            }
            #endregion

            Fill_rbl();
            Fill_PairsBox();
        }
        protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0 && ddlStitcher.SelectedIndex == 0 ||
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
            if (ddlStitcher.SelectedValue == "")
            {
                FillStitcher();
            }

            if (HiddenField1.Value == "Style")
            {
                ddlSize.SelectedIndex = 0;
                ddlOrderNo.SelectedIndex = 0;
                ddlStitcher.SelectedIndex = 0;
                Fill_Size();
                Fill_Order();
                FillStitcher();
            }
            else if (HiddenField2.Value == "Style")
            {
                if (HiddenField3.Value == "Order")
                {
                    ddlOrderNo.SelectedIndex = 0;
                    
                    if (HiddenField4.Value == "Size")
                    {
                        ddlSize.SelectedIndex = 0;
                        Fill_Order();
                        Fill_Size();
                    }
                    else if (HiddenField4.Value == "Stitcher")
                    {
                        ddlStitcher.SelectedIndex = 0;
                        Fill_Order();
                        FillStitcher();
                    }
                }
                else if (HiddenField3.Value == "Size")
                {
                    ddlSize.SelectedIndex = 0;
                    
                    if (HiddenField4.Value == "Order")
                    {
                        ddlOrderNo.SelectedIndex = 0;
                        Fill_Size();
                        Fill_Order();
                    }
                    else if (HiddenField4.Value == "Stitcher")
                    {
                        ddlStitcher.SelectedIndex = 0;
                        Fill_Size();
                        FillStitcher();
                    }
                }
                else if (HiddenField3.Value == "Stitcher")
                {
                    ddlStitcher.SelectedIndex = 0;
                    
                    if (HiddenField4.Value == "Order")
                    {
                        ddlOrderNo.SelectedIndex = 0;
                        FillStitcher();
                        Fill_Order();
                    }
                    else if (HiddenField4.Value == "Size")
                    {
                        ddlSize.SelectedIndex = 0;
                        FillStitcher();
                        Fill_Size();
                    }
                }
            }
            else if (HiddenField3.Value == "Style")
            {
                if (HiddenField4.Value == "Order")
                {
                    ddlOrderNo.SelectedIndex = 0;
                    Fill_Order();
                }
                else if (HiddenField4.Value == "Size")
                {
                    ddlSize.SelectedIndex = 0;
                    Fill_Size();
                }
                else if (HiddenField4.Value == "Stitcher")
                {
                    ddlStitcher.SelectedIndex = 0;
                    FillStitcher();
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
                else if (HiddenField4.Value == "")
                {
                    HiddenField4.Value = "Style";
                }
            }
            #endregion
            Fill_rbl();
            Fill_PairsBox();
        }
        protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0 && ddlStitcher.SelectedIndex == 0 ||
               ddlSize.SelectedIndex == 0 && HiddenField1.Value == "Size")
            {
                btnRefresh_Click(sender, e);
            }
            
            #region Filling Relatively
            if (ddlOrderNo.SelectedValue == "")
            {
                Fill_Order();
            }
            if (ddlStyle.SelectedValue == "")
            {
                Fill_Style();
            }
            if (ddlStitcher.SelectedValue == "")
            {
                FillStitcher();
            }

            if (HiddenField1.Value == "Size")
            {
                ddlStyle.SelectedIndex = 0;
                ddlOrderNo.SelectedIndex = 0;
                ddlStitcher.SelectedIndex = 0;
                Fill_Style();
                Fill_Order();
                FillStitcher();
            }
            else if (HiddenField2.Value == "Size")
            {
                if (HiddenField3.Value == "Order")
                {
                    ddlOrderNo.SelectedIndex = 0;
                    Fill_Order();
                    if (HiddenField4.Value == "Style")
                    {
                        ddlStyle.SelectedIndex = 0;
                        Fill_Style();
                    }
                    else if (HiddenField4.Value == "Stitcher")
                    {
                        ddlStitcher.SelectedIndex = 0;
                        FillStitcher();
                    }
                }
                else if (HiddenField3.Value == "Style")
                {
                    ddlStyle.SelectedIndex = 0;
                    Fill_Style();
                    if (HiddenField4.Value == "Order")
                    {
                        ddlOrderNo.SelectedIndex = 0;
                        Fill_Order();
                    }
                    else if (HiddenField4.Value == "Stitcher")
                    {
                        ddlStitcher.SelectedIndex = 0;
                        FillStitcher();
                    }
                }
                else if (HiddenField3.Value == "Stitcher")
                {
                    ddlStitcher.SelectedIndex = 0;
                    FillStitcher();
                    if (HiddenField4.Value == "Order")
                    {
                        ddlOrderNo.SelectedIndex = 0;
                        Fill_Order();
                    }
                    else if (HiddenField4.Value == "Style")
                    {
                        ddlStyle.SelectedIndex = 0;
                        Fill_Style();
                    }
                }
            }
            else if (HiddenField3.Value == "Size")
            {
                if (HiddenField4.Value == "Order")
                {
                    ddlOrderNo.SelectedIndex = 0;
                    Fill_Order();
                }
                else if (HiddenField4.Value == "Style")
                {
                    ddlStyle.SelectedIndex = 0;
                    Fill_Style();
                }
                else if (HiddenField4.Value == "Stitcher")
                {
                    ddlStitcher.SelectedIndex = 0;
                    FillStitcher();
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
                else if (HiddenField4.Value == "")
                {
                    HiddenField4.Value = "Size";
                }
            }
            #endregion

            Fill_rbl();
            Fill_PairsBox();
        }
        protected void ddlStitcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrderNo.SelectedIndex == 0 && ddlStyle.SelectedIndex == 0 && ddlSize.SelectedIndex == 0 && ddlStitcher.SelectedIndex == 0 ||
               ddlStitcher.SelectedIndex == 0 && HiddenField1.Value == "Stitcher")
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
            if (ddlOrderNo.SelectedValue == "")
            {
                Fill_Order();
            }

            if (HiddenField1.Value == "Stitcher")
            {
                ddlSize.SelectedIndex = 0;
                ddlStyle.SelectedIndex = 0;
                ddlOrderNo.SelectedIndex = 0;
                Fill_Size();
                Fill_Style();
                Fill_Order();
            }
            else if (HiddenField2.Value == "Stitcher")
            {
                if (HiddenField3.Value == "Style")
                {
                    ddlStyle.SelectedIndex = 0;
                    Fill_Style();
                    if (HiddenField4.Value == "Size")
                    {
                        ddlSize.SelectedIndex = 0;
                        Fill_Size();
                    }
                    else if (HiddenField4.Value == "Order")
                    {
                        ddlOrderNo.SelectedIndex = 0;
                        Fill_Order();
                    }
                }
                else if (HiddenField3.Value == "Size")
                {
                    ddlSize.SelectedIndex = 0;
                    Fill_Size();
                    if (HiddenField4.Value == "Style")
                    {
                        ddlStyle.SelectedIndex = 0;
                        Fill_Style();
                    }
                    else if (HiddenField4.Value == "Order")
                    {
                        ddlOrderNo.SelectedIndex = 0;
                        Fill_Order();
                    }
                }
                else if (HiddenField3.Value == "Order")
                {
                    ddlOrderNo.SelectedIndex = 0;
                    Fill_Order();
                    if (HiddenField4.Value == "Style")
                    {
                        ddlStyle.SelectedIndex = 0;
                        Fill_Style();
                    }
                    else if (HiddenField4.Value == "Size")
                    {
                        ddlSize.SelectedIndex = 0;
                        Fill_Size();
                    }
                }
            }
            else if (HiddenField3.Value == "Stitcher")
            {
                if (HiddenField4.Value == "Style")
                {
                    ddlStyle.SelectedIndex = 0;
                    Fill_Style();
                }
                else if (HiddenField4.Value == "Size")
                {
                    ddlSize.SelectedIndex = 0;
                    Fill_Size();
                }
                else if (HiddenField4.Value == "Order")
                {
                    ddlOrderNo.SelectedIndex = 0;
                    Fill_Order();
                }
            }
            
            if (ddlStitcher.SelectedValue != "")
            {
                if (HiddenField1.Value == "")
                {
                    HiddenField1.Value = "Stitcher";
                }
                else if (HiddenField2.Value == "")
                {
                    HiddenField2.Value = "Stitcher";
                }
                else if (HiddenField3.Value == "")
                {
                    HiddenField3.Value = "Stitcher";
                }
                else if (HiddenField4.Value == "")
                {
                    HiddenField4.Value = "Stitcher";
                }
            }
            #endregion

            Fill_rbl();
            Fill_PairsBox();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidatePage())
            {
                InsertStitching();
                ClearFields();
            }

        }


        protected bool ValidatePage()
        {
            bool flag = true;
            #region Stitching
            Stitching _Stitching = new Stitching();

            _Stitching.Employee_ID = int.Parse(ddlStitcher.SelectedValue);
            _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
            _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);
            _Stitching.Date_Issued = Convert.ToDateTime(rblDateOfIssuance.SelectedValue);

            _Stitching.Pairs_Rec = int.Parse(txtPairs.Text);

            #endregion

            validatingPairs(ref _Stitching);


            if (flag == false)
                lblMessage.ForeColor = System.Drawing.Color.Red;
            else
                lblMessage.ForeColor = System.Drawing.Color.Green;
            return flag;
        }
        protected void validatingPairs(ref Stitching _Stitching)
        {
            DataTable dt = Stitching_DA.Get_Pairs_From_Stitching(_Stitching);
            if (dt.Rows.Count > 0)
            {
                if (_Stitching.Pairs_Rec > int.Parse(dt.Rows[0][0].ToString()))
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
            _Stitching.Contractor_ID = int.Parse(ddlContractor.SelectedValue);

            _Stitching.Order_ID = int.Parse(ddlOrderNo.SelectedValue);
            _Stitching.Style_ID = int.Parse(ddlStyle.SelectedValue);
            _Stitching.Size_ID = int.Parse(ddlSize.SelectedValue);

            _Stitching.Date_Issued = Convert.ToDateTime(rblDateOfIssuance.SelectedValue);
            _Stitching.Pairs_Rec = int.Parse(txtPairs.Text);
            _Stitching.Date_Rec = Convert.ToDateTime(txtDate.Text);
            _Stitching.Description = txtDescription.Text;
            _Stitching.IsDeleted = false;
            #endregion

            lblMessage.Text += Stitching_DA.InsertStitching(_Stitching);

            lblMessage.ForeColor = System.Drawing.Color.Green;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlStitcher.SelectedIndex = 0;
            ddlOrderNo.SelectedIndex = 0;
            ddlStyle.SelectedIndex = 0;
            ddlSize.SelectedIndex = 0;

            HiddenField1.Value = "";
            HiddenField2.Value = "";
            HiddenField3.Value = "";
            HiddenField4.Value = "";


            Fill_Order();
            Fill_Size();
            Fill_Style();
            FillStitcher();

            txtPairs.Text = "";

        }
        protected void ClearFields()
        {
            ddlStitcher.SelectedIndex = 0;
            ddlContractor.SelectedIndex = 0;

            ddlOrderNo.SelectedIndex = 0;
            ddlStyle.SelectedIndex = 0;
            ddlSize.SelectedIndex = 0;
            rblDateOfIssuance.Items.Clear();

            HiddenField1.Value = "";
            HiddenField2.Value = "";
            HiddenField3.Value = "";
            HiddenField4.Value = "";

            Fill_Order();
            Fill_Size();
            Fill_Style();
            FillStitcher();

            txtPairs.Text = "";
            txtDescription.Text = "";
            txtDate.Text = "";
        }

        protected void rblDateOfIssuance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_PairsBox();
        }
    }
}