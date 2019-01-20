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
    public partial class AddReportUser : System.Web.UI.Page
    {
        ReportUserBL objBL = new ReportUserBL();
        Common com = new Common();
        CompanyBL cmpany = new CompanyBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtWHId.Text = getNextId();
            txtWHId.Enabled = false;

            if (!Page.IsPostBack)
            {
                BindCompanyDLL();
                ddlCompany.Items.FindByValue(Session["CompanyId"].ToString()).Selected = true;
                ddlCompany.Enabled = false;
                BindGrid();
            }
        }

        private void BindCompanyDLL()
        {
            DataSet ds = new DataSet();
            ds = cmpany.GetCompany();
            ddlCompany.DataSource = ds;
            ddlCompany.DataTextField = "CompanyName";
            ddlCompany.DataValueField = "Id";
            ddlCompany.DataBind();
        }
        protected string getNextId()
        {
            return com.GetNextId("USR", "ReportUser");
        }
        protected void BindGrid()
        {
            DataSet ds = new DataSet();
            ds = objBL.GetReportUserList(ddlCompany.SelectedValue);

            gvWH.DataSource = ds;
            gvWH.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int flag = Insert();
            if (flag > 0)
            {
                lblmsg.Text = "Record Added Successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                BindGrid();
                ClearControls();
                txtWHId.Text = getNextId();
                txtWHId.Enabled = false;
            }
            if (flag == -1)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Record Already Exist";

            }
        }

        private int Insert()
        {
            return objBL.InsertReportUser(txtWHId.Text, txtPassword.Text, txtName.Text, txtEmail.Text, txtContactNo.Text, txtPossition.Text, ddlCompany.SelectedValue);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void ClearControls()
        {
            txtPassword.Text = txtContactNo.Text = txtEmail.Text = txtName.Text = txtPossition.Text = string.Empty;
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}