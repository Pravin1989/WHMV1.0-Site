using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace WMS1._0.BAL
{
    public class ReportUserBL
    {
        string con = ConfigurationManager.AppSettings["DBConnectionString"].ToString();

        public DataSet GetReportUserList(string CompanyId)
        {
            DataSet ds = new DataSet();
            string Spname = "Get_ReportUserList";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CompanyId", SqlDbType.NVarChar, 50);
            param[0].Value = CompanyId;

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, Spname, param);
            return ds;
        }

        public DataSet GetRPTUserWarehouse(string userId,string companyId)
        {
            DataSet ds = new DataSet();
            string Spname = "Proc_GetRPTUserWarehouse";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CompanyId", SqlDbType.NVarChar, 50);
            param[0].Value = companyId;
            param[1] = new SqlParameter("@userId", SqlDbType.NVarChar, 50);
            param[1].Value = userId;

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, Spname, param);
            return ds;
        }

        internal int InsertReportUser(string UserID, string password, string Name, string Email, string contactNumber, string Possition, string CompanyId)
        {
            int flag = 0;
            string Spname = "Insert_ReportUser";

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ReportUserId", SqlDbType.NVarChar, 50);
            param[0].Value = UserID;
            param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            param[1].Value = password;
            param[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 150);
            param[2].Value = Name;
            param[3] = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            param[3].Value = Email;
            param[4] = new SqlParameter("@ContactNo", SqlDbType.NVarChar, 50);
            param[4].Value = contactNumber;
            param[5] = new SqlParameter("@Position", SqlDbType.NVarChar, 150);
            param[5].Value = Possition;
            param[6] = new SqlParameter("@CompanyId", SqlDbType.Int);
            param[6].Value = CompanyId;           

            flag = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Spname, param);

            return flag;

        }

        internal int Insert_AssignWHToUser(string WHID, string UserID)
        {
            int flag = 0;
            string Spname = "Insert_AssignWHToUser";

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@WHId", SqlDbType.NVarChar, 50);
            param[0].Value = WHID;
            param[1] = new SqlParameter("@RptUserId", SqlDbType.NVarChar, 50);
            param[1].Value = UserID;
            

            flag = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Spname, param);

            return flag;

        }

        internal int Delete_AssignWHToUser( string UserID)
        {
            int flag = 0;
            string Spname = "Delete_AssignWHToUser";

            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@RptUserId", SqlDbType.NVarChar, 50);
            param[0].Value = UserID;


            flag = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Spname, param);

            return flag;

        }

    }
}