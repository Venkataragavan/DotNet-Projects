using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dllDoctorDetails
{
    public class clsDoctorDetails
    {
        string strDocID, strDocName, strDocSpeciality, strDocDesc, strClinicID;
        public string DoctorID
        {
            get { return strDocID; }
            set { strDocID = value; }
        }
        public string DoctorName
        {
            get { return strDocName; }
            set { strDocName = value; }
        }
        public string DoctorSpeciality
        {
            get { return strDocSpeciality; }
            set { strDocSpeciality = value; }
        }
        public string DoctorDesc
        {
            get { return strDocDesc; }
            set { strDocDesc = value; }
        }
        public string ClinicID
        {
            get { return strClinicID; }
            set { strClinicID = value; }
        }


        public clsDoctorDetails()
        { }

    }
}
