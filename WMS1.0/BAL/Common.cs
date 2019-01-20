using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace WMS1._0.BAL
{
    public class Common
    {
        string con = ConfigurationManager.AppSettings["DBConnectionString"].ToString();

        public string GetNextId(string preText, string tableName)
        {
            object nextid = new object();
            string Spname = "Proc_GetNextId";

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@preText", SqlDbType.NVarChar, 100);
            param[0].Value = preText;
            param[1] = new SqlParameter("@TableName", SqlDbType.NVarChar, 100);
            param[1].Value = tableName;

            nextid = SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, Spname, param);

            return nextid.ToString();
        }
        public string Login(string userName, string Password)
        {

            object userType = new object();
            string Spname = "proc_Login";

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@userName", SqlDbType.NVarChar, 100);
            param[0].Value = userName;
            param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 100);
            param[1].Value = Password;

            userType = SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, Spname, param);
            
            return userType.ToString();
        }
        public DataSet GetUserDetails(string userType, string userId)
        {
            DataSet ds = new DataSet();
            string Spname = "get_userDetails";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@userType", SqlDbType.NVarChar, 50);
            param[0].Value = userType;
            param[1] = new SqlParameter("@userId", SqlDbType.NVarChar, 50);
            param[1].Value = userId;

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, Spname, param);
            return ds;
        }
    }
}