using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dllClinic
{
    public class clsClinic
    {

        string strClinicID, strClinicName, strClinicLocation;
        public string ClinicID
        {
            get { return strClinicID; }
            set { strClinicID = value; }
        }
        public string ClinicName
        {
            get { return strClinicName; }
            set { strClinicName = value; }
        }
        public string ClinicLocation
        {
            get { return strClinicLocation; }
            set { strClinicLocation = value; }
        }

        public clsClinic()
        { }
    
    }
}
