using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using dllDoctorDetails;

namespace prjClinic
{
    public class clsDocAdmin
    {
        SqlConnection con;
        SqlCommand cmdIns, cmdUpd, cmdDel,cmdDocIDL;
        SqlDataAdapter daCID,daDID,daDIDL;
        clsDoctorDetails objD; 
        public clsDocAdmin()
        {
            con = new SqlConnection(@"Data Source = INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
            //SqlCommand cmdIns = new SqlCommand("sp_InsertDoctor", con);
            cmdDocIDL = new SqlCommand("sp_GetDoctorID",con);
            cmdDocIDL.Parameters.Add("@ClinicID",SqlDbType.Char,4);
            cmdDocIDL.CommandType = CommandType.StoredProcedure;
        }
     
        public bool InsertDoc(clsDoctorDetails objD)
        {
            //con = new SqlConnection(@"Data Source = INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
            SqlCommand cmdIns = new SqlCommand("sp_InsertDoctor", con);
            cmdIns.Parameters.Add("@DoctorID", SqlDbType.Char, 4);
            cmdIns.Parameters.Add("@DoctorName", SqlDbType.VarChar, 50);
            cmdIns.Parameters.Add("@DoctorSpeciality", SqlDbType.VarChar, 50);
            cmdIns.Parameters.Add("@DoctorDesc", SqlDbType.VarChar, 1000);
            cmdIns.Parameters.Add("@ClinicID", SqlDbType.Char, 4);
            cmdIns.CommandType = CommandType.StoredProcedure;
            
            bool bRes = false;
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmdIns.Parameters[0].Value = objD.DoctorID;
            cmdIns.Parameters[1].Value = objD.DoctorName;
            cmdIns.Parameters[2].Value = objD.DoctorSpeciality;
            cmdIns.Parameters[3].Value = objD.DoctorDesc;
            cmdIns.Parameters[4].Value = objD.ClinicID;
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

        public bool DeleteCommand(clsDoctorDetails objD)
        {
           // con = new SqlConnection(@"Data Source = INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
            SqlCommand cmdDel = new SqlCommand("sp_DeleteDoctor", con);
            cmdDel.Parameters.Add("@DoctorID", SqlDbType.Char, 4);
            cmdDel.CommandType = CommandType.StoredProcedure;

            bool bRes = false;

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            con.Open();
            cmdDel.Parameters[0].Value = objD.DoctorID;
            if (cmdDel.ExecuteNonQuery() > 0)
                bRes = true;
            con.Close();
            return bRes;
        }
        public bool UpdateCommand(clsDoctorDetails objD)
        {

           // con = new SqlConnection(@"Data Source = INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
            SqlCommand cmdUpd = new SqlCommand("sp_UpdateDoctor", con);
            cmdUpd.Parameters.Add("@DoctorID", SqlDbType.Char, 4);
            cmdUpd.Parameters.Add("@DoctorName", SqlDbType.VarChar, 50);
            cmdUpd.Parameters.Add("@DoctorSpeciality", SqlDbType.VarChar, 50);
            cmdUpd.Parameters.Add("@DoctorDesc", SqlDbType.VarChar, 1000);
            cmdUpd.Parameters.Add("@ClinicID", SqlDbType.Char, 4);

            cmdUpd.CommandType = CommandType.StoredProcedure;
            
            bool bRes = false;
            cmdUpd.Parameters[0].Value = objD.DoctorID;
            cmdUpd.Parameters[1].Value = objD.DoctorName;
            cmdUpd.Parameters[2].Value = objD.DoctorSpeciality;
            cmdUpd.Parameters[3].Value = objD.DoctorDesc;
            cmdUpd.Parameters[4].Value = objD.ClinicID;
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            con.Open();
            if (cmdUpd.ExecuteNonQuery() > 0)
                bRes = true;
            else
                bRes = false;
            con.Close();
            return bRes;
        }

        public string GenerateNewDocID()
        {
            string DocID = null;
            //con = new SqlConnection(@"Data Source = INCHOL0278844\DOTNETCON;user id=sa;password=system;Initial Catalog=dbClinic");
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string strOld = new SqlCommand("select Max(cDoctor_ID) from tblDoctors", con).ExecuteScalar().ToString();
            con.Close();
            int iDID = Convert.ToInt32(strOld.Substring(1, 3));
            iDID++;
            if (iDID > 0 && iDID < 10)
                DocID = "D00" + iDID;
            else if (iDID >= 10 && iDID < 100)
                DocID = "D0" + iDID;
            else if (iDID >= 100 && iDID < 1000)
                DocID = "D" + iDID;

            return DocID;
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
        public List<string> GetDoctorID()
        {
            
            List<string> objDID = new List<string>();
            DataSet dsDocID = new DataSet();
            daDID = new SqlDataAdapter("Select cDoctor_ID from tblDoctors", con);
            daDID.Fill(dsDocID, "DoctorID");
            foreach (DataRow item in dsDocID.Tables["DoctorID"].Rows)
            {
                objDID.Add(item["cDoctor_ID"].ToString());
            }
            return objDID;
        }

        public List<string> GetDoctorID(string ClinicId)
        {
            SqlCommand cmdgetdoctorid = new SqlCommand("GetDoctorID", con);


            con.Open();

            cmdgetdoctorid.CommandType = CommandType.StoredProcedure;
            cmdgetdoctorid.Parameters.Add("@ClinicID", SqlDbType.VarChar, 100);
            cmdgetdoctorid.Parameters[0].Value = ClinicId;

            List<string> objDID = new List<string>();
            DataSet dsDocID = new DataSet();

            daDID = new SqlDataAdapter(cmdgetdoctorid);
            daDID.Fill(dsDocID, "DoctorID");
            foreach (DataRow item in dsDocID.Tables["DoctorID"].Rows)
            {
                objDID.Add(item["cDoctor_ID"].ToString());
            }
            return objDID; 
        }
    }
}
