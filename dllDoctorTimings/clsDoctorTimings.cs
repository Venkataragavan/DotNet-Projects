using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dllDoctorTimings
{
    public class clsDoctorTimings
    {
        string strDocID;
        DateTime strAvDate;
        TimeSpan strDocSTime, strDocETime;

        public string DoctorID
        {
            get { return strDocID; }
            set { strDocID = value; }
        }
        public DateTime AvDate
        {
            get { return strAvDate; }
            set { strAvDate = value; }
        }
        public TimeSpan DocSTime
        {
            get { return strDocSTime; }
            set { strDocSTime = value; }
        }
        public TimeSpan DocETime
        {
            get { return strDocETime; }
            set { strDocETime = value; }
        }

        public clsDoctorTimings()
        { }
        
    }
}
