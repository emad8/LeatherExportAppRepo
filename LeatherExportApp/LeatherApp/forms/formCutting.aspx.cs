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
    public partial class formCutting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                InitialFill();
            }
        }
        private void InitialFill()
        {
            Fill_Order();
            Fill_Size();
            Fill_Style();
            Fill_Lot1();
            Fill_Company();
            FillCutterNMarket();
            divLot2.Visible = false;
            ShowTotalCutted();
        }

        private void Fill_Company()
        {

            DataView dv = (DataView)SqlCompany.Select(DataSourceSelectArguments.Empty);
            DataTable dt = dv.ToTable();
            if (dt.Rows.Count == 0)
                ddlCompany.Items.Clear();
            else
            {
                ddlCompany.DataSource = dt;
                ddlCompany.DataBind();
            }
            ddlCompany.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));



        }
        private void ShowTotalCutted()
        {
            DataTable dt = Cutting_DA.Get_Total_Cutted_Pcs_Sqft();
            if (dt.Rows.Count > 0)
            {
                spanCuttedPcsSqft.InnerHtml = "";
                spanCuttedPcsSqft.InnerHtml += "Total Cutted so far &nbsp;&nbsp;&nbsp; Pcs : " + dt.Rows[0][0].ToString();
                spanCuttedPcsSqft.InnerHtml += "&nbsp;&nbsp;&nbsp; Sqft : " + dt.Rows[0][1].ToString();
            }
        }

        private void Fill_Lot1()
        {
            DataTable dt = Cutting_DA.Get_ddl_Lots_Sum_Of_Sqft_Pcs();
            if (dt.Rows.Count == 0)
                ddlLot1.Items.Clear();
            else
            {
                ddlLot1.DataSource = dt;
                ddlLot1.DataBind();
            }
                ddlLot1.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (divMarket.Visible == false)
            {
                ValidatePage();
            }
            InsertCutting();
            ClearFields();

        }

        protected void UpdateDeliveryForInstockCutting()
        {
            int BalancePcs = int.Parse(txtPcs.Text);
            float BalanceSqft = float.Parse(txtSqFt.Text);

            DataTable dt = Cutting_DA.Get_Delivery_By_LotId(ddlLot1.SelectedValue);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int pcs = int.Parse(dt.Rows[i][0].ToString());
                float sqft = float.Parse(dt.Rows[i][1].ToString());
                if (pcs >= BalancePcs && sqft >= BalanceSqft || i == dt.Rows.Count - 1)
                {
                    Cutting_DA.Update_Delivery_By_LotId_For_Pcs_Sqft(BalancePcs, BalanceSqft, dt.Rows[i][2].ToString());
                    BalancePcs = 0;
                    BalanceSqft = 0;
                    break;
                }
                else
                {
                    Cutting_DA.Update_Delivery_By_LotId_For_Pcs_Sqft(pcs, sqft, dt.Rows[i][2].ToString());
                    BalancePcs -= pcs;
                    BalanceSqft -= sqft;
                }
            }

            if (divLot2.Visible == true)
            {
                BalancePcs = int.Parse(txtPcs2.Text);
                BalanceSqft = float.Parse(txtSqFt2.Text);

                DataTable dt2 = Cutting_DA.Get_Delivery_By_LotId(ddlLot2.SelectedValue);

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    int pcs = int.Parse(dt2.Rows[i][0].ToString());
                    float sqft = float.Parse(dt2.Rows[i][1].ToString());
                    if (pcs >= BalancePcs && sqft >= BalanceSqft || i == dt2.Rows.Count - 1)
                    {
                        Cutting_DA.Update_Delivery_By_LotId_For_Pcs_Sqft(BalancePcs, BalanceSqft, dt2.Rows[i][2].ToString());
                        BalancePcs = 0;
                        BalanceSqft = 0;
                        break;
                    }
                    else
                    {
                        Cutting_DA.Update_Delivery_By_LotId_For_Pcs_Sqft(pcs, sqft, dt2.Rows[i][2].ToString());
                        BalancePcs -= pcs;
                        BalanceSqft -= sqft;
                    }
                }
            }

        }

        protected bool ValidatePage()
        {
            bool flag = true;
            #region Cutting
            Cutting _Cutting = new Cutting();
            if (ddlCutter.SelectedValue != "")
                _Cutting.Employee = int.Parse(ddlCutter.SelectedValue);
            else
                _Cutting.Company = int.Parse(ddlCompany.SelectedValue);

            if (ddlOrderNo.SelectedValue != "")
                _Cutting.Order = int.Parse(ddlOrderNo.SelectedValue);

            if (ddlStyle.SelectedValue != "")
                _Cutting.Style = int.Parse(ddlStyle.SelectedValue);

            if (ddlSize.SelectedValue != "")
                _Cutting.Size = int.Parse(ddlSize.SelectedValue);

            if (divPcsSqft.Visible == true)
            {
                _Cutting.Lot_1 = int.Parse(ddlLot1.SelectedValue);
                _Cutting.Pcs = int.Parse(txtPcs.Text);
                _Cutting.Sqft = float.Parse(txtSqFt.Text);

                if (divLot2.Visible == true)
                {
                    _Cutting.Lot_2 = int.Parse(ddlLot2.SelectedValue);
                    _Cutting.Pcs2 = int.Parse(txtPcs2.Text);
                    _Cutting.Sqft2 = float.Parse(txtSqFt2.Text);
                }


            }
            _Cutting.Pairs = int.Parse(txtPairs.Text);

            #endregion

            validatingPairs(ref _Cutting);

            if (ddlCutter.SelectedValue != "")
                validating_Pcs_Sqft_For_Cutter(ref _Cutting);
            //else
            //validating_Pcs_Sqft_For_Company(ref flag, ref _Cutting);

            if (flag == false)
                lblMessage.ForeColor = System.Drawing.Color.Red;
            else
                lblMessage.ForeColor = System.Drawing.Color.Green;
            return flag;
        }

        private void validating_Pcs_Sqft_For_Cutter(ref Cutting _Cutting)
        {

            DataTable dt1 = Cutting_DA.Get_Lot_Pcs_Sqft(_Cutting.Lot_1.ToString());
            if (dt1.Rows.Count > 0)
            {
                if (_Cutting.Pcs > int.Parse(dt1.Rows[0][0].ToString()))
                {
                    lblMessage.Text += "Using More Pcs then Then you have in Lot1 </br>";
                }
                if (_Cutting.Sqft > float.Parse(dt1.Rows[0][1].ToString()))
                {
                    lblMessage.Text += "Using More Sqft then Then you have in Lot1 </br>";
                }
            }

            if (_Cutting.Lot_2 != null)
            {
                DataTable dt2 = Cutting_DA.Get_Lot_Pcs_Sqft(_Cutting.Lot_2.ToString());
                if (_Cutting.Pcs2 > int.Parse(dt2.Rows[0][0].ToString()))
                {
                    lblMessage.Text += "Using More Pcs then you have in Lot2 </br>";
                }
                if (_Cutting.Sqft2 > float.Parse(dt2.Rows[0][1].ToString()))
                {
                    lblMessage.Text += "Using More Sqft then you have in Lot2 </br>";
                }
            }

        }

        private void validating_Pcs_Sqft_For_Company(ref bool flag, ref Cutting _Cutting)
        {

        }

        protected void validatingPairs(ref Cutting _Cutting)
        {
            DataTable dt = Cutting_DA.Get_Pairs(_Cutting);
            if (dt.Rows.Count > 0)
            {
                if (_Cutting.Pairs > int.Parse(dt.Rows[0][0].ToString()))
                {
                    lblMessage.Text += "Making More Pairs then required </br>";
                }
            }
        }

        protected void InsertCutting()
        {
            #region Cutting
            Cutting _Cutting = new Cutting();
            if (ddlCutter.SelectedValue != "")
            {
                _Cutting.Employee = int.Parse(ddlCutter.SelectedValue);
            }
            if (ddlCompany.SelectedValue != "")
            {
                _Cutting.Company = int.Parse(ddlCompany.SelectedValue);
            }
            if (ddlMarket.SelectedValue != "")
            {
                _Cutting.Market = int.Parse(ddlMarket.SelectedValue);
            }
            _Cutting.Order = int.Parse(ddlOrderNo.SelectedValue);
            _Cutting.Style = int.Parse(ddlStyle.SelectedValue);
            _Cutting.Size = int.Parse(ddlSize.SelectedValue);
            _Cutting.Pairs = int.Parse(txtPairs.Text);
            if (divPcsSqft.Visible == true)
            {
                _Cutting.Lot_1 = int.Parse(ddlLot1.SelectedValue);
                _Cutting.Pcs = int.Parse(txtPcs.Text);
                _Cutting.Sqft = float.Parse(txtSqFt.Text);
            }

            if (divLot2.Visible == true)
            {
                _Cutting.Lot_2 = int.Parse(ddlLot2.SelectedValue);
                _Cutting.Pcs2 = int.Parse(txtPcs2.Text);
                _Cutting.Sqft2 = float.Parse(txtSqFt2.Text);
            }


            _Cutting.Date = Convert.ToDateTime(txtDate.Text);
            _Cutting.Description = txtDescription.Text;
            _Cutting.Gp_No = txtGp_No.Text;
            _Cutting.Remarks = txtRemarks.Text;
            _Cutting.Is_Paid = false;
            _Cutting.IsDeleted = false;
            #endregion

            lblMessage.Text += Cutting_DA.InsertCutting(_Cutting);
            if (!lblMessage.Text.Contains(Constants.ALREADY_EXIST))
            {
                if (ddlCutter.SelectedValue != "")
                {
                    UpdateDeliveryForInstockCutting();
                }
                else if (ddlCompany.SelectedValue != "")
                {
                    Cutting_DA.Update_Outstock_For_Cutting(ddlCompany.SelectedValue);
                }
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void FillCutterNMarket()
        {
            ddlCutter.DataSource = sqlCutter;
            ddlCutter.DataBind();
            ddlCutter.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));

            ddlMarket.DataSource = SqlMarket;
            ddlMarket.DataBind();
            ddlMarket.Items.Insert(0, new ListItem(Constants.SELECT_HERE, ""));

        }

        protected void ddlCutter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCutter.SelectedValue != "")
            {
                divCompany.Visible = false;
                divMarket.Visible = false;
                ddlCompany.SelectedIndex = 0;
                ddlMarket.SelectedIndex = 0;
            }
            else
            {
                divCompany.Visible = true;
                divMarket.Visible = true;
            }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompany.SelectedValue != "")
            {
                divCutter.Visible = false;
                ddlCutter.SelectedIndex = 0;

                divMarket.Visible = false;
                ddlMarket.SelectedIndex = 0;

                divPcsSqft.Visible = false;
            }
            else
            {
                divCutter.Visible = true;
                divMarket.Visible = true;
                divPcsSqft.Visible = true;
            }
        }
        protected void ddlMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMarket.SelectedValue != "")
            {
                divCutter.Visible = false;
                ddlCutter.SelectedIndex = 0;
                divCompany.Visible = false;
                ddlCompany.SelectedIndex = 0;
                divPcsSqft.Visible = false;
            }
            else
            {
                divCutter.Visible = true;
                divCompany.Visible = true;
                divPcsSqft.Visible = true;
            }
        }

        protected void ddlLot1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLot1.SelectedValue != "")
            {
                DataTable dt = Cutting_DA.Get_Lot_Pcs_Sqft(ddlLot1.SelectedValue);

                if (dt.Rows.Count > 0)
                {
                    lblLot1Pcs.Text = "Pcs: " + dt.Rows[0][0].ToString();
                    lblLot1Sqft.Text = "   Sqft: " + dt.Rows[0][1].ToString();
                }
                else
                {
                    lblLot1Pcs.Text = "";
                    lblLot1Sqft.Text = "";
                }

                //divLot2.Visible = true;
                dt = Cutting_DA.Get_ddl_Lots_Sum_Of_Sqft_Pcs();
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
                //divLot2.Visible = false;
                ddlLot2.SelectedIndex = 0;
            }
        }

        protected void ddlLot2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLot2.SelectedValue != "")
            {
                DataTable dt = Cutting_DA.Get_Lot_Pcs_Sqft(ddlLot2.SelectedValue);

                if (dt.Rows.Count > 0)
                {
                    lblLot2Pcs.Text = "Pcs: " + dt.Rows[0][0].ToString();
                    lblLot2Sqft.Text = "   Sqft: " + dt.Rows[0][1].ToString();
                }
                else
                {
                    lblLot2Pcs.Text = "";
                    lblLot2Sqft.Text = "";
                }
            }
            else
            {
                lblLot2Pcs.Text = "";
                lblLot2Sqft.Text = "";
            }
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
                else if (HiddenField3.Value == "Size")
                {
                    ddlStyle.SelectedIndex = 0;
                    Fill_Size();
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
            Cutting _Cutting = new Cutting();
            if (ddlOrderNo.SelectedValue != "")
            {
                _Cutting.Order = int.Parse(ddlOrderNo.SelectedValue);
            }
            if (ddlStyle.SelectedValue != "")
            {
                _Cutting.Style = int.Parse(ddlStyle.SelectedValue);
            }
            if (ddlSize.SelectedValue != "")
            {
                _Cutting.Size = int.Parse(ddlSize.SelectedValue);
            }

            DataTable dt = Cutting_DA.Get_Style(_Cutting);

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
            Cutting _Cutting = new Cutting();
            if (ddlOrderNo.SelectedValue != "")
            {
                _Cutting.Order = int.Parse(ddlOrderNo.SelectedValue);
            }
            if (ddlStyle.SelectedValue != "")
            {
                _Cutting.Style = int.Parse(ddlStyle.SelectedValue);
            }
            if (ddlSize.SelectedValue != "")
            {
                _Cutting.Size = int.Parse(ddlSize.SelectedValue);
            }

            DataTable dt = Cutting_DA.Get_Size(_Cutting);

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
            Cutting _Cutting = new Cutting();
            if (ddlOrderNo.SelectedValue != "")
            {
                _Cutting.Order = int.Parse(ddlOrderNo.SelectedValue);
            }
            if (ddlStyle.SelectedValue != "")
            {
                _Cutting.Style = int.Parse(ddlStyle.SelectedValue);
            }
            if (ddlSize.SelectedValue != "")
            {
                _Cutting.Size = int.Parse(ddlSize.SelectedValue);
            }

            DataTable dt = Cutting_DA.Get_Order(_Cutting);

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
                Cutting _Cutting = new Cutting();

                _Cutting.Order = int.Parse(ddlOrderNo.SelectedValue);

                _Cutting.Style = int.Parse(ddlStyle.SelectedValue);

                _Cutting.Size = int.Parse(ddlSize.SelectedValue);

                DataTable dt = Cutting_DA.Get_Pairs(_Cutting);

                if (dt.Rows.Count > 0)
                {
                    txtPairs.Text = dt.Rows[0][0].ToString();
                    lblShippingDate.Text = Convert.ToDateTime(dt.Rows[0][1].ToString()).ToString("MM/dd/yyyy");
                    //txtDate.Text = Convert.ToDateTime(dt.Rows[0][1].ToString()).ToString("yyyy-MM-dd");
                }
                else
                {
                    txtPairs.Text = "";
                    lblShippingDate.Text = "";
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
            ddlCutter.SelectedIndex = 0;
            ddlCompany.SelectedIndex = 0;
            ddlMarket.SelectedIndex = 0;
            ddlOrderNo.SelectedIndex = 0;
            ddlStyle.SelectedIndex = 0;
            ddlSize.SelectedIndex = 0;
            ddlLot1.SelectedIndex = 0;
            //ddlLot2.SelectedIndex = 0;

            Fill_Order();
            Fill_Size();
            Fill_Style();
            Fill_Lot1();
            Fill_Company();

            txtPairs.Text = "";
            txtPcs.Text = "";
            txtSqFt.Text = "";
            txtPcs2.Text = "";
            txtSqFt2.Text = "";
            txtDate.Text = "";
            txtDescription.Text = "";
            txtRemarks.Text = "";
            txtGp_No.Text = "";

            lblLot1Pcs.Text = "";
            lblLot1Sqft.Text = "";
            lblLot2Pcs.Text = "";
            lblLot2Sqft.Text = "";
            lblShippingDate.Text = "";
        }

        protected void btnLot2_Click(object sender, EventArgs e)
        {
            divLot2.Visible = !divLot2.Visible;
        }
    }
}