using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WMS1._0.BAL;

namespace WMS1._0.Account
{
    public partial class Login : System.Web.UI.Page
    {
        Common obj = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
        protected void btnLogin_btnLogin(object sender, EventArgs e)
        {
            string userType =  obj.Login(LoginUser.UserName, LoginUser.Password);
            if (string.IsNullOrEmpty(userType))
            {
                pnlmessage.Visible = true;
            }
            else
            {
                switch (userType)
                {
                    case "SuperAdmin":

                        break;
                    case "Company":

                        break;
                    case "User":

                        break;
                    
                }
            }
        }
    }
}
