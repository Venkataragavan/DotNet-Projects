using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using dllPatient;
using dllOperations;
using dllClinic;

namespace dllOperations
{
    
    public class clsOperations
    {
        string generatedUID = null;
        SqlConnection con;
        SqlCommand cmdSUp,cmdSpec,cmdLogin,cmdGetDocID,cmdDocFromTime,cmdDocEndTime,cmdUpdateTime,cmdGetClinicID,cmdInsAppTable;
        SqlDataAdapter da,daSpec;
        public clsOperations()
        {

            con = new SqlConnection(@"Data Source =INCHOL0278844\DOTNETCON; user id= sa; password=system;Initial Catalog=dbClinic");
            cmdSUp = new SqlCommand("sp_SignUp",con);
            cmdSpec = new SqlCommand("sp_GetSpecfromArea", con);
            cmdLogin = new SqlCommand("sp_Login",con);
            cmdGetDocID = new SqlCommand("sp_GetDocID",con);
            cmdDocFromTime = new SqlCommand("sp_GetDocStartTime", con);
            cmdDocEndTime = new SqlCommand("sp_GetDocEndTime",con);
            cmdUpdateTime = new SqlCommand("sp_UpdateStartTime", con);
            cmdGetClinicID = new SqlCommand("sp_GetClinicID",con);
            cmdInsAppTable = new SqlCommand("sp_CreateAppointment", con);


            cmdSpec.Parameters.Add("@Area", SqlDbType.VarChar, 20);
            cmdGetDocID.Parameters.Add("@DocName",SqlDbType.VarChar,20);
            cmdGetDocID.Parameters.Add("@DocSpec",SqlDbType.VarChar,20);
            cmdDocFromTime.Parameters.Add("@DocID", SqlDbType.Char, 4);
            cmdDocFromTime.Parameters.Add("@Date",SqlDbType.Date);
            cmdDocEndTime.Parameters.Add("@DocID", SqlDbType.Char, 4);
            cmdDocEndTime.Parameters.Add("@Date", SqlDbType.Date);
            cmdUpdateTime.Parameters.Add("@DocID",SqlDbType.Char,4);
            cmdUpdateTime.Parameters.Add("@Date",SqlDbType.Date);
            cmdUpdateTime.Parameters.Add("@StartTime",SqlDbType.Time);
            cmdGetClinicID.Parameters.Add("@CName",SqlDbType.VarChar,20);
            cmdGetClinicID.Parameters.Add("@Location",SqlDbType.VarChar,20);
            cmdInsAppTable.Parameters.Add("@AppID",SqlDbType.Char,4);
            cmdInsAppTable.Parameters.Add("@PatientID", SqlDbType.Char, 4);
            cmdInsAppTable.Parameters.Add("@ClinicID", SqlDbType.Char, 4);
            cmdInsAppTable.Parameters.Add("@DoctorID", SqlDbType.Char, 4);
            cmdInsAppTable.Parameters.Add("@AppDate", SqlDbType.DateTime);
            cmdInsAppTable.Parameters.Add("@AppSTime",SqlDbType.Time);
            cmdInsAppTable.Parameters.Add("@AppEndTime", SqlDbType.Time);




        }
        public bool signup(string UN,string Pwd,string PhNo)
        {
            bool bRes = false;
            string UID=generateID();
            generatedUID = UID;
            cmdSUp.Parameters.Add(new SqlParameter("@UserID",UID));
            cmdSUp.Parameters.Add(new SqlParameter("@UserName",UN));
            cmdSUp.Parameters.Add(new SqlParameter("@Password",Pwd));
            cmdSUp.Parameters.Add(new SqlParameter("@PhoneNo",PhNo));
            cmdSUp.CommandType = CommandType.StoredProcedure;
            if (con.State == ConnectionState.Open)
            { con.Close(); }
            con.Open();
            int iRes = cmdSUp.ExecuteNonQuery();
            if (iRes > 0)
                bRes = true;
            con.Close();
             return bRes;

            

        }
        string generateID()
        {
            string strRet = null;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string strOld = new SqlCommand("select Max(cPatient_ID) from tblPatient", con).ExecuteScalar().ToString();
            con.Close();
            int iPID = Convert.ToInt32(strOld.Substring(1, 3));
            iPID++;
            if (iPID > 0 && iPID < 10)
                strRet = "P00" + iPID;
            else if (iPID >= 10 && iPID < 100)
                strRet = "P0" + iPID;
            else if (iPID >= 100 && iPID < 1000)
                strRet = "P" + iPID;

            return strRet;
        }

        public List<string> GetArea()
        {
            List<string> objArea = new List<string>();
            DataSet dsArea = new DataSet();
            da = new SqlDataAdapter("Select distinct(vcLocation) from tblClinic",con);
            da.Fill(dsArea,"Area");
            foreach(DataRow item in dsArea.Tables["Area"].Rows)
            {
                objArea.Add(item["vcLocation"].ToString());
            }

            return objArea;
        }

        public List<string> GetSpeciality(string Area)
        {
            cmdSpec.CommandType = CommandType.StoredProcedure;
            cmdSpec.Parameters[0].Value = Area;
            
            // cmdSpec.Parameters.Add(new SqlParameter("@Area", Area));
            List<string> objSpec = new List<string>();
            DataSet dsSpec = new DataSet();
            daSpec=new SqlDataAdapter(cmdSpec);
            daSpec.Fill(dsSpec,"Speciality");
            foreach(DataRow item in dsSpec.Tables["Speciality"].Rows)
            {
                objSpec.Add(item["vcSpeciality"].ToString());
            }
            return objSpec;

        }

        public bool LoginValid(string UN, string Pwd)
        {
            bool bRes = false;
            clsPatient objP = new clsPatient();
            SqlCommand cmd = new SqlCommand("sp_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PatientID", UN));
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            object objPass = cmd.ExecuteScalar();
            if (objPass != null)
            {
                string strPass = objPass.ToString();
                if (strPass.Equals(Pwd))
                    bRes = true;
            }
            return bRes;
        }


        public string GetDocID(string DocName,string Speciality)
        {
            string DocID = null;
            cmdGetDocID.CommandType = CommandType.StoredProcedure;
            cmdGetDocID.Parameters[0].Value = DocName;
            cmdGetDocID.Parameters[1].Value = Speciality;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            object objPass = cmdGetDocID.ExecuteScalar();
            if (objPass != null)
            {
                DocID = objPass.ToString();
            }

            return DocID;
        }


        public TimeSpan GetDocFromTime (string DocID, string Date)
        {
            DateTime docft = Convert.ToDateTime(Date);
            TimeSpan DocFT = TimeSpan.Parse(docft.ToShortTimeString());
            cmdDocFromTime.CommandType = CommandType.StoredProcedure;
            cmdDocFromTime.Parameters[0].Value = DocID;
            cmdDocFromTime.Parameters[1].Value = Convert.ToDateTime(Date) ;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            object objPass = cmdDocFromTime.ExecuteScalar();
            if (objPass != null)
            {
                DocFT = TimeSpan.Parse(objPass.ToString());
            }
            return DocFT; 

        }

        public DateTime GetDocToTime(string DocID, string Date)
        {
            DateTime DocET = Convert.ToDateTime(Date);
            cmdDocEndTime.CommandType = CommandType.StoredProcedure;
            cmdDocEndTime.Parameters[0].Value = DocID;
            cmdDocEndTime.Parameters[1].Value = DocET;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            object objPass = cmdDocEndTime.ExecuteScalar();
            if (objPass != null)
            {
                DocET = Convert.ToDateTime(objPass.ToString());
            }
            return DocET;
        }

        public bool UpdateTime(string DocID,string Date,TimeSpan time)
        {
            bool bRes=false;
           
            cmdUpdateTime.CommandType = CommandType.StoredProcedure;
            cmdUpdateTime.Parameters[0].Value = DocID;
            cmdUpdateTime.Parameters[1].Value = Convert.ToDateTime(Date);
            cmdUpdateTime.Parameters[2].Value = time;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (cmdUpdateTime.ExecuteNonQuery() > 0)
            {
                bRes = true;
            }
            return bRes;
        }

        public string GetClinicID(string ClinicName, string Location)
        {
            string strClinicID = null;
            cmdGetClinicID.CommandType = CommandType.StoredProcedure;
            cmdGetClinicID.Parameters[0].Value = ClinicName;
            cmdGetClinicID.Parameters[1].Value = Location;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            object objPass = cmdGetClinicID.ExecuteScalar();
            if (objPass != null)
            {
                strClinicID = objPass.ToString();
            }
            return strClinicID;
        }

        public string generateAppID()
        {
            string strRet = null;
            try
            {   //string strRet = null;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                string strOld = new SqlCommand("select Max(cAppoint_ID) from tblAppointment", con).ExecuteScalar().ToString();
                con.Close();
                int iPID = Convert.ToInt32(strOld.Substring(1, 3));
                iPID++;
                if (iPID > 0 && iPID < 10)
                    strRet = "A00" + iPID;
                else if (iPID >= 10 && iPID < 100)
                    strRet = "A0" + iPID;
                else if (iPID >= 100 && iPID < 1000)
                    strRet = "A" + iPID;
            }
            catch (Exception)
            {
                strRet = "A001";
                
            }

            return strRet;
        }


        public bool InsertInAppTable(string AppID, string PID, string DocID, string ClinID, DateTime DDate, TimeSpan AppSTime, TimeSpan AppETime)
        {
            bool bRes = false;
            cmdInsAppTable.CommandType = CommandType.StoredProcedure;
            cmdInsAppTable.Parameters[0].Value = AppID;
            cmdInsAppTable.Parameters[1].Value = PID;
            cmdInsAppTable.Parameters[2].Value = ClinID;
            cmdInsAppTable.Parameters[3].Value = DocID;
            cmdInsAppTable.Parameters[4].Value = DDate;
            cmdInsAppTable.Parameters[5].Value = AppSTime;
            cmdInsAppTable.Parameters[6].Value = AppETime;
            if (con.State == ConnectionState.Open)
            { con.Close(); }
            con.Open();
            int iRes = cmdInsAppTable.ExecuteNonQuery();
            if (iRes > 0)
                bRes = true;
            con.Close();
            return bRes;
        }


        public string UserID()
        {
            return generatedUID;
        }
    }
}
