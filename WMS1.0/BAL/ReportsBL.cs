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
    public class ReportsBL
    {
        string con = ConfigurationManager.AppSettings["DBConnectionString"].ToString();

        public DataSet GetCompanyList(string SPName)
        {
            DataSet ds = new DataSet();            
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, SPName);
            return ds;
        }
        public DataSet GetReportList(string userType)
        {
            DataSet ds = new DataSet();
            string Spname = "Get_reportList";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userType", SqlDbType.NVarChar, 50);
            param[0].Value = userType;

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, Spname, param);
            return ds;
        }
    }
}