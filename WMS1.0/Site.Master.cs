using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WMS1._0.BAL;
using System.Data;

namespace WMS1._0
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common obj = new Common();
            string userType = Session["userType"].ToString();
            DataSet userds = obj.GetUserDetails(userType, Session["userName"].ToString());

            lblUserName.Text = "Welcome <b>" + userds.Tables[0].Rows[0]["UserName"].ToString() + "</b>";
            Session["CompanyId"] = userds.Tables[0].Rows[0]["CompanyId"].ToString();
            switch (userType)
            {
                case "SuperAdmin":
                    NavigationMenu.Items.Add(new MenuItem("Register Company", "ADDCMP", "", "~/WebPages/AddCompany.aspx"));
                    NavigationMenu.Items.Add(new MenuItem("Active WH", "AWH", "", "~/WebPages/ActiveWH.aspx"));
                    NavigationMenu.Items.Add(new MenuItem("Reports", "RPT", "", "~/Reports/SAReport.aspx"));
                    
                    break;
                case "Company":
                    NavigationMenu.Items.Add(new MenuItem("Register Warehouse", "ADDWH", "", "~/WebPages/AddWarehouse.aspx"));
                    NavigationMenu.Items.Add(new MenuItem("Register Report User", "ADUSER", "", "~/WebPages/AddReportUser.aspx"));
                    NavigationMenu.Items.Add(new MenuItem("Assign WH to User", "ASSWH", "", "~/WebPages/AssignWHtoRUser.aspx"));
                    NavigationMenu.Items.Add(new MenuItem("Reports", "RPT", "", "~/WebPages/CReport.aspx"));
                  
                    break;
                case "User":

                    NavigationMenu.Items.Add(new MenuItem("Reports", "RPT", "", "~/WebPages/UReport.aspx"));

                    break;

            }
        }

        protected void lbtnLogout_OnClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}
