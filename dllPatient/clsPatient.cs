using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dllPatient
{
    public class clsPatient
    {
        string strPatientID, strPatientName, strPatientPass, strPatientPhone;
        public string PatientID
        {
            get { return strPatientID; }
            set { strPatientID = value; }
        }
        public string PatientName
        {
            get { return strPatientName; }
            set { strPatientName = value; }
        }
        public string PatientPass
        {
            get { return strPatientPass; }
            set { strPatientPass = value; }
        }
        public string PatientPhone
        {
            get { return strPatientPhone; }
            set { strPatientPhone = value; }
        }

        public clsPatient()
        { }
    }
}
