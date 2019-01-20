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
    public partial class AddCompany : System.Web.UI.Page
    {
        CompanyBL objBL = new CompanyBL();
        Common com = new Common();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();

                txtCompanyId.Text = getNextId();
                txtCompanyId.Enabled = false;
            }
        }
        protected string getNextId()
        {
            return com.GetNextId("COMP", "company");
        }
        protected void BindGrid()
        {
            DataSet ds = new DataSet();
            ds = objBL.GetCompany();

            gvCompany.DataSource = ds;
            gvCompany.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int flag = Insert();
            if (flag > 0)
            {
                lblmsg.Text = "Company Added Successfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                BindGrid();
                EmailService email = new EmailService();
                string body = "Your company registration get comlpeted. <br/> use below credential to login userName :" + txtCompanyId.Text + " Password:- " + txtCompanyId.Text;
                //email.sendMail(txtEmail.Text, "djayholepatil@gmail.com", "Company Registration Completed.", body);
                //EmailService.SendingMail("djayholepatil@gmail.com", txtEmail.Text, "Company Registration Completed.", body);
                ClearControls();
                txtCompanyId.Text = getNextId();
                txtCompanyId.Enabled = false;
                
            }
            if (flag == -1)
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Company Already Exist";

            }
        }

        private int Insert()
        {
            return objBL.InsertCompany(txtCompanyId.Text.Trim(), txtCompanyName.Text.Trim(), txtEmail.Text.Trim(), txtContactNo.Text.Trim(),txtContactPerson.Text.Trim(), txtAddress.Text.Trim());

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void ClearControls()
        {
            txtAddress.Text = txtContactNo.Text = txtEmail.Text = txtCompanyName.Text = txtContactPerson.Text= string.Empty;
        }
        protected void gvCompany_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = gvCompany.DataKeys[e.RowIndex].Value.ToString();
            objBL.deleteCompany(Id);
            BindGrid();
        }

    }
}