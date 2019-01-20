using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WMS1._0.BAL;
using System.Data;

namespace WMS1._0.WebPages
{
    public partial class AssignWHtoRUser : System.Web.UI.Page
    {
        ReportUserBL obj = new ReportUserBL();
        WHouseBL objWHBL = new WHouseBL();
        Common com = new Common();
        CompanyBL cmpany = new CompanyBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCompanyDLL();
                BindUserDLL();
                BindGrid(ddlUser.SelectedValue, ddlCompany.SelectedValue);


            }
        }

        private void BindUserDLL()
        {
            DataSet ds = new DataSet();
            ds = obj.GetReportUserList(ddlCompany.SelectedValue);
            ddlUser.DataSource = ds;
            ddlUser.DataTextField = "Name";
            ddlUser.DataValueField = "Id";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0,new ListItem("--SELECT--","0"));

        }

        private void BindCompanyDLL()
        {
            DataSet ds = new DataSet();
            ds = cmpany.GetCompany();
            ddlCompany.DataSource = ds;
            ddlCompany.DataTextField = "CompanyName";
            ddlCompany.DataValueField = "Id";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }

        protected string getNextId()
        {
            return com.GetNextId("WH", "warehouse");
        }
        protected void BindGrid(string userId, string companyId)
        {
            DataSet ds = new DataSet();
            ds = obj.GetRPTUserWarehouse(userId, companyId);

            gvWH.DataSource = ds;
            gvWH.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int flag = Insert();
            if (flag > 0)
            {
                lblmsg.Text = "Company Added Successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                BindGrid(ddlUser.SelectedValue, ddlCompany.SelectedValue);
                ClearControls();

            }
            if (flag == -1)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Company Already Exist";

            }
        }

        private int Insert()
        {
            int flag = 0;

            obj.Delete_AssignWHToUser(ddlUser.SelectedValue);
            foreach (GridViewRow row in gvWH.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("cbwh") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string whid = gvWH.DataKeys[row.RowIndex].Value.ToString();
                        flag = obj.Insert_AssignWHToUser(whid, ddlUser.SelectedValue);
                    }
                }
            }

            return flag;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void ClearControls()
        {

        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUserDLL();
            BindGrid(ddlUser.SelectedValue, ddlCompany.SelectedValue);

        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(ddlUser.SelectedValue, ddlCompany.SelectedValue);
        }
    }
}