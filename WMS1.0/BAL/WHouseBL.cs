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
    public class WHouseBL
    {
        string con = ConfigurationManager.AppSettings["DBConnectionString"].ToString();

        public DataSet GetWHList(string CompanyId)
        {
            DataSet ds = new DataSet();
            string Spname = "Get_Warehouse";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CompanyId", SqlDbType.NVarChar, 50);
            param[0].Value = CompanyId;

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, Spname, param);
            return ds;
        }


        internal int InsertWarehouse(string WHID,string CompanyId, string WHName, string Email, string contactNumber, string contactPerson,DateTime startDate, DateTime ExpiryDate, string address)
        {
            int flag = 0;
            string Spname = "Insert_Warehouse";

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@WHId", SqlDbType.NVarChar, 50);
            param[0].Value = WHID;
            param[1] = new SqlParameter("@CompanyId", SqlDbType.NVarChar, 50);
            param[1].Value = CompanyId;
            param[2] = new SqlParameter("@WHName", SqlDbType.NVarChar, 150);
            param[2].Value = WHName;
            param[3] = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            param[3].Value = Email;
            param[4] = new SqlParameter("@ContactNo", SqlDbType.NVarChar, 50);
            param[4].Value = contactNumber;
            param[5] = new SqlParameter("@ContactPerson", SqlDbType.NVarChar, 150);
            param[5].Value = contactPerson;
            param[6] = new SqlParameter("@StartDate", SqlDbType.DateTime);
            param[6].Value = startDate;
            param[7] = new SqlParameter("@ExpiryDate", SqlDbType.DateTime);
            param[7].Value = ExpiryDate;
            param[8] = new SqlParameter("@Address", SqlDbType.NVarChar, 500);
            param[8].Value = address;
            

            flag = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Spname, param);

            return flag;

        }

        internal int ActiveWH(string WHID, string CompanyId, DateTime ExpiryDate, string password)
        {
            int flag = 0;
            string Spname = "Proc_ActiveWH";

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@CompanyId", SqlDbType.NVarChar, 50);
            param[0].Value = WHID;
            param[1] = new SqlParameter("@WHID", SqlDbType.NVarChar, 50);
            param[1].Value = CompanyId;
            param[2] = new SqlParameter("@ExpiryDate", SqlDbType.DateTime);
            param[2].Value = ExpiryDate;
            param[3] = new SqlParameter("@password", SqlDbType.NVarChar, 50);
            param[3].Value = password;
            

            flag = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Spname, param);

            return flag;

        }
        
        internal int deleteWarehouse(string Id)
        {

            int flag = 0;
            string Spname = "Delete_Warehouse";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@WHID", SqlDbType.NVarChar, 100);
            param[0].Value = Id;
            flag = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Spname, param);

            return flag;
        }


        internal DataSet getWarehouse_ById(string whid)
        {
            DataSet ds = new DataSet();
            string Spname = "getwarehouse_byId";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@WHID", SqlDbType.NVarChar, 50);
            param[0].Value = whid;

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, Spname, param);
            return ds;
        }

        internal int UpdateWH(string WHID,string Name, string Address, string ContactNo, string ContactPerson,string Email)
        {
            int flag = 0;
            string Spname = "Update_Warehouse";

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@WHId", SqlDbType.NVarChar, 50);
            param[0].Value = WHID;            
            param[1] = new SqlParameter("@WHName", SqlDbType.NVarChar, 150);
            param[1].Value = Name;
            param[2] = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            param[2].Value = Email;
            param[3] = new SqlParameter("@ContactNo", SqlDbType.NVarChar, 50);
            param[3].Value = ContactNo;
            param[4] = new SqlParameter("@ContactPerson", SqlDbType.NVarChar, 150);
            param[4].Value = ContactPerson;            
            param[5] = new SqlParameter("@Address", SqlDbType.NVarChar, 500);
            param[5].Value = Address;


            flag = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, Spname, param);

            return flag;
        }
    }
}