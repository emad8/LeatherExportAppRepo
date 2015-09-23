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
    public partial class formWadaGhata : System.Web.UI.Page
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
            Fill_Lot1();
            divLot2.Visible = false;
        }
        private void Fill_Lot1()
        {
            DataTable dt = Cutting_DA.Get_ddl_Lots_Sum_Of_Sqft_Pcs();
            if (dt.Rows.Count==0)
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
            ValidatePage();

            InsertWadaGhata();
            ClearFields();
            InitialFill();

        }

        protected void UpdateDeliveryForWadaGhata()
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

            _Cutting.Lot_1 = int.Parse(ddlLot1.SelectedValue);
            _Cutting.Pcs = int.Parse(txtPcs.Text);
            _Cutting.Sqft = float.Parse(txtSqFt.Text);

            if (divLot2.Visible == true)
            {
                _Cutting.Lot_2 = int.Parse(ddlLot2.SelectedValue);
                _Cutting.Pcs2 = int.Parse(txtPcs2.Text);
                _Cutting.Sqft2 = float.Parse(txtSqFt2.Text);
            }

            #endregion

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

        protected void InsertWadaGhata()
        {
            #region WadaGhata
            WadaGhata _WadaGhata = new WadaGhata();

            _WadaGhata.Lot_1 = int.Parse(ddlLot1.SelectedValue);
            if (ddlLot2.SelectedValue != "")
            {
                _WadaGhata.Lot_2 = int.Parse(ddlLot2.SelectedValue);
                _WadaGhata.Pcs2 = int.Parse(txtPcs2.Text);
                _WadaGhata.Sqft2 = float.Parse(txtSqFt2.Text);
            }
            _WadaGhata.Pcs = int.Parse(txtPcs.Text);
            _WadaGhata.Sqft = float.Parse(txtSqFt.Text);
            _WadaGhata.Date = Convert.ToDateTime(txtDate.Text);
            _WadaGhata.Description = txtDescription.Text;

            _WadaGhata.IsDeleted = false;
            #endregion


            lblMessage.Text += WadaGhata_DA.InsertWadaGhata(_WadaGhata);
            if (!lblMessage.Text.Contains(Constants.ALREADY_EXIST))
            {
                UpdateDeliveryForWadaGhata();
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
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

        protected void ClearFields()
        {
            ddlLot1.SelectedIndex = 0;
            ddlLot2.SelectedIndex = 0;

            txtPcs.Text = "";
            txtSqFt.Text = "";
            txtPcs2.Text = "";
            txtSqFt2.Text = "";
            txtDate.Text = "";
            txtDescription.Text = "";

            lblLot1Pcs.Text = "";
            lblLot1Sqft.Text = "";
            lblLot2Pcs.Text = "";
            lblLot2Sqft.Text = "";


        }

        protected void btnLot2_Click(object sender, EventArgs e)
        {
            divLot2.Visible = !divLot2.Visible;
        }
    }
}