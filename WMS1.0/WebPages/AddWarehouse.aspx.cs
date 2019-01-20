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
    public partial class AddWarehouse : System.Web.UI.Page
    {
        WHouseBL objBL = new WHouseBL();
        Common com = new Common();
        CompanyBL cmpany = new CompanyBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!btnUpdate.Visible)
            {
                txtWHId.Text = getNextId();
                
            }
            txtWHId.Enabled = false;

            if (!Page.IsPostBack)
            {
                txtStartDate.Text = DateTime.Now.ToShortDateString();
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
            return com.GetNextId("WH", "warehouse");
        }
        protected void BindGrid()
        {
            DataSet ds = new DataSet();
            ds = objBL.GetWHList(Session["CompanyId"].ToString());

            gvWH.DataSource = ds;
            gvWH.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int flag = Insert();
            if (flag > 0)
            {
                lblmsg.Text = "Warehouse Added Successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                BindGrid();
                ClearControls();
                txtWHId.Text = getNextId();
                txtWHId.Enabled = false;
            }
            if (flag == -1)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Warehouse Already Exist";

            }
        }

        private int Insert()
        {
            return objBL.InsertWarehouse(txtWHId.Text.Trim(), ddlCompany.SelectedValue, txtName.Text, txtEmail.Text, txtContactNo.Text, txtContactPerson.Text, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtStartDate.Text), txtAddress.Text);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void ClearControls()
        {
            txtAddress.Text = txtContactNo.Text = txtEmail.Text = txtName.Text = txtContactPerson.Text = string.Empty;
        }
        protected void gvWH_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = gvWH.DataKeys[e.RowIndex].Value.ToString();
            objBL.deleteWarehouse(Id);
            BindGrid();
        }


        protected void gvWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string whid = gvWH.SelectedDataKey.Value.ToString();
            DataSet ds = objBL.getWarehouse_ById(whid);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtWHId.Text = Convert.ToString(ds.Tables[0].Rows[0]["WHId"]);
                                
                txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["WHName"]);
                txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                txtContactNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContactNo"]);
                txtContactPerson.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContactPerson"]);
                txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                txtStartDate.Text = DateTime.Today.ToShortDateString();
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int flag = objBL.UpdateWH(txtWHId.Text, txtName.Text, txtAddress.Text, txtContactNo.Text, txtContactPerson.Text, txtEmail.Text);
            if (flag > 0)
            {
                lblmsg.Text = "Updated Successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                BindGrid();
                ClearControls();
                txtWHId.Text = getNextId();
                txtWHId.Enabled = false;
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            if (flag == -1)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Error";

            }
            BindGrid();
        }
    }
}