using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Outlook_Project
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            UserDetails user = new UserDetails();
            user=GetLoginDetails();
            Console.WriteLine("User Details are {0} and {1}", user.email, user.password);
            ReadMail(user);
            Console.ReadKey();

        }

        private static void ReadMail(UserDetails user1)
        {
            Outlook.Application application = new Outlook.Application();
            Microsoft.Office.Interop.Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");
            nameSpace.Logon(user1.email, user1.password);//, Missing.Value, Missing.Value);

            Console.WriteLine("Accounts: {0}", nameSpace.Accounts.Count);
            MAPIFolder inboxfolder = nameSpace.Folders[nameSpace.Accounts[1].DisplayName].Folders["Inbox"];
            Console.WriteLine("Name: {0}", nameSpace.Accounts[1].DisplayName);
            int count = 1;
            string mailtime = "2017/10/15";
            DateTime receivetime = new DateTime();
            DateTime.TryParse(mailtime, out receivetime);
            Outlook.Items restricteditems = null;

            string sFilter = ("[ReceivedTime] > '" + receivetime.ToString() + "' ");
            

            foreach (Outlook.MailItem item in inboxfolder.Items)
            {

                 restricteditems= inboxfolder.Items.Restrict(sFilter);
            }
            


            

            
                foreach (Outlook.MailItem mailitem in restricteditems)
                {
                    #region Start
                    Console.WriteLine("{0} Found {1} Subject is: {2} Time received is: {3}", count, mailitem.SenderEmailAddress.ToString(),mailitem.Subject,mailitem.ReceivedTime);
                //if (mailitem.SenderEmailAddress.Equals("cvenkataragavan@gmail.com"))
                //        {
                //            DateTime systemdate = new DateTime(2017, 10, 15, 05, 33, 00);
                //            if(mailitem.Subject.ToString().Equals ("Incident List"))
                //            Console.WriteLine("{1} Found {0}", count, mailitem.SenderEmailAddress.ToString());
                //            break;
                //        }
                //        else
                //        {
                //            Console.WriteLine("{1} Sender Email ID is {0}", count, mailitem.SenderEmailAddress.ToString());
                //            count += 1;
                //        }
                    #endregion End

                //if (count < 100)
                //{
                //    if (mailitem.SenderEmailAddress.Equals("newsletter=brainpickings.org@mail97.atl71.mcdlv.net"))
                //    {

                //        count += 1;
                //        MessageBoxButtons buttons= MessageBoxButtons.YesNo;
                //        DialogResult result= MessageBox.Show("Found! Want to write this to a file?","Hey",buttons);
                //        if (result == DialogResult.No)
                //        {
                //            Console.Write("Body is {0}", mailitem.Body);
                //            break;
                //        }
                //        else
                //        {
                //            WriteToFile(mailitem.Body.ToString());
                //            break;
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine("Sender Email ID is {0}", mailitem.SenderEmailAddress.ToString());
                //        count += 1;
                //    }

                //}

                //application.Quit();
            };

        }

        private static void WriteToFile(string txt)
        {
            ExcelApplication MyExcel = new ExcelApplication();
            MyExcel.WritetoExcel(txt);
        }

        

        private static UserDetails GetLoginDetails()
        {
            UserDetails user1 = new UserDetails();
            Console.WriteLine("Enter your email address");
            string EAddress = Console.ReadLine();
            //Console.WriteLine("Email address is {0}", EAddress);
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();
            user1.email = EAddress;
            user1.password = password;
            return user1;
        }
    }

    
}
