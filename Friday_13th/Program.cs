using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friday_13th
{
    class Program
    {
        void Function_Program()
        {
            Get_Date_Range();
        }
        void Get_Date_Range()
        {
            try
            {
                Console.WriteLine("Enter number of test cases");
                int test_case = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < test_case; i++)
                {
                    DateTime date1 = new DateTime(2016, 2, 3);
                    DateTime date2 = new DateTime(2016, 4, 5);
                    
                    Console.WriteLine("Enter the first date in YYYY M D");
                    date1 = Convert.ToDateTime(Console.ReadLine());


                    Console.WriteLine("Enter the second date in YYYY M D");
                    date2 = Convert.ToDateTime(Console.ReadLine());

                    if (date1 > date2)
                    {
                        Console.WriteLine("Start date should not be before end date");
                        Get_Date_Range();
                    }
                    else
                        Count_Fridays(date1, date2);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Check inputs again");
                Get_Date_Range();              
            }
        }
        void Count_Fridays(DateTime date_start, DateTime date_end)
        {
            int count = 0;
            string start_day = date_start.DayOfWeek.ToString();
            string end_day = date_end.DayOfWeek.ToString();

            

                for (int j = 0; ; j++)
                    {   
                        {
                            if (date_start.DayOfWeek.ToString().Equals ("Friday") && date_start.ToShortDateString().Substring(0, 2).Equals ("13"))
                                count += 1;
                            if (date_start == date_end)
                                break;
                        }
                        date_start = date_start.AddDays(1);
                    }
            Console.WriteLine("Total occurrences of Friday the 13th is " + count);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Function_Program();
            Console.ReadKey();
        }
    }
}
