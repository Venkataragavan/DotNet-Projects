using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dllAppointment
{
    public class clsAppointment
    {
        string strAppID, strPatientID, strClinicID, strDoctorID, strAppDate, strAppSTime, strAppETime;

        public string AppID
        {
            get { return strAppID; }
            set { strAppID = value; }
        }
        public string PatientID
        {
            get { return strPatientID; }
            set { strPatientID = value; }
        }
        public string ClinicID
        {
            get { return strClinicID; }
            set { strClinicID = value; }
        }
        public string DoctorID
        {
            get { return strDoctorID; }
            set { strDoctorID = value; }
        }
        public string AppDate
        {
            get { return strAppDate; }
            set { strAppDate = value; }
        }
        public string AppSTime
        {
            get { return strAppSTime; }
            set { strAppSTime = value; }
        }
        public string AppETime
        {
            get { return strAppETime; }
            set { strAppETime = value; }
        }
        public clsAppointment()
        {
        }
        


    }
}
