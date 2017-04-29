using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dllDoctorTimings;
using dllDoctorDetails;
using System.Data;
using System.Data.SqlClient;

namespace prjClinic
{
    public class clsDoctimeAdmin
    {
        SqlConnection con;
        SqlCommand cmdIns, cmdUpd, cmdDel;
        clsDoctorTimings objDT;
        SqlDataAdapter daDocID;
        public clsDoctimeAdmin()
        {
            con = new SqlConnection(@"Data Source=INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
            
        }


        public bool InsertDoctime(clsDoctorTimings objD)
        {
            //con = new SqlConnection(@"Data Source=INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
            SqlCommand cmdIns = new SqlCommand("sp_InsertDoctortime", con);
            cmdIns.Parameters.Add("@DoctorID", SqlDbType.Char, 4);
            cmdIns.Parameters.Add("@AvDate", SqlDbType.Date);
            cmdIns.Parameters.Add("@DocSTime", SqlDbType.Time);
            cmdIns.Parameters.Add("@DocETime", SqlDbType.Time);

            cmdIns.CommandType = CommandType.StoredProcedure;

            bool bRes = false;
            cmdIns.Parameters[0].Value = objD.DoctorID;
            cmdIns.Parameters[1].Value = objD.AvDate;
            cmdIns.Parameters[2].Value = objD.DocSTime;
            cmdIns.Parameters[3].Value = objD.DocETime;

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


        //public bool UpdateCommand(clsDoctorTimings objD)
        //{

        //    con = new SqlConnection(@"Data Source=INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
        //    SqlCommand cmdUpd = new SqlCommand("sp_UpdateDoctorTime1", con);
        //    cmdUpd.Parameters.Add("@DoctorID", SqlDbType.Char, 4);
        //    cmdUpd.Parameters.Add("@AvDate", SqlDbType.Date);
        //    cmdUpd.Parameters.Add("@DocSTime", SqlDbType.Time);
        //    cmdUpd.Parameters.Add("@DocETime", SqlDbType.Time);

        //    cmdUpd.CommandType = CommandType.StoredProcedure;

        //    bool bRes = false;
        //    cmdUpd.Parameters[0].Value = objD.DoctorID;
        //    cmdUpd.Parameters[1].Value = objD.AvDate;
        //    cmdUpd.Parameters[2].Value = objD.DocSTime;
        //    cmdUpd.Parameters[3].Value = objD.DocETime;

        //    if (con.State == System.Data.ConnectionState.Open)
        //        con.Close();
        //    con.Open();
        //    if (cmdUpd.ExecuteNonQuery() > 0)
        //        bRes = true;
        //    else
        //        bRes = false;
        //    con.Close();
        //    return bRes;
        //}

        public List<string> GetDoctorID()
        {
            List<string> objDocID = new List<string>();
            DataSet dsDocID = new DataSet();
            daDocID = new SqlDataAdapter("Select cDoctor_ID from tblDoctors", con);
            daDocID.Fill(dsDocID, "DoctorID");
            foreach (DataRow item in dsDocID.Tables["DoctorID"].Rows)
            {
                objDocID.Add(item["cDoctor_ID"].ToString());
            }
            return objDocID;
        }

    }
}
