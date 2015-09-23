using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeatherExportApp.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Page.User.Identity!=null)
            //{
            //    Response.Redirect("~/forms/Default.aspx");
            //}
            RegisterHyperLink.NavigateUrl = "Register";
            ForgetPasswordHyperlink.NavigateUrl = "ForgetPassword";

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }
    }
}