using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using dllClinic;

namespace prjClinic
{
    public class clsAdminClinic
    {
        SqlConnection con;
        SqlCommand cmdIns, cmdUpd, cmdDel;
        SqlDataAdapter daCID;
        clsClinic objC;
        public clsAdminClinic()
        {
            con = new SqlConnection(@"Data Source=INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
  
        }
        public bool InsertClinic(clsClinic objC)
        {
           
            SqlCommand cmdIns = new SqlCommand("sp_InsertClinic", con);
            cmdIns.Parameters.Add("@ClinicID", SqlDbType.Char, 4);
            cmdIns.Parameters.Add("@ClinicName", SqlDbType.VarChar, 50);
            cmdIns.Parameters.Add("@ClinicLocation", SqlDbType.VarChar, 50);
            cmdIns.CommandType = CommandType.StoredProcedure;

            bool bRes = false;
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmdIns.Parameters[0].Value = objC.ClinicID;
            cmdIns.Parameters[1].Value = objC.ClinicName;
            cmdIns.Parameters[2].Value = objC.ClinicLocation;
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            int iRes = cmdIns.ExecuteNonQuery();
            con.Close();
            if (iRes > 0)
                bRes = true;
            return bRes;
        }
        //public bool DeleteCommand(clsClinic objC)
        //{
        //   // con = new SqlConnection(@"Data Source = INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
        //    SqlCommand cmdDel = new SqlCommand("sp_DeleteClinic", con);
        //    cmdDel.Parameters.Add("@ClinicID", SqlDbType.Char, 4);
        //    cmdDel.CommandType = CommandType.StoredProcedure;

        //    bool bRes = false;

        //    if (con.State == System.Data.ConnectionState.Open)
        //        con.Close();
        //    con.Open();
        //    cmdDel.Parameters[0].Value = objC.ClinicID;
        //    if (cmdDel.ExecuteNonQuery() > 0)
        //        bRes = true;
        //    con.Close();
        //    return bRes;
        //}
        public bool UpdateCommand(clsClinic objC)
        {
            
                //con = new SqlConnection(@"Data Source = INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
                SqlCommand cmdUpd = new SqlCommand("sp_UpdateClinic", con);
                cmdUpd.Parameters.Add("@ClinicID", SqlDbType.Char, 4);
                cmdUpd.Parameters.Add("@ClinicName", SqlDbType.VarChar, 50);
                cmdUpd.Parameters.Add("@ClinicLocation", SqlDbType.VarChar, 50);
                cmdUpd.CommandType = CommandType.StoredProcedure;

                bool bRes = false;
                cmdUpd.Parameters[0].Value = objC.ClinicID;
                cmdUpd.Parameters[1].Value = objC.ClinicName;
                cmdUpd.Parameters[2].Value = objC.ClinicLocation;
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Open();
                if (cmdUpd.ExecuteNonQuery() > 0)
                    bRes = true;
                con.Close();
            
            
            return bRes;
        }

        public string GenerateNewClinicID()
        {
            string ClinicID = null;
            //con = new SqlConnection(@"Data Source = INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string strOld = new SqlCommand("select Max(cClinic_ID) from tblClinic", con).ExecuteScalar().ToString();
            con.Close();
            int iCID = Convert.ToInt32(strOld.Substring(1, 3));
            iCID++;
            if (iCID > 0 && iCID < 10)
                ClinicID = "C00" + iCID;
            else if (iCID >= 10 && iCID < 100)
                ClinicID = "C0" + iCID;
            else if (iCID >= 100 && iCID < 1000)
                ClinicID = "C" + iCID;

            return ClinicID;
        }

        public List<string> GetClinicID()
        {
            List<string> objCID = new List<string>();
            DataSet dsclinicID = new DataSet();
            daCID = new SqlDataAdapter("Select cClinic_ID from tblClinic", con);
            daCID.Fill(dsclinicID, "ClinicID");
            foreach (DataRow item in dsclinicID.Tables["ClinicID"].Rows)
            {
                objCID.Add(item["cClinic_ID"].ToString());
            }

            return objCID;
        }
    }
}
