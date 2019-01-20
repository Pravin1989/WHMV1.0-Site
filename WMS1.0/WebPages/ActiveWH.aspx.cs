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
    public partial class ActiveWH : System.Web.UI.Page
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
                BindGrid(ddlCompany.SelectedValue);


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
            ddlCompany.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }
               
        protected void BindGrid( string companyId)
        {
            DataSet ds = new DataSet();
            ds = objWHBL.GetWHList(ddlCompany.SelectedValue);

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
                BindGrid(ddlCompany.SelectedValue);
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

            
            foreach (GridViewRow row in gvWH.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("cbwh") as CheckBox);
                    TextBox txtExpiryDate = (row.Cells[6].FindControl("txtExpiryDate") as TextBox);
                    TextBox txtPassword = (row.Cells[7].FindControl("txtPassword") as TextBox);
                    if (chkRow.Checked)
                    {
                        DateTime expiry = Convert.ToDateTime(txtExpiryDate.Text);
                        string whid = gvWH.DataKeys[row.RowIndex].Value.ToString();
                        flag = objWHBL.ActiveWH(whid, ddlCompany.SelectedValue, expiry, txtPassword.Text);
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
            
            BindGrid( ddlCompany.SelectedValue);

        }
    }
}