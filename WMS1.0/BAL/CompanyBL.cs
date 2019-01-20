using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WMS1._0.BAL
{
    public class CompanyBL
    {
        string con = ConfigurationManager.AppSettings["DBConnectionString"].ToString();

        public DataSet GetCompany()
        {
            DataSet ds = new DataSet();
            string Spname = "Get_Company";

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, Spname);
            return ds;
        }


        internal int InsertCompany(string CompanyId ,string CompanyName, string Email, string contactNumber,string contactPerson, string address)
        {
            int flag = 0;
            string Spname = "Insert_Company";

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@CompanyId", SqlDbType.NVarChar, 100);
            param[0].Value = CompanyId;
            param[1] = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 100);
            param[1].Value = CompanyName;
            param[2] = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            param[2].Value = Email;
            param[3] = new SqlParameter("@ContactNo", SqlDbType.NVarChar, 20);
            param[3].Value = contactNumber;
            param[4] = new SqlParameter("@ContactPerson", SqlDbType.NVarChar, 150);
            param[4].Value = contactPerson;
            param[5] = new SqlParameter("@Address", SqlDbType.NVarChar, 500);
            param[5].Value = address;

            flag = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Spname, param);

            return flag;

        }

        internal int deleteCompany(string CompanyId)
        {
            int flag = 0;
            string Spname = "Delete_Company";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CompanyId", SqlDbType.NVarChar, 100);
            param[0].Value = CompanyId;
            flag = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Spname, param);

            return flag;
        }
    }
}