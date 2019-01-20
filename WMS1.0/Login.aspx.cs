using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WMS1._0.BAL;

namespace WMS1._0
{
    public partial class Login : System.Web.UI.Page
    {
        Common obj = new Common();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_btnLogin(object sender, EventArgs e)
        {
            string userType = obj.Login(txtUserName.Text, txtPassword.Text);
            if (userType.Equals("NR"))
            {
                pnlmessage.Visible = true;
            }
            else
            {
                
                Session["userType"] = userType;
                Session["userName"] = txtUserName.Text;
                Response.Redirect("~/Default.aspx");

                //switch (userType)
                //{
                //    case "SuperAdmin":
                //        Response.Redirect("");
                //        break;
                //    case "Company":
                //        Response.Redirect("");

                //        break;
                //    case "User":
                //        Response.Redirect("");

                //        break;

                //}
            }
        }
    }
}