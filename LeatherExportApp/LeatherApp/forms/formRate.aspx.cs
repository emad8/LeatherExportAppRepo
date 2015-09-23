using DataAccess;
using DataAccess.App_Code;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeatherExportApp.forms
{
    public partial class formRate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                Fill_Style();
                Fill_Size();
            }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertRate();
            if (Constants.SUCESS_INSERT == lblMessage.Text)
            {
                ClearFields();
            }

        }

        protected void InsertRate()
        {
            #region Rate
            Rate _Rate = new Rate();
            _Rate.Style_ID = int.Parse(ddlStyle.SelectedValue);
            _Rate.Size_ID = int.Parse(ddlSize.SelectedValue);
            _Rate.Standard_Value = float.Parse(txtStandardValue.Text);
            if (txtCuttingRate.Text != "")
                _Rate.Cutting_Rate = float.Parse(txtCuttingRate.Text);
            if (txtElasticStitchingRate.Text != "")
                _Rate.Elastic_Stitching = float.Parse(txtElasticStitchingRate.Text);
            if (txtOverlock.Text != "")
                _Rate.OverLock = float.Parse(txtOverlock.Text);
            if (txtContractorCommision.Text != "")
                _Rate.Contractor_Commission = float.Parse(txtContractorCommision.Text);
            if (txtbindingrate.Text != "")
                _Rate.BindingRate = float.Parse(txtbindingrate.Text);
            if (txtGloveStitchingRate.Text != "")
                _Rate.GloveStitchingRate = float.Parse(txtGloveStitchingRate.Text);


            _Rate.IsDeleted = false;
            #endregion

            lblMessage.Text = Rate_DA.InsertRate(_Rate);

            lblMessage.ForeColor = System.Drawing.Color.Green;
        }

        protected void ClearFields()
        {
            ddlSize.SelectedIndex = 0;
            ddlStyle.SelectedIndex = 0;

            txtStandardValue.Text = "";
            txtCuttingRate.Text = "";
            txtElasticStitchingRate.Text = "";
            txtContractorCommision.Text = "";
            txtOverlock.Text = "";
            txtbindingrate.Text = "";
            txtGloveStitchingRate.Text = "";

        }
    }
}