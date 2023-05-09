using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkCount
{
    class LogfileOperations
    {
        public static string LogfilePath = @"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Logfiles\Logfile " + DateTime.Now.ToString("dd/MM/yyyy") + @".txt";


        public static void WriteLogfile(string text , bool error = false , int errorCode = 0000)
        {
            if (error == false)
            {
                try
                {
                    StreamWriter logfileWriter = new StreamWriter(LogfilePath, true);
                    logfileWriter.WriteLine(text + "  " + DateTime.Now.TimeOfDay);
                    logfileWriter.Close();
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Logfiles\");
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Please contact the developer ! Error code : 0001");
                }
            }
            else // if there is an error
            {
                try
                {
                    StreamWriter logfileWriter = new StreamWriter(LogfilePath, true);
                    logfileWriter.WriteLine("!" + text  + "  Error code : " + errorCode + " " + DateTime.Now.TimeOfDay + "!");
                    logfileWriter.Close();
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Logfiles\");
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Please contact the developer ! Error code : 0001");
                }
            }
        }
    }
}
